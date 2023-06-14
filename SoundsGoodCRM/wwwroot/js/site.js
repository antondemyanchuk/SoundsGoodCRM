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

document.addEventListener('click', function (event) {
    var navbar = document.getElementById('navbarSupportedContent');
    var targetElement = event.target;

    // Check if the clicked element is outside the navbar
    if (!navbar.contains(targetElement)) {
        // Collapse the navbar if it is currently expanded
        if (navbar.classList.contains('show')) {
            var navbarToggler = document.querySelector('.navbar-toggler');
            navbarToggler.click();
        }
    }
});