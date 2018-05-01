function updateProgress(progressId, multiplicator) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);

            document.getElementById("progress_" + progressId).value = response.points;
            document.getElementById("progress_" + progressId).title = response.points + ' ' + response.unit;
            document.getElementById("total_" + progressId).innerHTML = response.total;
        }
    };
    xhttp.open("GET", "UpdateProgress1/" + progressId + "?multiplicator=" + multiplicator, true);
    xhttp.send();
}

$(document).ready(function () {
    var weekSelector = document.querySelector('#weekSelector');
    weekSelector.addEventListener('change', function () {
        var val = weekSelector.value;

        var xhttp = new XMLHttpRequest();
        xhttp.open("GET", "Select?week=" + val, true);
        xhttp.send();
    }, false);
});