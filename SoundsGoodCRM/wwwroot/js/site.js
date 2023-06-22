//for name changing if screen width less than 600 
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

//to collapse the navbar
document.addEventListener('click', function (event) {
    var navbar = document.getElementById('navbarSupportedContent');
    var targetElement = event.target;

    if (!navbar.contains(targetElement)) {
        if (navbar.classList.contains('show')) {
            var navbarToggler = document.querySelector('.navbar-toggler');
            navbarToggler.click();
        }
    }
});

//to highlight row in the table
document.addEventListener("DOMContentLoaded", function () {
    var table = document.getElementById("main-table");
    var rows = table.getElementsByTagName("tr");

    for (var i = 0; i < rows.length; i++) {
        rows[i].addEventListener("mouseover", function () {
            this.classList.add("highlight");
        });

        rows[i].addEventListener("mouseout", function () {
            this.classList.remove("highlight");
        });
    }
});

// Toast notification init
$(document).ready(function () {
    $('.toast').toast('show');
});

//To chose element from the table clicking everywhere 
$(document).ready(function () {
    $("#main-table tbody tr").click(function () {
        window.location = $(this).find("a").attr("href");
    });
});

// To check password, is it equal
$(document).ready(function () {
    $('#confirmPassword').on('input', function () {
        var password = $('#password').val();
        var confirmPassword = $(this).val();

        if (password !== confirmPassword) {
            $(this).get(0).setCustomValidity("Passwords do not match.");
        } else {
            $(this).get(0).setCustomValidity("");
        }
    });
});