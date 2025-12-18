$(document).ready(function () {

    $("#btnNuevaActividad").on("click", function (e) {
        e.preventDefault();

        const $modal = $("#modalActividad");

        $modal.find(".modal-body").html("");

        $.get("/ActividadFinanciera/VistaParcialRegistrarActividad", function (html) {
            $modal.find(".modal-body").html(html);
            $modal.modal("show");
        });
    });

    $("#modalActividad").on("submit", "#formCrearActividadFinanciera", function (e) {
        e.preventDefault();

        const $form = $(this);

        $.ajax({
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize(),

            success: function (result) {

                if (typeof result === "string") {
                    $("#modalActividad .modal-body").html(result);
                    return;
                }

                if (result && result.success === true) {

                    $("#modalActividad").modal("hide");

                    const mensaje = result.message || "La actividad financiera se ha guardado correctamente.";

                    if (window.Swal && typeof Swal.fire === "function") {

                        Swal.fire({
                            icon: "success",
                            title: "Actividad registrada con éxito",
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

                    const msgError = result.message || "Ocurrió un error al registrar la actividad financiera.";

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

                $("#modalActividad .modal-body").html(result);
            },

            error: function () {

                $("#modalActividad").modal("hide");

                const msg = "Ocurrió un error inesperado al registrar la actividad financiera.";

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

    $("#modalActividad").on("hidden.bs.modal", function () {
        $(this).find(".modal-body").html("");
    });
});
