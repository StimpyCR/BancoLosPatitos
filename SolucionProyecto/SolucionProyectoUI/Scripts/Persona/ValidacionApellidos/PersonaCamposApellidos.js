$(document).ready(function () {

    function actualizarCamposApellidos(contexto) {
        var $ctx = contexto ? $(contexto) : $(document);

        var $tipo = $ctx.find("#TipoIdentificacion");
        var $apellidos = $ctx.find("#PrimerApellido, #SegundoApellido");

        if ($tipo.length === 0 || $apellidos.length === 0) {
            return;
        }

        var valor = ($tipo.val() || "").toString().trim();
        var esJuridica = (valor === "2");

        var esCrear = $ctx.closest("#modalPersona").length > 0;
        var esEditar = $ctx.closest("#modalEditarPersona").length > 0;

        if (esJuridica) {
            if (esCrear) {
                $apellidos
                    .val("")
                    .prop("disabled", true)
                    .prop("readonly", false)
                    .removeClass("bg-light");
            } else if (esEditar) {
                $apellidos
                    .prop("disabled", false)
                    .prop("readonly", true)
                    .addClass("bg-light")                 
                    .css({
                        "cursor": "not-allowed",          
                        "background-color": "#e9ecef"     
                    });
            }
        } else {
            $apellidos
                .prop("disabled", false)
                .prop("readonly", false)
                .removeClass("bg-light")
                .css({
                    "cursor": "",
                    "background-color": ""               
                });
        }
    }

    actualizarCamposApellidos();

    $(document).on("change", "#TipoIdentificacion", function () {
        actualizarCamposApellidos($(this).closest("form"));
    });

    $(document).on("shown.bs.modal", "#modalPersona, #modalEditarPersona", function () {
        actualizarCamposApellidos(this);
    });
});
