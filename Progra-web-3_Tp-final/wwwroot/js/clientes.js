$(document).ready(() => {
    var table = $('#tabla_clientes').DataTable({
        "searching": false,
        "info": false,
        "order": [[1, "asc"]]
    });

    $("#guardar").click(() => {
        const data = collectData();

        guardar(data, () => {
            window.location.href = "/Clientes/Index";
        });
    });

    $("#eliminar_cliente").click(() => {
        const data = collectData();

        console.log('-----', data);

        Swal.fire({
            title: `Eliminar cliente?`,
            text: `Esta seguro que desea eliminar al cliente: ${data.Nombre}`,
            icon: 'question',
            showCancelButton: true,
        }).then(result => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Clientes/Eliminar/${data.IdCliente}`,
                    success: response => {
                        Swal.fire({
                            position: 'top-end',
                            icon: 'success',
                            title: `El cliente: ${data.Nombre} fue eliminado`,
                            showConfirmButton: false,
                            timer: 1500
                        }).then(response => (window.location.href = "/Clientes/Index"));
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

        $(".clientes-form :input").each(function () {
            data[this.id] = $(this).val();
        });

        return data;
    };

    const limpiarForm = () => {
        $(".clientes-form :input").each(function () {
            $(this).val("");
        });
    };

    function existeNumero(numero) {
        return $.get("/clientes/existenumero?numero=" + numero, response => (response.responseJSON));
    }

    $("#cancelar").click(() => {
        window.location.href = "/Clientes/Index";
    });

    async function guardar(data, callback) {
        $.ajax({
            url: "/Clientes/Alta",
            data,
            success: response => {
                Swal.fire(
                    `Exito`,
                    `El cliente: ${data.nombre} se creo correctamente`,
                    'success',
                ).then(result => {
                    callback();
                });
            },
            error: error => {
                console.log(error);
            }
        });
    }

    filtro_eliminados();
});

function filtro_nombre() {
    var input, filter, tr, td, i, txtValue;
    input = document.getElementById("buscar_nombre");
    filter = input.value.toUpperCase();
    tr = $("#tabla_clientes tr");

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

function filtro_numero() {
    var input, filter, tr, td, i, txtValue;
    input = document.getElementById("buscar_numero");
    filter = input.value.toUpperCase();
    tr = $("#tabla_clientes tr");

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

function filtro_eliminados() {
    var input, filter, tr, td, i, txtValue;
    input = document.getElementById("excluir_eliminados");
    filter = input.checked;
    tr = $("#tabla_clientes tr");

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