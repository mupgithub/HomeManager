$(function () {
    $('a[data-modal=producto]').on('click', function () {
        $('#productoModalContent').load(this.href, function () {
            $('#productoModal').modal({
                backdrop: 'static',
                keyboard: true
            }, 'show');

        });
        return false;
    });

    //Ventana Modal Proveedor
    $('a[data-modal=proveedor]').on('click', function () {
        $('#proveedorModalContent').load(this.href, function () {
            $('#proveedorModal').modal({
                backdrop: 'static',
                keyboard: true
            }, 'show');

        });
        return false;
    });

    //Ventana Modal Detalle de Facturas
    $('a[data-modal=detalles]').on('click', function () {
        $('#detallesModalContent').load(this.href, function () {
            $('#detallesModal').modal({
                backdrop: 'static',
                keyboard: true
            }, 'show');

        });
        return false;
    });
});

//$('#myModalContent').load(this.href, function () {
//    $('#myModal').modal({
//        backdrop: 'static',
//        keyboard: true
//    }, 'show');
//    //bindForm(this);
//});