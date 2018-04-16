-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.2.13-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             9.4.0.5125
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for accountowner
DROP DATABASE IF EXISTS `accountowner`;
CREATE DATABASE IF NOT EXISTS `accountowner` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `accountowner`;

-- Dumping structure for table accountowner.account
DROP TABLE IF EXISTS `account`;
CREATE TABLE IF NOT EXISTS `account` (
  `AccountId` char(100) NOT NULL,
  `DateCreated` date NOT NULL,
  `AccountType` varchar(45) NOT NULL,
  `OwnerId` char(100) NOT NULL,
  KEY `Index` (`OwnerId`),
  CONSTRAINT `FK_account_owner` FOREIGN KEY (`OwnerId`) REFERENCES `owner` (`OwnerId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table accountowner.account: ~8 rows (approximately)
DELETE FROM `account`;
/*!40000 ALTER TABLE `account` DISABLE KEYS */;
INSERT INTO `account` (`AccountId`, `DateCreated`, `AccountType`, `OwnerId`) VALUES
	('03e91478-5608-4132-a753-d494dafce00b', '2003-12-15', 'Domestic', 'f98e4d74-0f68-4aac-89fd-047f1aaca6b6'),
	('356a5a9b-64bf-4de0-bc84-5395a1fdc9c4', '1996-02-15', 'Domestic', '261e1685-cf26-494c-b17c-3546e65f5620'),
	('371b93f2-f8c5-4a32-894a-fc672741aa5b', '1999-05-04', 'Domestic', '24fd81f8-d58a-4bcc-9f35-dc6cd5641906'),
	('670775db-ecc0-4b90-a9ab-37cd0d8e2801', '1999-12-21', 'Savings', '24fd81f8-d58a-4bcc-9f35-dc6cd5641906'),
	('a3fbad0b-7f48-4feb-8ac0-6d3bbc997bfc', '2010-05-28', 'Domestic', 'a3c1880c-674c-4d18-8f91-5d3608a2c937'),
	('aa15f658-04bb-4f73-82af-82db49d0fbef', '1999-05-12', 'Foreign', '24fd81f8-d58a-4bcc-9f35-dc6cd5641906'),
	('c6066eb0-53ca-43e1-97aa-3c2169eec659', '1996-02-16', 'Foreign', '261e1685-cf26-494c-b17c-3546e65f5620'),
	('eccadf79-85fe-402f-893c-32d3f03ed9b1', '2010-06-20', 'Foreign', 'a3c1880c-674c-4d18-8f91-5d3608a2c937');
/*!40000 ALTER TABLE `account` ENABLE KEYS */;

-- Dumping structure for table accountowner.owner
DROP TABLE IF EXISTS `owner`;
CREATE TABLE IF NOT EXISTS `owner` (
  `OwnerId` char(100) NOT NULL,
  `Name` varchar(60) NOT NULL,
  `DateOfBirth` date NOT NULL,
  `Address` varchar(100) NOT NULL,
  PRIMARY KEY (`OwnerId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table accountowner.owner: ~4 rows (approximately)
DELETE FROM `owner`;
/*!40000 ALTER TABLE `owner` DISABLE KEYS */;
INSERT INTO `owner` (`OwnerId`, `Name`, `DateOfBirth`, `Address`) VALUES
	('24fd81f8-d58a-4bcc-9f35-dc6cd5641906', 'John Keen', '1980-12-05', '61 Wellfield Road'),
	('261e1685-cf26-494c-b17c-3546e65f5620', 'Anna Bosh', '1974-11-14', '27 Colored Row'),
	('a3c1880c-674c-4d18-8f91-5d3608a2c937', 'Sam Query', '1990-04-22', '91 Western Roads'),
	('f98e4d74-0f68-4aac-89fd-047f1aaca6b6', 'Martin Miller', '1983-05-21', '3 Edgar Buildings');
/*!40000 ALTER TABLE `owner` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
