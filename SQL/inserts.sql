INSERT INTO Almacen.dbo.TipoMovimientoPallets (descripcion) VALUES ('Ingreso por Ajuste');
INSERT INTO Almacen.dbo.TipoMovimientoPallets (descripcion) VALUES ('Egreso por Ajuste');
INSERT INTO Almacen.dbo.TipoMovimientoPallets (descripcion) VALUES ('Egreso por Parte Salida');
INSERT INTO Almacen.dbo.TipoMovimientoPallets (descripcion) VALUES ('Ingreso por Devolucion de Cliente');


-- Inserts para la tabla EstadoDevolucionPallet
INSERT INTO Almacen.dbo.EstadoDevolucionPallets (descripcion)
VALUES ('Buen Estado'),('Mal Estado'),('Vale');


-- Inserts mov Pallets con EstadoDevolucion "Mal Estado"
INSERT INTO Almacen.dbo.Pallets (Fecha, FechaCarga, CodFletero, CodCliente, Cantidad, EstadoDevolucionId, TipoPallet, TipoMovimientoId, Observacion, Retorna)
VALUES 
('2025-02-20T11:00:00', SYSDATETIME(), 0, 0, 50, 2, 2, 1, 'Daño en Transporte', 1),
('2025-02-18T15:15:00', SYSDATETIME(), 0, 0, 75, 2, 1, 1, 'Problemas en Almacenaje', 1),
('2025-02-05T09:30:00', SYSDATETIME(), 0, 0, 100, 2, 2, 2, 'Contaminación', 1),
('2025-02-15T13:00:00', SYSDATETIME(), 0, 0, 25, 2, 2, 1, 'Falta de Inspección', 1),
('2025-02-10T12:00:00', SYSDATETIME(), 4, 108, 200, 2, 2, 4, 'Devolucion cliente vale', 1),
('2025-02-15T13:00:00', SYSDATETIME(), 3, 120, 120, 2, 2, 3, 'Egreso sin devolucion', 0),
('2025-02-15T13:00:00', SYSDATETIME(), 0, 0, 75, 2, 2, 1, 'Falta de Inspección', 1);

-- Inserts mov Pallets con EstadoDevolucion "Vale"
INSERT INTO Almacen.dbo.Pallets (Fecha, FechaCarga, CodFletero, CodCliente, Cantidad, EstadoDevolucionId, TipoPallet, TipoMovimientoId, Observacion, Retorna)
VALUES 
('2025-02-20T11:00:00', SYSDATETIME(), 0, 0, 50, 3, 2, 1, 'Devolución con vale', 1),
('2025-02-18T15:15:00', SYSDATETIME(), 0, 0, 75, 3, 1, 1, 'Devolución con vale', 1),
('2025-02-05T09:30:00', SYSDATETIME(), 0, 0, 100, 3, 2, 2, 'Devolución con vale', 1),
('2025-03-15T13:00:00', SYSDATETIME(), 0, 0, 25, 3, 2, 1, 'Devolución con vale', 1),
('2025-03-10T12:00:00', SYSDATETIME(), 4, 108, 200, 3, 2, 4, 'Devolución con vale', 1),
('2025-03-10T12:00:00', SYSDATETIME(), 3, 107, 150, 3, 2, 4, 'Devolución con vale', 1),
('2025-03-10T12:00:00', SYSDATETIME(), 2, 105, 120, 3, 2, 4, 'Devolución con vale', 1),
('2025-03-10T12:00:00', SYSDATETIME(), 1, 105, 100, 3, 2, 4, 'Devolución con vale', 1),
('2025-03-15T13:00:00', SYSDATETIME(), 3, 120, 120, 3, 2, 3, 'Devolución con vale', 0),
('2025-03-15T13:00:00', SYSDATETIME(), 0, 0, 75, 3, 2, 1, 'Devolución con vale', 1);

