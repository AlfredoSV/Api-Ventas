INSERT INTO Cliente VALUES('Alfredo',null,'Sánchez','Verduzco',GETDATE(),'2019-02-23 20:02:21.550');
INSERT INTO Cliente VALUES('ALondra',null,'Sánchez','Verduzco',GETDATE(),'2019-02-23 20:02:21.550');
INSERT INTO Cliente VALUES('Sofia',null,'Sánchez','Verduzco',GETDATE(),'2019-02-23 20:02:21.550');
INSERT INTO Cliente VALUES('Blanca',null,'Sánchez','Verduzco',GETDATE(),'2019-02-23 20:02:21.550');
-----------------------
INSERT INTO Sucursal VALUES('Santa Marta','En servicio');
INSERT INTO Sucursal VALUES('Nativitas','En servicio');

-----------------------

INSERT INTO Caja VALUES('Caja 1',1,'En servicio');
INSERT INTO Caja VALUES('Caja 2',1,'En servicio');
INSERT INTO Caja VALUES('Caja Extra',1,'Fuera de servicio');

INSERT INTO Caja VALUES('Caja 1',2,'En servicio');
INSERT INTO Caja VALUES('Caja 2',2,'En servicio');
INSERT INTO Caja VALUES('Caja Extra',2,'Fuera de servicio');

---------------

INSERT INTO Producto VALUES('Cigarros Malboro',45.5,55.5,'Activo');
INSERT INTO Producto VALUES('Cigarros Camel',55.5,45.5,'Activo');
INSERT INTO Producto VALUES('Botella Bonafont',10,4,'Activo');
INSERT INTO Producto VALUES('Bolsa de arroz 1Kg',20,15,'Activo');
INSERT INTO Producto VALUES('Garrafon de agua',35,30,'Activo');
INSERT INTO Producto VALUES('Sabritas',15,13,'Activo');
INSERT INTO Producto VALUES('CoCa Cola 1 Lt',15,12,'Activo');
INSERT INTO Producto VALUES('Café 1 Kg',25,22,'Activo');
INSERT INTO Producto VALUES('Leche Alputa 1 Lt',27,24,'Activo');

--------------------

INSERT INTO Inventario VALUES(1,1,20);
INSERT INTO Inventario VALUES(2,1,4);
INSERT INTO Inventario VALUES(3,1,35);
INSERT INTO Inventario VALUES(4,1,23);
INSERT INTO Inventario VALUES(5,1,10);
INSERT INTO Inventario VALUES(6,1,3);
INSERT INTO Inventario VALUES(7,1,3);
INSERT INTO Inventario VALUES(8,1,0);

INSERT INTO Inventario VALUES(1,2,1);
INSERT INTO Inventario VALUES(2,2,4);
INSERT INTO Inventario VALUES(3,2,5);
INSERT INTO Inventario VALUES(4,2,2);
INSERT INTO Inventario VALUES(5,2,1);
INSERT INTO Inventario VALUES(6,2,20);
INSERT INTO Inventario VALUES(7,2,30);
INSERT INTO Inventario VALUES(8,2,7);
INSERT INTO Inventario VALUES(9,2,3);

------------------------------------------
Insert into Ticket VALUES(1,70,'2021-08-25 20:02:21.550',1);
Insert into Ticket VALUES(2,55,'2021-08-25 20:02:21.550',4);

----------------------------------------

INSERT INTO Detalle_ticket VALUES(3,3,1);
INSERT INTO Detalle_ticket VALUES(4,2,1);

INSERT INTO Detalle_ticket VALUES(6,1,2);
INSERT INTO Detalle_ticket VALUES(7,1,2);
INSERT INTO Detalle_ticket VALUES(8,1,2);
-----------------------------------------
Select * from Inventario;
SELECT * from Producto;
SELECT * FROM Caja;
Select * FROM Sucursal;
SELECT * FROM Cliente;
Select * from Detalle_ticket;
Select * from Ticket;