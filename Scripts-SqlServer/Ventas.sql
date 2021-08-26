CREATE DATABASE [Ventas]
ON
PRIMARY
(
  NAME = N'Ventas',
  FILENAME = N'/var/opt/mssql/data\Ventas.ndf',
  SIZE = 8MB,
  MAXSIZE = UNLIMITED,
  FILEGROWTH = 64MB
)
LOG ON
(
  NAME = N'Ventas_log',
  FILENAME = N'/var/opt/mssql/data\Ventas_log.ldf',
  SIZE = 8MB,
  MAXSIZE = UNLIMITED,
  FILEGROWTH = 64MB
)
GO
Use Ventas;

DROP TABLE IF EXISTS Detalle_ticket;
DROP TABLE IF EXISTS Ticket;
DROP TABLE IF EXISTS Cliente;
DROP TABLE IF EXISTS Inventario;
DROP TABLE IF EXISTS Producto;
DROP TABLE IF EXISTS Caja;
DROP TABLE IF EXISTS Sucursal;


CREATE TABLE Cliente(
	id_cliente int CONSTRAINT pk_id_cli PRIMARY key not null IDENTITY(1,1),
	nombre VARCHAR(20) not null,
	segundo_nombre VARCHAR(20),
	apellidoP VARCHAR(20) not null,
	apellidoM VARCHAR(20) not null,
	fecha_nacimiento DATE not null,
	fechayhora_alta SmallDateTime not null
);

CREATE TABLE Producto(
	id_producto int CONSTRAINT pk_id_pro PRIMARY key not null IDENTITY(1,1),
	nombre_producto varchar(30) not null,
	costo_pz REAL not null,
	costo_pz_mayoreo REAL,
	estatus varchar(30) not null,
	CONSTRAINT Ck_est_pro CHECK (estatus in('Activo','Inactvo'))
	
);

CREATE TABLE Sucursal(
	id_sucursal int CONSTRAINT PK_ID_SUC PRIMARY key not null IDENTITY(1,1),
	nombre_sucursal varchar(25) not null,
	estatus varchar(30) not null,
	CONSTRAINT Ck_est_suc CHECK (estatus in('Fuera de servicio','En servicio'))
);

CREATE TABLE Caja(
	id_caja int CONSTRAINT PK_ID_caj PRIMARY key not null IDENTITY(1,1),
	nombre_caja varchar(30) not null,
	id_sucursal int CONSTRAINT fk_caja_sucu FOREIGN KEY REFERENCES Sucursal(id_sucursal) not null,
	estatus varchar(30) not null,
	CONSTRAINT Ck_est_caja CHECK (estatus in('Fuera de servicio','En servicio'))
		
);

CREATE TABLE Inventario(
	ID_INVENTARIO int CONSTRAINT PK_ID_INV PRIMARY key not null IDENTITY(1,1),
	ID_PRODUCTO int CONSTRAINT fk_INV_PRODU FOREIGN  KEY REFERENCES PRODUCTO(id_producto) not null,
	ID_SUCURSAL int CONSTRAINT fk_INV_SUCU FOREIGN  KEY REFERENCES SUCURSAL(id_sucursal) not null,
	PZ_DISPONIBLES int NOT NULL,
);

CREATE TABLE Ticket(
	id_ticket int CONSTRAINT pk_id_tick PRIMARY key not null IDENTITY(1,1),
	id_cliente int CONSTRAINT fk_ticket_clie FOREIGN  KEY REFERENCES Cliente(id_cliente) not null,
	monto_total REAL not NULL,
	fechayhora	SmallDateTime not null,
	id_caja int CONSTRAINT fk_tick_caja FOREIGN KEY REFERENCES Caja(id_caja) not null
);

CREATE TABLE Detalle_ticket(
	id_detalle_ticket int PRIMARY key not null IDENTITY(1,1),
	id_producto int CONSTRAINT fk_det_tick_pro FOREIGN KEY REFERENCES Producto(id_producto) not null,
	cantidad SMALLINT not null,
	id_ticket int CONSTRAINT fk_det_tic_ticket FOREIGN KEY REFERENCES Ticket(id_ticket) not null
	
);







