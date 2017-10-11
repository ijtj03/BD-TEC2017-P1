CREATE TABLE Persona(
  IdCedula INT NOT NULL PRIMARY KEY,
  Nombre VARCHAR(50) NOT NULL,
  Apellido1 VARCHAR(50) NOT NULL,
  Apellido2 VARCHAR(50) NOT NULL,
  Telefono INT,
  Contraseña VARCHAR(100) NOT NULL,
  Provincia VARCHAR(100) NOT NULL,
  Canton VARCHAR(100) NOT NULL,
  Distrito VARCHAR(100) NOT NULL,
  DescripcionDireccion VARCHAR(300),
  FechaNacimiento DATETIME NOT NULL,
  LogicDelete BIT NOT NULL DEFAULT 0
)

CREATE TABLE Rol(
  IdRol INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
  Nombre VARCHAR(50) NOT NULL,
  Descripcion VARCHAR(50) NOT NULL,
  LogicDelete BIT NOT NULL DEFAULT 0
)

CREATE TABLE PersonaxRol(
  IdRol INT NOT NULL,
  IdCedula INT NOT NULL,
  LogicDelete BIT NOT NULL DEFAULT 0
)


CREATE TABLE Sucursal(
  IdSucursal INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  IdEmpresa INT NOT NULL,
  Nombre VARCHAR(50) NOT NULL,
  Administrador INT NOT NULL,
  Provincia VARCHAR(50) NOT NULL,
  Canton VARCHAR(50) NOT NULL,
  Distrito VARCHAR(50) NOT NULL,
  DescripcionDireccion VARCHAR(300) NOT NULL,
  LogicDelete BIT NOT NULL DEFAULT 0
)  

CREATE TABLE Medicamento(
  IdMedicamento INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  Nombre VARCHAR(50) NOT NULL,
  NecesitaReceta BIT NOT NULL,
  LogicDelete BIT NOT NULL DEFAULT 0
)

CREATE TABLE CasaFarmaceutica(
  IdCasaFarmaceutica INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  Nombre VARCHAR(50) NOT NULL,
  LogicDelete BIT NOT NULL DEFAULT 0
)

CREATE TABLE PersonaxSucursal(
  IdCedula INT NOT NULL,
  IdSucursal INT NOT NULL,
	SalarioHora INT NOT NULL,
  LogicDelete BIT NOT NULL DEFAULT 0
)

CREATE TABLE MedicamentoxSucursal(
  IdMedicamento INT NOT NULL,
  IdSucursal INT NOT NULL,
  Cantidad INT NOT NULL,
  PrecioSucursal INT NOT NULL,
  LogicDelete BIT NOT NULL DEFAULT 0
)

CREATE TABLE MedicamentoxCasaFarmaceutica(
  IdMedicamento INT NOT NULL,
  IdCasaFarmaceutica INT NOT NULL,
	PrecioProveedor INT NOT NULL,
  LogicDelete BIT NOT NULL DEFAULT 0
)


CREATE TABLE Enfermedad(
	IdEnfermedad INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  Nombre VARCHAR(100)  NOT NULL,
  LogicDelete BIT NOT NULL DEFAULT 0
)

CREATE TABLE EnfermedadxPersona(
  IdCedula INT NOT NULL,
  IdEnfermedad INT NOT NULL,
  FechaEnfermedad DATE NOT NULL,
  LogicDelete BIT NOT NULL DEFAULT 0
)


CREATE TABLE Pedido(
  IdPedido INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  IdCedula INT NOT NULL,
  IdSucursal INT NOT NULL,
  Estado BIT NOT NULL,
  LogicDelete BIT NOT NULL DEFAULT 0,
  Recogido BIT NOT NULL DEFAULT 0,
  Preparado BIT NOT NULL DEFAULT 0,
  FechaRecojo DATE NOT NULL
)

CREATE TABLE PedidoxMedicamento(
  IdPedido INT NOT NULL,
  IdMedicamento INT NOT NULL,
  Cantidad INT NOT NULL,
  RecetaImg IMAGE ,
  LogicDelete BIT NOT NULL DEFAULT 0
)

CREATE TABLE Empresa(
  IdEmpresa INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
  Nombre VARCHAR(100) NOT NULL,
  LogicDelete BIT NOT NULL DEFAULT 0
)

  
ALTER TABLE PersonaxRol
ADD CONSTRAINT FkPersonaxRolPersona 
FOREIGN KEY (IdCedula) REFERENCES Persona (IdCedula);

