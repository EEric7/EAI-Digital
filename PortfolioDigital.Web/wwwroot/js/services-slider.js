(() => {
  "use strict";

  const slider = document.querySelector("[data-services-slider]");
  if (!slider) {
    return;
  }

  const slides = Array.from(slider.querySelectorAll("[data-service-slide]"));
  if (slides.length <= 1) {
    return;
  }

  const prevButton = slider.querySelector("[data-service-prev]");
  const nextButton = slider.querySelector("[data-service-next]");
  const dotsHost = slider.querySelector("[data-service-dots]");

  const dots = slides.map((_, index) => {
    const dot = document.createElement("span");
    dot.className = index === 0 ? "is-active" : "";
    dotsHost?.appendChild(dot);
    return dot;
  });

  let currentIndex = 0;
  let autoSlideTimer = null;

  function render(index) {
    slides.forEach((slide, slideIndex) => {
      slide.classList.toggle("is-active", slideIndex === index);
    });

    dots.forEach((dot, dotIndex) => {
      dot.classList.toggle("is-active", dotIndex === index);
    });
  }

  function goTo(index) {
    const nextIndex = (index + slides.length) % slides.length;
    currentIndex = nextIndex;
    render(nextIndex);
  }

  function clearAutoSlide() {
    if (autoSlideTimer) {
      clearInterval(autoSlideTimer);
      autoSlideTimer = null;
    }
  }

  function restartAutoSlide() {
    clearAutoSlide();
    autoSlideTimer = window.setInterval(() => {
      goTo(currentIndex + 1);
    }, 4500);
  }

  prevButton?.addEventListener("click", () => {
    goTo(currentIndex - 1);
    restartAutoSlide();
  });

  nextButton?.addEventListener("click", () => {
    goTo(currentIndex + 1);
    restartAutoSlide();
  });

  slider.addEventListener("mouseenter", clearAutoSlide);
  slider.addEventListener("mouseleave", restartAutoSlide);

  render(0);
  restartAutoSlide();
})();
