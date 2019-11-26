$(document).ready(() => {
    $(".sidesSubmit").on("click", function () {
        let id = jQuery(this).attr("sideid");
        addSide(id)
    });
    $(".sidesRemove").on("click", function () {

        let id = jQuery(this).attr("sideid");
        removeSide(id)
    });



});




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