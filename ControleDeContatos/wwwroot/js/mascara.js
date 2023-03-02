function aplicarMascaraTelefone() {
    $(document).ready(function () {
        // Seleciona o input do telefone
        var phoneInput = $('input[type="tel"]');

        // Aplica a máscara quando o usuário digita
        phoneInput.on('input', function () {
            var unformatted = phoneInput.val().replace(/\D/g, '');
            var formatted = '';

            // Aplica a máscara dependendo do comprimento do número
            if (unformatted.length >= 11) {
                formatted = unformatted.replace(/^(\d{2})(\d{5})(\d{4}).*/, '($1) $2-$3');
            } else if (unformatted.length >= 6) {
                formatted = unformatted.replace(/^(\d{2})(\d{4})(\d{0,4}).*/, '($1) $2-$3');
            } else if (unformatted.length >= 1) {
                formatted = unformatted.replace(/^(\d{0,2})(\d{0,5})(\d{0,4}).*/, '($1) $2-$3');
            }

            // Atualiza o valor do input com a máscara aplicada
            phoneInput.val(formatted);
        });
    });
}