document.addEventListener('DOMContentLoaded', function () {

    const dt = new DataTable('#tablaPersonas', {
        scrollX: true,
        autoWidth: false,
        paging: true,
        searching: true,
        ordering: true,
        initComplete: function () {
            const boton = document.getElementById('btnNuevaPersona');

            const container = document
                .querySelector('#tablaPersonas')
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