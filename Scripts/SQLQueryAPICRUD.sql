--CREATE DATABASE api_crud;
--GO
USE api_crud;
GO

CREATE TABLE Tb_HccCatEstatusOrden(
catord_id INT NOT NULL,
catord_nombre VARCHAR(50)NOT NULL,
catord_estatus TINYINT NOT NULL,
CONSTRAINT Pk_Tb_HccCatEstatusOrden_catord_id PRIMARY KEY (catord_id)
);
GO

CREATE TABLE Tb_HccMesas(
mes_id INT NOT NULL,
mes_lugares SMALLINT NOT NULL,
mes_disponible TINYINT NOT NULL,
mes_estatus TINYINT NOT NULL,
CONSTRAINT Pk_Tb_HccMesas_mes_id PRIMARY KEY (mes_id)
);
GO

CREATE TABLE Tb_HccOrdenes(
ord_id int NOT NULL IDENTITY,
mes_id INT NOT NULL,
catord_id INT NOT NULL,
ord_fecha_inicio DATE NOT NULL,
ord_estatus TINYINT NOT NULL,
CONSTRAINT Pk_Tb_HccOrdenes_ord_id PRIMARY KEY (ord_id),
CONSTRAINT Fk_Tb_HccOrdenes_Tb_HccMesas FOREIGN KEY(mes_id) REFERENCES Tb_HccMesas(mes_id) ON DELETE NO ACTION ON UPDATE NO ACTION,
CONSTRAINT Fk_Tb_HccOrdenes_Tb_HccCatEstatusOrden FOREIGN KEY(catord_id) REFERENCES Tb_HccCatEstatusOrden(catord_id) ON DELETE NO ACTION ON UPDATE NO ACTION,
);
GO

CREATE TABLE Tb_HccAlmacen(
alm_id INT NOT NULL IDENTITY,
alm_cantidad INT NOT NULL,
alm_fecha_actualizacion DATE NOT NULL,
alm_estatus TINYINT NOT NULL,
CONSTRAINT Pk_Tb_HccAlmacen_alm_id PRIMARY KEY (alm_id)
);
GO

