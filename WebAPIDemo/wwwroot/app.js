/*javascript for dynamic visual displays  */
const menu = document.querySelector('#mobile-menu');
const menuContent = document.querySelector('.navbar__menu');

function mobileMenu(e) {
    menu.classList.toggle('is-active')
    menuContent.classList.toggle('active')
    e.stopPropagation();
}

menu.addEventListener("click", mobileMenu)

