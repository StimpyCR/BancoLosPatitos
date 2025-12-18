drop database if exists DB_PROYECTO_PA;
go
CREATE DATABASE DB_PROYECTO_PA;
 GO
 USE DB_PROYECTO_PA;
 GO------------------------------------------------------------ TABLA PERSONA-- Almacena los datos de las personas físicas o jurídicas-- supervisadas por el sistema LAFT.---------------------------------------------------------
CREATE TABLE PERSONA (
 IdPersona INT IDENTITY(1,1) PRIMARY KEY,
 Identificacion INT NOT NULL,
    TipoIdentificacion INT NOT NULL CHECK (TipoIdentificacion IN (1, 2)), -- 1=Física, 2=Jurídica
    Nombre VARCHAR(100) NOT NULL,
    PrimerApellido VARCHAR(100) NULL,
    SegundoApellido VARCHAR(100) NULL,
    Telefono VARCHAR(20) NOT NULL,
    CorreoElectronico VARCHAR(200) NOT NULL,
    Direccion VARCHAR(500) NOT NULL,
    EstadoDeRiesgo INT NOT NULL CHECK (EstadoDeRiesgo IN (0,1,2,3,4)), -- 0=Sin análisis, 1-4 
 FechaDeRegistro DATETIME NOT NULL DEFAULT(GETDATE()),
 FechaDeModificacion DATETIME NULL DEFAULT(GETDATE()),
    Estado BIT NOT NULL DEFAULT(1)
 );
GO-- Restricción para evitar duplicidad de identificaciones
 ALTER TABLE PERSONA
 ADD CONSTRAINT UQ_PERSONA_IDENTIFICACION UNIQUE (Identificacion);
 GO------------------------------------------------------------ TABLA ACTIVIDAD_FINANCIERA-- Contiene las actividades que pueden ser supervisadas.---------------------------------------------------------
CREATE TABLE ACTIVIDAD_FINANCIERA (
 IdActividadFinanciera INT IDENTITY(1,1) PRIMARY KEY,
 NombreActividadFinanciera VARCHAR(50) NOT NULL,
 DescripcionActividadFinanciera VARCHAR(150) NOT NULL,
 NivelDeRiesgo INT NOT NULL CHECK (NivelDeRiesgo IN (1,2,3)), -- 1=Bajo, 2=Medio, 3=Alto
 FechaDeRegistro DATETIME NOT NULL DEFAULT(GETDATE()),
 FechaDeModificacion DATETIME NULL,
    Estado BIT NOT NULL DEFAULT(1)
 );
 GO-- Restricción para evitar nombres duplicados
 ALTER TABLE ACTIVIDAD_FINANCIERA
 ADD CONSTRAINT UQ_ACTIVIDADFIN_NOMBRE UNIQUE (NombreActividadFinanciera);
 GO------------------------------------------------------------ TABLA ACTIVIDAD_PERSONA-- Relación entre personas y sus actividades financieras.---------------------------------------------------------
CREATE TABLE ACTIVIDAD_PERSONA (
 IdActividad INT IDENTITY(1,1) PRIMARY KEY,
    IdPersona INT NOT NULL,
 IdActividadFinanciera INT NOT NULL,
 FechaDeRegistro DATETIME NOT NULL DEFAULT(GETDATE()),
FechaDeModificacion DATETIME NULL,
    Estado BIT NOT NULL DEFAULT(1), -- 1=Activo, 0=Eliminado
    CONSTRAINT FK_ACTIVIDAD_PERSONA FOREIGN KEY (IdPersona)
        REFERENCES PERSONA(IdPersona),
    CONSTRAINT FK_ACTIVIDAD_FINANCIERA FOREIGN KEY (IdActividadFinanciera)
        REFERENCES ACTIVIDAD_FINANCIERA(IdActividadFinanciera)
 );
 GO-- Evita registros duplicados de la misma actividad por persona
 ALTER TABLE ACTIVIDAD_PERSONA
 ADD CONSTRAINT UQ_ACTIVIDAD_PERSONA UNIQUE (IdPersona, IdActividadFinanciera);
 GO------------------------------------------------------------ TABLA ARCHIVO_ANALISIS-- Guarda los textos, documentos o noticias relevantes-- para análisis de riesgo.---------------------------------------------------------
