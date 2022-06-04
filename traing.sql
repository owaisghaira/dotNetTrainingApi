-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               8.0.27 - MySQL Community Server - GPL
-- Server OS:                    Linux
-- HeidiSQL Version:             11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Dumping structure for table training.event
CREATE TABLE IF NOT EXISTS `event` (
  `EventID` int NOT NULL AUTO_INCREMENT,
  `FileData` text,
  `EventType` int NOT NULL,
  `Target` varchar(50) DEFAULT NULL,
  `Link` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`EventID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table training.event: ~4 rows (approximately)
/*!40000 ALTER TABLE `event` DISABLE KEYS */;
REPLACE INTO `event` (`EventID`, `FileData`, `EventType`, `Target`, `Link`) VALUES
	(1, 'Test weather info', 2, 'Instructor', ''),
	(2, NULL, 5, 'Instructor', 'https://localhost:5001/baking.jpg'),
	(3, 'Email description text Email description text Email description text', 4, 'Instructor', ''),
	(4, 'instruction text instruction text instruction text', 3, 'Instructor', ''),
	(5, NULL, 7, 'Ship User', 'https://localhost:5001/02-Level 1 Eloquent Queries to JSON.mp4');
/*!40000 ALTER TABLE `event` ENABLE KEYS */;

-- Dumping structure for table training.event_type
CREATE TABLE IF NOT EXISTS `event_type` (
  `EventTypeID` int NOT NULL AUTO_INCREMENT,
  `Name` text,
  `Code` text,
  PRIMARY KEY (`EventTypeID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table training.event_type: ~7 rows (approximately)
/*!40000 ALTER TABLE `event_type` DISABLE KEYS */;
REPLACE INTO `event_type` (`EventTypeID`, `Name`, `Code`) VALUES
	(1, 'Sail Plan', 'SP'),
	(2, 'Wether', 'W'),
	(3, 'Instruction', 'INS'),
	(4, 'Email', 'EML'),
	(5, 'Image', 'IMG'),
	(6, 'Audio', 'AUD'),
	(7, 'Video', 'VID');
/*!40000 ALTER TABLE `event_type` ENABLE KEYS */;

-- Dumping structure for table training.group
CREATE TABLE IF NOT EXISTS `group` (
  `GroupID` int unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`GroupID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table training.group: ~0 rows (approximately)
/*!40000 ALTER TABLE `group` DISABLE KEYS */;
REPLACE INTO `group` (`GroupID`, `Name`) VALUES
	(1, 'Test');
/*!40000 ALTER TABLE `group` ENABLE KEYS */;

-- Dumping structure for table training.message
CREATE TABLE IF NOT EXISTS `message` (
  `MessageID` int NOT NULL AUTO_INCREMENT,
  `MessageText` text,
  `MessageTypeID` int NOT NULL,
  `From` int NOT NULL,
  `To` int NOT NULL,
  `MessageTime` time NOT NULL,
  `Sent` tinyint(1) NOT NULL,
  `Read` tinyint(1) NOT NULL,
  PRIMARY KEY (`MessageID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table training.message: ~0 rows (approximately)
/*!40000 ALTER TABLE `message` DISABLE KEYS */;
/*!40000 ALTER TABLE `message` ENABLE KEYS */;

-- Dumping structure for table training.message_type
CREATE TABLE IF NOT EXISTS `message_type` (
  `MessageTypeID` int NOT NULL AUTO_INCREMENT,
  `Type` text,
  PRIMARY KEY (`MessageTypeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table training.message_type: ~0 rows (approximately)
/*!40000 ALTER TABLE `message_type` DISABLE KEYS */;
/*!40000 ALTER TABLE `message_type` ENABLE KEYS */;

-- Dumping structure for table training.response
CREATE TABLE IF NOT EXISTS `response` (
  `AnswerID` int NOT NULL AUTO_INCREMENT,
  `EventID` int NOT NULL,
  `StudentID` int NOT NULL,
  `Answer` text,
  `CreatedOn` datetime NOT NULL,
  PRIMARY KEY (`AnswerID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table training.response: ~0 rows (approximately)
/*!40000 ALTER TABLE `response` DISABLE KEYS */;
/*!40000 ALTER TABLE `response` ENABLE KEYS */;

-- Dumping structure for table training.role
CREATE TABLE IF NOT EXISTS `role` (
  `RoleID` int NOT NULL AUTO_INCREMENT,
  `Name` text,
  PRIMARY KEY (`RoleID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table training.role: ~3 rows (approximately)
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
REPLACE INTO `role` (`RoleID`, `Name`) VALUES
	(1, 'Instructor'),
	(2, 'Coast Guard'),
	(3, 'Ship User');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;

-- Dumping structure for table training.sail_plan
CREATE TABLE IF NOT EXISTS `sail_plan` (
  `SailPlanID` int NOT NULL AUTO_INCREMENT,
  `StartDate` datetime NOT NULL,
  `EndDate` datetime NOT NULL,
  `Arrived` tinyint(1) NOT NULL,
  `ArrivalTime` datetime NOT NULL,
  `ExpectedArrivalTime` datetime NOT NULL,
  `VesselName` text,
  `OwnerName` text,
  `TelephoneAddress` text,
  `MMSINumber` text,
  `IsMotor` tinyint(1) NOT NULL,
  `SizeAndType` text,
  `ColorOfCabin` text,
  `ColorOfHulk` text,
  `ColorOfDeck` text,
  `OtherCharactistics` text,
  `NumberOfLifeRafts` int NOT NULL,
  `DescriptionAndColor` text,
  `InboardOrOutboard` tinyint(1) NOT NULL,
  `HorsePower` text,
  `Type` text,
  `VHFRadioMonitorsCH` text,
  `MFRadioMonitorsFrequency` text,
  `CBRadioMonitorsCH` text,
  PRIMARY KEY (`SailPlanID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table training.sail_plan: ~0 rows (approximately)
/*!40000 ALTER TABLE `sail_plan` DISABLE KEYS */;
/*!40000 ALTER TABLE `sail_plan` ENABLE KEYS */;

-- Dumping structure for table training.sail_plan_location
CREATE TABLE IF NOT EXISTS `sail_plan_location` (
  `SailPlanLocationID` int NOT NULL AUTO_INCREMENT,
  `SailPlanID` int NOT NULL,
  `SortOrder` int NOT NULL,
  `Latitude` text,
  `Longitude` text,
  `ExpectedArrival` datetime NOT NULL,
  `ExpectedDeparture` datetime NOT NULL,
  `Arrived` tinyint(1) NOT NULL,
  PRIMARY KEY (`SailPlanLocationID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table training.sail_plan_location: ~0 rows (approximately)
/*!40000 ALTER TABLE `sail_plan_location` DISABLE KEYS */;
/*!40000 ALTER TABLE `sail_plan_location` ENABLE KEYS */;

-- Dumping structure for table training.script
CREATE TABLE IF NOT EXISTS `script` (
  `ScriptID` int NOT NULL AUTO_INCREMENT,
  `Name` mediumtext,
  PRIMARY KEY (`ScriptID`) USING BTREE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table training.script: ~0 rows (approximately)
/*!40000 ALTER TABLE `script` DISABLE KEYS */;
REPLACE INTO `script` (`ScriptID`, `Name`) VALUES
	(1, 'Test1 Script');
/*!40000 ALTER TABLE `script` ENABLE KEYS */;

-- Dumping structure for table training.script_event
CREATE TABLE IF NOT EXISTS `script_event` (
  `ScriptEventID` int NOT NULL AUTO_INCREMENT,
  `ScriptID` int NOT NULL,
  `EventID` int NOT NULL,
  `Duration` time DEFAULT NULL,
  `Parameters` text,
  `From` int DEFAULT '0',
  `To` int DEFAULT '0',
  PRIMARY KEY (`ScriptEventID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table training.script_event: ~4 rows (approximately)
/*!40000 ALTER TABLE `script_event` DISABLE KEYS */;
REPLACE INTO `script_event` (`ScriptEventID`, `ScriptID`, `EventID`, `Duration`, `Parameters`, `From`, `To`) VALUES
	(1, 1, 1, '00:00:10', 'None', 0, 0),
	(2, 1, 2, '00:00:03', 'None', 0, 0),
	(3, 1, 3, '00:00:06', 'hello', 0, 0),
	(4, 1, 4, '00:00:05', 'hello', 0, 0),
	(5, 1, 5, '00:00:07', 'hello', 0, 0);
/*!40000 ALTER TABLE `script_event` ENABLE KEYS */;

-- Dumping structure for table training.script_group
CREATE TABLE IF NOT EXISTS `script_group` (
  `ScriptGroupID` int unsigned NOT NULL AUTO_INCREMENT,
  `ScriptID` int DEFAULT NULL,
  `GroupID` int DEFAULT NULL,
  `ScheduledDate` datetime DEFAULT NULL,
  `Status` int DEFAULT NULL,
  PRIMARY KEY (`ScriptGroupID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table training.script_group: ~0 rows (approximately)
/*!40000 ALTER TABLE `script_group` DISABLE KEYS */;
REPLACE INTO `script_group` (`ScriptGroupID`, `ScriptID`, `GroupID`, `ScheduledDate`, `Status`) VALUES
	(1, 1, 1, '2022-04-14 06:54:40', 1);
/*!40000 ALTER TABLE `script_group` ENABLE KEYS */;

-- Dumping structure for table training.station
CREATE TABLE IF NOT EXISTS `station` (
  `StationID` int NOT NULL AUTO_INCREMENT,
  `Name` text,
  PRIMARY KEY (`StationID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table training.station: ~0 rows (approximately)
/*!40000 ALTER TABLE `station` DISABLE KEYS */;
/*!40000 ALTER TABLE `station` ENABLE KEYS */;

-- Dumping structure for table training.user
CREATE TABLE IF NOT EXISTS `user` (
  `UserID` int NOT NULL AUTO_INCREMENT,
  `Name` text,
  `Email` text,
  `Password` text,
  `Locale` varchar(50) DEFAULT NULL,
  `StationID` varchar(50) DEFAULT NULL,
  `IsReady` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table training.user: ~4 rows (approximately)
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
REPLACE INTO `user` (`UserID`, `Name`, `Email`, `Password`, `Locale`, `StationID`, `IsReady`) VALUES
	(1, 'instructor', 'instructor1@mailinator.com', '123456', 'en', 'COASTAL STATION 1', 0),
	(2, 'Sam', 'dsm@mailinator.com', '123456', 'en', NULL, 0),
	(3, 'William', 'will@mailinator.com', '123456', 'en', NULL, 1),
	(4, 'Haris', 'haris@mailinator.com', '123456', 'en', 'SHIP STATION 1', 0);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

-- Dumping structure for table training.user_group
CREATE TABLE IF NOT EXISTS `user_group` (
  `UserGroupID` int unsigned NOT NULL AUTO_INCREMENT,
  `UserID` int DEFAULT NULL,
  `GroupID` int DEFAULT NULL,
  PRIMARY KEY (`UserGroupID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table training.user_group: ~2 rows (approximately)
/*!40000 ALTER TABLE `user_group` DISABLE KEYS */;
REPLACE INTO `user_group` (`UserGroupID`, `UserID`, `GroupID`) VALUES
	(3, 2, 1),
	(4, 3, 1);
/*!40000 ALTER TABLE `user_group` ENABLE KEYS */;

-- Dumping structure for table training.user_role
CREATE TABLE IF NOT EXISTS `user_role` (
  `UserRoleID` int NOT NULL AUTO_INCREMENT,
  `UserID` int NOT NULL,
  `RoleID` int NOT NULL,
  PRIMARY KEY (`UserRoleID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table training.user_role: ~4 rows (approximately)
/*!40000 ALTER TABLE `user_role` DISABLE KEYS */;
REPLACE INTO `user_role` (`UserRoleID`, `UserID`, `RoleID`) VALUES
	(1, 1, 1),
	(2, 2, 2),
	(3, 3, 3),
	(4, 4, 3);
/*!40000 ALTER TABLE `user_role` ENABLE KEYS */;

-- Dumping structure for table training.user_station
CREATE TABLE IF NOT EXISTS `user_station` (
  `UserStationID` int NOT NULL AUTO_INCREMENT,
  `UserID` int NOT NULL,
  `StationID` int NOT NULL,
  `LastLogin` datetime NOT NULL,
  PRIMARY KEY (`UserStationID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table training.user_station: ~0 rows (approximately)
/*!40000 ALTER TABLE `user_station` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_station` ENABLE KEYS */;

-- Dumping structure for table training.weather_amount_type
CREATE TABLE IF NOT EXISTS `weather_amount_type` (
  `WeatherAmountTypeID` int NOT NULL AUTO_INCREMENT,
  `Type` text,
  PRIMARY KEY (`WeatherAmountTypeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table training.weather_amount_type: ~0 rows (approximately)
/*!40000 ALTER TABLE `weather_amount_type` DISABLE KEYS */;
/*!40000 ALTER TABLE `weather_amount_type` ENABLE KEYS */;

-- Dumping structure for table training.weather_info
CREATE TABLE IF NOT EXISTS `weather_info` (
  `WeatherInfoID` int NOT NULL AUTO_INCREMENT,
  `Date` datetime NOT NULL,
  `Time` time NOT NULL,
  `RecordDate` datetime NOT NULL,
  `WindSpeed` text,
  `WindDirection` text,
  `Humidity` text,
  `Temprature` text,
  `Visibility` text,
  `WindGusts` text,
  `CloudCover` text,
  `Location` text,
  `Latitude` text,
  `Longitude` text,
  `HighTemprature` text,
  `LowTemprature` text,
  `Pressure` text,
  `Desctiption` text,
  `Amount` int NOT NULL,
  `FeelsLike` text,
  `AmountType` int NOT NULL,
  `UVIndex` text,
  PRIMARY KEY (`WeatherInfoID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table training.weather_info: ~0 rows (approximately)
/*!40000 ALTER TABLE `weather_info` DISABLE KEYS */;
/*!40000 ALTER TABLE `weather_info` ENABLE KEYS */;

-- Dumping structure for table training.__efmigrationshistory
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table training.__efmigrationshistory: ~0 rows (approximately)
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
