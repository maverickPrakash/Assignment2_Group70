// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function checkPassword() {
    var Pass = document.getElementById('Password').value;
    var RepPass = document.getElementById('RepeatPassword').value;

    console.log(RepPass, Pass);
    if (Pass == RepPass) {
        document.getElementById('validatorPass').classList.add("visually-hidden");

    } else {
        document.getElementById('validatorPass').classList.remove("visually-hidden");
    }
}