//Agregar Pedido
let agregar = document.getElementById("agregar")
let articulosPedidos = document.getElementById("articulosPedidos")
agregar.addEventListener("click", agregarArticulo)

function agregarArticulo() {
    var evento = window.event || e;
    evento.preventDefault();
    let articuloSelect = document.getElementById("articuloSelect");
    let cantidad = document.getElementById("cant").value;
    let cantidades = document.getElementsByClassName('cantidad');
    let articulosAgregados = document.getElementsByClassName("articulosAgregados")

    let agregados = document.getElementsByClassName("agregados");
    let validar = false;
    for (let i = 0; i < agregados.length; i++) {
        if (articuloSelect.value == agregados[i].value) {
            validar = true;
            cantidad = parseInt(cantidades[i].value) + parseInt(cantidad)
            if (cantidad > 0) {
                articulosAgregados[i].innerHTML = "<td> <input type='hidden' name='articulo' class='agregados' value='" + articuloSelect.value + "'/><input type='hidden' class='cantidad' name='cantidad' value='" + cantidad + "'/> - " + articuloSelect.options[articuloSelect.selectedIndex].text + " </td> <td></td><td>" + cantidad + "</td><td><button class='quitar btn btn-danger' name='quitar'>Quitar</button></td>";
            }

        }
    }

    if (validar == false) {

        articulosPedidos.innerHTML += "<tr class='articulosAgregados'><td> <input type='hidden' class='agregados' name='articulo' value='" + articuloSelect.value + "'/><input type='hidden' class='cantidad' name='cantidad' value='" + cantidad + "'/> - " + articuloSelect.options[articuloSelect.selectedIndex].text + " </td> <td></td><td>" + cantidad + "</td><td><button class='quitar btn btn-danger' name='quitar'>Quitar</button></td></tr>";
    }
}

articulosPedidos.addEventListener("click", quitarArticulo)

function quitarArticulo(e) {
    var evento = window.event || e;
    evento.preventDefault();
    if (e.target.name == 'quitar') {
        console.log(e.target.parentElement);
        e.target.parentElement.parentElement.remove();
    }
}


function filtro_cliente() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("buscar_cliente");
    filter = input.value.toUpperCase();
    table = document.getElementById("tabla_pedidos");
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
    table = document.getElementById("tabla_pedidos");
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

function eliminar() {

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

function filtro_eliminados() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("excluir_eliminados");
    filter = input.checked;
    table = document.getElementById("tabla_pedidos");
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