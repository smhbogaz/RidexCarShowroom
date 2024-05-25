'use strict';


const overlay = document.querySelector("[data-overlay]");
const navbar = document.querySelector("[data-navbar]");
const navToggleBtn = document.querySelector("[data-nav-toggle-btn]");
const navbarLinks = document.querySelectorAll("[data-nav-link]");
const loginButton = document.querySelector("#adminButton");
const loginField = document.querySelector(".overlayX");

const navToggleFunc = function () {
    navToggleBtn.classList.toggle("active");
    navbar.classList.toggle("active");
    overlay.classList.toggle("active");
}

navToggleBtn.addEventListener("click", navToggleFunc);
overlay.addEventListener("click", navToggleFunc);

for (let i = 0; i < navbarLinks.length; i++) {
    navbarLinks[i].addEventListener("click", navToggleFunc);
}





const header = document.querySelector("[data-header]");

window.addEventListener("scroll", function () {
    window.scrollY >= 10 ? header.classList.add("active")
        : header.classList.remove("active");
});


loginButton.addEventListener("click", () => {
    loginField.style.display = "flex";
    loginField.style.position = "fixed";
    loginField.style.top = "0";
    loginField.style.left = "0";
    document.querySelector("body").style.overflow = "hidden";
    document.querySelector(".overlay-close-button").addEventListener("click", () => {
        loginField.style.display = "none";
        document.querySelector("body").style.overflow = "unset";
    });
});