-- MySQL Script generated by MySQL Workbench
-- Thu Nov  3 23:31:04 2022
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema ExamenII
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema ExamenII
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `ExamenII` DEFAULT CHARACTER SET utf8 ;
USE `ExamenII` ;

-- -----------------------------------------------------
-- Table `ExamenII`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ExamenII`.`Usuario` (
  `CodigoUsuario` VARCHAR(20) NOT NULL,
  `Nombre` VARCHAR(45) NOT NULL,
  `Clave` VARCHAR(120) NOT NULL,
  PRIMARY KEY (`CodigoUsuario`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ExamenII`.`Cliente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ExamenII`.`Cliente` (
  `CodigoCliente` VARCHAR(20) NOT NULL,
  `Nombre` VARCHAR(45) NOT NULL,
  `Telefono` VARCHAR(20) NOT NULL,
  `DescripSolicitud` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`CodigoCliente`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ExamenII`.`TipoSoporte`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ExamenII`.`TipoSoporte` (
  `CodigoSoporte` VARCHAR(20) NOT NULL,
  `Precio` DECIMAL NOT NULL,
  PRIMARY KEY (`CodigoSoporte`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ExamenII`.`Ticket`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ExamenII`.`Ticket` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Fecha` DATETIME NOT NULL,
  `CodigoUsuario` VARCHAR(20) NOT NULL,
  `CodigoCliente` VARCHAR(20) NOT NULL,
  `TipoSoporte` VARCHAR(100) NOT NULL,
  `DescripRespuesta` VARCHAR(100) NOT NULL,
  `ISV` DECIMAL(8,2) NOT NULL,
  `Descuento` DECIMAL(8,2) NOT NULL,
  `Total` DECIMAL(8,2) NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `FK_Ticket_Cliente_idx` (`CodigoCliente` ASC) VISIBLE,
  INDEX `FK_Ticket_Usuario_idx` (`CodigoUsuario` ASC) VISIBLE,
  INDEX `FK_Ticket_TipoSoporte_idx` (`TipoSoporte` ASC) VISIBLE,
  CONSTRAINT `FK_Ticket_Cliente`
    FOREIGN KEY (`CodigoCliente`)
    REFERENCES `ExamenII`.`Cliente` (`CodigoCliente`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Ticket_Usuario`
    FOREIGN KEY (`CodigoUsuario`)
    REFERENCES `ExamenII`.`Usuario` (`CodigoUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Ticket_TipoSoporte`
    FOREIGN KEY (`TipoSoporte`)
    REFERENCES `ExamenII`.`TipoSoporte` (`CodigoSoporte`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
