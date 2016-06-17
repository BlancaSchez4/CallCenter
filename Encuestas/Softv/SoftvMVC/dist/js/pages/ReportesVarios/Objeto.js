// obtener valor del radiobutton seleccionado
function radioBtn() {
    var ordenarPor = $("input[name='ordenar']:checked").val();
    return ordenarPor;
}

function filtrarPor() {
    //var marcado = $('#soloInternet').is(':checked');  
    if ($('#soloInternet').is(':checked')) {
        var soloInternet = 1; //seleccionado
    }
    else {
        var soloInternet = 0; //no seleccionado
    }
    return soloInternet;
}

function reporte() {
    //obtiene el id del Reporte del 0 al 12 (no hay 9 ni 10)
    var lista = document.getElementById("reportes"); //select id = reportes 
    var idReporte = lista.options[lista.selectedIndex].id;   // Obtener valor de la opción seleccionada
    return idReporte;
}


var obj = {}; // es global 


function guardarDatos(numModal) {
    var idReporte = reporte();//reporte seleccionado
    if (numModal == 1) {
        //Pantalla principal ó Modal 0
        var soloInternet = 0;
        var op = cableInternet();//tipo de servicio seleccionado
        var orden = radioBtn(); //ordenar reportes por contrato(1) ó colonia y calle(2)

        objPrincipal.op = op;
        objPrincipal.Orden = orden;
        objPrincipal.clv_reporte = idReporte;

        if (op == 2) {
            soloInternet = filtrarPor();//filtrarPor = filtrarPor(); //filtrar por soloInternet
            objPrincipal.soloInternet = soloInternet;
        }
        //Fin pantalla principal

        var seleccionTipoCliente = [];
        var lista = document.getElementById('destinoClientes');
        for (var i = 0; i < lista.length; i++) {
            var opcionSel = lista.options[i].value //Obtener valor de todas las opciones en la lista destino
            seleccionTipoCliente.push(opcionSel);
        }
        objTipoCliente.tipoCliente = seleccionTipoCliente;

    } else if (numModal == 2) {
        var seleccionServicios = [];
        var lista = document.getElementById('destinoServicios');
        for (var i = 0; i < lista.length; i++) {
            var opcionSel = lista.options[i].value //Obtener valor de todas las opciones en la lista destino
            seleccionServicios.push(opcionSel);
        }
        objServicio.servicio = seleccionServicios;

    } else if (numModal == 3) {

        var seleccionCiudades = [];
        var lista = document.getElementById('destinoCiudades');
        for (var i = 0; i < lista.length; i++) {
            var opcionSel = lista.options[i].value //Obtener valor de todas las opciones en la lista destino
            seleccionCiudades.push(opcionSel);
        }
        objCiudades.ciudades = seleccionCiudades;

    } else if (numModal == 4) {
        var seleccionColonias = [];

        var lista = document.getElementById('destinoColonias');
        for (var i = 0; i < lista.length; i++) {
            var opcionSel = lista.options[i].value //Obtener valor de todas las opciones en la lista destino
            seleccionColonias.push(opcionSel);
        }
        objColonias.colonias = seleccionColonias;

    } else if (numModal == 5) {
        var telefono = 0; var todos = 0; var conTel = 0; var sinTel = 0;

        if ($("#conTel").is(':checked')) {
            conTel = 1;
            telefono = 1;
        }

        if ($("#sinTel").is(':checked')) {
            var sinTel = 1;
            telefono = 0;
        }

        if (conTel == 1 && sinTel == 1) {
            todos = 1;
            telefono = 0;
        }

        objTelefono.telefono = telefono;
        objTelefono.todos = todos;

    } else if (numModal == 6) {
        var seleccionPeriodo = [];

        var lista = document.getElementById('destinoPeriodo');
        for (var i = 0; i < lista.length; i++) {
            var opcionSel = lista.options[i].value //Obtener valor de todas las opciones en la lista destino
            seleccionPeriodo.push(opcionSel);
        }
        objPeriodo.periodo = seleccionPeriodo;

        if (idReporte == 5) {
            var lista = document.getElementById("listaMesP"); //select id = listaTipoServicio 
            var mes = lista.options[lista.selectedIndex].value;   // Obtener el valor de la opción seleccionada
            var valorp = document.getElementById("anioCP").value; //valor del textbox
            objPeriodo.periodo = seleccionPeriodo;
            objPeriodo.lista = lista;
            objPeriodo.mes = mes
            objPeriodo.valorp = valorp;
        }


    } else if (numModal == 7) {

        var ordenEjecutada = 0;
        var pendiente = 0;

        if ($("#pendiente").is(':checked')) {
            pendiente = 1;
        }
        if ($("#ejecutada").is(':checked')) {
            ordenEjecutada = 1;
        }
        if (pendiente == 1 && ordenEjecutada == 1) {
            ordenEjecutada = 2;
        }

        objEstatusOrden.OrdenEjecutada = ordenEjecutada;

    } else if (numModal == 8) {

        var fechaInicial = document.getElementById("fechaInicial").value
        var fechaFinal = document.getElementById("fechaFinal").value
        //alert('inicial ' + fechaInicial + ' final ' + fechaFinal);
        objRangoFechas.fechaInicial = fechaInicial;
        objRangoFechas.fechaFinal = fechaFinal;

        if (idReporte == 7) {
            var lista = document.getElementById("listaMotivoCancelacion"); //select id = listaTipoServicio 
            var motivoCancelacion = lista.options[lista.selectedIndex].value;   // Obtener el valor de la opción seleccionada
        
            objRangoFechas.fechaInicial = fechaInicial;
            objRangoFechas.fechaFinal = fechaFinal;
            objRangoFechas.motivoCancelacion = motivoCancelacion;
        }

    } else if (numModal == 11) {
        var seleccionCalles = [];

        var lista = document.getElementById('destinoCalles');
        for (var i = 0; i < lista.length; i++) {
            var opcionSel = lista.options[i].value //Obtener valor de todas las opciones en la lista destino
            seleccionCalles.push(opcionSel);
        }
        //console.log(seleccionTipoCliente);
        objCalles.calles = seleccionCalles;

    } else if (numModal == 12) {
        //valores del checkbox  
        var fruits = [];

        if ($("#contratado").is(':checked')) {
            var contratado = $('#contratado:checked').val();
            fruits.push(contratado);
        }
        if ($("#fuera").is(':checked')) {
            var fuera = $('#fuera:checked').val();
            fruits.push(fuera);
        }
        if ($("#suspendidos").is(':checked')) {
            var suspendidos = $('#suspendidos:checked').val();
            fruits.push(suspendidos);
        }
        if ($("#instalados").is(':checked')) {
            var instalados = $('#instalados:checked').val();
            fruits.push(instalados);
        }
        if ($("#desconectado").is(':checked')) {
            var desconectado = $('#desconectado:checked').val();
            fruits.push(desconectado);
        }
        if ($("#cancelados").is(':checked')) {
            var cancelados = $('#cancelados:checked').val();
            fruits.push(cancelados);
        }
        if ($("#suspendidosTempo").is(':checked')) {
            var suspendidosTempo = $('#suspendidosTempo:checked').val();
            fruits.push(suspendidosTempo);
        }


        //  alert('conTel ' + conTel + ' sinTel ' + sinTel);

        var lista = document.getElementById("listaMotivoCancelacion12"); //select id = listaTipoServicio 
        var listaMotivoCancelacion12 = lista.options[lista.selectedIndex].value;   // Obtener el valor de la opción seleccionada
        var listaMenor = document.getElementById("listaMenorIgual"); //select id = listaTipoServicio 
        var listaMenorIgual = listaMenor.options[listaMenor.selectedIndex].value;   // Obtener el valor de la opción seleccionada
        var listaMes = document.getElementById("listaMesQueAdeuda"); //select id = listaTipoServicio 
        var listaMesQueAdeuda = listaMes.options[listaMes.selectedIndex].value;   // Obtener el valor de la opción seleccionada
        var valorC = document.getElementById("anioC").value; //valor del textbox  

        //obj.estatusCliente = fruits;
        objEstatusCliente.estatusCliente = [fruits, listaMotivoCancelacion12, listaMenorIgual, listaMesQueAdeuda, valorC];
    }

    console.log(obj)
}


