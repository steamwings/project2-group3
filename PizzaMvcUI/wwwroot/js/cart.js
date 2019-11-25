$(document).ready(() => {
    $("#checkoutForm").hide()
    $("#checkoutButton").on("click", function () {
        showCheckout()
    })
});




function showCheckout() {

    $("#checkoutForm").show()

}