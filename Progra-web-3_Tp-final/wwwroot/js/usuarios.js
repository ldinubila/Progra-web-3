$(document).ready(function () {

    // DataTable
    var table = $('#tabla_usuarios').DataTable({
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

function filtro_nombre_usuarios() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("buscar_nombre_usuarios");
    filter = input.value.toUpperCase();
    table = document.getElementById("tabla_usuarios");
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


function filtro_email_usuarios() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("buscar_email_usuarios");
    filter = input.value.toUpperCase();
    table = document.getElementById("tabla_usuarios");
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

function filtro_usuarios_eliminados() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("excluir_eliminados");
    filter = input.checked;
    table = document.getElementById("tabla_usuarios");
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
            window.location.href = "/Usuarios/Index";
        });
    });


    const collectData = () => {
        const data = {};

        $(".usuarios-form :input").each(function () {
            data[this.id] = $(this).val();
        });

        return data;
    };

    async function guardar(data, callback) {
        var descripcion = $("#descripcion").val();
        Swal.fire(
            `usuario ${descripcion} creado con éxito`,
            'Haga click para continuar',
            'success'
        ).then((result) => {
            $.ajax({
                url: "/Usuarios/Nuevousuario",
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

    $("#cancelar_usuario").click(() => {
        window.location.href = "/Usuarios/Index";
    });

    $("#editar_usuario").click(() => {
        const data = collectData2();

        editar(data, () => {
            window.location.href = "/Usuarios/Index";
        });
    });

    const collectData2 = () => {
        const data = {};

        $(".usuarios-form :input").each(function () {
            data[this.id] = $(this).val();
        });

        return data;
    };



    async function editar(data, callback) {
        var nombre = $("#nombre").val();
        Swal.fire(
            `usuario ${nombre} modificado con exito`,
            'Haga click para continuar',
            'success'
        ).then((result) => {
            $.ajax({
                type: "POST",
                url: "/Usuarios/Editarusuario",
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

    $("#eliminar_usuario").click(() => {
        const data = collectData3();

        console.log('-----', data);

        Swal.fire({
            title: `Eliminar usuario?`,
            text: `Esta seguro que desea eliminar el usuario: ${data.Nombre}`,
            icon: 'question',
            showCancelButton: true,
        }).then(result => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Usuarios/Eliminar/${data.IdUsuario}`,
                    success: response => {
                        Swal.fire({
                            position: 'top-end',
                            icon: 'success',
                            title: `El usuario: ${data.nombre} fue eliminado`,
                            showConfirmButton: false,
                            timer: 1500
                        }).then(response => (window.location.href = "/Usuarios/Index"));
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

        $(".usuarios-form :input").each(function () {
            data[this.id] = $(this).val();
        });
        
        return data;
    };


});