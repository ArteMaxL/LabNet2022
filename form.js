const form = document.getElementById("form");
const nombre = document.getElementById("nombre");
const apellido = document.getElementById("apellido");
const edad = document.getElementById("edad");
const empresa = document.getElementById("empresa");
const parrafo = document.getElementById("warnings");

form.addEventListener("submit", e =>{
    e.preventDefault()
    let warnings = "";
    let entrar = false;
    parrafo.innerHTML = "";

    if(nombre.value.trim() == null || nombre.value.trim() == "" || nombre.value.trim().length < 2){
        warnings += `El Nombre no es válido<br>`
        entrar = true
    }
    if(apellido.value.trim() == null || apellido.value.trim() == "" || apellido.value.trim().length < 4){
        warnings += `El Apellido no es válido<br>`
        entrar = true
    } 

    if(entrar){
        parrafo.innerHTML = warnings
    }else{
        parrafo.innerHTML = "Formulario Enviado!"
    }
});

const deleteForm = () => {
    nombre.value = "";  
    apellido.value = "";
    edad.value = ""; 
    empresa.value = "";
  };