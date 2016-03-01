var getDay = function()
{
    var d = new Date();
    return d.getDay();
}
var getFilteredDay  = function()
{
    var d = getDay();
    if(d==6)
    {
        d = 5;
    }
    return d;
}
var getToday = function () {
    var d = new Date();
    var day = d.getDay();
    if (day == 0)
    {
        day = 6;
    }
    return day;
}
var DAY = "bible_day";
function set_cookie(name, value, minutes) {
    var cookie = name + '=' + escape(value);
    if (minutes) {
        var expiration = new Date((new Date()).getTime() + minutes * 60000);
        cookie += ';expires=' + expiration.toGMTString();
    }
    document.cookie = cookie;
}

function get_cookie(name) {
    var str_cookies = document.cookie;
    var arr_cookies = str_cookies.split(';');
    var num_cookies = arr_cookies.length;
    for (var i = 0; i < num_cookies; i++) {
        var arr = arr_cookies[i].split("=");
        if (arr[0] == name) return unescape(arr[1]);
    }
    return null;
}

function remove_cookie(name, path, domain) {
    if (get_cookie(name)) {
        var cookie = name + '=;expires=Fri, 02-Jan-1970 00:00:00 GMT';
        if (path) cookie += ';path=' + path;
        if (domain) cookie += ';domain=' + domain;
        document.cookie = cookie;
    }
}
