-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.4.11-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             11.0.0.5919
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Dumping structure for table training_scheduler.event
CREATE TABLE IF NOT EXISTS `event` (
  `EventID` int(11) NOT NULL AUTO_INCREMENT,
  `FileData` text DEFAULT NULL,
  `EventType` int(11) NOT NULL,
  `Target` varchar(50) DEFAULT NULL,
  `Link` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`EventID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

-- Dumping structure for table training_scheduler.event_type
CREATE TABLE IF NOT EXISTS `event_type` (
  `EventTypeID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text DEFAULT NULL,
  `Code` text DEFAULT NULL,
  PRIMARY KEY (`EventTypeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

-- Dumping structure for table training_scheduler.group
CREATE TABLE IF NOT EXISTS `group` (
  `GroupID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`GroupID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

-- Dumping structure for table training_scheduler.message
CREATE TABLE IF NOT EXISTS `message` (
  `MessageID` int(11) NOT NULL AUTO_INCREMENT,
  `MessageText` text DEFAULT NULL,
  `MessageTypeID` int(11) NOT NULL,
  `From` int(11) NOT NULL,
  `To` int(11) NOT NULL,
  `MessageTime` time NOT NULL,
  `Sent` tinyint(1) NOT NULL,
  `Read` tinyint(1) NOT NULL,
  PRIMARY KEY (`MessageID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

-- Dumping structure for table training_scheduler.message_type
CREATE TABLE IF NOT EXISTS `message_type` (
  `MessageTypeID` int(11) NOT NULL AUTO_INCREMENT,
  `Type` text DEFAULT NULL,
  PRIMARY KEY (`MessageTypeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

-- Dumping structure for table training_scheduler.response
CREATE TABLE IF NOT EXISTS `response` (
  `AnswerID` int(11) NOT NULL AUTO_INCREMENT,
  `EventID` int(11) NOT NULL,
  `StudentID` int(11) NOT NULL,
  `Answer` text DEFAULT NULL,
  `CreatedOn` datetime NOT NULL,
  PRIMARY KEY (`AnswerID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

-- Dumping structure for table training_scheduler.role
CREATE TABLE IF NOT EXISTS `role` (
  `RoleID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text DEFAULT NULL,
  PRIMARY KEY (`RoleID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

-- Dumping structure for table training_scheduler.sail_plan
CREATE TABLE IF NOT EXISTS `sail_plan` (
  `SailPlanID` int(11) NOT NULL AUTO_INCREMENT,
  `StartDate` datetime NOT NULL,
  `EndDate` datetime NOT NULL,
  `Arrived` tinyint(1) NOT NULL,
  `ArrivalTime` datetime NOT NULL,
  `ExpectedArrivalTime` datetime NOT NULL,
  `VesselName` text DEFAULT NULL,
  `OwnerName` text DEFAULT NULL,
  `TelephoneAddress` text DEFAULT NULL,
  `MMSINumber` text DEFAULT NULL,
  `IsMotor` tinyint(1) NOT NULL,
  `SizeAndType` text DEFAULT NULL,
  `ColorOfCabin` text DEFAULT NULL,
  `ColorOfHulk` text DEFAULT NULL,
  `ColorOfDeck` text DEFAULT NULL,
  `OtherCharactistics` text DEFAULT NULL,
  `NumberOfLifeRafts` int(11) NOT NULL,
  `DescriptionAndColor` text DEFAULT NULL,
  `InboardOrOutboard` tinyint(1) NOT NULL,
  `HorsePower` text DEFAULT NULL,
  `Type` text DEFAULT NULL,
  `VHFRadioMonitorsCH` text DEFAULT NULL,
  `MFRadioMonitorsFrequency` text DEFAULT NULL,
  `CBRadioMonitorsCH` text DEFAULT NULL,
  PRIMARY KEY (`SailPlanID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

-- Dumping structure for table training_scheduler.sail_plan_location
CREATE TABLE IF NOT EXISTS `sail_plan_location` (
  `SailPlanLocationID` int(11) NOT NULL AUTO_INCREMENT,
  `SailPlanID` int(11) NOT NULL,
  `SortOrder` int(11) NOT NULL,
  `Latitude` text DEFAULT NULL,
  `Longitude` text DEFAULT NULL,
  `ExpectedArrival` datetime NOT NULL,
  `ExpectedDeparture` datetime NOT NULL,
  `Arrived` tinyint(1) NOT NULL,
  PRIMARY KEY (`SailPlanLocationID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

-- Dumping structure for table training_scheduler.script
CREATE TABLE IF NOT EXISTS `script` (
  `ScriptID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` mediumtext DEFAULT NULL,
  PRIMARY KEY (`ScriptID`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

-- Dumping structure for table training_scheduler.script_event
CREATE TABLE IF NOT EXISTS `script_event` (
  `ScriptEventID` int(11) NOT NULL AUTO_INCREMENT,
  `ScriptID` int(11) NOT NULL,
  `EventID` int(11) NOT NULL,
  `Duration` time DEFAULT NULL,
  `Parameters` text DEFAULT NULL,
  `From` int(11) DEFAULT 0,
  `To` int(11) DEFAULT 0,
  PRIMARY KEY (`ScriptEventID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

-- Dumping structure for table training_scheduler.script_group
CREATE TABLE IF NOT EXISTS `script_group` (
  `ScriptGroupID` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `ScriptID` int(11) DEFAULT NULL,
  `GroupID` int(11) DEFAULT NULL,
  `ScheduledDate` datetime DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  PRIMARY KEY (`ScriptGroupID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

-- Dumping structure for table training_scheduler.station
CREATE TABLE IF NOT EXISTS `station` (
  `StationID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text DEFAULT NULL,
  PRIMARY KEY (`StationID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

-- Dumping structure for table training_scheduler.user
CREATE TABLE IF NOT EXISTS `user` (
  `UserID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` text DEFAULT NULL,
  `Email` text DEFAULT NULL,
  `Password` text DEFAULT NULL,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

-- Dumping structure for table training_scheduler.user_group
CREATE TABLE IF NOT EXISTS `user_group` (
  `UserGroupID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `GroupID` int(11) DEFAULT NULL,
  PRIMARY KEY (`UserGroupID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

-- Dumping structure for table training_scheduler.user_role
CREATE TABLE IF NOT EXISTS `user_role` (
  `UserRoleID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) NOT NULL,
  `RoleID` int(11) NOT NULL,
  PRIMARY KEY (`UserRoleID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

-- Dumping structure for table training_scheduler.user_station
CREATE TABLE IF NOT EXISTS `user_station` (
  `UserStationID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) NOT NULL,
  `StationID` int(11) NOT NULL,
  `LastLogin` datetime NOT NULL,
  PRIMARY KEY (`UserStationID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

-- Dumping structure for table training_scheduler.weather_amount_type
CREATE TABLE IF NOT EXISTS `weather_amount_type` (
  `WeatherAmountTypeID` int(11) NOT NULL AUTO_INCREMENT,
  `Type` text DEFAULT NULL,
  PRIMARY KEY (`WeatherAmountTypeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

-- Dumping structure for table training_scheduler.weather_info
CREATE TABLE IF NOT EXISTS `weather_info` (
  `WeatherInfoID` int(11) NOT NULL AUTO_INCREMENT,
  `Date` datetime NOT NULL,
  `Time` time NOT NULL,
  `RecordDate` datetime NOT NULL,
  `WindSpeed` text DEFAULT NULL,
  `WindDirection` text DEFAULT NULL,
  `Humidity` text DEFAULT NULL,
  `Temprature` text DEFAULT NULL,
  `Visibility` text DEFAULT NULL,
  `WindGusts` text DEFAULT NULL,
  `CloudCover` text DEFAULT NULL,
  `Location` text DEFAULT NULL,
  `Latitude` text DEFAULT NULL,
  `Longitude` text DEFAULT NULL,
  `HighTemprature` text DEFAULT NULL,
  `LowTemprature` text DEFAULT NULL,
  `Pressure` text DEFAULT NULL,
  `Desctiption` text DEFAULT NULL,
  `Amount` int(11) NOT NULL,
  `FeelsLike` text DEFAULT NULL,
  `AmountType` int(11) NOT NULL,
  `UVIndex` text DEFAULT NULL,
  PRIMARY KEY (`WeatherInfoID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

-- Dumping structure for table training_scheduler.__efmigrationshistory
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Data exporting was unselected.

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
