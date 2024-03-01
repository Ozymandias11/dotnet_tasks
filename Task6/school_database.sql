-- --------------------------------------------------------
-- ჰოსტი:                        127.0.0.1
-- Server version:               11.3.0-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL ვერსია:              12.3.0.6589
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for school_database
CREATE DATABASE IF NOT EXISTS `school_database` /*!40100 DEFAULT CHARACTER SET armscii8 COLLATE armscii8_bin */;
USE `school_database`;

-- Dumping structure for table school_database.pupil
CREATE TABLE IF NOT EXISTS `pupil` (
  `pupil_id` int(11) unsigned NOT NULL,
  `p_name` varchar(50) DEFAULT NULL,
  `p_lastname` varchar(50) DEFAULT NULL,
  `gender` enum('M','F') DEFAULT NULL,
  `class` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`pupil_id`)
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;

-- Dumping data for table school_database.pupil: ~4 rows (approximately)
DELETE FROM `pupil`;
INSERT INTO `pupil` (`pupil_id`, `p_name`, `p_lastname`, `gender`, `class`) VALUES
	(1, 'Alex', 'Johnson', 'M', '10A'),
	(2, 'Sophia', 'Miller', 'F', '10B'),
	(3, 'Daniel', 'Williams', 'M', '11A'),
	(4, 'Olivia', 'Davis', 'F', '11B');

-- Dumping structure for table school_database.teacher
CREATE TABLE IF NOT EXISTS `teacher` (
  `teacher_id` int(11) unsigned NOT NULL,
  `t_name` varchar(50) DEFAULT NULL,
  `t_lastname` varchar(50) DEFAULT NULL,
  `gender` enum('M','F') DEFAULT NULL,
  `subject` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`teacher_id`)
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;

-- Dumping data for table school_database.teacher: ~4 rows (approximately)
DELETE FROM `teacher`;
INSERT INTO `teacher` (`teacher_id`, `t_name`, `t_lastname`, `gender`, `subject`) VALUES
	(1, 'John', 'Smith', 'M', 'Mathematics'),
	(2, 'Emily', 'Jones', 'F', 'English Literature'),
	(3, 'David', 'Brown', 'M', 'Science'),
	(4, 'Jessica', 'Taylor', 'F', 'History');

-- Dumping structure for table school_database.teaches
CREATE TABLE IF NOT EXISTS `teaches` (
  `teacher_id` int(11) unsigned NOT NULL,
  `pupil_id` int(11) unsigned NOT NULL,
  PRIMARY KEY (`teacher_id`,`pupil_id`),
  KEY `FK_teaches_pupil` (`pupil_id`),
  CONSTRAINT `FK_teaches_pupil` FOREIGN KEY (`pupil_id`) REFERENCES `pupil` (`pupil_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_teaches_teacher` FOREIGN KEY (`teacher_id`) REFERENCES `teacher` (`teacher_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=armscii8 COLLATE=armscii8_bin;

-- Dumping data for table school_database.teaches: ~6 rows (approximately)
DELETE FROM `teaches`;
INSERT INTO `teaches` (`teacher_id`, `pupil_id`) VALUES
	(1, 1),
	(1, 2),
	(2, 2),
	(3, 3),
	(3, 4),
	(4, 4);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
