window.addEventListener('DOMContentLoaded', () => {

    // Navbar shrink function
    var navbarShrink = function () {
        const navbarCollapsible = document.body.querySelector('#mainNav');
        if (!navbarCollapsible) {
            return;
        }
        if (window.scrollY === 0) {
            navbarCollapsible.classList.remove('navbar-shrink')
        } else {
            navbarCollapsible.classList.add('navbar-shrink')
        }

    };

    // Shrink the navbar 
    navbarShrink();

    // Shrink the navbar when page is scrolled
    document.addEventListener('scroll', navbarShrink);

    // Activate Bootstrap scrollspy on the main nav element
    const mainNav = document.body.querySelector('#mainNav');
    if (mainNav) {
        new bootstrap.ScrollSpy(document.body, {
            target: '#mainNav',
            rootMargin: '0px 0px -40%',
        });
    };

    // Collapse responsive navbar when toggler is visible
    const navbarToggler = document.body.querySelector('.navbar-toggler');
    const responsiveNavItems = [].slice.call(
        document.querySelectorAll('#navbarResponsive .nav-link')
    );

    if (navbarToggler) {
        responsiveNavItems.forEach(function (responsiveNavItem) {
            responsiveNavItem.addEventListener('click', () => {
                if (window.getComputedStyle(navbarToggler).display !== 'none') {
                    navbarToggler.click();
                }
            });
        });
    }

    const card = document.getElementById("tarifCard");
    const title = document.getElementById("cardTitle");
    const price = document.getElementById("cardPrice");

    document.querySelectorAll('.tech-banner__carousel-item')
            .forEach(item => {

                item.addEventListener("click", () => {
                    title.textContent = item.dataset.tech;
                    price.textContent = item.dataset.price;
                    card.classList.add("show");
                });

            });

    document.querySelector('.tech-card__close')

    .addEventListener("click", () => {

        card.classList.remove("show");

    });
});
