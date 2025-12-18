$(document).ready(function () {

    var $modalEditar = $("#modalEditarPalabraClave");

    $(document).on("click", ".btn-editar-palabra-clave", function (e) {
        e.preventDefault();

        var idPalabra = $(this).data("id");

        $modalEditar.find(".modal-body").html("");

        $.get("/PalabraClave/VistaParcialEditarPalabraClave", { id: idPalabra }, function (html) {
            $modalEditar.find(".modal-body").html(html);
            $modalEditar.modal("show");
        });
    });

    $modalEditar.on("submit", "#formEditarPalabraClave", function (e) {
        e.preventDefault();

        var $form = $(this);

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

                    $modalEditar.modal("hide");

                    var mensaje = result.message || "La palabra clave se ha actualizado correctamente.";

                    if (window.Swal && typeof Swal.fire === "function") {
                        Swal.fire({
                            icon: "success",
                            title: "Palabra clave actualizada con éxito",
                            text: mensaje,
                            confirmButtonText: "Aceptar",
                            confirmButtonColor: "#3085d6"
                        }).then(function () {
                            window.location.reload();
                        });

                    } else if (window.swal && typeof swal === "function") {
                        swal({
                            title: "Palabra clave actualizada con éxito",
                            text: mensaje,
                            icon: "success"
                        }).then(function () {
                            window.location.reload();
                        });

                    } else {
                        alert(mensaje);
                        window.location.reload();
                    }

                } else if (result && result.success === false) {

                    var msgError = result.message || "Ocurrió un error al actualizar la palabra clave.";

                    if (window.Swal && typeof Swal.fire === "function") {
                        Swal.fire({
                            icon: "error",
                            title: "No se pudo actualizar la palabra clave",
                            text: msgError,
                            confirmButtonText: "Aceptar",
                            confirmButtonColor: "#d33"
                        });
                    } else if (window.swal && typeof swal === "function") {
                        swal("No se pudo actualizar la palabra clave", msgError, "error");
                    } else {
                        alert(msgError);
                    }

                } else {
                    $modalEditar.find(".modal-body").html(result);
                }
            },
            error: function (xhr, status, error) {
                $modalEditar.modal("hide");

                var msg = "Ocurrió un error al actualizar la palabra clave.";

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

                console.error("Error en AJAX EditarPalabraClave:", status, error);
            }
        });
    });

    $modalEditar.on("hidden.bs.modal", function () {
        $(this).find(".modal-body").html("");
    });
});