-- Inserts mov Pallets con EstadoDevolucion "Vale"
INSERT INTO Almacen.dbo.Pallets (Fecha, FechaCarga, CodFletero, CodCliente, Cantidad, EstadoDevolucionId, TipoPallet, TipoMovimientoId, Observacion, Retorna)
VALUES 
('2025-02-20T11:00:00', SYSDATETIME(), 0, 0, 50, 3, 2, 1, 'Devolución con vale', 1),
('2025-02-18T15:15:00', SYSDATETIME(), 0, 0, 75, 3, 1, 1, 'Devolución con vale', 1),
('2025-02-05T09:30:00', SYSDATETIME(), 0, 0, 100, 3, 2, 2, 'Devolución con vale', 1),
('2025-03-15T13:00:00', SYSDATETIME(), 0, 0, 25, 3, 2, 1, 'Devolución con vale', 1),
('2025-03-10T12:00:00', SYSDATETIME(), 4, 108, 200, 3, 2, 4, 'Devolución con vale', 1),
('2025-03-10T12:00:00', SYSDATETIME(), 3, 107, 150, 3, 2, 4, 'Devolución con vale', 1),
('2025-03-10T12:00:00', SYSDATETIME(), 2, 105, 120, 3, 2, 4, 'Devolución con vale', 1),
('2025-03-10T12:00:00', SYSDATETIME(), 1, 105, 100, 3, 2, 4, 'Devolución con vale', 1),
('2025-03-15T13:00:00', SYSDATETIME(), 3, 120, 120, 3, 2, 3, 'Devolución con vale', 0),
('2025-03-15T13:00:00', SYSDATETIME(), 0, 0, 75, 3, 2, 1, 'Devolución con vale', 1);


INSERT INTO CtasCtesSQL.dbo.Clientes (CodCliente, RazonSocial, Direccion, CodProvincia, CUIT, CodEstadoCliente)
VALUES 
    (1001, 'Cliente A', 'Calle 123', 1, '30-12345678-9',1),
    (1002, 'Cliente B', 'Calle 333', 1, '30-345345345-9',1),
    (1003, 'Cliente C', 'Calle 321', 1, '30-312132132-9',1),
    (1004, 'Cliente D', 'Calle 444', 1, '30-12345678-9',1);


INSERT INTO CtasCtesSQL.dbo.Fleteros (CodFletero, RazonSocial, Direccion, CodProvincia, Telefono, CUIT, Activo)
VALUES 
    (34, 'Transporte El Pony', 'Ruta 9 km 45', 1, '351-1234567', '30567890123','S');


INSERT INTO Almacen.dbo.ParteSalida (NroParteSalida, Fecha, Operador, Transporte, Chofer, Destino, Dominio1, Dominio2, Bultos, Kilos, Pallets, CodEstadoParte, CodFletero)
VALUES (39343, '2025-03-19 10:00:00', 100, '34- TRANSPORTE EL PONY', 'LOPEZ JUAN', 'CÓRDOBA', 'XYZ999', 'ABC888', 800, 12000, 30, 1, 34);


INSERT INTO Almacen.dbo.oenOEntrega (nroOEntrega, Fecha, Operador, Transporte, Chofer, Destino, Dominio1, Dominio2, Bultos, Kilos, Pallets, Confirmado, FechaFin, OperadorFin, codEstado, ParteSalida)
VALUES 
    (1132301, '2025-03-19 08:30:00', 100, 'Transporte El Pony', 'LOPEZ JUAN', 'VILLA MARIA', 'DEF456', 'GHI789', 50, 1400, 10, 1, '2025-03-19 14:00:00', 100, 4, 39343),
    (1132302, '2025-03-19 08:45:00', 100, 'Transporte El Pony', 'LOPEZ JUAN', 'CÓRDOBA', 'JKL123', 'MNO456', 40, 1300, 8, 1, '2025-03-19 14:15:00', 100, 4, 39343);


