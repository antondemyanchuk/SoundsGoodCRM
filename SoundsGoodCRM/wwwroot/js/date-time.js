
// to show date and time on the page
document.addEventListener("DOMContentLoaded", function () {
    function displayTime() {
        var now = new Date();
        var hours = ("0" + now.getHours()).slice(-2);
        var minutes = ("0" + now.getMinutes()).slice(-2);
        var seconds = ("0" + now.getSeconds()).slice(-2);
        var timeString = hours + ":" + minutes + ":" + seconds;

        var month = ("0" + (now.getMonth() + 1)).slice(-2);
        var day = ("0" + now.getDate()).slice(-2);
        var year = now.getFullYear();
        var dateString = day + "/" + month + "/" + year;

        document.getElementById("time-display").textContent = timeString;
        document.getElementById("date-display").textContent = dateString;
    }

    setInterval(displayTime, 1000);
});
