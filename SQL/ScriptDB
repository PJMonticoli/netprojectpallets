-- TABLAS NUEVAS
CREATE TABLE TipoMovimientoPallets (
    id INT PRIMARY KEY IDENTITY(1,1),
    descripcion NVARCHAR(50) NOT NULL unique 
);

CREATE TABLE EstadoDevolucionPallets (
    id INT PRIMARY KEY IDENTITY(1,1),
    descripcion NVARCHAR(50) NOT NULL UNIQUE
);

  CREATE TABLE AsignacionPalletsOEntrega(
	id INT PRIMARY KEY IDENTITY(1,1),
	FechaCarga DATETIME,
    NroParteSalida INT NOT NULL,
    NroOEntrega INT NOT NULL,
    CantidadPallets SMALLINT NOT NULL,
    PosicionEnCamion VARCHAR(25) NOT NULL,
	TipoMovimientoId INT
);

CREATE TABLE Pallets (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE NOT NULL, 
    FechaCarga DATETIME, 
    CodFletero SMALLINT,
    CodCliente INT,
    Cantidad INT NOT NULL,
    EstadoDevolucionId INT,
    TipoMovimientoId INT,
    Observacion NVARCHAR(50),
    Retorna BIT DEFAULT 0,
    TipoPallet BIGINT NOT NULL,
	AsignacionPalletId INT
);
-----------------------------------------------------------------------------------------






