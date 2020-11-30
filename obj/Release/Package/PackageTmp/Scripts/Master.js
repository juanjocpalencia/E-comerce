function buscar() {
    var palabra = document.getElementById("Busqueda").innerHTML;
    
    location.href ='/Home/Index?buscar=' + palabra;
}
function buscarFamilia(palabra) {


    location.href = '/Home/Index?buscar=' + palabra;
}

function Login() {

    con = document.getElementById('pwd').value;
    correo = document.getElementById('user').value;
    $.ajax({
        url: '/Home/Login',
        data: { pwd: con ,user:correo},
        method:'POST' ,
        success: function (data) {
            
            document.getElementById('id01').style.display = 'none';
            location.href = "/Home/index";
        },
        error: function (data) {
            alert("Error");
        }

    });
}


function registrar() {
    var correo = document.getElementById("correo").value;
    var pwd = document.getElementById("pwd").value;
    var usuario = document.getElementById("usuario").value;
    var nombre = document.getElementById("Nombre").value;
    var ap_mat = document.getElementById("ap_mat").value;
    var ap_pat = document.getElementById("ap_pat").value;
    var numero = document.getElementById("numero").value;
    alert(correo + pwd + usuario + nombre + ap_mat + ap_pat + numero);
    $.ajax({
        url: '/usuarios/Create',
        data: { correo: correo, pwd: pwd, usuario: usuario, nombre: nombre, ap_mat: ap_mat, ap_pat: ap_pat, numero: numero },
        method: 'POST',
        async: true,
        success: function (data) {
            alert("True");
            location.href="/Home/Index"
        }
    });

}