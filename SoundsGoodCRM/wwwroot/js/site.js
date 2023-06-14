window.addEventListener('resize', function () {
    var serialNumber = document.querySelectorAll('.serial-number');
    if (window.innerWidth <= 600) {
        serialNumber.forEach(function (element) {
            element.textContent = 'S/N';
        });
    } else {
        serialNumber.forEach(function (element) {
            element.textContent = 'Serial Number';
        });
    }
});
