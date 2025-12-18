$(document).on("click", ".btn-realizar-analisis", function () {
    let idPersona = $(this).data("id");

$.ajax({
    url: '/Analisis/RealizarAnalisis',
type: 'POST',
data: {idPersona: idPersona },
success: function (response) {
       
    if (response.success) {
    Swal.fire({
        title: 'Análisis realizado',
        text: response.message || 'El análisis se completó correctamente.',
        icon: 'success',
        confirmButtonText: 'Aceptar'
    });

    } else {
        Swal.fire({
            title: 'No se pudo realizar el análisis',
            text: response.message || 'No fue posible completar el análisis.',
            icon: 'error',
            confirmButtonText: 'Aceptar'
    });
    }
},
error: function () {
    Swal.fire({
        title: 'Error',
        text: 'Ocurrió un error inesperado al realizar el análisis.',
        icon: 'error',
        confirmButtonText: 'Cerrar'
    });
        }
    });
});


