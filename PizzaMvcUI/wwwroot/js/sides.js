$(document).ready(() => {
    $(".sidesSubmit").on("click", function () {
        let id = jQuery(this).attr("sideid");
        addSide(id)
        confirmSide();
    });
    $(".sidesRemove").on("click", function () {

        let id = jQuery(this).attr("sideid");
        removeSide(id)
    });



});

function confirmSide() {
    var popup = document.getElementById("SideConfirm");
    popup.style.display = "block";
    $("#SideContinue").click(closeConfirmation);
}

function closeConfirmation() {
    var popup = document.getElementById("SideConfirm");
    popup.style.display = "none";
}


function addSide(id) {
    console.log("Adding Side To Cart...");

    console.log(id)

    $.ajax({
        type: "GET",
        url: baseUrl + `/api/Cart/AddSide/${id}`,
        success: function (data, textStatus, jqXHR) {
            console.log("GET success");

        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("GET failed: " + textStatus);
        }
    });
}

function removeSide(id) {
    console.log("Adding Side To Cart...");

    console.log(id)

    $.ajax({
        type: "GET",
        url: baseUrl + `/api/Cart/RemoveSide/${id}`,
        success: function (data, textStatus, jqXHR) {
            console.log("GET success");
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("GET failed: " + textStatus);
        }
    });
}