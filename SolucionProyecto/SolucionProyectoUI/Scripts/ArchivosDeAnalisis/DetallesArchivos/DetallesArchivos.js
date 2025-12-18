$(document).ready(function () {

    $(document).on("click", ".btn-detalles-archivo", function (e) {
        e.preventDefault();

        var id = $(this).data("id");
        if (!id) return;

        var $modal = $("#modalDetallesArchivo");
        $modal.find(".modal-body").html("");

        $.get("/ArchivosDeAnalisis/VistaParcialDetallesArchivo", { id: id }, function (html) {
            $modal.find(".modal-body").html(html);
            $modal.modal("show");
        }).fail(function () {

            $modal.modal("hide");

            var msg = "No se pudieron cargar los detalles del archivo.";

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

    $("#modalDetallesArchivo").on("hidden.bs.modal", function () {
        $(this).find(".modal-body").html("");
    });

});
