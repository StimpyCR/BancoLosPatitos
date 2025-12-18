document.addEventListener('DOMContentLoaded', function () {

    const tablaActividades = new DataTable('#tablaActividades', {
        paging: true,
        searching: true,
        ordering: true,
        autoWidth: false
    });

    var spanMensaje = document.getElementById('mensajeTempData');
    if (spanMensaje) {
        var mensaje = spanMensaje.getAttribute('data-mensaje');
        var tipo = spanMensaje.getAttribute('data-tipo') || "info";
        var titulo = spanMensaje.getAttribute('data-titulo') || "Notificación";

        Swal.fire({
            icon: tipo,
            title: titulo,
            text: mensaje,
            confirmButtonText: "Aceptar",
            confirmButtonColor: "#3085d6"
        });
    }
});