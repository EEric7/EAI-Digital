const body = document.querySelector("#snakeBody");
const head = document.querySelector("#snakeHead");
const text = document.querySelector("#progressText");
const button = document.querySelector("#startButton");

if (body && head && text && button) {
    const pathLength = body.getTotalLength();

    body.style.strokeDasharray = pathLength;
    body.style.strokeDashoffset = pathLength;

    function setProgress(value) {
        const progress = Math.min(Math.max(value, 0), 100);
        const visibleLength = pathLength * (progress / 100);

        body.style.strokeDashoffset = pathLength - visibleLength;

        const point = body.getPointAtLength(visibleLength);
        const nextPoint = body.getPointAtLength(
            Math.min(visibleLength + 1, pathLength)
        );

        const angle =
            Math.atan2(
                nextPoint.y - point.y,
                nextPoint.x - point.x
            ) * 180 / Math.PI;

        head.setAttribute(
            "transform",
            `translate(${point.x} ${point.y}) rotate(${angle})`
        );

        text.textContent = `${Math.round(progress)} %`;
    }

    function startAnimation() {
        const duration = 4000;
        const startTime = performance.now();

        button.disabled = true;

        function animate(currentTime) {
            const elapsed = currentTime - startTime;
            const progress = Math.min(elapsed / duration, 1);

            // Accélération et décélération douces
            const eased =
                progress < 0.5
                    ? 2 * progress * progress
                    : 1 - Math.pow(-2 * progress + 2, 2) / 2;

            setProgress(eased * 100);

            if (progress < 1) {
                requestAnimationFrame(animate);
            } else {
                button.disabled = false;
            }
        }

        requestAnimationFrame(animate);
    }

    button.addEventListener("click", startAnimation);

    setProgress(0);
}