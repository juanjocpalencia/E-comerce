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
            alert(data);
        }
    });
}