CREATE TABLE ARCHIVO_ANALISIS (
 IdArchivo INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(10) NOT NULL,
 TextoDelArchivo VARCHAR(MAX) NOT NULL,
    Fuente VARCHAR(2000) NOT NULL,
 FechaDeRegistro DATETIME NOT NULL DEFAULT(GETDATE())
 );
 GO------------------------------------------------------------ TABLA BITACORA_EVENTOS-- Registra todos los eventos del sistema:-- Registrar, Editar, Eliminar, Error.---------------------------------------------------------
CREATE TABLE BITACORA_EVENTOS (
 IdEvento INT IDENTITY(1,1) PRIMARY KEY,
    TablaDeEvento VARCHAR(20) NOT NULL,
    TipoDeEvento VARCHAR(20) NOT NULL, -- Registrar, Editar, Eliminar, Error
 FechaDeEvento DATETIME NOT NULL DEFAULT(GETDATE()),
 DescripcionDeEvento VARCHAR(MAX) NOT NULL,
 StackTrace VARCHAR(MAX) NULL,
 DatosAnteriores VARCHAR(MAX) NULL,
 DatosPosteriores VARCHAR(MAX) NULL
 );
 GO------------------------------------------------------------ DATOS INICIALES-- Se insertan las actividades mínimas requeridas-- por la Ley Antilavado (según el enunciado).---------------------------------------------------------
INSERT INTO ACTIVIDAD_FINANCIERA 
(NombreActividadFinanciera, DescripcionActividadFinanciera, NivelDeRiesgo)
 VALUES
 ('Profesionales en derecho', 'Servicios legales, notariales o jurídicos', 2),
 ('Profesionales en contaduría', 'Servicios contables y financieros', 2),
 ('Casinos', 'Operaciones de apuestas y juegos de azar', 3),
 ('Compra y venta de bienes y muebles', 'Actividades comerciales de bienes de alto valor', 2),
 ('Comercio de metales y piedras preciosas', 'Negocios de joyería o metales', 3),
 ('Administración de dinero', 'Gestión de capitales o fondos de terceros', 3),
 ('Cuentas bancarias de ahorros', 'Servicios bancarios y financieros', 1);
 GO

insert into PERSONA
(Identificacion, TipoIdentificacion, Nombre, PrimerApellido, SegundoApellido, Telefono, CorreoElectronico, Direccion, EstadoDeRiesgo)
values
(208750123, 1, 'Luis', 'Castro', 'Morales', '8884-3321', 'luis.castro@gmail.com', 'San José, Costa Rica', 1);

insert into PERSONA
(Identificacion, TipoIdentificacion, Nombre, PrimerApellido, SegundoApellido, Telefono, CorreoElectronico, Direccion, EstadoDeRiesgo)
values
(309850777, 2, 'Soluciones Verdes S.A.', null, null, '2223-4587', 'contacto@solucionesverdes.com', 'Heredia, Costa Rica', 2);

insert into PERSONA
(Identificacion, TipoIdentificacion, Nombre, PrimerApellido, SegundoApellido, Telefono, CorreoElectronico, Direccion, EstadoDeRiesgo)
values
(109660512, 1, 'Andrea', 'López', 'Jiménez', '8754-6690', 'andrea.lopez@hotmail.com', 'Cartago, Costa Rica', 0);

insert into PERSONA
(Identificacion, TipoIdentificacion, Nombre, PrimerApellido, SegundoApellido, Telefono, CorreoElectronico, Direccion, EstadoDeRiesgo)
values
(310570999, 2, 'Importadora El Faro Ltda.', null, null, '4002-7788', 'ventas@elfaro.co.cr', 'Puntarenas, Costa Rica', 3);

INSERT INTO ACTIVIDAD_PERSONA (IdPersona, IdActividadFinanciera, FechaDeRegistro, Estado)
VALUES 
(1, 2, GETDATE(), 1),  
(1, 3, GETDATE(), 1),  
(2, 1, GETDATE(), 1),  
(2, 4, GETDATE(), 1),  
(3, 2, GETDATE(), 1),  
(4, 1, GETDATE(), 1),  
(4, 3, GETDATE(), 1);

