-- -------------------------------------------
-- Este script corre en un ambiente MySql: --
-- Author: Ing. Mariano Peinador P.
-- -------------------------------------------

CREATE schema dbNamuTest;

-- esto se utiliza para poder generar el modelo de entity framework para mysql desde .NET:
use dbNamuTest;
	set global optimizer_switch='derived_merge=off';
	set optimizer_switch='derived_merge=off';

-- Tabla para direcciones en general
-- Se usa el city, state, country como texto por simplicidad, 
-- aunque en ambiente de produccion se pueden tener tablas con esta informacion para validación de entrada
CREATE TABLE taddress(
  idtaddress INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  city varchar(500),
  state VARCHAR(500),
  country VARCHAR(100),
  exactAddress longtext,
  userid INT NULL -- no usa foreign key debido a que es para razones de audit y no es necesario el index (puede ser ingresado por base de datos o por admin)
) ENGINE=InnoDB;

-- Tabla proveedores:
CREATE TABLE tprovider(
  idtprovider INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(500) NOT NULL,
  providerTypeCode INT NOT NULL, -- 1 es para hotel, 2 es para tour
  numcode INT NOT NULL,
  phonecode INT NOT NULL,
  userid INT NULL
) ENGINE=InnoDB;

-- Utilizo tabla intermedia para desacoplar direcciones de proveedores
CREATE TABLE tproviderxtaddress(
  fktaddress INT NOT NULL,
  fktprovider INT NOT NULL,
  INDEX ind_tproviderxtaddress_taddress (fktaddress),
  FOREIGN KEY (fktaddress) REFERENCES taddress(idtaddress),
  INDEX ind_tproviderxtaddress_tprovider (fktprovider),
  FOREIGN KEY (fktprovider) REFERENCES tprovider(idtprovider),
  PRIMARY KEY(fktaddress, fktprovider)
) ENGINE=InnoDB;

-- data para proveedores tipo "Hotel"
CREATE TABLE tprovider_hoteltype(
  idtprovider INT NOT NULL PRIMARY KEY,
  checkin_hour INT NOT NULL,
  checkin_minute INT NOT NULL,
  checkout_hour INT NOT NULL,
  checkout_minute INT NOT NULL,
  minimum_age INT NOT NULL,
  userid INT NULL,
  INDEX ind_tprovider_tourtype_tprovider (idtprovider),
  FOREIGN KEY (idtprovider) REFERENCES tprovider(idtprovider)
) ENGINE=InnoDB;

-- categorías de cuartos de hoteles
CREATE TABLE troomcategory(
  idtroomcategory INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(100) NOT NULL,
  maxcapacity INT NOT NULL,
  fktprovider INT NOT NULL,
  userid INT NULL,
  INDEX ind_troomcategory_tprovider (fktprovider),
  FOREIGN KEY (fktprovider) REFERENCES tprovider_hoteltype(idtprovider)
) ENGINE=InnoDB;

-- data para proveedores tipo "Tour"
CREATE TABLE tprovider_tourtype(
  idtprovider INT NOT NULL PRIMARY KEY,
  location longtext,
  userid INT NULL,
  INDEX ind_tprovider_tourtype_tprovider (idtprovider),
  FOREIGN KEY (idtprovider) REFERENCES tprovider(idtprovider)
) ENGINE=InnoDB;

-- info de tours de proveedores
CREATE TABLE ttour(
  idttour INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  location longtext NOT NULL,
  description longtext NOT NULL,
  departuretime_hour INT NOT NULL,
  departuretime_minute INT NOT NULL,
  fktprovider INT NOT NULL,
  userid INT NULL,
  INDEX ind_troomcategory_tprovider (fktprovider),
  FOREIGN KEY (fktprovider) REFERENCES tprovider_tourtype(idtprovider)
) ENGINE=InnoDB;

CREATE TABLE tuser(
	idtuser INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	name VARCHAR(100) NOT NULL,
    passwordCypher VARCHAR(500) NOT NULL
) ENGINE=InnoDB;

-- admin admin
INSERT INTO tuser(name, passwordCypher) VALUES ('admin', 'Hpl2oQeO4go=');

CREATE TABLE ttokens(
  idttokens INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  authToken VARCHAR(250) NOT NULL,
  startDate DATETIME NOT NULL,
  endDate DATETIME NOT NULL,
  fktuser INT NOT NULL,
  INDEX ind_ttokens_tuser (fktuser),
  FOREIGN KEY (fktuser) REFERENCES tuser(idtuser)
) ENGINE=InnoDB;
