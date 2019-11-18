
$(document).ready(() => {
    $("#btnIWant").click(crust);
});

function crust() {
    makeRadioOptions("/api/crusttypes");
    addToProgressBar('Crust');
    $("#btnIWant").val("I Want This!");
    $("#btnIWant").unbind('click');
    $("#btnIWant").click(sauce);
}

function sauce() {
    addOptionToCart("/api/cart/crust/");
    makeRadioOptions("/api/saucetypes");
    addToProgressBar('Sauce');
    $("#btnIWant").unbind('click');
    $("#btnIWant").click(cheese);
}

function cheese() {
    addOptionToCart("/api/cart/sauce/");
    makeRadioOptions("/api/cheesetypes");
    addToProgressBar('Cheese');
    $("#btnIWant").unbind('click');
    $("#btnIWant").click(toppings);
}

function toppings() {
    addToProgressBar('Toppings');
    $("#btnIWant").val("Whelp this doesn't work yet");
    $("#btnIWant").unbind('click');
}


function addToProgressBar(name) {
    var pbar = document.createElement('div');
    pbar.setAttribute('class', 'progress-bar progress-bar-striped progress-bar-success active');
    pbar.setAttribute('role', 'progressbar');
    pbar.setAttribute('style', 'width:20%');
    pbar.innerHTML = name;
    $("#progressBuildPizza").append(pbar);
}

function addOptionToCart(uri) {
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
}

function makeRadioOptions(resource, headerText) {
    makeOptions(resource, headerText, populateRadio);
}

function makeOptions(resource, headerText, callback) {
    $("#divDoStuff").innerHTML = 'Loading...';
    $.ajax({
        contentType: 'application/json',
        type: "GET",
        url: apiUrl + resource,
        //        headers: { "Access-Control-Request-Method": "GET"},
        //       xhrFields: { withCredentials: true },
        success: (data, textStatus, jqXHR) => {
            console.log("API GET succeeded");
            $("#headerSelect").val(headerText);
            $("#divDoStuff").innerHTML = '';
            callback(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("API GET failed");
            $("#headerSelect").val(jqXHR.statusText);
        }
    });
}

function populateRadio (data) {
    var groupName = 'pizzaDiv';
    $("#divDoStuff").empty();
    data.forEach(function (option) {
        var d = document.createElement('div');
        d.setAttribute('name', groupName);
        var o = document.createElement('input');
        o.setAttribute('type', 'radio');
        o.setAttribute('name', 'pizzaOption');
        o.setAttribute('id', option.name);
        o.setAttribute('value', option.id);
        var l = document.createElement('label');
        l.setAttribute('for', option.name);
        l.setAttribute('style', 'style="display:block"');
        l.innerHTML = " <strong>" + option.name + "</strong> - " + option.description;
        $(d).append(o);
        $(d).append(l);
        $("#divDoStuff").prepend(d);
    });
}