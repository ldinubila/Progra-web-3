$(document).ready(function () {

    // DataTable
    var table = $('#tabla_articulos').DataTable({
        "searching": false,
        "info": false,
        "order": [[1, "asc"]],
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


});

function filtro_articulo() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("buscar_descripcion");
    filter = input.value.toUpperCase();
    table = document.getElementById("tabla_articulos");
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


function filtro_codigo() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("buscar_codigo");
    filter = input.value.toUpperCase();
    table = document.getElementById("tabla_articulos");
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

function filtro_articulos_eliminados() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("excluir_eliminados");
    filter = input.checked;
    table = document.getElementById("tabla_articulos");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByClassName("fecha-borrado")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (filter) {
                if (txtValue === '') {
                    tr[i].style.display = "";
                } else {
                    tr[i].style.display = "none";
                }
            } else {
                tr[i].style.display = "";
            }
        }
    }
};


$(document).ready(() => {
    $("#guardar").click(() => {
        const data = collectData();

        guardar(data, () => {
            window.location.href = "/Articulos/Index";
        });
    });


    const collectData = () => {
        const data = {};

        $(".articulos-form :input").each(function () {
            data[this.id] = $(this).val();
        });

        return data;
    };

    async function guardar(data, callback) {
        var descripcion = $("#descripcion").val();
        Swal.fire(
            `Articulo ${descripcion} creado con éxito`,
            'Haga click para continuar',
            'success'
        ).then((result) => {
            $.ajax({
                url: "/Articulos/NuevoArticulo",
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

    $("#cancelar_articulo").click(() => {
        window.location.href = "/Articulos/Index";
    });

    $("#editar_articulo").click(() => {
        const data = collectData2();

        editar(data, () => {
            window.location.href = "/Articulos/Index";
        });
    });

    const collectData2 = () => {
        const data = {};

        $(".articulos-form :input").each(function () {
            data[this.id] = $(this).val();
        });

        return data;
    };



    async function editar(data, callback) {
        var descripcion = $("#descripcion").val();
        Swal.fire(
            `Articulo ${descripcion} modificado con exito`,
            'Haga click para continuar',
            'success'
        ).then((result) => {
            $.ajax({
                type: "POST",
                url: "/Articulos/EditarArticulo",
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

    $("#eliminar_articulo").click(() => {
        const data = collectData3();

        Swal.fire({
            title: `Eliminar articulo?`,
            text: `Esta seguro que desea eliminar el articulo: ${data.descripcion}`,
            icon: 'question',
            showCancelButton: true,
        }).then(result => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Articulos/Eliminar/${data.id}`,
                    success: response => {
                        Swal.fire({
                            position: 'top-end',
                            icon: 'success',
                            title: `El articulo: ${data.descripcion} fue eliminado`,
                            showConfirmButton: false,
                            timer: 1500
                        }).then(response => (window.location.href = "/Articulos/Index"));
                    },
                    error: error => {
                        console.log(error);
                    }
                });
            }
        });
    });

    const collectData3 = () => {
        const data = {};

        $(".articulos-form :input").each(function () {
            data[this.id] = $(this).val();
        });

        return data;
    };


});




