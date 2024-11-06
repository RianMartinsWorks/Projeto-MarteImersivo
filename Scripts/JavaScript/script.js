document.getElementById("themeToggleBtn").addEventListener("click", function () {
    // Transição em milissegundos
    const transitionDuration = 200;

    // Transição a todo o conteúdo da página
    document.querySelectorAll("*").forEach((element) => {
        element.style.transition = `background-color ${transitionDuration}ms ease, color ${transitionDuration}ms ease, background-image ${transitionDuration}ms ease`;
    });

    // Alterna entre os temas
    document.body.classList.toggle("light-theme");
    document.body.classList.toggle("dark-theme");

    var navbar = document.querySelector("nav.navbar");
    navbar.classList.toggle("navbar-light-theme");
    navbar.classList.toggle("navbar-dark-theme");

    var homeSection = document.getElementById("Home");
    homeSection.classList.toggle("light-theme");
    homeSection.classList.toggle("dark-theme");

    var historiaSection = document.getElementById("Historia");
    historiaSection.classList.toggle("light-theme");
    historiaSection.classList.toggle("dark-theme");

    var questionario = document.getElementById("Questionario");
    var questionarioForm = document.getElementById("questionario-form");
    questionario.classList.toggle("light-theme");
    questionario.classList.toggle("dark-theme");
    questionarioForm.classList.toggle("light-theme");
    questionarioForm.classList.toggle("dark-theme");

    // Alterar a aparência do botão, sem mudar o texto
    this.classList.toggle("btn-dark");
    this.classList.toggle("btn-light");

    // Transição após o tempo definido
    setTimeout(() => {
        document.querySelectorAll("*").forEach((element) => {
            element.style.transition = '';
        });
    }, transitionDuration);
});

// Inicia com o tema escuro
document.body.classList.add("dark-theme");
document.querySelector("nav.navbar").classList.add("navbar-dark-theme");
document.getElementById("Home").classList.add("dark-theme");

// Definir o texto do botão como "Alterar Tema" e já ajustar a aparência
document.getElementById("themeToggleBtn").textContent = "Alterar Tema";
