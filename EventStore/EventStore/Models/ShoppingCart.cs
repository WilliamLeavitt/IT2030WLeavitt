using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventStore.Models
{
    public class ShoppingCart
    {
        public string ShoppingCartId;

        private EventStoreDB db = new EventStoreDB();

        public static ShoppingCart GetCart(HttpContextBase context)
         {
             ShoppingCart cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
             return cart;
         }

        private string GetCartId(HttpContextBase context)
        {
            const string CartSessionId = "CartId";
            string cartId;

            if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
            {
                cartId = context.User.Identity.Name;
                context.Session[CartSessionId] = cartId;
            } else
            {
                cartId = context.Session[CartSessionId].ToString();
            }

            return cartId;
        }

        public List<Cart> GetCartItems()
        {
            return db.Carts.Where(c => c.CartId == this.ShoppingCartId).ToList();
        }

        public void AddToCart(int eventId, int ordered)
        {
            Cart cartItem = db.Carts.SingleOrDefault(c => c.CartId == this.ShoppingCartId && c.EventId == eventId);

            Event changed = db.Events.FirstOrDefault(x => x.EventID == eventId);

            //check that too many tickets aren't ordered
            if (changed.AvailTickets < ordered)
            {
                //abandon function without processing anything if too many tickets
                return;
            }

            if (cartItem == null)
            {
                cartItem = new Cart()
                {
                    CartId = this.ShoppingCartId,
                    EventId = eventId,
                    Tickets = ordered,
                    DateCreated = DateTime.Now
                };

                db.Carts.Add(cartItem);
            } else
            {
                cartItem.Tickets += ordered;
            }

            changed.AvailTickets -= ordered;
            db.SaveChanges();
            
        }

        public void RemoveFromCart(int recordId)
        {
            Cart cartItem = db.Carts.SingleOrDefault(c => c.CartId == this.ShoppingCartId && c.RecordId == recordId);
            if(cartItem == null)
            {
                throw new NullReferenceException();
            }

            //add tickets to available tickets before deletion
            Event changed = db.Events.FirstOrDefault(x => x.EventID == cartItem.EventId);
            changed.AvailTickets += cartItem.Tickets;
            db.Carts.Remove(cartItem);

            db.SaveChanges();
        }
     }
 }

    