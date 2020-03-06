CREATE DATABASE  IF NOT EXISTS `ledenbeheer` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `ledenbeheer`;
-- MySQL dump 10.13  Distrib 8.0.13, for Win64 (x86_64)
--
-- Host: localhost    Database: ledenbeheer
-- ------------------------------------------------------
-- Server version	5.7.20-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tblbijdragen`
--

DROP TABLE IF EXISTS `tblbijdragen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblbijdragen` (
  `lidid` int(11) NOT NULL,
  `datum` datetime NOT NULL,
  `bedrag` decimal(14,0) NOT NULL,
  `projectid` int(11) DEFAULT NULL,
  PRIMARY KEY (`lidid`,`datum`),
  KEY `fk_tblbijdragen_tbllid_idx` (`lidid`),
  KEY `Fk_tblbijdragen_tblproject_idx` (`projectid`),
  CONSTRAINT `Fk_tblbijdragen_tblproject` FOREIGN KEY (`projectid`) REFERENCES `tblproject` (`id`) ON DELETE SET NULL ON UPDATE SET NULL,
  CONSTRAINT `fk_tblbijdragen_tbllid` FOREIGN KEY (`lidid`) REFERENCES `tbllid` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblbijdragen`
--

LOCK TABLES `tblbijdragen` WRITE;
/*!40000 ALTER TABLE `tblbijdragen` DISABLE KEYS */;
INSERT INTO `tblbijdragen` VALUES (1,'2019-12-01 10:10:00',10,1),(1,'2020-01-01 15:30:00',12,2),(1,'2020-02-03 00:00:00',7,1),(1,'2020-02-22 00:00:00',12,3),(2,'2018-04-05 14:20:00',7,4),(2,'2019-01-14 00:00:00',14,1),(2,'2020-01-01 00:00:00',10,2),(3,'2020-01-15 00:00:00',16,3),(4,'2020-01-10 00:00:00',18,1),(6,'2020-02-01 00:00:00',74,1),(6,'2020-02-07 00:00:00',74,4),(6,'2020-02-22 00:00:00',74,2),(9,'2020-02-22 00:00:00',75,3),(10,'2020-02-07 00:00:00',63,1),(10,'2020-02-22 00:00:00',63,2),(11,'2020-02-07 00:00:00',12,2),(12,'2020-02-22 00:00:00',15,1),(13,'2020-02-22 00:00:00',12,2);
/*!40000 ALTER TABLE `tblbijdragen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbllid`
--

DROP TABLE IF EXISTS `tbllid`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tbllid` (
  `id` int(11) NOT NULL,
  `naam` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbllid`
--

LOCK TABLES `tbllid` WRITE;
/*!40000 ALTER TABLE `tbllid` DISABLE KEYS */;
INSERT INTO `tbllid` VALUES (1,'Mhamad'),(2,'Mounir'),(3,'Jonas'),(4,'Kacper'),(5,'Musthafa'),(6,'Nabila'),(9,'Piet'),(10,'Jan'),(11,'benis'),(12,'dirk'),(13,'Benisa');
/*!40000 ALTER TABLE `tbllid` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblproject`
--

DROP TABLE IF EXISTS `tblproject`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tblproject` (
  `id` int(11) NOT NULL,
  `omschrijving` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblproject`
--

LOCK TABLES `tblproject` WRITE;
/*!40000 ALTER TABLE `tblproject` DISABLE KEYS */;
INSERT INTO `tblproject` VALUES (1,'Uitstap Berlijn'),(2,'Ondersteuning minderbedeelden'),(3,'Verfraaiïng lokalen'),(4,'Culinaire avonden');
/*!40000 ALTER TABLE `tblproject` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-03-06 18:42:52
