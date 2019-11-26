
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
    addOptionToCart("/api/cart/cheese/");
    makeCheckboxOptions('/api/toppings');
    addToProgressBar('Toppings');
    $("#btnIWant").val("I Want These!");
    $("#btnIWant").unbind('click');
    $("#btnIWant").click(reviewPizza);
}

function reviewPizza() {
    addOptionsToCart("/api/cart/topping/");
    addToProgressBar('Review');
    $("#btnIWant").unbind('click');
    $("#btnIWant").val("Add to My Order");
    $("#btnIWant").click(confirmOrder);
}

function confirmOrder() {
    finalizePizza();
    var popup = document.getElementById("PizzaConfirm");
    var close = document.getElementById("closeButton");
    popup.style.display = "block";
}

function finalizePizza() {
    console.log("Adding Pizza To Cart...");
    $.ajax({
        type: "GET",
        url: baseUrl + "/api/Cart/AddPizza/",
        success: function (data, textStatus, jqXHR) {
            console.log("GET success");
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("GET failed: " + textStatus);
        }
    });
}


function addToProgressBar(name) {
    var pbar = document.createElement('div');
    pbar.setAttribute('class', 'progress-bar progress-bar-striped active');
    pbar.setAttribute('role', 'progressbar');
    pbar.setAttribute('style', 'width:20%');
    pbar.innerHTML = name;
    $("#progressBuildPizza").append(pbar);
}

function addOptionsToCart(uri) {

    function x(val, callback) {
        return (uri) => {
            addOptionToCart(uri, val, callback);
        }
    }
    var nextf = (p) => { };
    var fs = [];
    $("input[name=optionGroup]:checked").map((_, e) => {
        var func = x(e.value, nextf);
        fs.push(func);
        nextf = func;
    });
    fs[fs.length - 1](uri);
}

function addOptionToCart(uri, val = null, callback = null) {
    console.log("uri: " + uri + " val: " + val);
    var id = (val != null) ? val : $("input[name=optionGroup]:checked").val();
    console.log("Read value " + id);
    $.ajax({
        //            contentType: 'application/json',
        type: "GET",
        url: baseUrl + uri + id,
        success: function (data, textStatus, jqXHR) {
            console.log("GET success to " + uri + " with " + id);
            if (callback != null) callback(uri);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log("GET failed (" + textStatus + "): " + errorThrown);
        }
    });
}

function makeRadioOptions(resource) {
    makeOptions("divDoStuff", "btnIWant", resource, populate);
}

function makeCheckboxOptions(resource) {
    var pop = (divId, data) => {
        populate(divId, data, 'checkbox');
    };
    makeOptions("divDoStuff", "btnIWant", resource, pop);
}


function makeOptions(divId, btnId, resource, callback, headerId = null, headerText = null) {
    $(`#${divId}`).html('<div class="text-center">Loading options...</div>');
    $(`#${btnId}`).prop('disabled', true);
    var path = apiUrl + resource;
    $.ajax({
        contentType: 'application/json',
        type: "GET",
        url: path,
        //        headers: { "Access-Control-Request-Method": "GET"},
        //       xhrFields: { withCredentials: true },
        success: (data, textStatus, jqXHR) => {
            console.log(`API GET succeeded (${path})`);
            if (headerId) $(`#${headerId}`).val(headerText);
            $(`#${divId}`).html('');
            $(`#${btnId}`).prop('disabled', false);
            callback(divId, data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(`API GET failed (${path})`);
            if (headerId) $(`#${headerId}`).val(jqXHR.statusText);
        }
    });
}

function populate (divId, data, type='radio') {
    $(`#${divId}`).empty();
    data.forEach((option, index) => {
        var d = document.createElement('div');
        var o = document.createElement('input');
        if (index == 0) o.setAttribute('checked', true);
        o.setAttribute('type', type);
        o.setAttribute('name', 'optionGroup');
        o.setAttribute('id', option.name);
        o.setAttribute('value', option.id);
        var l = document.createElement('label');
        l.setAttribute('for', option.name);
        l.setAttribute('style', 'style="display:block"');
        l.innerHTML = " <strong>" + option.name + "</strong> - " + option.description;
        $(d).append(o);
        $(d).append(l);
        $(`#${divId}`).append(d);
    });
}