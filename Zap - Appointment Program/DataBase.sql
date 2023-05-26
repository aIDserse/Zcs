-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versione server:              10.4.21-MariaDB - mariadb.org binary distribution
-- S.O. server:                  Win64
-- HeidiSQL Versione:            11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Dump della struttura di tabella zap.events
CREATE TABLE IF NOT EXISTS `events` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Date` datetime NOT NULL,
  `MaxPlaces` int(10) unsigned NOT NULL DEFAULT 0,
  `Title` varchar(20) DEFAULT '""',
  `Description` varchar(50) DEFAULT '""',
  `Organizer` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_events_museums` (`Organizer`),
  CONSTRAINT `FK_events_museums` FOREIGN KEY (`Organizer`) REFERENCES `museums` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4;

-- Dump dei dati della tabella zap.events: ~9 rows (circa)
/*!40000 ALTER TABLE `events` DISABLE KEYS */;
INSERT INTO `events` (`ID`, `Date`, `MaxPlaces`, `Title`, `Description`, `Organizer`) VALUES
	(1, '2023-05-13 15:47:33', 10, 'Film Meeting', 'Taxi Driver', 1);
/*!40000 ALTER TABLE `events` ENABLE KEYS */;

-- Dump della struttura di tabella zap.museums
CREATE TABLE IF NOT EXISTS `museums` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT '',
  `Location` varchar(50) DEFAULT '',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;

-- Dump dei dati della tabella zap.museums: ~3 rows (circa)
/*!40000 ALTER TABLE `museums` DISABLE KEYS */;
INSERT INTO `museums` (`ID`, `Name`, `Location`) VALUES
	(1, 'BM', 'London'),
	(2, 'Egizio', 'Turin'),
	(3, 'Louvre', 'Paris');
/*!40000 ALTER TABLE `museums` ENABLE KEYS */;

-- Dump della struttura di tabella zap.reservations
CREATE TABLE IF NOT EXISTS `reservations` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) NOT NULL DEFAULT 0,
  `EventID` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`ID`),
  KEY `FK__users` (`UserID`),
  KEY `FK__events` (`EventID`),
  CONSTRAINT `FK__events` FOREIGN KEY (`EventID`) REFERENCES `events` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK__users` FOREIGN KEY (`UserID`) REFERENCES `users` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4;

-- Dump dei dati della tabella zap.reservations: ~7 rows (circa)
/*!40000 ALTER TABLE `reservations` DISABLE KEYS */;
/*!40000 ALTER TABLE `reservations` ENABLE KEYS */;

-- Dump della struttura di tabella zap.users
CREATE TABLE IF NOT EXISTS `users` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(20) NOT NULL DEFAULT '0',
  `Surname` varchar(20) NOT NULL DEFAULT '0',
  `Email` varchar(40) NOT NULL DEFAULT '0',
  `MuseumID` int(11) DEFAULT NULL,
  `Role` varchar(10) DEFAULT '"Basic"',
  `Password` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `FK_users_museums` (`MuseumID`),
  CONSTRAINT `FK_users_museums` FOREIGN KEY (`MuseumID`) REFERENCES `museums` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4;

-- Dump dei dati della tabella zap.users: ~2 rows (circa)
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
/*!40000 ALTER TABLE `users` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
