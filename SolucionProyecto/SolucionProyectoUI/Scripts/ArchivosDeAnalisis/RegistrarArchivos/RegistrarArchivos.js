$(document).ready(function () {

    $("#btnNuevoArchivo").on("click", function (e) {
        e.preventDefault();

        var $modal = $("#modalArchivo");
        $modal.find(".modal-body").html("");

        $.get("/ArchivosDeAnalisis/VistaParcialRegistrarArchivo", function (html) {
            $modal.find(".modal-body").html(html);
            $modal.modal("show");
        });
    });

    $("#modalArchivo").on("submit", "#formRegistrarArchivo", function (e) {
        e.preventDefault();

        var $form = $(this);

        $.ajax({
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize(),

            success: function (result) {

                if (typeof result === "string") {
                    $("#modalArchivo .modal-body").html(result);
                    return;
                }

                if (result && result.success === true) {

                    $("#modalArchivo").modal("hide");

                    var mensaje = result.message || "El archivo se ha guardado correctamente.";

                    if (window.Swal && typeof Swal.fire === "function") {
                        Swal.fire({
                            icon: "success",
                            title: "Archivo registrado con éxito",
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

                    var msgError = result.message || "Ocurrió un error al registrar el archivo.";

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

                $("#modalArchivo .modal-body").html(result);
            },

            error: function () {

                $("#modalArchivo").modal("hide");

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

    $("#modalArchivo").on("hidden.bs.modal", function () {
        $(this).find(".modal-body").html("");
    });
});