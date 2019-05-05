function searchFailed() {
    $("#searchresults").html("No Results Found.");
}

$(function () {
    $(".RemoveLink").click(function () {
        var id = $(this).attr("data-id");

        $.post("/Cart/RemoveFromCart", { "id": id }, function (data) {
            $("#update-message").text(data.Message);
                $("#record-" + data.DeleteId).fadeOut();
            

        });


    })
});

$(document).on('click', '#btnRegister', function (e) {
    e.preventDefault();
    window.location.href = '@Url.Action("AddToCart", "Cart", new { id = @Model.EventId } )' + '?ordered' + $('#tickets').val();
});

