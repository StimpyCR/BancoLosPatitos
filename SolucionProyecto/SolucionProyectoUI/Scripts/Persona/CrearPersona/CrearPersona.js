$(document).ready(function () {

    $("#btnNuevaPersona").on("click", function (e) {
        e.preventDefault();

        var $modal = $("#modalPersona");

        $modal.find(".modal-body").html("");

        $.get("/Persona/VistaParcialCrearPersona", function (html) {
            $modal.find(".modal-body").html(html);
            $modal.modal("show");
        });
    });

    $("#modalPersona").on("submit", "#formCrearPersona", function (e) {
        e.preventDefault();

        var $form = $(this);

        $.ajax({
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize(),

            success: function (result) {

                if (typeof result === "string") {
                    $("#modalPersona .modal-body").html(result);
                    return;
                }

                if (result && result.success === true) {

                    $("#modalPersona").modal("hide");

                    var mensaje = result.message || "La persona se ha guardado correctamente.";

                    if (window.Swal && typeof Swal.fire === "function") {

                        Swal.fire({
                            icon: "success",
                            title: "Persona registrada con éxito",
                            text: mensaje,
                            confirmButtonText: "Aceptar",
                            confirmButtonColor: "#3085d6"
                        }).then(function () {
                            window.location.reload();
                        });

                    } else {
                        alert(mensaje);
                        window.location.reload();
                    }

                    return;
                }

                if (result && result.success === false) {

                    var msgError = result.message || "Ocurrió un error al registrar la persona.";

                    if (window.Swal && typeof Swal.fire === "function") {

                        Swal.fire({
                            icon: "error",
                            title: "No se pudo registrar",
                            text: msgError,
                            confirmButtonText: "Aceptar",
                            confirmButtonColor: "#d33"
                        });

                    } else {
                        alert(msgError);
                    }

                    return;
                }

                $("#modalPersona .modal-body").html(result);
            },

            error: function () {

                $("#modalPersona").modal("hide");

                var msg = "Ocurrió un error inesperado.";

                if (window.Swal && typeof Swal.fire === "function") {

                    Swal.fire({
                        icon: "error",
                        title: "Error",
                        text: msg,
                        confirmButtonText: "Aceptar",
                        confirmButtonColor: "#d33"
                    });

                } else {
                    alert(msg);
                }
            }
        });
    });

    $("#modalPersona").on("hidden.bs.modal", function () {
        $(this).find(".modal-body").html("");
    });
});