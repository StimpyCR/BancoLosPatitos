$(document).ready(function () {

    var $modalEditarActividad = $("#modalEditarActividad");

    $(document).on("click", ".btn-editar-actividad", function (e) {
        e.preventDefault();

        var idActividad = $(this).data("id");
        if (!idActividad) {
            console.error("No se encontró data-id en el botón de editar.");
            return;
        }

        $modalEditarActividad.find(".modal-body").html("");

        $.get("/ActividadFinanciera/VistaParcialEditarActividad",
            { id: idActividad })
            .done(function (html) {
                $modalEditarActividad.find(".modal-body").html(html);
                $modalEditarActividad.modal("show");
            })
            .fail(function (xhr, status, error) {
                console.error("Error al cargar vista parcial de edición:", status, error, xhr.responseText);
                var msg = "Ocurrió un error al cargar el formulario de edición.";

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
            });
    });

    $modalEditarActividad.on("submit", "#formEditarActividadFinanciera", function (e) {
        e.preventDefault();

        var $form = $(this);

        $.ajax({
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize(),

            success: function (result) {
                console.log("Respuesta AJAX EditarActividad:", result, "tipo:", typeof result);

                if (typeof result === "string") {

                    if (result.indexOf("<form") !== -1) {
                        $modalEditarActividad.find(".modal-body").html(result);
                        return;
                    }

                    $modalEditarActividad.find(".modal-body").html(result);
                    return;
                }

                if (result && result.success === true) {
                    $modalEditarActividad.modal("hide");

                    var mensaje = result.message || "La actividad financiera se ha actualizado correctamente.";

                    if (window.Swal && typeof Swal.fire === "function") {
                        Swal.fire({
                            icon: "success",
                            title: "Actividad actualizada con éxito",
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
                    var msgError = result.message || "Ocurrió un error al actualizar la actividad financiera.";

                    if (window.Swal && typeof Swal.fire === "function") {
                        Swal.fire({
                            icon: "error",
                            title: "No se pudo actualizar",
                            text: msgError,
                            confirmButtonText: "Aceptar",
                            confirmButtonColor: "#d33"
                        });
                    } else {
                        alert(msgError);
                    }

                    return;
                }

                $modalEditarActividad.find(".modal-body").html(result);
            },

            error: function (xhr, status, error) {
                $modalEditarActividad.modal("hide");

                var msg = "Ocurrió un error al editar la actividad financiera.";

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

                console.error("Error en AJAX EditarActividad:", status, error, xhr.responseText);
            }
        });
    });

    $modalEditarActividad.on("hidden.bs.modal", function () {
        $(this).find(".modal-body").html("");
    });
});

