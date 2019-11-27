$(document).ready(() => {
    homePageSlideshowIndex = 0;
    carousel();
});

var homePageSlideshowIndex


function carousel() {
    var i;
    var x = document.getElementsByClassName("mySlides");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    homePageSlideshowIndex++;
    if (homePageSlideshowIndex > x.length) { homePageSlideshowIndex = 1 }
    x[homePageSlideshowIndex - 1].style.display = "block";
    setTimeout(carousel, 3500); // Change image every 3.5 seconds
}