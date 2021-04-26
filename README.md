# SmartContract Reserva de Hoteles

El siguiente contrato permite a una persona poder registrarse dentro del sistema del hotel y posterior realizar una reserva asociada a su nombre.

## Contrato

El contrato utilizado para este fin se identifica con el nombre:

```bash
ReservaHotel.sol
```

## Funciones

```bash
function registrarUsuario(...) public
```
Esta función le permite a una persona ingresar sus datos personales y ser registrado dentro del sistema del hotel. La información personal enviada es la siguiente: 

- Nombre y apellido
- Número de identificación
- Tipo de identificación
- Correo electrónico
- Número celular

```bash
function consultarUsuario(...)
```
Esta función permite consultar la información de los distintos usuarios registrados en el sistema.

```bash
function confirmarReserva(...) public
```
Esta función permite guardar una reserva por medio de su número de identificación y asociarla a una persona previamente registrada, para este caso se debe enviar:

- Número de reserva
- Número de identificación de la persona

```bash
function consultarReserva(...)
```
Esta función permite consultar la información de las distintas reservas en el sistema.

## Despliegue

Para su despliegue se requiere descargar el contrato y dentro de un proyecto creado en la plataforma Remix - Ethereum IDE compilarlo y posterior desplegarlo.

```bash
http://remix.ethereum.org/
```

# Equipo de trabajo
Los integrantes del equipo son:

- Paola Sotelo
- Julio Olarte
- Andres Solis