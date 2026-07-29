(() => {

      "use strict";

      const canvas = document.getElementById("particleCanvas");

      if (!canvas) {

        return;

      }

      const banner = canvas.closest(".tarif-section");

      const context = canvas.getContext("2d");

      if (!banner || !context) {

        return;

      }

      const reducedMotion = window.matchMedia(

        "(prefers-reduced-motion: reduce)"

      ).matches;

      let width = 0;

      let height = 0;

      let pixelRatio = 1;

      let animationFrame = null;

      const particles = [];

      const shootingStars = [];

      const PARTICLE_COUNT = 115;

      /*

        Valeur comprise entre min et max.

      */

      function random(min, max) {

        return Math.random() * (max - min) + min;

      }

      /*

        Dimensions du canvas.

      */

      function resizeCanvas() {

        const bounds = banner.getBoundingClientRect();

        width = bounds.width;

        height = bounds.height;

        pixelRatio = Math.min(

          window.devicePixelRatio || 1,

          2

        );

        canvas.width = Math.floor(width * pixelRatio);

        canvas.height = Math.floor(height * pixelRatio);

        canvas.style.width = `${width}px`;

        canvas.style.height = `${height}px`;

        context.setTransform(

          pixelRatio,

          0,

          0,

          pixelRatio,

          0,

          0

        );

        createParticles();

        if (reducedMotion) {

          drawParticles(0);

        }

      }

      /*

        Création des étoiles.

      */

      function createParticles() {

        particles.length = 0;

        for (

          let index = 0;

          index < PARTICLE_COUNT;

          index++

        ) {

          particles.push({

            x: random(0, width),

            y: random(0, height),

            radius: random(0.35, 1.5),

            baseOpacity: random(0.15, 0.9),

            phase: random(0, Math.PI * 2),

            pulseSpeed: random(0.001, 0.004),

            speedX: random(-0.025, 0.025),

            speedY: random(-0.04, -0.008),

            color: Math.random() > 0.65

              ? "125, 186, 255"

              : "255, 255, 255"

          });

        }

      }

      /*

        Ajout occasionnel d'une étoile filante.

      */

      function createShootingStar() {

        shootingStars.push({

          x: random(width * 0.1, width * 0.8),

          y: random(0, height * 0.4),

          length: random(70, 150),

          speed: random(8, 13),

          opacity: 1,

          thickness: random(0.7, 1.5)

        });

      }

      /*

        Animation des petites étoiles.

      */

      function drawParticles(time) {

        particles.forEach(particle => {

          particle.x += particle.speedX;

          particle.y += particle.speedY;

          if (particle.y < -5) {

            particle.y = height + 5;

            particle.x = random(0, width);

          }

          if (particle.x < -5) {

            particle.x = width + 5;

          }

          if (particle.x > width + 5) {

            particle.x = -5;

          }

          const pulse =

            0.55 +

            Math.sin(

              time * particle.pulseSpeed +

              particle.phase

            ) * 0.45;

          const opacity =

            particle.baseOpacity * pulse;

          context.beginPath();

          context.arc(

            particle.x,

            particle.y,

            particle.radius,

            0,

            Math.PI * 2

          );

          context.fillStyle =

            `rgba(${particle.color}, ${opacity})`;

          context.fill();

          /*

            Halo autour des étoiles les plus brillantes.

          */

          if (

            particle.radius > 1.15 &&

            opacity > 0.45

          ) {

            context.beginPath();

            context.arc(

              particle.x,

              particle.y,

              particle.radius * 4,

              0,

              Math.PI * 2

            );

            context.fillStyle =

              `rgba(${particle.color}, ${opacity * 0.08})`;

            context.fill();

          }

        });

      }

      /*

        Animation des étoiles filantes.

      */

      function drawShootingStars() {

        for (

          let index = shootingStars.length - 1;

          index >= 0;

          index--

        ) {

          const star = shootingStars[index];

          star.x += star.speed;

          star.y += star.speed * 0.42;

          star.opacity -= 0.018;

          const endX = star.x - star.length;

          const endY = star.y - star.length * 0.42;

          const gradient =

            context.createLinearGradient(

              star.x,

              star.y,

              endX,

              endY

            );

          gradient.addColorStop(

            0,

            `rgba(255, 255, 255, ${star.opacity})`

          );

          gradient.addColorStop(

            0.15,

            `rgba(112, 175, 255, ${star.opacity * 0.8})`

          );

          gradient.addColorStop(

            1,

            "rgba(83, 58, 255, 0)"

          );

          context.beginPath();

          context.moveTo(star.x, star.y);

          context.lineTo(endX, endY);

          context.lineWidth = star.thickness;

          context.lineCap = "round";

          context.strokeStyle = gradient;

          context.stroke();

          if (

            star.opacity <= 0 ||

            star.x > width + star.length ||

            star.y > height + star.length

          ) {

            shootingStars.splice(index, 1);

          }

        }

      }

      /*

        Boucle principale.

      */

      function animate(time = 0) {

        context.clearRect(0, 0, width, height);

        drawParticles(time);

        drawShootingStars();

        if (Math.random() < 0.0025) {

          createShootingStar();

        }

        animationFrame = requestAnimationFrame(animate);

      }

      /*

        Parallaxe contrôlée par la souris.

      */

      function handlePointerMove(event) {

        if (reducedMotion) {

          return;

        }

        const bounds = banner.getBoundingClientRect();

        const normalizedX =

          (event.clientX - bounds.left) /

          bounds.width -

          0.5;

        const normalizedY =

          (event.clientY - bounds.top) /

          bounds.height -

          0.5;

        const moveX = normalizedX * -14;

        const moveY = normalizedY * -10;

        banner.style.setProperty(

          "--mouse-x",

          `${moveX}px`

        );

        banner.style.setProperty(

          "--mouse-y",

          `${moveY}px`

        );

      }

      /*

        Retour progressif au centre.

      */

      function resetParallax() {

        banner.style.setProperty("--mouse-x", "0px");

        banner.style.setProperty("--mouse-y", "0px");

      }

      function initialize() {

        if (animationFrame) {

          cancelAnimationFrame(animationFrame);

        }

        resizeCanvas();

        if (!reducedMotion) {

          animate();

        } else {

          drawParticles(0);

        }

      }

      banner.addEventListener(

        "pointermove",

        handlePointerMove

      );

      banner.addEventListener(

        "pointerleave",

        resetParallax

      );

      window.addEventListener(

        "resize",

        resizeCanvas

      );

      initialize();

    })();
