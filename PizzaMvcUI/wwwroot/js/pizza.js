
$(document).ready(function () {
    assignGet("/api/cart/crust/");
    makeRadioOptions("/api/crusttypes");
});

function assignGet(uri) {
    $("#btnIWant").click(function (e) {
        var id = $("input[name=pizzaOption]:checked").val();
        console.log("Read value is " + id);
        $.ajax({
//            contentType: 'application/json',
            type: "GET",
            url: baseUrl + uri + id,
            success: function (data, textStatus, jqXHR) {
                $("#headerSelect").val("Success!");
                console.log("GET was successful...I think.");
            },
            error: function (jqXHR, textStatus, errorThrown) {
                $("#headerSelect").val(jqXHR.statusText);
                console.log("GET failed: " + textStatus);
            }
        });
    });
}

function makeRadioOptions(resource, headerText) {
    $.ajax({
        contentType: 'application/json',
        type: "GET",
        url: apiUrl + resource,
//        headers: { "Access-Control-Request-Method": "GET"},
 //       xhrFields: { withCredentials: true },
        success: function (data, textStatus, jqXHR) {
            console.log("API GET succeeded");
            document.getElementsByName("pizzaOption").forEach(function (e) { e.remove() });
            data.forEach(function (option) {
                var d = document.createElement('div');
                var o = document.createElement('input');
                o.setAttribute('type', 'radio');
                o.setAttribute('name', 'pizzaOption');
                o.setAttribute('id', option.name);
                o.setAttribute('value', option.id);
                $("#divDoStuff").append(o);
                var l = document.createElement('label');
                l.setAttribute('for', option.name);
                l.setAttribute('style', 'style="display:block"');
                l.innerText = " " + option.name + " - " + option.description;
                $(d).append(o);
                $(d).append(l);
                $("#divDoStuff").prepend(d);
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