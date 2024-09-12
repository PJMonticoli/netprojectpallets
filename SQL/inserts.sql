INSERT INTO TipoMovimientoPallets (descripcion) VALUES ('Ingreso por Ajuste');
INSERT INTO TipoMovimientoPallets (descripcion) VALUES ('Egreso por Ajuste');
INSERT INTO TipoMovimientoPallets (descripcion) VALUES ('Egreso por Parte Salida');
INSERT INTO TipoMovimientoPallets (descripcion) VALUES ('Ingreso por Devolucion de Cliente');


-- Inserts para la tabla EstadoDevolucionPallet
INSERT INTO EstadoDevolucionPallets (descripcion)
VALUES ('Buen Estado'),('Mal Estado'),('Vale');


-- Inserts mov Pallets con EstadoDevolucion "Buen Estado"
INSERT INTO Pallets (Fecha, FechaCarga, CodFletero, CodCliente, Cantidad, EstadoDevolucionId, TipoPallet, TipoMovimientoId, Observacion, Retorna)
VALUES 
('2024-01-05T10:00:00', SYSDATETIME(), 0, 0, 500, 1, 1, 1, 'Ajusto stock pallets', 0),
('2024-03-15T14:30:00', SYSDATETIME(), 2, 102, 300, 1, 1, 3, 'Entrega Regular', 1),
('2024-06-22T08:45:00', SYSDATETIME(), 0, 0, 400, 1, 2, 1, 'Corrección de Inventario', 0),
('2024-08-10T12:00:00', SYSDATETIME(), 4, 104, 200, 1, 1, 4, 'Devolucion cliente x', 1),
('2024-08-10T12:00:00', SYSDATETIME(), 4, 103, 200, 1, 1, 4, 'Devolucion cliente vale', 1),
('2024-08-10T12:00:00', SYSDATETIME(), 4, 104, 200, 1, 1, 4, 'Devolucion cliente x', 1),
('2024-08-10T12:00:00', SYSDATETIME(), 4, 104, 150, 1, 1, 3, 'Entrega Regular', 1);

-- Inserts mov Pallets con EstadoDevolucion "Mal Estado"
INSERT INTO Pallets (Fecha, FechaCarga, CodFletero, CodCliente, Cantidad, EstadoDevolucionId, TipoPallet, TipoMovimientoId, Observacion, Retorna)
VALUES 
('2024-02-20T11:00:00', SYSDATETIME(), 0, 0, 50, 2, 2, 1, 'Daño en Transporte', 1),
('2024-04-18T15:15:00', SYSDATETIME(), 0, 0, 75, 2, 1, 1, 'Problemas en Almacenaje', 1),
('2024-07-05T09:30:00', SYSDATETIME(), 0, 0, 100, 2, 2, 2, 'Contaminación', 1),
('2024-08-15T13:00:00', SYSDATETIME(), 0, 0, 25, 2, 2, 1, 'Falta de Inspección', 1),
('2024-08-10T12:00:00', SYSDATETIME(), 4, 108, 200, 2, 2, 4, 'Devolucion cliente vale', 1),
('2024-08-15T13:00:00', SYSDATETIME(), 3, 120, 120, 2, 2, 3, 'Egreso sin devolucion', 0),
('2024-08-15T13:00:00', SYSDATETIME(), 0, 0, 75, 2, 2, 1, 'Falta de Inspección', 1);

-- Inserts mov Pallets con EstadoDevolucion "Vale"
INSERT INTO Pallets (Fecha, FechaCarga, CodFletero, CodCliente, Cantidad, EstadoDevolucionId, TipoPallet, TipoMovimientoId, Observacion, Retorna)
VALUES 
('2024-02-20T11:00:00', SYSDATETIME(), 0, 0, 50, 3, 2, 1, 'Devolución con vale', 1),
('2024-04-18T15:15:00', SYSDATETIME(), 0, 0, 75, 3, 1, 1, 'Devolución con vale', 1),
('2024-07-05T09:30:00', SYSDATETIME(), 0, 0, 100, 3, 2, 2, 'Devolución con vale', 1),
('2024-08-15T13:00:00', SYSDATETIME(), 0, 0, 25, 3, 2, 1, 'Devolución con vale', 1),
('2024-08-10T12:00:00', SYSDATETIME(), 4, 108, 200, 3, 2, 4, 'Devolución con vale', 1),
('2024-08-10T12:00:00', SYSDATETIME(), 3, 107, 150, 3, 2, 4, 'Devolución con vale', 1),
('2024-08-10T12:00:00', SYSDATETIME(), 2, 105, 120, 3, 2, 4, 'Devolución con vale', 1),
('2024-08-10T12:00:00', SYSDATETIME(), 1, 105, 100, 3, 2, 4, 'Devolución con vale', 1),
('2024-08-15T13:00:00', SYSDATETIME(), 3, 120, 120, 3, 2, 3, 'Devolución con vale', 0),
('2024-08-15T13:00:00', SYSDATETIME(), 0, 0, 75, 3, 2, 1, 'Devolución con vale', 1);



