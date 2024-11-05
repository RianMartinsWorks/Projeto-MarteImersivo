
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



document.getElementById("themeToggleBtn").addEventListener("click", function () {
    // Define a duração da transição em milissegundos
    const transitionDuration = 500;

    // Aplica uma transição a todo o conteúdo da página
    document.querySelectorAll("*").forEach((element) => {
        element.style.transition = `background-color ${transitionDuration}ms ease, color ${transitionDuration}ms ease, background-image ${transitionDuration}ms ease`;
    });

    // Alterna entre as classes do tema para o body
    document.body.classList.toggle("light-theme");
    document.body.classList.toggle("dark-theme");

    // Alterna entre as classes de tema para navbar
    var navbar = document.querySelector("nav.navbar");
    navbar.classList.toggle("navbar-light-theme");
    navbar.classList.toggle("navbar-dark-theme");

    // Alterna entre as classes de tema para a seção Home
    var homeSection = document.getElementById("Home");
    homeSection.classList.toggle("light-theme");
    homeSection.classList.toggle("dark-theme");

    // Alterna entre as classes de tema para a seção Historia
    var historiaSection = document.getElementById("Historia");
    historiaSection.classList.toggle("light-theme");
    historiaSection.classList.toggle("dark-theme");

    // Alterna entre as classes de tema para o questionário
    var questionario = document.getElementById("Questionario");
    var questionarioForm = document.getElementById("questionario-form");
    questionario.classList.toggle("light-theme");
    questionario.classList.toggle("dark-theme");
    questionarioForm.classList.toggle("light-theme");
    questionarioForm.classList.toggle("dark-theme");

    // Atualiza o texto do botão de acordo com o tema ativo
    if (document.body.classList.contains("dark-theme")) {
        this.textContent = "Alternar para Tema Claro";
        this.classList.remove("btn-dark");
        this.classList.add("btn-light");
    } else {
        this.textContent = "Alternar para Tema Escuro";
        this.classList.remove("btn-light");
        this.classList.add("btn-dark");
    }

    // Remove o estilo de transição após o tempo definido
    setTimeout(() => {
        document.querySelectorAll("*").forEach((element) => {
            element.style.transition = '';
        });
    }, transitionDuration);
});

// Inicializa com o tema claro ao carregar a página
document.body.classList.add("dark-theme");
document.querySelector("nav.navbar").classList.add("navbar-dark-theme");
document.getElementById("Home").classList.add("dark-theme");
