CREATE TABLE contras (con_admin VARCHAR(100), con_mast VARCHAR(100));
CREATE TABLE direccion (dirLocal VARCHAR(100), correo VARCHAR(100));
CREATE TABLE audit (fecha VARCHAR(100), hora VARCHAR(100), operacion VARCHAR(100), cambioRealizado VARCHAR(100));
CREATE TABLE provedores (clave VARCHAR(100), provedor VARCHAR(100), correo VARCHAR(100), telefono VARCHAR(100));
***CREATE TABLE prod_prov (ID INTEGER, cProv VARCHAR (100), cProd VARCHAR (100));
CREATE TABLE folios (ID INTEGER, noFolio VARCHAR(100));
CREATE TABLE inventario (clave VARCHAR(100), producto VARCHAR(100), presentacion VARCHAR(100), precio REAL, costo REAL, montounit REAL, cantidad INTEGER, limite_inferior INTEGER, iva REAL);
CREATE TABLE ventas (vendedor VARCHAR(100), folioAsociado VARCHAR(100));
CREATE TABLE vendedores (claveVendedor VARCHAR(100), nombre VARCHAR(100), ventas INTEGER, puesto VARCHAR(100), salario VARCHAR(100));
***CREATE TABLE proveedores (clave VARCHAR(100), proveedor VARCHAR(100), tel INTEGER, correo VARCHAR(100));

INSERT INTO contras (con_admin, con_mast) VALUES ('0', '03112134A09087F0BABE3C456E55A4E6');
INSERT INTO folios (ID, noFolio) VALUES (1, 'A000000');
					
drop TABLE contras;
drop TABLE direccion;
drop TABLE audit;
drop TABLE provedores;
***drop TABLE prod_prov;
drop TABLE folios;
drop TABLE inventario;
drop TABLE ventas;
drop TABLE vendedores;
***drop TABLE proveedores;			