--insert Pedidos

-- NroPedido	CodAutor	NroCliente	NroZona	NroSucursal	NroFactura	NroOrdenCarga	NroOrdenEntrega	TipoPedido	TipoBonificacion	TipoPago	Oferta	DiasPago	CodTipoDtoPedido	OrdenCompraCte	Obs	FechaToma	FechaCarga	FechaEstimada	FechaSolicitada	FechaEfectiva	TotalCajas	TotalKilos	ImporteNeto	ImporteBruto	FormaPago	AutoPrecio	AutoCredito	AutoBonif	Autorizado	codEstadoPedido	codMoneda	BultosDeclarados	CodDespachante	TextoEntrega	DeInternet	ImportePercepcion	FechaFinPendiente	ObsInterna	TipoEntrega	PedidoOriginal	Palletizado	PercepcionCba	Version	CodCatPolPre	CodMotivoCredito	RequiereOCompra	CodTransporteRedespacho	NroPrefijo	Letra	TipoComp	NetoAproxAcuerdos
-- 117	100	619	25	-1	145130	44	1001554	5	0	0	0	8	0	0	Entrega Inmediata	2004-09-07 00:00:00	2004-09-07 12:23:00.000	2004-09-13 00:00:00	2004-09-13 00:00:00	NULL	50	225.000	900.000	1089.000	8 días Neto	S	S	S	S	4	0	0	0	CASA 20-BRIO. VURILOCHE 4TO. - S. C. BARILOCHE	1	0.000	2004-09-14 00:00:00	NULL	0	0	N	0.000	1	          	-1	0	-1	NULL	NULL	NULL	0.00

-- INSERT ParteSalida
-- nroParteSalida	Fecha	Operador	Transporte	Chofer	Destino	Dominio1	Dominio2	Bultos	Kilos	Pallets	CodEstadoParte	CamionPropio	KilosReales	KmSalida	KmRegreso	Legajo	CodVehiculoPropio	Guardia	KilosIngreso	FechaGuardia	KilosEgreso	ValorSeguro	TotalPesoBrutoEstimado	CantProdPesoDiferentes	CodOperadorEgreso	CodFletero
-- 39343	2024-08-20 20:37:00	100	34- TRANSPORTE "EL PONY" (CTA 166)	CEJAS RAMON	CORDOBA	ELZ751    	TNF482    	1144.00	13285.00	24	1	S	0.000	0	0	0	0	1	14400.000	2024-08-20 20:52:00	28910.000	11276102.119	14090.370	0	110	34


--INSERT oenOEntrega
-- nroOEntrega	Fecha	Operador	Transporte	Chofer	Destino	Dominio1	Dominio2	Bultos	Kilos	Pallets	Confirmado	FechaFin	OperadorFin	codEstado	codMotivoAnulado	codTurno	codTipoVehiculo	CargaDirecta	codMovAlmacen	ListoConteo	ParteSalida
-- 1132289	2024-08-20 17:01:45.657	100	34- TRANSPORTE "EL PONY" (CTA 166)	CEJAS RAMON	COLONIA CAROYA	ELZ751	TNF482	30	351	24	1	2024-08-20 20:36:00	100	4	NULL	Tarde	1	SI	0	0	39343
-- 1132290	2024-08-20 17:03:07.120	100	34- TRANSPORTE "EL PONY" (CTA 166)	CEJAS RAMON	VILLA ALLENDE	0     	-     	312	3406,73	0	1	2024-08-20 20:36:00	100	4	NULL	Tarde	1	SI	0	0	39343
-- 1132291	2024-08-20 17:05:07.777	100	34- TRANSPORTE "EL PONY" (CTA 166)	CEJAS RAMON	CORDOBA	0     	-     	617	7677	0	1	2024-08-20 20:36:00	100	4	NULL	Tarde	1	SI	0	0	39343
-- 1132292	2024-08-20 17:07:42.080	100	34- TRANSPORTE "EL PONY" (CTA 166)	CEJAS RAMON	CORDOBA	0     	-     	112	1085,64	0	1	2024-08-20 20:36:00	100	4	NULL	Tarde	1	SI	0	0	39343
-- 1132293	2024-08-20 17:09:08.060	100	34- TRANSPORTE "EL PONY" (CTA 166)	CEJAS RAMON	CORDOBA	0     	-     	73	764,64	0	1	2024-08-20 20:37:00	100	4	NULL	Tarde	1	SI	0	0	39343