-- TABLAS VIEJAS
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clientes](
	[CodCliente] [int] NOT NULL,
	[RazonSocial] [varchar](50) NULL,
	[CodZona] [smallint] NULL,
	[CodGrupoCliente] [smallint] NULL,
	[Direccion] [varchar](50) NULL,
	[CodLocalidad] [int] NULL,
	[CodProvincia] [smallint] NULL,
	[CodPostal] [char](10) NULL,
	[Telefono] [char](40) NULL,
	[CodCondIVA] [smallint] NULL,
	[CUIT] [char](20) NULL,
	[CodCondicionIBrutos] [smallint] NULL,
	[NroIBrutos] [char](15) NULL,
	[FechaAlta] [smalldatetime] NULL,
	[CodCalifAnterior] [char](1) NULL,
	[SaldoCtaCte] [decimal](18, 3) NULL,
	[SaldoDocumentada] [decimal](18, 3) NULL,
	[SaldoInicHistorico] [decimal](18, 3) NULL,
	[SaldoChequesCartera] [decimal](18, 3) NULL,
	[SaldoChequesSeguridad] [decimal](18, 3) NULL,
	[CreditoAsignado] [decimal](18, 3) NULL,
	[PorcRestriccionCredito] [decimal](18, 3) NULL,
	[CodEntregaMetrop] [char](10) NULL,
	[CodEstadoCliente] [smallint] NULL,
	[CodCatTipoCliente] [smallint] NULL,
	[CodCatRamoCliente] [smallint] NULL,
	[CodCatFuncionCliente] [smallint] NULL,
	[CodCatPolPrecioCliente] [char](1) NULL,
	[CodCatRepositoresCliente] [smallint] NULL,
	[CodCatPotLiquido] [smallint] NULL,
	[CodCatPotJabon] [smallint] NULL,
	[DiasEntrega] [smallint] NULL,
	[Email] [varchar](60) NULL,
	[EsCliente] [smallint] NULL,
	[PercibirIIBBCba] [smallint] NULL,
	[DescLocalidad] [char](50) NULL,
	[DescProvincia] [char](30) NULL,
	[LetraProvincia] [char](1) NULL,
	[CodDtoVolumen] [char](1) NULL,
	[DtoPromJab] [decimal](8, 2) NULL,
	[DtoPromLiq] [decimal](8, 2) NULL,
	[RemitoAuto] [smallint] NULL,
	[CodTransporteRedespacho] [smallint] NULL,
	[SaldoCtaCte2] [decimal](18, 2) NULL,
	[SaldoInicialSQL] [decimal](18, 3) NULL,
	[DireccionPostal] [varchar](50) NULL,
	[CodLocalidadPostal] [int] NULL,
	[CodProvinciaPostal] [smallint] NULL,
	[TelefonoPostal] [varchar](40) NULL,
	[EmailPostal] [varchar](60) NULL,
	[CPPostal] [varchar](10) NULL,
	[DescLocalidadPostal] [varchar](50) NULL,
	[DescProvinciaPostal] [varchar](30) NULL,
	[CodTipoComercio] [int] NULL,
	[CodPais] [int] NULL,
	[CodTipoSujeto] [int] NULL,
	[SeguimientoEspecial] [smallint] NULL,
	[ContactoImpositivo] [char](50) NULL,
	[ContactoImpTel] [char](30) NULL,
	[ContactoImpMail] [char](60) NULL,
	[RequiereOrdenCompra] [bit] NULL,
	[EnvioAutomaticoPDF] [smallint] NULL,
	[EmailCompElectronico] [varchar](60) NULL,
	[EmailCompElectronico2] [varchar](60) NULL,
	[EmailCompElectronico3] [varchar](60) NULL,
	[CodMonedaOperada] [smallint] NULL,
	[DescMaxExporta] [decimal](18, 3) NULL,
	[DtoLista] [smallint] NULL,
	[CodigoCDA] [int] NULL,
	[RubroCDA] [varchar](50) NULL,
	[Oriental] [smallint] NULL,
	[DeudaMasXDias] [smallint] NULL,
	[Operacion2] [smallint] NULL,
	[DeudaMasXDias2] [smallint] NULL,
	[DecisionComercial] [smallint] NULL,
	[EANPlanexwareCliente] [char](15) NULL,
	[CodigoProveedorSegunCliente] [varchar](25) NULL,
	[Vtof346] [smalldatetime] NULL,
	[EnvioRecibosHabilitado] [bit] NULL,
	[EnvioRecibosEmail] [varchar](60) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[CodCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_SaldoChequesCartera]  DEFAULT ((0)) FOR [SaldoChequesCartera]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_SaldoChequesCustodia]  DEFAULT ((0)) FOR [SaldoChequesSeguridad]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_CodEntregaMetrop]  DEFAULT ('') FOR [CodEntregaMetrop]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_EsCliente]  DEFAULT ((1)) FOR [EsCliente]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_PercibirIIBBCba]  DEFAULT ((0)) FOR [PercibirIIBBCba]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_DescuentoVolJab]  DEFAULT ('') FOR [CodDtoVolumen]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_DtoPromJab]  DEFAULT ((0)) FOR [DtoPromJab]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_DtoPromLiq]  DEFAULT ((0)) FOR [DtoPromLiq]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_RemitoAuto]  DEFAULT ((0)) FOR [RemitoAuto]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_CodTransporteRedespacho]  DEFAULT ((0)) FOR [CodTransporteRedespacho]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_SaldoCtaCte2]  DEFAULT ((0)) FOR [SaldoCtaCte2]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_SaldoInicialSQL]  DEFAULT ((0)) FOR [SaldoInicialSQL]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_SeguimientoEspecial]  DEFAULT ((1)) FOR [SeguimientoEspecial]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_ContactoImpositivo]  DEFAULT ('') FOR [ContactoImpositivo]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_ContactoImpTel]  DEFAULT ('') FOR [ContactoImpTel]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_ContactoImpMail]  DEFAULT ('') FOR [ContactoImpMail]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_RequiereOrdenCompra]  DEFAULT ((0)) FOR [RequiereOrdenCompra]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_EnvioAutomaticoPDF]  DEFAULT ((0)) FOR [EnvioAutomaticoPDF]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_DtoLista]  DEFAULT ((0)) FOR [DtoLista]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_CodigoCDA]  DEFAULT ((0)) FOR [CodigoCDA]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_RubroCDA]  DEFAULT ('') FOR [RubroCDA]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_Oriental]  DEFAULT ((0)) FOR [Oriental]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_DeudaMasXDias]  DEFAULT ((0)) FOR [DeudaMasXDias]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_Operacion2]  DEFAULT ((1)) FOR [Operacion2]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_DeudaMasXDias2]  DEFAULT ((0)) FOR [DeudaMasXDias2]
