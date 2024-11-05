

        document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();
            const targetId = this.getAttribute('href').substring(1);
            const targetElement = document.getElementById(targetId);

            if (targetElement) {
                let startPosition = window.pageYOffset;
                let targetPosition = targetElement.getBoundingClientRect().top;
                let startTime = null;

                function animation(currentTime) {
                    if (startTime === null) startTime = currentTime;
                    const timeElapsed = currentTime - startTime;
                    const run = ease(timeElapsed, startPosition, targetPosition, 500); // 1000ms = 1s
                    window.scrollTo(0, run);
                    if (timeElapsed < 500) requestAnimationFrame(animation);
                }

                function ease(t, b, c, d) { // função de suavização "ease-in-out"
                    t /= d / 2;
                    if (t < 1) return c / 2 * t * t + b;
                    t--;
                    return -c / 2 * (t * (t - 2) - 1) + b;
                }

                requestAnimationFrame(animation);
            }
        });
        });