function borrarObj() {

    objPrincipal = {};
    objTipoCliente = {};
    objServicio = {};
    objCiudades = {};
    objColonias = {};
    objTelefono = {};
    objPeriodo = {};
    objEstatusOrden = {};
    objRangoFechas = {};
    objCalles = {};
    // objEstatusCliente = {};
}

//mandar los datos al controlador ReportesVarios
function enviarDatos() {
    //se activa cuando se presiona el botón id='aceptar6' ó 'aceptar7'
    //siempre y cuando pase los filtros 
    alert('se envían los datos');
    console.log('objPrincipal' + objPrincipal + ' objTipoCliente' + objTipoCliente + 'objServicio' + objServicio +
              'objCiudades' + objCiudades + 'objColonias' + objColonias + 'objTelefono' + objTelefono + 'objPeriodo' + objPeriodo,
              'objEstatusOrden' + objEstatusOrden + 'objRangoFechas' + objRangoFechas + 'objCalles' + objCalles);
    $.ajax({
        url: "ReportesVarios/Create/",
        type: "POST",
        data: {
            'objPrincipal': objPrincipal, 'objTipoCliente': objTipoCliente, 'objServicio': objServicio,
            'objCiudades': objCiudades, 'objColonias': objColonias, 'objTelefono': objTelefono, 'objPeriodo': objPeriodo,
            'objEstatusOrden': objEstatusOrden, 'objRangoFechas': objRangoFechas, 'objCalles': objCalles
        },
        success: function (data) {
            //     console.log(data);
        }
    });
}
//alert('se envían los datos');
//$('#aceptar6').click(function () {
//    console.log(obj);
//    $.ajax({
//        url: "ReportesVarios/ReportePorPagarInternet_2/",
//        type: "POST",
//        data: { 'obj': obj },
//        success: function (data) {
//            console.log(data);
//        }
//    });
//});