GO

ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_DecisionComercial]  DEFAULT ((0)) FOR [DecisionComercial]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 = NO; 1 = SI' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clientes', @level2type=N'COLUMN',@level2name=N'RequiereOrdenCompra'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1-0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clientes', @level2type=N'COLUMN',@level2name=N'EnvioAutomaticoPDF'
GO

USE [GestionPallets]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Fleteros](
	[CodFletero] [smallint] NOT NULL,
	[RazonSocial] [varchar](50) NULL,
	[Direccion] [varchar](50) NULL,
	[CodPostal] [char](10) NULL,
	[CodLocalidad] [int] NULL,
	[CodProvincia] [smallint] NULL,
	[Telefono] [char](40) NULL,
	[CodCondIVA] [smallint] NULL,
	[CUIT] [char](11) NULL,
	[NroIBrutos] [char](20) NULL,
	[CAI] [char](25) NULL,
	[FechaVtoCai] [smalldatetime] NULL,
	[Email] [varchar](50) NULL,
	[Contacto] [varchar](50) NULL,
	[Activo] [char](1) NULL,
	[NroProveedor] [smallint] NULL,
 CONSTRAINT [PK_Fleteros] PRIMARY KEY CLUSTERED 
(
	[CodFletero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Fleteros] ADD  CONSTRAINT [DF_Fleteros_NroProveedor]  DEFAULT ((0)) FOR [NroProveedor]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'S / N' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Fleteros', @level2type=N'COLUMN',@level2name=N'Activo'
GO





CREATE INDEX idx_pallets_fecha ON pallets (fecha);

CREATE INDEX idx_pallets_transporte_id ON pallets (cod_fletero);

CREATE INDEX idx_pallets_cliente_id ON pallets (cod_cliente);



USE [GestionPallets]
GO

/****** Object:  Table [dbo].[Insumos]    Script Date: 21/08/2024 10:38:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Insumos](
	[codRubro] [smallint] NOT NULL,
	[codSubRubro] [smallint] NOT NULL,
	[codItem] [smallint] NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[UMedida] [smallint] NULL,
	[Stock] [decimal](18, 3) NULL,
	[StockMinimo] [decimal](8, 2) NULL,
	[codCuenta] [char](7) NULL,
	[DV] [char](1) NULL,
	[FormAprob1] [varchar](20) NULL,
	[FormAprob2] [varchar](20) NULL,
	[UltimoPrecio] [decimal](10, 3) NULL,
	[FechaUltimoPrecio] [datetime] NULL,
	[ProveeUltimoPrecio] [smallint] NULL,
	[Ubicacion] [varchar](20) NULL,
	[Estado] [char](1) NULL,
	[codInsumo] [bigint] NOT NULL,
	[AGranel] [char](1) NULL,
	[Cliente] [int] NULL,
	[Tipo] [int] NULL,
	[CodArea] [smallint] NOT NULL,
	[CodSubArea] [smallint] NOT NULL,
	[CodigoAnterior] [int] NULL,
	[Marca] [int] NULL,
	[UltimoPreciodolar] [decimal](8, 3) NULL,
	[FechaUltimoPrecioDolar] [datetime] NULL,
	[ProveeUltimoPrecioDolar] [smallint] NULL,
	[PorcentajeCierre] [decimal](8, 3) NULL,
	[Inflamabilidad] [smallint] NULL,
	[Reactividad] [smallint] NULL,
	[Toxicidad] [smallint] NULL,
	[Blanco] [smallint] NULL,
	[StockComprometido] [decimal](18, 3) NOT NULL,
	[CargaCantProv] [smallint] NOT NULL,
	[ValidaPrimeraVez] [smallint] NOT NULL,
	[CargaStockEnProv] [smallint] NOT NULL,
	[CodRecomendacion1] [smallint] NULL,
	[CodRecomendacion2] [smallint] NULL,
	[CodRecomendacion3] [smallint] NULL,
	[CodRecomendacion4] [smallint] NULL,
	[CodSugerencia1] [smallint] NULL,
	[CodSugerencia2] [smallint] NULL,
	[CodSugerencia3] [smallint] NULL,
	[CodSugerencia4] [smallint] NULL,
	[PathIcono1] [varchar](200) NULL,
	[PathIcono2] [varchar](200) NULL,
	[PathIcono3] [varchar](200) NULL,
	[Observaciones] [varchar](250) NULL,
	[FechaCreacion] [datetime] NULL,
	[Bloqueado] [int] NULL,
	[codCentroCosto] [smallint] NULL,
	[UltimoPrecioDolarEnPeso] [decimal](8, 3) NULL,
	[FechaUltimoPrecioDolarEnPeso] [datetime] NULL,
	[ProveeUltimoPrecioDolarEnPeso] [smallint] NULL,
	[requiereVto] [char](1) NULL,
	[Participa] [int] NULL,
 CONSTRAINT [PK_Insumos] PRIMARY KEY CLUSTERED 
(
	[codInsumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_AGranel]  DEFAULT ('N') FOR [AGranel]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_Genero]  DEFAULT ((0)) FOR [Tipo]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_CodArea]  DEFAULT ((1)) FOR [CodArea]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_CodSubArea]  DEFAULT ((1)) FOR [CodSubArea]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_Inflamabilidad]  DEFAULT ((1)) FOR [Inflamabilidad]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_Reactividad]  DEFAULT ((1)) FOR [Reactividad]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_Toxicidad]  DEFAULT ((1)) FOR [Toxicidad]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_Blanco]  DEFAULT ((1)) FOR [Blanco]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_StockComprometido]  DEFAULT ((0)) FOR [StockComprometido]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_CargaCantProv]  DEFAULT ((0)) FOR [CargaCantProv]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_ValidaPrimeraVez]  DEFAULT ((0)) FOR [ValidaPrimeraVez]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_CargaStockEnProv]  DEFAULT ((0)) FOR [CargaStockEnProv]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_CodRecomendacion1]  DEFAULT ((117)) FOR [CodRecomendacion1]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_CodRecomendacion2]  DEFAULT ((117)) FOR [CodRecomendacion2]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_CodRecomendacion3]  DEFAULT ((117)) FOR [CodRecomendacion3]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_CodRecomendacion4]  DEFAULT ((117)) FOR [CodRecomendacion4]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_CodSugerencia1]  DEFAULT ((75)) FOR [CodSugerencia1]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_CodSugerencia2]  DEFAULT ((75)) FOR [CodSugerencia2]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_CodSugerencia3]  DEFAULT ((75)) FOR [CodSugerencia3]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_CodSugerencia4]  DEFAULT ((75)) FOR [CodSugerencia4]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_Bloqueado]  DEFAULT ((0)) FOR [Bloqueado]
GO

ALTER TABLE [dbo].[Insumos] ADD  CONSTRAINT [DF_Insumos_Participa]  DEFAULT ((0)) FOR [Participa]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 - NO Participa , 1 Participa' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Insumos', @level2type=N'COLUMN',@level2name=N'Participa'
GO






USE [Almacen]
GO

/****** Object:  Table [dbo].[ParteSalida]    Script Date: 27/08/2024 11:34:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ParteSalida](
	[nroParteSalida] [int] NOT NULL,
	[Fecha] [smalldatetime] NULL,
	[Operador] [smallint] NULL,
	[Transporte] [varchar](50) NULL,
	[Chofer] [varchar](50) NULL,
	[Destino] [varchar](50) NULL,
	[Dominio1] [char](10) NULL,
	[Dominio2] [char](10) NULL,
	[Bultos] [decimal](18, 2) NULL,
	[Kilos] [decimal](18, 2) NULL,
	[Pallets] [smallint] NULL,
	[CodEstadoParte] [smallint] NULL,
	[CamionPropio] [char](1) NULL,
	[KilosReales] [decimal](18, 3) NULL,
	[KmSalida] [int] NULL,
	[KmRegreso] [int] NULL,
	[Legajo] [smallint] NULL,
	[CodVehiculoPropio] [smallint] NULL,
	[Guardia] [smallint] NULL,
	[KilosIngreso] [decimal](18, 3) NULL,
	[FechaGuardia] [smalldatetime] NULL,
	[KilosEgreso] [decimal](18, 3) NULL,
	[ValorSeguro] [decimal](18, 3) NULL,
	[TotalPesoBrutoEstimado] [decimal](18, 3) NULL,
	[CantProdPesoDiferentes] [int] NULL,
	[CodOperadorEgreso] [smallint] NULL,
	[CodFletero] [int] NULL,
 CONSTRAINT [PK_ParteSalida] PRIMARY KEY CLUSTERED 
(
	[nroParteSalida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ParteSalida] ADD  CONSTRAINT [DF_ParteSalida_KilosReales]  DEFAULT (0) FOR [KilosReales]
GO

ALTER TABLE [dbo].[ParteSalida] ADD  CONSTRAINT [DF_ParteSalida_KmSalida]  DEFAULT (0) FOR [KmSalida]
GO

ALTER TABLE [dbo].[ParteSalida] ADD  CONSTRAINT [DF_ParteSalida_KmRegreso]  DEFAULT (0) FOR [KmRegreso]
GO

ALTER TABLE [dbo].[ParteSalida] ADD  CONSTRAINT [DF_ParteSalida_Legajo]  DEFAULT (0) FOR [Legajo]
GO

ALTER TABLE [dbo].[ParteSalida] ADD  CONSTRAINT [DF_ParteSalida_CodVehiculoPropio]  DEFAULT (0) FOR [CodVehiculoPropio]
GO

ALTER TABLE [dbo].[ParteSalida] ADD  CONSTRAINT [DF_ParteSalida_Guardia]  DEFAULT (0) FOR [Guardia]
GO

ALTER TABLE [dbo].[ParteSalida] ADD  CONSTRAINT [DF_ParteSalida_KilosGuardia]  DEFAULT (0) FOR [KilosIngreso]
GO

ALTER TABLE [dbo].[ParteSalida] ADD  CONSTRAINT [DF_ParteSalida_KilosEgreso]  DEFAULT (0) FOR [KilosEgreso]
GO

ALTER TABLE [dbo].[ParteSalida] ADD  CONSTRAINT [DF_ParteSalida_ValorSeguro]  DEFAULT (0) FOR [ValorSeguro]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParteSalida', @level2type=N'COLUMN',@level2name=N'KilosReales'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParteSalida', @level2type=N'COLUMN',@level2name=N'Legajo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ParteSalida', @level2type=N'COLUMN',@level2name=N'CodVehiculoPropio'
GO


USE [Almacen]
GO

/****** Object:  Table [dbo].[oenOEntrega]    Script Date: 28/08/2024 10:14:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[oenOEntrega](
	[nroOEntrega] [int] NOT NULL,
	[Fecha] [datetime] NULL,
	[Operador] [smallint] NULL,
	[Transporte] [varchar](50) NULL,
	[Chofer] [varchar](50) NULL,
	[Destino] [varchar](50) NULL,
	[Dominio1] [char](6) NULL,
	[Dominio2] [char](6) NULL,
	[Bultos] [float] NULL,
	[Kilos] [float] NULL,
	[Pallets] [smallint] NULL,
	[Confirmado] [smallint] NULL,
	[FechaFin] [smalldatetime] NULL,
	[OperadorFin] [smallint] NULL,
	[codEstado] [smallint] NULL,
	[codMotivoAnulado] [smallint] NULL,
	[codTurno] [varchar](6) NULL,
	[codTipoVehiculo] [smallint] NULL,
	[CargaDirecta] [char](2) NULL,
	[codMovAlmacen] [int] NULL,
	[ListoConteo] [smallint] NULL,
	[ParteSalida] [int] NULL,
 CONSTRAINT [PK_oenOEntrega] PRIMARY KEY CLUSTERED 
(
	[nroOEntrega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[oenOEntrega] ADD  CONSTRAINT [DF_oenOEntrega_ListoConteo]  DEFAULT (0) FOR [ListoConteo]
GO

ALTER TABLE [dbo].[oenOEntrega] ADD  CONSTRAINT [DF_oenOEntrega_ParteSalida]  DEFAULT (0) FOR [ParteSalida]
GO


USE [Almacen]
GO

/****** Object:  Table [dbo].[oenOCarga]    Script Date: 29/08/2024 10:35:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[oenOCarga](
	[NroOEntrega] [int] NOT NULL,
	[OCarga] [int] NOT NULL,
	[Origen] [smallint] NULL,
 CONSTRAINT [PK_oenOCarga] PRIMARY KEY CLUSTERED 
(
	[NroOEntrega] ASC,
	[OCarga] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO





USE [Ventas]
GO

/****** Object:  Table [dbo].[DetalleOCarga]    Script Date: 29/08/2024 10:37:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DetalleOCarga](
	[NroOCarga] [int] NOT NULL,
	[NroPedido] [int] NOT NULL,
	[LetraTipoPedido] [char](2) NULL,
 CONSTRAINT [PK_DetalleOCarga] PRIMARY KEY CLUSTERED 
(
	[NroOCarga] ASC,
	[NroPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




USE [Ventas]
GO

/****** Object:  Table [dbo].[Pedidos]    Script Date: 29/08/2024 10:37:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pedidos](
	[NroPedido] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[CodAutor] [smallint] NULL,
	[NroCliente] [int] NULL,
	[NroZona] [smallint] NULL,
	[NroSucursal] [int] NULL,
	[NroFactura] [int] NULL,
	[NroOrdenCarga] [int] NULL,
	[NroOrdenEntrega] [int] NULL,
	[TipoPedido] [smallint] NULL,
	[TipoBonificacion] [smallint] NULL,
	[TipoPago] [smallint] NULL,
	[Oferta] [smallint] NULL,
	[DiasPago] [smallint] NULL,
	[CodTipoDtoPedido] [smallint] NULL,
	[OrdenCompraCte] [varchar](25) NULL,
	[Obs] [varchar](50) NULL,
	[FechaToma] [smalldatetime] NULL,
	[FechaCarga] [datetime] NULL,
	[FechaEstimada] [smalldatetime] NULL,
	[FechaSolicitada] [smalldatetime] NULL,
	[FechaEfectiva] [smalldatetime] NULL,
	[TotalCajas] [int] NULL,
	[TotalKilos] [decimal](18, 3) NULL,
	[ImporteNeto] [decimal](18, 3) NULL,
	[ImporteBruto] [decimal](18, 3) NULL,
	[FormaPago] [varchar](50) NULL,
	[AutoPrecio] [char](1) NULL,
	[AutoCredito] [char](1) NULL,
	[AutoBonif] [char](1) NULL,
	[Autorizado] [char](1) NULL,
	[codEstadoPedido] [smallint] NULL,
	[codMoneda] [smallint] NULL,
	[BultosDeclarados] [int] NOT NULL,
	[CodDespachante] [smallint] NULL,
	[TextoEntrega] [varchar](50) NULL,
	[DeInternet] [smallint] NULL,
	[ImportePercepcion] [decimal](18, 3) NOT NULL,
	[FechaFinPendiente] [smalldatetime] NULL,
	[ObsInterna] [varchar](80) NULL,
	[TipoEntrega] [smallint] NULL,
	[PedidoOriginal] [int] NULL,
	[Palletizado] [char](1) NULL,
	[PercepcionCba] [decimal](18, 3) NULL,
	[Version] [smallint] NULL,
	[CodCatPolPre] [char](10) NULL,
	[CodMotivoCredito] [smallint] NULL,
	[RequiereOCompra] [smallint] NULL,
	[CodTransporteRedespacho] [smallint] NULL,
	[NroPrefijo] [smallint] NULL,
	[Letra] [char](2) NULL,
	[TipoComp] [char](2) NULL,
	[NetoAproxAcuerdos] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[NroPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Pedidos] ADD  CONSTRAINT [DF_Pedidos_CodAutor]  DEFAULT (0) FOR [CodAutor]
GO

ALTER TABLE [dbo].[Pedidos] ADD  CONSTRAINT [DF_Pedidos_FechaCarga]  DEFAULT (getdate()) FOR [FechaCarga]
GO

ALTER TABLE [dbo].[Pedidos] ADD  CONSTRAINT [DF_Pedidos_BultosDeclarados]  DEFAULT (0) FOR [BultosDeclarados]
GO

ALTER TABLE [dbo].[Pedidos] ADD  CONSTRAINT [DF_Pedidos_DeInternet]  DEFAULT (0) FOR [DeInternet]
GO

ALTER TABLE [dbo].[Pedidos] ADD  CONSTRAINT [DF_Pedidos_ImportePercepcion]  DEFAULT (0) FOR [ImportePercepcion]
GO

ALTER TABLE [dbo].[Pedidos] ADD  CONSTRAINT [DF_Pedidos_TipoEntrega]  DEFAULT (0) FOR [TipoEntrega]
GO

ALTER TABLE [dbo].[Pedidos] ADD  CONSTRAINT [DF_Pedidos_PedidoOriginal]  DEFAULT (0) FOR [PedidoOriginal]
GO

ALTER TABLE [dbo].[Pedidos] ADD  CONSTRAINT [DF_Pedidos_Palletizado]  DEFAULT ('N') FOR [Palletizado]
GO

ALTER TABLE [dbo].[Pedidos] ADD  CONSTRAINT [DF_Pedidos_PercepcionCba]  DEFAULT (0) FOR [PercepcionCba]
GO

ALTER TABLE [dbo].[Pedidos] ADD  CONSTRAINT [DF_Pedidos_Version]  DEFAULT (1) FOR [Version]
GO

ALTER TABLE [dbo].[Pedidos] ADD  CONSTRAINT [DF_Pedidos_CodCatPolPre]  DEFAULT ('') FOR [CodCatPolPre]
GO

ALTER TABLE [dbo].[Pedidos] ADD  CONSTRAINT [DF_Pedidos_CodMotivoCredito]  DEFAULT ((-1)) FOR [CodMotivoCredito]
GO

ALTER TABLE [dbo].[Pedidos] ADD  CONSTRAINT [DF_Pedidos_RequiereOCompra]  DEFAULT (0) FOR [RequiereOCompra]
GO

ALTER TABLE [dbo].[Pedidos] ADD  CONSTRAINT [DF_Pedidos_CodTransporteRedespacho]  DEFAULT ((-1)) FOR [CodTransporteRedespacho]
GO

ALTER TABLE [dbo].[Pedidos] ADD  CONSTRAINT [DF_Pedidos_NetoAproxAcuerdos]  DEFAULT (0) FOR [NetoAproxAcuerdos]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Es la fecha estimada de carga' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pedidos', @level2type=N'COLUMN',@level2name=N'FechaEstimada'
GO