$(document).ready(function () {

   //add basket
    $(document).on("submit", "#basket-form", function (e) {
        e.preventDefault();
        let productId = $(this).attr("data-id")

        let data = { id: productId }

        $.ajax({

            url: "cart/addbasket",
            type: "Post",
            data: data,
            success: function (res) {
                $("sup.rounded-circle").text(res);
            }



        })

    })




})