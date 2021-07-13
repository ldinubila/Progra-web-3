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
$("#guardar").click(() => {
    const data = collectData();

        guardar(data, () => {
            window.location.href = "/Usuarios/Index";
        });
    });

    $("#eliminar").click(() => {
        const data = collectData();

        Swal.fire({
            title: `Eliminar usuario?`,
            text: `Esta seguro que desea eliminar al usuario: ${data.nombre}`,
            icon: 'question',
            showCancelButton: true,
        }).then(result => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Usuarios/Eliminar/${data.id}`,
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

    $("#guardar_y_limpiar").click(() => {
        const data = collectData();
        guardar(data, limpiarForm);
    });

    const collectData = () => {
        const data = {};

        $(".usuarios-form :input").each(function () {
            data[this.id] = $(this).val();
        });

        return data;
    };

    const limpiarForm = () => {
        $(".usuarios-form :input").each(function () {
            $(this).val("");
        });
    };

    function existeNumero(numero) {
        return $.get("/usuarios/existenumero?numero=" + numero, response => (response.responseJSON));
    }

    $("#cancelar").click(() => {
        window.location.href = "/Usuarios/Index";
    });

    async function validarForm() {
        const nombre = $("#nombre").val();
        const numero = $("#numero").val();


        if (!nombre) {
            Swal.fire(
                'Error [nombre]',
                `El campo nombre es obligatorio`,
                'error'
            );
            return false;
        }

        if (numero) {
            if (!$.isNumeric(numero)) {
                Swal.fire(
                    'Error [numero]',
                    'El numero debe contener unicamente numeros',
                    'error'
                );
                return false;
            }

            const numeroRepetido = await existeNumero($("#numero").val());


            if (numeroRepetido) {
                Swal.fire(
                    `Error [numero]`,
                    `El numero: ${numero} es repetido, ingrese otro por favor`,
                    'error'
                );
                return false;
            }
        }

        return true;
    }

function filtro_usuario() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("buscar_nombre");
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

function filtro_email() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("buscar_email");
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

function filtro_eliminados() {
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