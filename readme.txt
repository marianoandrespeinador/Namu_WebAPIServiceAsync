---------------------------------------------------
---------------------------------------------------
----- Prueba ténica de Costarrican Vacations ------
---------------------------------------------------
----- Desarrollador: Mariano Peinador P. ----------
----- Fecha de realización: 01/Oct/2016 ----------
---------------------------------------------------
---------------------------------------------------


***************************************************
***************************************************
***** NOTAS DE ARQUITECTURA: **********************
***************************************************
***************************************************

----------------------------
-- Proyectos y librerías: --
----------------------------

NamuService: Portal del servicio REST por JSON

Namu.DAL:
Capa de acceso a Datos con Entity Framework y diagramas de modelo de entidades de BD.

Namu.DAL.DBCalls.Contract ('Namu.DAL'): interfaces para las llamadas a la BD (CRUD)

Namu.DAL.DBCalls ('Namu.DAL'): implementaciones asíncronas de la interfaz de "Namu.DAL.DBCalls.Contract" para llamadas a la BD con entity framework.

Namu.DAL.DBCalls.ProviderBaseDO.cs ('Namu.DAL'): clase base abstracta para los proveedores.

* OJO los paquetes de NuGet (Solo se instala 'MySql.Data.Entities' y sus dependencias):
  
  <package id="EntityFramework" version="6.1.3" targetFramework="net45" />
  <package id="MySql.Data" version="6.9.9" targetFramework="net45" />
  <package id="MySql.Data.Entities" version="6.8.3.0" targetFramework="net45" />

Namu.BLL:
Capa de negocio, donde estarían todas las llamadas al DAL y los algoritmos de negocio.

Namu.Entity.DB ('Namu.Entity'): 
Entidades de negocio generadas por Entity Framework, se mantienen intactas para facilitar futuros cambios (sobreescribir, borrar, etc.) -Escalabilidad-

Namu.Entity:
- Entidades de negocio, para ser utilizadas en todas las librerias.
- Además se encuentras las entidades POCO (Plain old CLR objects) para comunicación con consumidores del servicio (serializables) y para desacoplar las entidades de Entity Framework.
- Utilidades de aplicación, como el algoritmo de encriptamiento.
- Logger es una pequeña utilidad para Loggear todo lo que uno quiera de manera asíncrona con System.Diagnostics (actualmente loggea a 'TextWriterOutput.log' en la base del proyecto).

***********************************************
**************** LIMITACIONES: ****************
***********************************************

Por limitaciones de tiempo, quedo debiendo algunas características que normalmente agregaría/cambiaría:
- Agregar startDate y endDate(NULL) a las tablas pertinentes para no borrar todos los datos sino setear una fecha final.
- Utilizar un usuario con acceso limitado a la base de datos para las llamadas a la BD MySql.
- Encriptar la conexión del web.config por seguridad.
- Crear Tests Units para cada librería de clases para automatizar el testing.
- Ya se tiene el token vivo en la BD, falta enviarlo en el Header de todos los requests de informacion por seguridad. Que haria si el token no esta vivo, retorna "Acceso Prohibido".
- Documentar el REST Web Service.

***********************************************
**************** GRACIAS **********************
***********************************************
