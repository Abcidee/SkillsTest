$(window).on('load', function () {
    var notiName = "";

    notiName = "Flash.Success";
    var notySuccess = readCookie(notiName);
    if (notySuccess != null) {
        $.niftyNoty({
            type: 'success',
            title: 'Success',
            message: notySuccess,
            container: 'floating',
            timer: 5000
        });
        eraseCookie(notiName);
    }

    notiName = "Flash.Information";
    var notyInfo = readCookie(notiName);
    if (notyInfo != null) {
        $.niftyNoty({
            type: 'info',
            title: 'Information',
            message: notyInfo,
            container: 'floating',
            timer: 5000
        });
        eraseCookie(notiName);
    }

    notiName = "Flash.Warning";
    var notyWarning = readCookie(notiName);
    if (notyWarning != null) {
        $.niftyNoty({
            type: 'warning',
            title: 'Warning',
            message: notyWarning,
            container: 'floating',
            timer: 5000
        });
        eraseCookie(notiName);
    }

    notiName = "Flash.Error";
    var notyDanger = readCookie(notiName);
    if (notyDanger != null) {
        $.niftyNoty({
            type: 'danger',
            title: 'Error',
            message: notyDanger,
            container: 'floating',
            timer: 5000
        });
        eraseCookie(notiName);
    }
});

function createCookie(name, value, days) {
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        var expires = "; expires=" + date.toGMTString();
    }
    else var expires = "";
    document.cookie = name + "=" + value + expires + "; path=/";
}

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function eraseCookie(name) {
    createCookie(name, "", -1);
}