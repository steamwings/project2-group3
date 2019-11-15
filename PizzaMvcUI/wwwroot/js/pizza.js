
$(document).ready(function () {
    assignGet("/api/cart/crust/");
    makeRadioOptions("/api/crusttypes");
});

function assignGet(uri) {
    $("#btnIWant").click(function (e) {
        console.log("Read value is " + $("pizzaOption").val());
//        $.ajax({
////            contentType: 'application/json',
//            type: "GET",
//            url: baseUrl + uri,
//            success: function (data, textStatus, jqXHR) {
//                $("#headerSelect").val("Success!");
//                console.log("GET was successful...I think.");
//            },
//            error: function (jqXHR, textStatus, errorThrown) {
//                $("#headerSelect").val(jqXHR.statusText);
//                console.log("GET failed: " + textStatus);
//            }
//        });
    });
}

function makeRadioOptions(resource, headerText) {
    $.ajax({
        contentType: 'application/json',
        type: "GET",
        url: apiUrl + resource,
//        headers: { "Access-Control-Request-Method": "GET"},
//        xhrFields: { withCredentials: true },
        success: function (data, textStatus, jqXHR) {
            console.log("API GET succeeded");
            data.forEach(function (option) {
                document.getElementByName("pizzaOption").remove();
                var o = document.createElement('input');
                o.setAttribute('type', 'radio');
                o.setAttribute('name', 'pizzaOption');
                o.setAttribute('value', option.id);
                o.val(option.name + " - " + option.description);
                $("#divDoStuff").appendChild(o);
            });
            $("#headerSelect").val(headerText);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("API GET failed");
            $("#headerSelect").val(jqXHR.statusText);
        }
    });
}

//<form>
//    <input type="radio" name="gender" value="male" checked> Male<br>
//        <input type="radio" name="gender" value="female"> Female<br>
//            <input type="radio" name="gender" value="other"> Other  
//</form> 