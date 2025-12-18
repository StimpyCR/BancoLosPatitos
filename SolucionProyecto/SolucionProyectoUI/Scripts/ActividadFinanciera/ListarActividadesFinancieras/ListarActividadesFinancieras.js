document.addEventListener('DOMContentLoaded', function () {

    const dtActividad = new DataTable('#tablaActividades', {
        scrollX: true,
        autoWidth: false,
        paging: true,
        searching: true,
        ordering: true,

        initComplete: function () {

            const botonNuevaActividad = document.getElementById('btnNuevaActividad');

            const container = document
                .querySelector('#tablaActividades')
                .closest('.dt-container');

            if (!container || !botonNuevaActividad) return;

            const celdaEnd = container.querySelector('.dt-layout-cell.dt-layout-end');

            if (celdaEnd) {
                botonNuevaActividad.classList.add('ms-2');
                celdaEnd.appendChild(botonNuevaActividad);
            }
        }
    });

});
