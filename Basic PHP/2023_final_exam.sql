-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Jul 07, 2023 at 06:13 AM
-- Server version: 5.7.40
-- PHP Version: 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `2023_final_exam`
--

-- --------------------------------------------------------

--
-- Table structure for table `universities`
--

DROP TABLE IF EXISTS `universities`;
CREATE TABLE IF NOT EXISTS `universities` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `uni_name` varchar(255) NOT NULL,
  `uni_location` varchar(255) NOT NULL,
  `uni_students` int(11) NOT NULL,
  `uni_summary` text NOT NULL,
  `uni_img` varchar(255) NOT NULL,
  `user_id` int(11) NOT NULL DEFAULT '1',
  `date_created` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `universities`
--

INSERT INTO `universities` (`id`, `uni_name`, `uni_location`, `uni_students`, `uni_summary`, `uni_img`, `user_id`, `date_created`) VALUES
(1, 'Can Tho University', 'CanTho', 12000, '    Lorem ipsum dolor sit, amet consectetur adipisicing elit. Tempore esse quae dolores magni, officia nulla praesentium accusantium voluptatum hic provident ullam vitae rerum animi velit ab suscipit iste? Quidem, adipisci!', 'images/cantho.jpg', 1, '2023-07-07 12:47:52'),
(2, 'Danang University', 'Danang', 9000, '    Lorem ipsum dolor sit, amet consectetur adipisicing elit. Tempore esse quae dolores magni, officia nulla praesentium accusantium voluptatum hic provident ullam vitae rerum animi velit ab suscipit iste? Quidem, adipisci!', 'images/danang.jpg', 1, '2023-07-07 12:47:52'),
(3, 'Duy Tan University', 'Haoi', 15000, '    Lorem ipsum dolor sit, amet consectetur adipisicing elit. Tempore esse quae dolores magni, officia nulla praesentium accusantium voluptatum hic provident ullam vitae rerum animi velit ab suscipit iste? Quidem, adipisci!', 'images/duytan.jpg', 1, '2023-07-07 12:59:43'),
(4, 'Foreign Trade University', 'HCMC', 22000, '    Lorem ipsum dolor sit, amet consectetur adipisicing elit. Tempore esse quae dolores magni, officia nulla praesentium accusantium voluptatum hic provident ullam vitae rerum animi velit ab suscipit iste? Quidem, adipisci!', 'images/foreigntrde.jpg', 1, '2023-07-07 12:59:43'),
(5, 'HCM University of Science', 'HCMC', 15000, '    Lorem ipsum dolor sit, amet consectetur adipisicing elit. Tempore esse quae dolores magni, officia nulla praesentium accusantium voluptatum hic provident ullam vitae rerum animi velit ab suscipit iste? Quidem, adipisci!', 'images/hcmus.jpg', 1, '2023-07-07 13:00:46'),
(6, 'Ton Duc Thang University', 'HCMC', 11000, '    Lorem ipsum dolor sit, amet consectetur adipisicing elit. Tempore esse quae dolores magni, officia nulla praesentium accusantium voluptatum hic provident ullam vitae rerum animi velit ab suscipit iste? Quidem, adipisci!', 'images/tdt.jpg', 1, '2023-07-07 13:00:46'),
(7, 'RMIT', 'HCMC', 6000, '    Lorem ipsum dolor sit, amet consectetur adipisicing elit. Tempore esse quae dolores magni, officia nulla praesentium accusantium voluptatum hic provident ullam vitae rerum animi velit ab suscipit iste? Quidem, adipisci!', 'images/rmit.jpg', 1, '2023-07-07 13:01:22');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
