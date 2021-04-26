pragma solidity ^0.4.0;

contract ReservaHotel {

    //Estructura del objeto Usuario para guardar informacion del mismo
   struct Usuario {
       string nombreYApellidos;
       uint numIdentificacion;
       string tpIdentificacion;
       string email;
       uint telefono;
       bool valido; //flag
   }
   
   //Estructura de la reserva que guarda la informacion de la persona y el num de reserva
    struct Reserva {
       uint numReserva; 
       string nombreYApellidos;
       uint numIdentificacion;
       string tpIdentificacion;
       string email;
       uint telefono;
       bool valido; //flag
   }
   
   //Arreglo de reservas
   Reserva[] arrayReserva;
   mapping(uint => Reserva) mappingReserva;
   
   //Arreglo de usuarios
   Usuario[] arrayUsuario;
   mapping(uint => Usuario) mappingUsuario;
   
   // Funciones del contrato
   
   //función para registrar usuarios
   function registrarUsuario(string _nombreYApellidos, uint _numIdentificacion, string _email, string _tpIdentificacion, uint _telefono) public {
       //Se valida que no exista un usuario ya registrado con la misma cedula
       require(mappingUsuario[_numIdentificacion].valido == false); 
       //Se almacena la informacion en el mappin y en el arreglo de usuarios
       mappingUsuario[_numIdentificacion] = Usuario(_nombreYApellidos, _numIdentificacion, _email, _tpIdentificacion, _telefono, true);
       arrayUsuario.push(mappingUsuario[_numIdentificacion]);
   }
   
   //funcion para consultar si un usuario existe (validacion de proceso de registro)
   function consultarUsuario(uint _numIdentificacion) public constant returns (string, uint, string, string, uint) {
       Usuario storage usuario = mappingUsuario[_numIdentificacion];
        //Se comprueba si el usuario obtenido del mapping existe
       require(usuario.valido);
       return (usuario.nombreYApellidos, usuario.numIdentificacion, usuario.email, usuario.tpIdentificacion, usuario.telefono);
   }

    //funcion para guardar una reserva (confirmacion de reserva con num reserva y usuario)
    function confirmarReserva(uint _numReserva, uint _numIdentificacion) public {
        //Se comprueba que no exista una reserva asociada al numero de habitacion ingresado
       require(mappingReserva[_numReserva].valido == false); 
       Usuario storage usuario = mappingUsuario[_numIdentificacion];
       //Se comprueba si el usuario obtenido del mapping existe
       require(usuario.valido); 
       //Se almacena la informacion de la reserva
       mappingReserva[_numReserva] = Reserva(_numReserva, usuario.nombreYApellidos, usuario.numIdentificacion, usuario.email, usuario.tpIdentificacion, usuario.telefono, true);
       arrayReserva.push(mappingReserva[_numReserva]);
   }
   
   //funcion para consultar si una reserva ya existe (validacion de proceso de registro)
   function consultarReserva(uint _numReserva) public constant returns (uint,string, uint, string, string, uint) {
       Reserva storage reserva = mappingReserva[_numReserva];
        //comprobar que la reserva con el numero de habitacion existe
       require(reserva.valido);
       return (reserva.numReserva, reserva.nombreYApellidos, reserva.numIdentificacion, reserva.email, reserva.tpIdentificacion, reserva.telefono);
   }
}