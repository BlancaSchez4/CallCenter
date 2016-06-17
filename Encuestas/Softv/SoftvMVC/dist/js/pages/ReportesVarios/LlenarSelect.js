

function cargarDatos(numModal) {
    var tipoServicioSeleccionado = cableInternet(); //1 = cable, 2 = internet
    //'<option value="0">Servicio Básico </option>'

    if (numModal == 1 ) //TipoCliente y cable
    {
        $.ajax({
            url: '/TipoCliente/GetTipoClientes/',
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                console.log(data);
                $.each(data, function (i, item) {
                    $('<option value="' + item.Clv_TipoCliente + '">' + item.Descripcion + '</option>').appendTo('#origenClientes');
                });
            },
            error: function () {
                console.log('err')
            }
        });
    }
        // Dependiendo del modal y si es cable o internet, se cargan los datos en el modal de Servicio

    else if (numModal == 2 && tipoServicioSeleccionado == 1) //Servicio y cable       
    {
        alert('tipoServicioSeleccionado ' + tipoServicioSeleccionado);
        //llenar select 
        $.ajax({
            url: '/Servicio/GetServicioCable/',
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                console.log(data);
                $.each(data, function (i, item) {
                    $('<option value="' + item.Clv_Servicio + '">' + item.Descripcion + '</option>').appendTo('#origenServicios');
                });
            },
            error: function () {
                console.log('err')
            }
        });
    }
    else if (numModal == 2 && tipoServicioSeleccionado == 2) //Servicio e internet
    {   // LLENAR CON CONTROLADOR SERVICIO
        alert('tipoServicioSeleccionado ' + tipoServicioSeleccionado);
        //llenar select 
        $.ajax({
            url: '/Servicio/GetServicioBasico/',
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                console.log(data);
                $.each(data, function (i, item) {
                    $('<option value="' + item.Clv_Servicio + '">' + item.Descripcion + '</option>').appendTo('#origenServicios');
                });
            },
            error: function () {
                console.log('err')
            }
        });
    }
    else if (numModal == 3) // Ciudades
    {
        $.ajax({
            url: '/CIUDAD/GetCiudad/',
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                console.log(data);
                $.each(data, function (i, item) {
                    $('<option value="' + item.Clv_Ciudad + '">' + item.Nombre + '</option>').appendTo('#origenCiudades');
                });
            },
            error: function () {
                console.log('err')
            }
        });
    }
    else if (numModal == 4) // Colonias
    {
        $.ajax({
            url: '/COLONIA/GetColonia/',
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                console.log(data);
                $.each(data, function (i, item) {
                    $('<option value="' + item.Clv_Colonia + '">' + item.Nombre + '</option>').appendTo('#origenColonias');
                });
            },
            error: function () {
                console.log('err')
            }
        });

    }
    else if (numModal == 6) // Periodo
    {
        $.ajax({
            url: '/CatalogoPeriodosCorte/GetCatalogoPeriodosCorte/',
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                console.log(data);
                $.each(data, function (a, item1) {
                    $('<option value="' + item1.Clv_Periodo + '">' + item1.Descripcion + '</option>').appendTo('#origenPeriodo');
                });
            },
            error: function () {
                console.log('err')
            }
        });
    }
    else if (numModal == 8)// RangoFechas
    {
        alert(numModal)
        $.ajax({
            url: '/MotivoCancelacion/GetMotivoCancelacion/',
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                console.log(data);
                $.each(data, function (a, item1) {
                    $('<option value="' + item1.Clv_MOTCAN + '">' + item1.MOTCAN + '</option>').appendTo('#listaMotivoCancelacion');
                });
            },
            error: function () {
                console.log('err')
            }
        });
    }
    else if (numModal == 11) //Calles
    {
        //    $.ajax({
        //        url: '/CALLE/GetCALLE/',
        //        type: 'POST',
        //        dataType: 'json',
        //        success: function (data) {
        //            console.log(data);
        //            $.each(data, function (i, item) {
        //                $('<option value="' + item.Clv_Calle + '">' + item.Nombre + '</option>').appendTo('#origenCalles');
        //            });
        //        },
        //        error: function () {
        //            console.log('err')
        //        }
        //    });
    }
    else if (numModal == 12) //EstatusCliente
    {
        alert(numModal)
        $.ajax({
            url: '/MotivoCancelacion/GetMotivoCancelacion/',
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                console.log(data);
                $.each(data, function (a, item1) {
                    $('<option value="' + item1.Clv_MOTCAN + '">' + item1.MOTCAN + '</option>').appendTo('#listaMotivoCancelacion12');
                });
            },
            error: function () {
                console.log('err')
            }
        });
    }
}








