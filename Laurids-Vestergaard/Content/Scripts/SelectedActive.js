$(document).ready(function () {
    var url = window.location.pathname.replace("/Home/", "");
    if (url.indexOf('/') >= 0 && url.indexOf('/') <= 3) {
        url = "Index";
    }

    if (url.indexOf('VisGalleri') >= 0) {
        url = "Galleri";
    };

    $(".selected").removeClass("selected");
    $("#" + url).addClass("selected");
});