select * from ACTIVIDAD_PERSONA

create table PALABRACLAVE(
idPalabra int identity primary key,
Palabra varchar(30) not null,
Orden int not null,
FechaDeRegistro datetime not null,
FechaDeModificacion datetime null,
estado bit not null default(1)
)


Go


CREATE TABLE ANALISIS (
    IdAnalisis INT IDENTITY(1,1) PRIMARY KEY,
    IdPersona INT NOT NULL,
    CantidadArchivos INT NOT NULL,
    CantidadPalabrasClave INT NOT NULL,
    NivelDeRiesgo INT NOT NULL CHECK (NivelDeRiesgo IN (1,2,3,4)),
    Comentario VARCHAR(MAX) NOT NULL,
    FechaDeAnalisis DATETIME NOT NULL DEFAULT(GETDATE()),

    CONSTRAINT FK_ANALISIS_PERSONA 
        FOREIGN KEY (IdPersona) REFERENCES PERSONA(IdPersona)
);
GO

INSERT INTO ARCHIVO_ANALISIS (Nombre, TextoDelArchivo, Fuente)
VALUES
('NEWS000001',
'San José — Autoridades financieras confirmaron que la persona física Andrea López Jiménez, identificada con la cédula 109660512, fue mencionada en un informe preliminar relacionado con movimientos en cuentas bancarias de ahorros. El reporte no detalla irregularidades, pero recomienda seguimiento preventivo.',
'https://diariofinanciero.cr/actualidad/seguimiento-cuentas');

INSERT INTO ARCHIVO_ANALISIS (Nombre, TextoDelArchivo, Fuente)
VALUES
('NEWS000002',
'Un informe operativo señala que Luis Castro Morales (208750123) aparece vinculado a actividades económicas relacionadas con casinos. La investigación menciona patrones de apuestas reiteradas durante un periodo corto, sin que hasta el momento se haya confirmado actividad ilícita.',
'https://seguridadpublica.cr/reportes/casinos');

INSERT INTO ARCHIVO_ANALISIS (Nombre, TextoDelArchivo, Fuente)
VALUES
('NEWS000003',
'La empresa Soluciones Verdes S.A. (cédula jurídica 309850777) fue citada en una nota de análisis económico por su participación en operaciones de compra y venta de bienes y muebles. Especialistas indicaron que las transacciones se ajustan al giro comercial declarado.',
'https://economiahoy.cr/empresas/soluciones-verdes');

INSERT INTO ARCHIVO_ANALISIS (Nombre, TextoDelArchivo, Fuente)
VALUES
('NEWS000004',
'Heredia — Importadora El Faro Ltda., identificada con la cédula 310570999, figura en un reporte sectorial sobre comercio de metales y piedras preciosas. El documento recomienda reforzar procesos de debida diligencia debido al alto valor de las operaciones.',
'https://comercio.cr/sectores/metales');

INSERT INTO ARCHIVO_ANALISIS (Nombre, TextoDelArchivo, Fuente)
VALUES
('NEWS000005',
'Un boletín interno de cumplimiento menciona a Rodolfo (cédula jurídica 123587452) en una revisión rutinaria asociada a servicios de administración de dinero. No se reportan hallazgos negativos, pero se sugiere monitoreo periódico.',
'Fuente interna: Boletín Cumplimiento #45');

INSERT INTO ARCHIVO_ANALISIS (Nombre, TextoDelArchivo, Fuente)
VALUES
('NEWS000006',
'Según una nota publicada este lunes, Andrea López Jiménez (109660512) aparece citada en un expediente relacionado con un caso de robo investigado por autoridades locales. El documento no vincula directamente operaciones financieras, pero la identifica como contacto de interés.',
'https://sucesos.cr/noticias/robo-investigacion');

INSERT INTO ARCHIVO_ANALISIS (Nombre, TextoDelArchivo, Fuente)
VALUES
('NEWS000007',
'Un análisis legal reveló que Luis Castro Morales (208750123) solicitó servicios de profesionales en derecho para la constitución de asesorías comerciales. La información forma parte de una revisión de antecedentes sin observaciones de riesgo elevado.',
'https://legal.cr/analisis/asesorias');