INSERT INTO Almacen.dbo.oenOCarga (NroOEntrega, OCarga, Origen)
VALUES 
    (1132301, 51001, 1),
    (1132302, 51002, 1);


INSERT INTO Ventas.dbo.DetalleOCarga (NroOCarga, NroPedido, LetraTipoPedido)
VALUES 
    (51001, 11, 'A'),
    (51002, 12, 'B');


INSERT INTO Ventas.dbo.Pedidos (CodAutor, NroCliente, NroZona, NroSucursal, NroFactura, NroOrdenCarga, NroOrdenEntrega, TipoPedido, TotalCajas, TotalKilos, ImporteNeto, ImporteBruto, FormaPago, AutoPrecio, AutoCredito, AutoBonif, Autorizado, codEstadoPedido, codMoneda, BultosDeclarados, TextoEntrega)
VALUES 
    (100, 1001, 1, -1, 145140, 51001, 1132301, 5, 55, 225.000, 900.000, 1089.000, '8 días Neto', 'S', 'S', 'S', 'S', 4, 0, 0, 'Entrega en Villa María'),
    (100, 1002, 2, -1, 145141, 51002, 1132302, 5, 65, 260.000, 1000.000, 1250.000, '10 días Neto', 'S', 'S', 'S', 'S', 4, 0, 0, 'Entrega en Córdoba');


INSERT INTO Almacen.dbo.Pallets (Fecha, FechaCarga, CodFletero, CodCliente, Cantidad, EstadoDevolucionId, TipoPallet, TipoMovimientoId, Observacion, Retorna)
VALUES 
('2025-03-10T12:00:00', SYSDATETIME(), 4, 103, 200, 1, 1, 4, 'Devolución cliente vale', 1),
('2025-03-15T13:00:00', SYSDATETIME(), 3, 120, 120, 3, 2, 3, 'Devolución con vale', 0);


USE [Proveedores]
GO

INSERT INTO [dbo].[Insumos] (codRubro, codSubRubro, codItem, Descripcion, Participa, codInsumo) 
VALUES 
(10, 101, 1001, 'Pallets de Madera 100x120', 1, '10204200'),
(10, 101, 1002, 'Pallets Metálicos Reforzados', 1, '102344200'),
(10, 101, 1003, 'Pallets de Cartón Reciclado', 1, '10204300');


INSERT INTO Almacen.dbo.oenOEntrega (nroOEntrega, Fecha, Operador, Transporte, Chofer, Destino, Dominio1, Dominio2, Bultos, Kilos, Pallets, Confirmado, FechaFin, OperadorFin, codEstado, ParteSalida)
VALUES (1132290, '2025-03-19 08:30:00', 100, 'Transporte El Pony', 'LOPEZ JUAN', 'VILLA MARIA', 'DEF456', 'GHI789', 50, 1400, 10, 1, '2025-03-19 14:00:00', 100, 4, 39343);


INSERT INTO Almacen.dbo.oenOCarga (NroOEntrega, OCarga, Origen)
VALUES (1132290, 51001, 1);

INSERT INTO Ventas.dbo.DetalleOCarga (NroOCarga, NroPedido, LetraTipoPedido)
VALUES (51001, 1, 'A');


INSERT INTO Ventas.dbo.Pedidos (CodAutor, NroCliente, NroZona, NroSucursal, NroFactura, NroOrdenCarga, NroOrdenEntrega, TipoPedido, TotalCajas, TotalKilos, ImporteNeto, ImporteBruto, FormaPago, AutoPrecio, AutoCredito, AutoBonif, Autorizado, codEstadoPedido, codMoneda, BultosDeclarados, TextoEntrega)
VALUES (100, 1001, 1, -1, 145130, 51001, 1132290, 5, 55, 225.000, 900.000, 1089.000, '8 días Neto', 'S', 'S', 'S', 'S', 4, 0, 0, 'Entrega en Villa María');