CREATE TABLE Tb_HccProductos(
pro_id int NOT NULL IDENTITY,
alm_id INT NOT NULL,
pro_nombre varchar(50) NOT NULL,
pro_descripcion varchar(120) NOT NULL,
pro_precio DECIMAL(10,4) NOT NULL,
pro_estatus TINYINT NOT NULL,
CONSTRAINT Pk_Tb_HccProductos_pro_id PRIMARY KEY (pro_id),
CONSTRAINT Fk_Tb_HccProductos_Tb_HccAlmacen FOREIGN KEY(alm_id) REFERENCES Tb_HccAlmacen(alm_id) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO


CREATE TABLE Tb_HccOrdenesDetalle(
orddet_id int NOT NULL IDENTITY,
ord_id int NOT NULL,
pro_id int NOT NULL,
orddet_cantidad DECIMAL(10,4) NOT NULL,
orddet_estatus TINYINT NOT NULL,
CONSTRAINT Pk_Tb_HccOrdenesDetalle_orddet_id PRIMARY KEY (orddet_id),
CONSTRAINT Fk_Tb_HccOrdenesDetalle_Tb_HccOrdenes FOREIGN KEY(ord_id) REFERENCES Tb_HccOrdenes(ord_id) ON DELETE NO ACTION ON UPDATE NO ACTION,
CONSTRAINT Fk_Tb_HccOrdenesDetalle_Tb_HccProductos FOREIGN KEY(pro_id) REFERENCES Tb_HccProductos(pro_id) ON DELETE NO ACTION ON UPDATE NO ACTION
);
GO

--Tb_HccCatEstatusOrden
INSERT INTO Tb_HccCatEstatusOrden (catord_id, catord_nombre, catord_estatus) 
VALUES (1, 'Nueva orden', 1);

INSERT INTO Tb_HccCatEstatusOrden (catord_id, catord_nombre, catord_estatus) 
VALUES (2, 'Orden recibida', 1);

INSERT INTO Tb_HccCatEstatusOrden (catord_id, catord_nombre, catord_estatus) 
VALUES (3, 'Orden en preparación', 1);

INSERT INTO Tb_HccCatEstatusOrden (catord_id, catord_nombre, catord_estatus) 
VALUES (4, 'Orden lista', 1);

INSERT INTO Tb_HccCatEstatusOrden (catord_id, catord_nombre, catord_estatus) 
VALUES (5, 'Orden pagada', 1);

--Tb_HccMesas

INSERT INTO Tb_HccMesas (mes_id, mes_lugares, mes_disponible, mes_estatus)
VALUES (1, 4, 1, 1);

INSERT INTO Tb_HccMesas (mes_id, mes_lugares, mes_disponible, mes_estatus)
VALUES (2, 6, 1, 1);

INSERT INTO Tb_HccMesas (mes_id, mes_lugares, mes_disponible, mes_estatus)
VALUES (3, 2, 0, 1);

INSERT INTO Tb_HccMesas (mes_id, mes_lugares, mes_disponible, mes_estatus)
VALUES (4, 4, 0, 1);

--Tb_HccOrdenes

INSERT INTO Tb_HccOrdenes (mes_id, catord_id, ord_fecha_inicio, ord_estatus)
VALUES (1, 1, '2024-09-01', 1);

INSERT INTO Tb_HccOrdenes (mes_id, catord_id, ord_fecha_inicio, ord_estatus)
VALUES (2, 2, '2024-09-01', 1);

INSERT INTO Tb_HccOrdenes (mes_id, catord_id, ord_fecha_inicio, ord_estatus)
VALUES (3, 3, '2024-09-02', 1);

INSERT INTO Tb_HccOrdenes (mes_id, catord_id, ord_fecha_inicio, ord_estatus)
VALUES (4, 4, '2024-09-02', 1);

--Tb_HccAlmacen

INSERT INTO Tb_HccAlmacen (alm_cantidad, alm_fecha_actualizacion, alm_estatus)
VALUES (100, '2024-09-01', 1);

INSERT INTO Tb_HccAlmacen (alm_cantidad, alm_fecha_actualizacion, alm_estatus)
VALUES (150, '2024-09-01', 1);

INSERT INTO Tb_HccAlmacen (alm_cantidad, alm_fecha_actualizacion, alm_estatus)
VALUES (200, '2024-09-01', 1);

INSERT INTO Tb_HccAlmacen (alm_cantidad, alm_fecha_actualizacion, alm_estatus)
VALUES (50, '2024-09-01', 1);

--Tb_HccProductos

INSERT INTO Tb_HccProductos (alm_id, pro_nombre, pro_descripcion, pro_precio, pro_estatus)
VALUES (1, 'Hamburguesa', 'Hamburguesa de res con queso', 5.99, 1);

INSERT INTO Tb_HccProductos (alm_id, pro_nombre, pro_descripcion, pro_precio, pro_estatus)
VALUES (2, 'Pizza', 'Pizza grande con extra queso', 8.50, 1);

INSERT INTO Tb_HccProductos (alm_id, pro_nombre, pro_descripcion, pro_precio, pro_estatus)
VALUES (3, 'Tacos', 'Tacos de carne asada', 3.75, 1);

INSERT INTO Tb_HccProductos (alm_id, pro_nombre, pro_descripcion, pro_precio, pro_estatus)
VALUES (4, 'Refresco', 'Refresco de cola 500 ml', 1.50, 1);

--Tb_HccOrdenesDetalle

INSERT INTO Tb_HccOrdenesDetalle (ord_id, pro_id, orddet_cantidad, orddet_estatus)
VALUES (1, 1, 2.00, 1);

INSERT INTO Tb_HccOrdenesDetalle (ord_id, pro_id, orddet_cantidad, orddet_estatus)
VALUES (2, 2, 1.00, 1);

INSERT INTO Tb_HccOrdenesDetalle (ord_id, pro_id, orddet_cantidad, orddet_estatus)
VALUES (3, 3, 3.00, 1);

INSERT INTO Tb_HccOrdenesDetalle (ord_id, pro_id, orddet_cantidad, orddet_estatus)
VALUES (4, 4, 1.00, 1);


select * from  Tb_HccOrdenes
select * from Tb_HccOrdenesDetalle