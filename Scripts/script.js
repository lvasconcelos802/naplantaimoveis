
function modal_contatos() {
    //teste
    $("#modalContatos").modal("show");    
}  

function modal_visualizar() {
    //teste
    $("#modalVisualizar").modal("show");      
} 

$(document).ready(function () {

    function limpa_formulário_cep() {
        // Limpa valores do formulário de cep.
        $("#ContentPlaceHolder1_txtEndereco").val("");
        $("#ContentPlaceHolder1_txtBairro").val("");
        $("#ContentPlaceHolder1_txtCidade").val("");
        $("#ContentPlaceHolder1_txtEstado").val("");
    }    

    //Quando o campo cep perde o foco.
    $("#ContentPlaceHolder1_txtCep").blur(function () {

        //Nova variável "cep" somente com dígitos.
        var cep = $(this).val().replace(/\D/g, '');

        //Verifica se campo cep possui valor informado.
        if (cep != "") {

            //Expressão regular para validar o CEP.
            var validacep = /^[0-9]{8}$/;

            //Valida o formato do CEP.
            if (validacep.test(cep)) {

                //Preenche os campos com "..." enquanto consulta webservice.
                $("#ContentPlaceHolder1_txtEndereco").val("...");
                $("#ContentPlaceHolder1_txtBairro").val("...");
                $("#ContentPlaceHolder1_txtCidade").val("...");
                $("#ContentPlaceHolder1_txtEstado").val("...");

                //Consulta o webservice viacep.com.br/
                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        //Atualiza os campos com os valores da consulta.
                        $("#ContentPlaceHolder1_txtEndereco").val(dados.logradouro);
                        $("#ContentPlaceHolder1_txtBairro").val(dados.bairro);
                        $("#ContentPlaceHolder1_txtCidade").val(dados.localidade);
                        $("#ContentPlaceHolder1_txtEstado").val(dados.uf);

                    } //end if.
                    else {
                        //CEP pesquisado não foi encontrado.
                        limpa_formulário_cep();
                        alert("CEP não encontrado.");
                    }
                });
            } //end if.
            else {
                //cep é inválido.
                limpa_formulário_cep();
                alert("Formato de CEP inválido.");
            }
        } //end if.
        else {
            //cep sem valor, limpa formulário.
            limpa_formulário_cep();
        }
    });    

    //busca     
    $("#ContentPlaceHolder1_txtBusca").focus();
    $("#ContentPlaceHolder1_txtBusca").autocomplete({
        source: function (request, response) {
            $.getJSON("busca.ashx?texto=" + $("#ContentPlaceHolder1_txtBusca").val(), { query: request.term }, response);
        },
        minLength: 1,
        select: function (event, ui) {            

            $("#ContentPlaceHolder1_hidKey").val(ui.item.key);           
        },
    });

    //busca fim

});