ALTER TABLE PersonaxRol
ADD CONSTRAINT FkPersonaxRolRol
FOREIGN KEY (IdRol) REFERENCES Rol (IdRol);

ALTER TABLE EnfermedadxPersona
ADD CONSTRAINT FkEnfermedadxPersonaEnfermedad 
FOREIGN KEY (IdEnfermedad) REFERENCES Enfermedad(IdEnfermedad);

ALTER TABLE EnfermedadxPersona
ADD CONSTRAINT FkEnfermedadxPersonaPersona 
FOREIGN KEY (IdCedula) REFERENCES Persona (IdCedula);

ALTER TABLE MedicamentoxCasaFarmaceutica
ADD CONSTRAINT FkMedicamentoxCasaFarmaceutica 
FOREIGN KEY (IdCasaFarmaceutica) REFERENCES CasaFarmaceutica (IdCasaFarmaceutica);

ALTER TABLE MedicamentoxCasaFarmaceutica
ADD CONSTRAINT FkMedicamentoxCasaMedicamento 
FOREIGN KEY (IdMedicamento) REFERENCES Medicamento (IdMedicamento) ;

ALTER TABLE PedidoxMedicamento
ADD CONSTRAINT FkPedidoxMedicamentoMedicamento 
FOREIGN KEY (IdMedicamento) REFERENCES Medicamento (IdMedicamento);

ALTER TABLE PedidoxMedicamento
ADD CONSTRAINT FkPedidoxMedicamentoPedido 
FOREIGN KEY (IdPedido) REFERENCES Pedido (IdPedido);

ALTER TABLE Pedido
ADD CONSTRAINT FkPedidPersona 
FOREIGN KEY (IdCedula) REFERENCES Persona (IdCedula);

ALTER TABLE Pedido 
ADD CONSTRAINT FkPedidoSucursal 
FOREIGN KEY (IdSucursal) REFERENCES Sucursal (IdSucursal);


ALTER TABLE PersonaxSucursal
ADD CONSTRAINT FkPersonaxSucursalPersona 
FOREIGN KEY (IdCedula) REFERENCES Persona (IdCedula);

ALTER TABLE PersonaxSucursal
ADD CONSTRAINT FkPersonaxSucursalSucursal 
FOREIGN KEY (IdSucursal) REFERENCES Sucursal (IdSucursal);

ALTER TABLE Sucursal
ADD CONSTRAINT FkSucursalEmpresa 
FOREIGN KEY (IdEmpresa) REFERENCES Empresa (IdEmpresa);

ALTER TABLE Sucursal
ADD CONSTRAINT FkSucursalPersona 
FOREIGN KEY (Administrador) REFERENCES Persona (IdCedula);

ALTER TABLE MedicamentoxSucursal
ADD CONSTRAINT FkMedicamentoxSucursalSucursal 
FOREIGN KEY (IdSucursal) REFERENCES Sucursal (IdSucursal);

ALTER TABLE MedicamentoxSucursal
ADD CONSTRAINT FkMedicamentoxSucursalMedicamento 
FOREIGN KEY (IdMedicamento) REFERENCES Medicamento (IdMedicamento);



ALTER TABLE PersonaxSucursal
ADD CONSTRAINT PK_PersonaxSucursal PRIMARY KEY (IdCedula,IdSucursal);

ALTER TABLE MedicamentoxSucursal
ADD CONSTRAINT PK_MedicamentoxSucursal PRIMARY KEY (IdMedicamento,IdSucursal);

ALTER TABLE MedicamentoxCasaFarmaceutica
ADD CONSTRAINT PK_MedicamentoxCasaFarmaceutica PRIMARY KEY (IdMedicamento,IdCasaFarmaceutica);

ALTER TABLE EnfermedadxPersona
ADD CONSTRAINT PK_EnfermedadxPersona PRIMARY KEY (IdEnfermedad,IdCedula,FechaEnfermedad);

ALTER TABLE PedidoxMedicamento
ADD CONSTRAINT PK_PedidoxMedicamento PRIMARY KEY (IdPedido,IdMedicamento);

ALTER TABLE PersonaxRol
ADD CONSTRAINT PK_PersonaxRol PRIMARY KEY (IdCedula,IdRol);