document.addEventListener('DOMContentLoaded', function () {

    const dt = new DataTable('#tablaArchivos', {
        scrollX: true,
        autoWidth: false,
        paging: true,
        searching: true,
        ordering: true,
        initComplete: function () {
            const boton = document.getElementById('btnNuevoArchivo');

            const container = document
                .querySelector('#tablaArchivos')
                .closest('.dt-container');

            if (!container || !boton) return;

            const celdaEnd = container.querySelector('.dt-layout-cell.dt-layout-end');

            if (celdaEnd) {
                boton.classList.add('ms-2');
                celdaEnd.appendChild(boton);
            }
        }
    });
});
