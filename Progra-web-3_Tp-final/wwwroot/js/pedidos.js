$(document).ready(function () {

    // Setup - add a text input to each footer cell
    //$('#example tfoot th').each(function () {
      //  var title = $(this).text();
      //$(this).html('<input type="text" placeholder="Buscar ' + title + '" />');
    //});

    // DataTable
    var table = $('#example').DataTable({
        "searching": false,
        "info": false,
        initComplete: function () {
            // Apply the search
            this.api().columns().every(function () {
                var that = this;

                $('input', this.footer()).on('keyup change clear', function () {
                    if (that.search() !== this.value) {
                        that
                            .search(this.value)
                            .draw();
                    }
                });
            });
        }
    });

    console.log("Hola");
    

    let eliminar = document.getElementsByClassName('eliminar')

    for (let i = 0; i < eliminar.length; i++) {

        console.log(eliminar[i])
    }
});