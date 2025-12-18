$(document).ready(function () {

    const $modalEditar = $("#modalEditarPersona");
    const modalEditarEl = document.getElementById("modalEditarPersona");
    const modalEditar = bootstrap.Modal.getOrCreateInstance(modalEditarEl);

    $(document).on("click", ".btn-editar-persona", function (e) {
        e.preventDefault();

        const idPersona = $(this).data("id");
        if (!idPersona) return;

        $modalEditar.find(".modal-body").html("");

        $.get("/Persona/VistaParcialEditarPersona", { id: idPersona }, function (html) {
            $modalEditar.find(".modal-body").html(html);
            modalEditar.show(); 
        }).fail(function () {
            modalEditar.hide(); 

            const msg = "No se pudieron cargar los datos para editar a la persona.";

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

    $modalEditar.on("submit", "#formEditarPersona", function (e) {
        e.preventDefault();

        const $form = $(this);

        $.ajax({
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize(),
            success: function (result) {

                if (typeof result === "string") {
                    $modalEditar.find(".modal-body").html(result);
                    return;
                }

                if (result && result.success === true) {

                    modalEditar.hide(); 

                    const mensaje = result.message || "La persona se ha actualizado correctamente";

                    if (window.Swal && typeof Swal.fire === "function") {
                        Swal.fire({
                            icon: "success",
                            title: "Persona actualizada con éxito",
                            text: mensaje,
                            confirmButtonText: "Aceptar",
                            confirmButtonColor: "#3085d6"
                        }).then(function () {
                            window.location.reload();
                        });
                    } else if (window.swal && typeof swal === "function") {
                        swal({
                            title: "Persona actualizada con éxito",
                            text: mensaje,
                            icon: "success"
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

                    const msgError = result.message || "Ocurrió un error al actualizar a la persona.";

                    if (window.Swal && typeof Swal.fire === "function") {
                        Swal.fire({
                            icon: "error",
                            title: "No se pudo actualizar a la persona",
                            text: msgError,
                            confirmButtonText: "Aceptar",
                            confirmButtonColor: "#d33"
                        });
                    } else if (window.swal && typeof swal === "function") {
                        swal("No se pudo actualizar a la persona", msgError, "error");
                    } else {
                        alert(msgError);
                    }

                    return;
                }

                $modalEditar.find(".modal-body").html(result);
            },
            error: function (xhr, status, error) {

                modalEditar.hide(); 

                const msg = "Ocurrió un error al actualizar a la persona.";

                if (window.Swal && typeof Swal.fire === "function") {
                    Swal.fire({
                        icon: "error",
                        title: "Error",
                        text: msg,
                        confirmButtonText: "Aceptar",
                        confirmButtonColor: "#d33"
                    });
                } else if (window.swal && typeof swal === "function") {
                    swal("Error", msg, "error");
                } else {
                    alert(msg);
                }

                console.error("Error en AJAX EditarPersona:", status, error);
            }
        });
    });


    $modalEditar.on("hidden.bs.modal", function () {
        $(this).find(".modal-body").html("");
    });
});
