$(document).ready(function () {

    $(document).on("click", ".btn-detalles-persona", function (e) {
        e.preventDefault();

        var id = $(this).data("id");
        if (!id) return;

        var $modal = $("#modalDetallesPersona");
        $modal.find(".modal-body").html("");

        $.get("/Persona/VistaParcialDetallesPersona", { id: id }, function (html) {
            $modal.find(".modal-body").html(html);
            $modal.modal("show");
        }).fail(function () {

            $modal.modal("hide");

            var msg = "No se pudieron cargar los detalles de la persona.";

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

    $("#modalDetallesPersona").on("hidden.bs.modal", function () {
        $(this).find(".modal-body").html("");
    });

});
