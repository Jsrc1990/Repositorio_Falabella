Create Database Base_Datos_Falabella

Use Base_Datos_Falabella

--**************************************************************************************** CONTACTO

--Define los tipos de contacto que puede tener una persona o compañia
Create Table Tipo_Contacto
(
Consecutivo Integer Identity (1,1),
id Varchar(36) Primary Key Not Null Default NewId(),
Nombre Varchar(100) Not Null Unique,
Descripcion Varchar(1000)
)

Insert Into Tipo_Contacto Values (Default,'Dirección',NULL)
Insert Into Tipo_Contacto Values (Default,'Telefono',NULL)
Insert Into Tipo_Contacto Values (Default,'Celular',NULL)
Insert Into Tipo_Contacto Values (Default,'Email',NULL)

--**************************************************************************************** COMPAÑIA

--Define las compañias aseguradoras con las que trabaja falabella como intermediaria
Create Table Compania
(
Consecutivo Integer Identity (1,1),
id Varchar(36) Primary Key Not Null Default NewId(),
Nombre Varchar(100) Not Null Unique,
Imagen Varchar(256),
Descripcion Varchar(1000)
)

Insert Into Compania Values (Default, 'Colmena Seguros', NULL, NULL)
Insert Into Compania Values (Default, 'BNP Paribas Cardif', NULL, NULL)
Insert Into Compania Values (Default, 'Mapfre', NULL, NULL)
Insert Into Compania Values (Default, 'Colpatria Seguros', NULL, NULL)
Insert Into Compania Values (Default, 'Seguros Bolivar', NULL, NULL)

--****************************************************************************************

--Una compañia puede tener muchos contactos pero no el mismo contacto más de una vez
Create Table Compania_Tipo_Contacto
(
Consecutivo Integer Identity (1,1),
id Varchar(36) Primary Key Not Null Default NewId(),
CompaniaId Varchar(36) References Compania(id) ON UPDATE CASCADE Not Null,
Tipo_ContactoId Varchar(36) References Tipo_Contacto(id) ON UPDATE CASCADE Not Null,
Valor Varchar(100) Not Null,
Unique(CompaniaId, Tipo_ContactoId)
)

--**************************************************************************************** PRODUCTO

--Define la naturaleza del producto
Create Table Tipo_Producto
(
Consecutivo Integer Identity (1,1),
id Varchar(36) Primary Key Not Null Default NewId(),
Nombre Varchar(100) Not Null Unique,
Descripcion Varchar(1000)
)

Insert Into Tipo_Producto Values (Default,'Prima',NULL)
Insert Into Tipo_Producto Values (Default,'Cobertura',NULL)
Insert Into Tipo_Producto Values (Default,'Asistencia',NULL)

--****************************************************************************************

Create Table Producto
(
Consecutivo Integer Identity (1,1),
id Varchar(36) Primary Key Not Null Default NewId(),
Nombre Varchar(100) Not Null Unique,
Tipo_ProductoId Varchar(36) References Tipo_Producto(id) ON UPDATE CASCADE Not Null,
CompaniaId Varchar(36) References Compania(id) ON UPDATE CASCADE Not Null, --Cada compañía ofrece productos con primas, coberturas y asistencias DISTINTAS
Imagen Varchar(256),
Precio Money Not Null,
Descripcion Varchar(1000)
)

--****************************************************************************************

--Define las actividades que se realizan con el producto escogido
Create Table Actividad
(
Consecutivo Integer Identity (1,1),
id Varchar(36) Primary Key Not Null Default NewId(),
Nombre Varchar(100) Not Null Unique,
Descripcion Varchar(1000)
)

--****************************************************************************************

--Una producto puede tener muchas actividades pero no la misma actividad más de una vez
Create Table Producto_Actividad
(
Consecutivo Integer Identity (1,1),
id Varchar(36) Primary Key Not Null Default NewId(),
ProductoId Varchar(36) References Producto(id) ON UPDATE CASCADE Not Null,
ActividadId Varchar(36) References Actividad(id) ON UPDATE CASCADE Not Null,
Descripcion Varchar(1000)
Unique(ProductoId, ActividadId)
)

--****************************************************************************************

--Define los tipos de documento
Create Table Tipo_Documento
(
Consecutivo Integer Identity (1,1),
id Varchar(36) Primary Key Not Null Default NewId(),
Nombre Varchar(100) Not Null Unique,
Descripcion Varchar(1000)
)

Insert Into Tipo_Documento Values ('11D0218A-5F26-4B2E-B007-0CD2743CECA1', 'CC','Cedula de Ciudadanía')
Insert Into Tipo_Documento Values (Default, 'CE','Cedula de Extranjería')
Insert Into Tipo_Documento Values (Default, 'NIT','Número de Identificación Tributaria')

--****************************************************************************************

--Define el asesor de ventas que se encarga de impulsar los productos de las compañias aseguradoras
Create Table Asesor
(
Consecutivo Integer Identity (1,1),
Tipo_DocumentoId Varchar(36) References Tipo_Documento(id) ON UPDATE CASCADE Not Null,
id Varchar(15) Primary Key Not Null,
Nombre Varchar(100) Not Null Unique,
Correo Varchar(100) Not Null Unique,
Contrasenia Varchar(10) Not Null,
Imagen Varchar(256),
Descripcion Varchar(1000)
)

Insert Into Asesor Values ('11D0218A-5F26-4B2E-B007-0CD2743CECA1','1082911972','Sebastian Reyes','Jsrc1990@hotmail.com','1234556',NULL,NULL)

--****************************************************************************************

--Define el cliente que compra los productos
Create Table Cliente
(
Consecutivo Integer Identity (1,1),
Tipo_DocumentoId Varchar(36) References Tipo_Documento(id) ON UPDATE CASCADE Not Null,
id Varchar(15) Primary Key Not Null,
Nombre Varchar(100) Not Null Unique,
Imagen Varchar(256),
Descripcion Varchar(1000)
)

--****************************************************************************************

--Define la factura de la venta
Create Table Venta
(
Consecutivo Integer Identity (1,1),
id Varchar(36) Primary Key Not Null Default NewId(),
AsesorId Varchar(15) References Asesor(id) ON UPDATE CASCADE Not Null,
ClienteId Varchar(15) Not Null, --References Cliente(id) ON UPDATE CASCADE 
Fecha Date Not Null,
Descripcion Varchar(1000)
)

Alter Table Venta Add Constraint FK_Venta_ClienteId Foreign Key (ClienteId) References Cliente(id);

--****************************************************************************************

--Una factura de venta puede tener muchos productos pero no el mismo producto más de una vez
Create Table Venta_Producto
(
Consecutivo Integer Identity (1,1),
id Varchar(36) Primary Key Not Null Default NewId(),
VentaId Varchar(36) References Venta(id) ON UPDATE CASCADE Not Null,
ProductoId Varchar(36) References Producto(id) ON UPDATE CASCADE Not Null,
Descripcion Varchar(1000)
)