$(document).ready(() => {
    $(".pMPizzaSubmit").on("click", function () {
        let id = jQuery(this).attr("pizzaid");
        addPreMade(id);
        confirmPMPizza();
    });
});

function addPreMade(id) {
    console.log("Adding pizza To Cart...");
    console.log(id)

    $.ajax({
        type: "GET",
        url: baseUrl + `/api/Cart/AddPreMade/${id}`,
        success: function (data, textStatus, jqXHR) {
            console.log("GET success");

        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("GET failed: " + textStatus);
        }
    });
}
function confirmPMPizza() {
    var popup = document.getElementById("pMPizzaConfirm");
    popup.style.display = "block";
    $("#pmPizzaContinue").click(closeConfirmation);
}

function closeConfirmation() {
    var popup = document.getElementById("pMPizzaConfirm");
    popup.style.display = "none";
}