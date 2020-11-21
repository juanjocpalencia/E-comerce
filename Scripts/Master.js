function buscar() {
    var palabra = document.getElementById("Busqueda").innerHTML;
    
    location.href ='/Home/Index?buscar=' + palabra;
}
function buscarFamilia(palabra) {


    location.href = '/Home/Index?buscar=' + palabra;
}