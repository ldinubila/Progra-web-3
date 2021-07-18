$(document).ready(function () {

    // DataTable
    var table = $('#tabla_pedidos').DataTable({
        "searching": false,
        "info": false,
        initComplete: function () {
            // Apply the search
            this.api().columns().every(function () {
                var that = this;
            });
        }
   });


    let eliminar = document.getElementsByClassName('eliminar')

    for (let i = 0; i < eliminar.length; i++) {

        console.log(eliminar[i])
    }
});


