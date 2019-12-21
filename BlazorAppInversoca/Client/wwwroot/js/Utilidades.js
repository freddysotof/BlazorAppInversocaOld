function CustomConfirmDialog(titulo,mensaje,action,ico){
    return new Promise((resolve) => {
        Swal.fire({
          title: titulo,
          text: mensaje,
          type: ico,
          showCancelButton: true,
          confirmButtonColor: '#3085d6',
          cancelButtonColor: '#d33',
          cancelButtonText: 'Cancelar',
          confirmButtonText: action
        }).then((result) => 
        {
            if(result.value){
                resolve(true);
            }else
            {
                resolve(false);
            }
        });
    });
};

function LoginFailed(titulo,mensaje,type,popup){
Swal.fire({
  title: titulo,
  text: mensaje,
  type: type,
  animation: false,
  customClass: {
    popup: popup
  }
})
}

function Mixin(titulo,icono){
const Toast = Swal.mixin({
  toast: true,
  position: 'top-end',
  showConfirmButton: false,
  timer: 3000
})

Toast.fire({
  type: icono,
  title: titulo
})
}