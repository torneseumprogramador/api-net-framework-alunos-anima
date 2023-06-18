$(document).ready(function () {
    $("#btnSalvar").click(function () {
        var produto = {
            Nome: $("#Nome").val(),
            Descricao: $("#Descricao").val()
        };
        $.ajax({
            url: 'Create',
            type: 'POST',
            dataType: 'json',
            data: produto,
            success: function (response) {
                debugger;
                if (response.Success) {
                    alert("Produto criado com sucesso!");
                    window.location.href = 'Create';
                } else {
                    alert("Ocorreu um erro ao criar o produto.");
                }
            },
            error: function () {
                alert("Ocorreu um erro ao processar a requisição.");
            }
        });
    });
});