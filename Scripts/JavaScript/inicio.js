    document.getElementById("themeToggleBtn").addEventListener("click", function () {
        const transitionDuration = 1000;

    document.body.style.transition = `background-color ${transitionDuration}ms ease, color ${transitionDuration}ms ease`;

    document.body.classList.toggle("light-theme");
    document.body.classList.toggle("dark-theme");

    var homeSection = document.getElementById("Home");
    homeSection.style.transition = `background-image ${transitionDuration}ms ease`;
    homeSection.classList.toggle("light-theme");
    homeSection.classList.toggle("dark-theme");

    if (document.body.classList.contains("dark-theme")) {
        this.textContent = "Alternar para Tema Escuro";
        } else {
        this.textContent = "Alternar para Tema Claro";
        }

        setTimeout(() => {
        document.body.style.transition = '';
    homeSection.style.transition = '';
        }, transitionDuration);
    });

    document.body.classList.add("light-theme");
    document.getElementById("Home").classList.add("light-theme");
    document.body.classList.add("no-bg");
