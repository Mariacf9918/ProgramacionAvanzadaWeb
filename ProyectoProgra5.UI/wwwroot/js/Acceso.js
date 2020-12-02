$(document).ready(function () {

});

function Iniciar() {
    if (VALIDAR() == true) {

        var usrObj = {
            Cedula: document.getElementById("usuario").value,
            Contrasena: document.getElementById("contrasena").value
        };

        $.ajax({
            url: "/Acceso/IniciarSesion",
            data: JSON.stringify(usrObj),
            typr: "GET",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",

            success: function (result) {

            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}//FIN DE Iniciar

function MENSAJE_WARNING_(MENSAJE) {
    swal({
        title: "¡No se pudo procesar!",
        text: MENSAJE,
        type: "info",
        showCancelButton: false,
        confirmButtonText: "¡ Entendido !",
        confirmButtonColor: '#24a0ed',
        closeOnConfirm: true

    });
}//FIN DE MENSAJE_WARNING

function VALIDAR() {
    var ENTRAR = false;

    var USUARIO = document.getElementById("usuario").value;
    var CONTASENA = document.getElementById("contrasena").value;

    if (USUARIO == "") {
        alert("¡El usuario no puede ser nulo, por favor revise los datos brindados!")
    } else if (CONTASENA == "") {
        alert("¡La contraseña no puede ser nula, por favor revise los datos brindados!")
    } else {
        ENTRAR = true;
    }
    return ENTRAR;
}//FIN DE VALIDAR