INSERT INTO ARCHIVO_ANALISIS (Nombre, TextoDelArchivo, Fuente)
VALUES
('NEWS000008',
'La compañía Soluciones Verdes S.A. fue mencionada nuevamente en un reporte financiero por operaciones canalizadas a través de cuentas bancarias de ahorros. Analistas indican que los montos coinciden con ingresos reportados.',
'https://bancayfinanzas.cr/reportes/soluciones-verdes');

INSERT INTO ARCHIVO_ANALISIS (Nombre, TextoDelArchivo, Fuente)
VALUES
('NEWS000009',
'San José — Una investigación periodística señala que Importadora El Faro Ltda. habría sido mencionada en un expediente donde se analizan posibles vínculos con redes de narcotráfico en la región. Las autoridades aclararon que la empresa no figura como imputada.',
'https://investigacion.cr/reportajes/narcotrafico');

INSERT INTO ARCHIVO_ANALISIS (Nombre, TextoDelArchivo, Fuente)
VALUES
('NEWS000010',
'En un reporte de seguimiento, se menciona que Rodolfo (123587452) realizó operaciones relacionadas con compra y venta de bienes y muebles durante el último trimestre. El informe destaca un aumento significativo en el volumen de transacciones.',
'https://mercado.cr/seguimiento/bienes');

INSERT INTO ARCHIVO_ANALISIS (Nombre, TextoDelArchivo, Fuente)
VALUES
('NEWS000011',
'Autoridades judiciales informaron que Andrea López Jiménez y Luis Castro Morales aparecen citados en un expediente por presunto asalto ocurrido en la capital. La mención se limita a referencias documentales sin imputaciones formales.',
'https://judicial.cr/noticias/asalto');

INSERT INTO ARCHIVO_ANALISIS (Nombre, TextoDelArchivo, Fuente)
VALUES
('NEWS000012',
'Un reporte contable menciona a Soluciones Verdes S.A. e Importadora El Faro Ltda. como parte de un análisis sobre administración de dinero en empresas medianas. El estudio resalta buenas prácticas financieras.',
'Fuente interna: Reporte Contable Sectorial 2025');

INSERT INTO ARCHIVO_ANALISIS (Nombre, TextoDelArchivo, Fuente, FechaDeRegistro)
VALUES (
    'NEWS00006',
    'San José — En un informe complementario, autoridades indicaron que la persona física Andrea López Jiménez, 
    identificada con la cédula 109660512, fue mencionada nuevamente en un seguimiento administrativo relacionado 
    con movimientos financieros recientes. El documento hace referencia a la palabra CLAVE_PENDIENTE, 
    la cual será evaluada posteriormente por los analistas del sistema.',
    'https://diariofinanciero.cr/actualidad/seguimiento-complementario',
    GETDATE()
);

INSERT INTO PalabraClave (Palabra, Orden, FechaDeRegistro, Estado)
VALUES ('CLAVE_PENDIENTE', 5, GETDATE(), 1);

INSERT INTO ARCHIVO_ANALISIS
(
    Nombre,
    TextoDelArchivo,
    Fuente,
    FechaDeRegistro
)
VALUES
(
    'NEWS00007',
    'San José — Un nuevo reporte emitido por el área de control interno señala que la persona física 
    Andrea López Jiménez, identificada con la cédula 109660512, continúa siendo mencionada en procesos 
    de monitoreo financiero. El informe hace referencia a revisiones asociadas con cuentas bancarias de ahorro 
    y menciona nuevamente términos relacionados con Asalto y Robo, los cuales serán evaluados dentro 
    del sistema de análisis de riesgo.',
    'https://finanzas.cr/reportes/monitoreo-financiero-adicional',
    GETDATE()
);

/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/11/2024 13:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/11/2024 13:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/11/2024 13:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/11/2024 13:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/11/2024 13:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO

insert into ASPNETROLES values (NEWID(), 'Admin')
 
insert into ASPNETROLES values (NEWID(), 'Analista')

