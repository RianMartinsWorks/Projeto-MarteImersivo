const form = document.getElementById('questionario-form');
form.addEventListener('submit', function (event) {
    event.preventDefault();

    const formData = new FormData(form);

    fetch('/Home/SubmitFeedback', {
        method: 'POST',
        body: formData
    })
        .then(response => response.ok ? response.json() : Promise.reject('Erro ao enviar feedback'))
        .then(data => {
            if (data.success) {
                // Redireciona para a página de agradecimento
                window.location.href = data.redirectUrl; // Isso vai redirecionar corretamente
            } else {
                console.error('Erro no envio:', data.errors);
            }
        })
        .catch(error => {
            console.error('Erro:', error);
        });
});
