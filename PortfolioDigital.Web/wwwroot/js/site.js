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

    const supernovaCanvas = document.getElementById('supernovaCanvas');
    if (supernovaCanvas instanceof HTMLCanvasElement) {
        const context = supernovaCanvas.getContext('2d');
        if (!context) {
            return;
        }

        const prefersReducedMotion = window.matchMedia('(prefers-reduced-motion: reduce)');
        const mobileMediaQuery = window.matchMedia('(max-width: 767.98px), (pointer: coarse)');
        let animationFrameId = 0;
        let stars = [];
        let lastRenderTime = 0;

        const isMobileAnimation = () => mobileMediaQuery.matches;

        const createStars = (count) => Array.from({ length: count }, () => ({
            x: Math.random(),
            y: Math.random(),
            radius: Math.random() * (isMobileAnimation() ? 1.1 : 1.6) + 0.3,
            alpha: Math.random() * 0.55 + 0.2,
            speed: Math.random() * (isMobileAnimation() ? 0.00045 : 0.0007) + 0.00015,
        }));

        const resizeCanvas = () => {
            const bounds = supernovaCanvas.getBoundingClientRect();
            const devicePixelRatio = window.devicePixelRatio || 1;
            const pixelRatio = Math.min(devicePixelRatio, isMobileAnimation() ? 1.5 : 2);

            supernovaCanvas.width = Math.max(1, Math.floor(bounds.width * pixelRatio));
            supernovaCanvas.height = Math.max(1, Math.floor(bounds.height * pixelRatio));
            context.setTransform(pixelRatio, 0, 0, pixelRatio, 0, 0);

            const area = bounds.width * bounds.height;
            const densityDivisor = isMobileAnimation() ? 15000 : 9000;
            const minStars = isMobileAnimation() ? 28 : 50;
            const maxStars = isMobileAnimation() ? 72 : 140;
            const starCount = Math.max(minStars, Math.min(maxStars, Math.floor(area / densityDivisor)));
            stars = createStars(starCount);
        };

        const render = (time) => {
            if (isMobileAnimation() && time - lastRenderTime < 33) {
                animationFrameId = window.requestAnimationFrame(render);
                return;
            }

            lastRenderTime = time;

            const width = supernovaCanvas.clientWidth;
            const height = supernovaCanvas.clientHeight;

            context.clearRect(0, 0, width, height);

            for (const star of stars) {
                const pulse = 0.65 + Math.sin(time * star.speed) * 0.35;
                context.beginPath();
                context.fillStyle = `rgba(255, 255, 255, ${star.alpha * pulse})`;
                context.arc(star.x * width, star.y * height, star.radius, 0, Math.PI * 2);
                context.fill();
            }

            animationFrameId = window.requestAnimationFrame(render);
        };

        resizeCanvas();

        if (!prefersReducedMotion.matches) {
            animationFrameId = window.requestAnimationFrame(render);
        } else {
            render(0);
            window.cancelAnimationFrame(animationFrameId);
        }

        window.addEventListener('resize', resizeCanvas);
        mobileMediaQuery.addEventListener('change', resizeCanvas);
    }

});
