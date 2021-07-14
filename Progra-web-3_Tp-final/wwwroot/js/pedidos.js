$(document).ready(function () {

    // DataTable
    var table = $('#tabla_pedidos').DataTable({
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


    let eliminar = document.getElementsByClassName('eliminar')

    for (let i = 0; i < eliminar.length; i++) {

        console.log(eliminar[i])
    }
});

function filtro_cliente() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("buscar_cliente");
    filter = input.value.toUpperCase();
    table = document.getElementById("example");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
};

function filtro_estado() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("buscar_estado");
    filter = input.value.toUpperCase();
    table = document.getElementById("example");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[1];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
};

$(document).ready(() => {
    $("#guardar").click(() => {
        const data = collectData();

        guardar(data, () => {
            window.location.href = "/Pedidos/Index";
        });
    });

    $("#guardar_y_limpiar").click(() => {
        const data = collectData();
        guardar(data, limpiarForm);
    });

    const limpiarForm = () => {
        $(".pedidos-form :select, input").each(function () {
            $(this).val("");
        });
    }

    const collectData = () => {
        const data = {};

        $(".articulos-form :input").each(function () {
            data[this.id] = $(this).val();
        });

        return data;
    };

    async function guardar(data, callback) {
        Swal.fire(
            'Pedido *DESCRIPCION* creado con éxito',
            'Haga click para continuar',
            'success'
        ).then((result) => {
            $.ajax({
                url: "/Pedidos/Alta",
                data,
                success: response => {
                    console.log(response);
                    callback();
                },
                error: error => {
                    console.log(error);
                }
            })
        })
    };
});
    function eliminar_pedidos() {

        valor = $('#boton_eliminar').val();
        Swal.fire({
            title: 'Esta seguro que desea eliminar el pedido: ' + valor,
            text: "Esta acción no se podrá revertir",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sí, eliminar'
        }).then((result) => {
            $.ajax({
                url: "/Pedidos/Eliminar/${data.id}",
                success: response => {
                    Swal.fire(
                        'Eliminado!',
                        'El articulo ha sido borrado',
                        'success'
                    ).then((result) => {

                        window.location = "/Pedidos/Index"
                    })
                }
                ,
                error: error => {
                    console.log(error);
                }
            });
        })
};

function validarEstado() {
    console.log("Hola estado");
};

