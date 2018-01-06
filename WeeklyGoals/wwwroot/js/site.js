// Write your JavaScript code.
//if (!String.format) {
//    String.format = function (format) {
//        var args = Array.prototype.slice.call(arguments, 1);
//        return format.replace(/{(\d+)}/g, function (match, number) {
//            return typeof args[number] != 'undefined'
//                ? args[number]
//                : match
//                ;
//        });
//    };
//}

function updateProgress(progressId, multiplicator) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("progress_" + progressId).value = this.responseText;
        }
    };
    //xhttp.open("GET", "Home//UpdateProgress//{0}?multiplicator={1}".format(progressId, multiplicator), true);
    xhttp.open("GET", "UpdateProgress/" + progressId + "?multiplicator=" + multiplicator, true);
    xhttp.send();
}