-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 15, 2024 at 01:32 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dorm_rental_system`
--

-- --------------------------------------------------------

--
-- Table structure for table `table_email`
--

CREATE TABLE `table_email` (
  `Recipient` varchar(50) NOT NULL,
  `Subject` varchar(50) NOT NULL,
  `Message` varchar(255) NOT NULL,
  `Date` text NOT NULL,
  `Time` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `table_email`
--

INSERT INTO `table_email` (`Recipient`, `Subject`, `Message`, `Date`, `Time`) VALUES
('riguelalleje919@gmail.com', 'Request For Rent Payment', 'Dear [tenant\'s name],\r\n\r\nGood day! \r\n\r\nI would like to inform you that the amount you have to pay for your rent is [amount] where the due date is on  [date]. I will be expecting your payment until the said date and a week after that.  \r\n\r\nI hope you pay t', '2024-01-07 00:00:00', '2024-01-07 00:06:14'),
('riguelalleje919@gmail.com', 'Request For Rent Payment', 'Dear Riguel,\r\n\r\nGood day! \r\n\r\nI would like to inform you that the amount you have to pay for your rent is 6500.00 where the due date is on  January 13, 2023\r\n\r\nI hope you pay the rent as soon as you can. Thank you!\r\n\r\nYours sincerely,\r\n\r\nVernadette', '2024-01-07 00:00:00', '2024-01-07 09:13:27'),
('riguelalleje919@gmail.com', 'notice', 'Dear Riguel,\r\n\r\n\n\nGood day!\r\n\n\nI would like to inform you that the amount you have to pay for your rent is 2500,00\r\n where the due date is on January 13, 2024. I will be expecting your payment \r\nuntil the said date and a week after that. \n\nI hope you pay ', '01-07-2024', '05:52:59');

-- --------------------------------------------------------

--
-- Table structure for table `table_employee`
--

CREATE TABLE `table_employee` (
  `Id` int(50) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `Sex` varchar(50) NOT NULL,
  `ContactNo` varchar(50) NOT NULL,
  `EmployeeType` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `table_employee`
--

INSERT INTO `table_employee` (`Id`, `Name`, `Username`, `Password`, `Sex`, `ContactNo`, `EmployeeType`) VALUES
(1, 'Administrator', 'admin', '7af2d10b73ab7cd8f603937f7697cb5fe432c7ff', 'Male', '09127539361', 'Administrator'),
(2, 'Vernadette Tominio', 'dette', '1833ffe8be404d33d725a89cd1e632b3084fcdea', 'Female', '09397167304', 'Landlady'),
(4, 'Levi Smith', 'Levi123', '22e08182ef58512222fa3a1cfd5e7f2f8e6fa5ba', 'Male', '09123456789', 'Administrator');

-- --------------------------------------------------------

--
-- Table structure for table `table_payment`
--

CREATE TABLE `table_payment` (
  `TenantID` int(50) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `RoomNo` varchar(50) NOT NULL,
  `Balance` decimal(10,2) NOT NULL,
  `RentAmount` int(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `table_payment`
--

INSERT INTO `table_payment` (`TenantID`, `Name`, `RoomNo`, `Balance`, `RentAmount`) VALUES
(9, 'Eury Hidalgo', 'Rm.301', 0.00, 4500),
(18, 'Judy Ann  Grace Villegas', 'Rm.201', 2500.00, 2500);

-- --------------------------------------------------------

--
-- Table structure for table `table_payment_history`
--

CREATE TABLE `table_payment_history` (
  `TransactionNo` varchar(255) NOT NULL,
  `PaymentID` int(50) NOT NULL,
  `TenantID` int(50) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `RoomNo` varchar(50) NOT NULL,
  `RentAmount` decimal(10,2) NOT NULL,
  `Payment` decimal(10,2) NOT NULL,
  `Balance` decimal(10,2) NOT NULL,
  `Date` text NOT NULL,
  `Time` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `table_payment_history`
--

INSERT INTO `table_payment_history` (`TransactionNo`, `PaymentID`, `TenantID`, `Name`, `RoomNo`, `RentAmount`, `Payment`, `Balance`, `Date`, `Time`) VALUES
('SGN202401159282', 163, 9, 'Eury Hidalgo', 'Rm.301', 4500.00, 4500.00, 0.00, '2024-01-15', '17:06:47'),
('TSO202401157751', 164, 18, 'Judy Ann  Grace Villegas', 'Rm.201', 2500.00, 500.00, 2000.00, '2024-01-15', '17:07:54'),
('GYK202401153181', 165, 18, 'Judy Ann  Grace Villegas', 'Rm.201', 2500.00, 2000.00, 0.00, '2024-01-15', '17:08:30');

-- --------------------------------------------------------

--
-- Table structure for table `table_rooms`
--

CREATE TABLE `table_rooms` (
  `RoomID` int(11) NOT NULL,
  `RoomNo` varchar(50) DEFAULT NULL,
  `RoomType` varchar(255) DEFAULT NULL,
  `RentAmount` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `table_rooms`
--

INSERT INTO `table_rooms` (`RoomID`, `RoomNo`, `RoomType`, `RentAmount`) VALUES
(1, 'Rm.201', 'Single Room', 2500.00),
(2, 'Rm.202', 'Single Room', 2500.00),
(3, 'Rm.203', 'Single Room', 2500.00),
(5, 'Rm.101', 'Double Room', 3500.00),
(6, 'Rm.301', 'Triple Room', 4500.00),
(8, 'Rm.204', 'Single Room', 2500.00),
(9, 'Rm.102', 'Double Room', 3500.00),
(10, 'Rm.302', 'Single Room', 2500.00),
(12, 'Rm.208', 'Double Room', 3500.00);

-- --------------------------------------------------------

--
-- Table structure for table `table_tenant`
--

CREATE TABLE `table_tenant` (
  `TenantID` int(11) NOT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `Sex` varchar(20) DEFAULT NULL,
  `Birthday` text DEFAULT NULL,
  `ContactNo` varchar(50) DEFAULT NULL,
  `EmailAddress` varchar(255) DEFAULT NULL,
  `RoomID` int(11) DEFAULT NULL,
  `RoomNo` varchar(50) DEFAULT NULL,
  `RoomType` varchar(255) DEFAULT NULL,
  `StartDate` text DEFAULT NULL,
  `RentAmount` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `table_tenant`
--

INSERT INTO `table_tenant` (`TenantID`, `Name`, `Sex`, `Birthday`, `ContactNo`, `EmailAddress`, `RoomID`, `RoomNo`, `RoomType`, `StartDate`, `RentAmount`) VALUES
(9, 'Eury Hidalgo', 'Female', '01-15-2024', '09127539361', 'euryhidalgo@gmail.com', 6, 'Rm.301', 'Triple Room', '20-01-2024', 4500.00),
(13, 'Riguel Alleje', 'Male', '01-15-2024', '09127539361', 'riguelalleje919@gmail.com', 2, 'Rm.202', 'Single Room', '22-01-2024', 2500.00),
(14, 'Hades Riego', 'Male', '01-15-2024', '09123456781', 'hades@gmail.com', 6, 'Rm.301', 'Triple Room', '23-01-2024', 4500.00),
(15, 'Jordan Perez', 'Female', '01-15-2024', '09121212121', 'perezjordan543@gmail.com', 8, 'Rm.204', 'Single Room', '23-01-2024', 2500.00),
(16, 'Justine Terencio', 'Female', '01-15-2024', '09663414921', 'justintineterencio28@gmail.com', 5, 'Rm.101', 'Double Room', '21-01-2024', 3500.00),
(18, 'Judy Ann  Grace Villegas', 'Female', '10-08-2003', '09637151439', 'prismaticannie@gmail.com', 1, 'Rm.201', 'Single Room', '15-02-2024', 2500.00);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `table_employee`
--
ALTER TABLE `table_employee`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `table_payment_history`
--
ALTER TABLE `table_payment_history`
  ADD PRIMARY KEY (`PaymentID`),
  ADD KEY `TenantID` (`TenantID`);

--
-- Indexes for table `table_rooms`
--
ALTER TABLE `table_rooms`
  ADD PRIMARY KEY (`RoomID`);

--
-- Indexes for table `table_tenant`
--
ALTER TABLE `table_tenant`
  ADD PRIMARY KEY (`TenantID`),
  ADD KEY `table_tenant_ibfk_1` (`RoomID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `table_employee`
--
ALTER TABLE `table_employee`
  MODIFY `Id` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `table_payment_history`
--
ALTER TABLE `table_payment_history`
  MODIFY `PaymentID` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=166;

--
-- AUTO_INCREMENT for table `table_rooms`
--
ALTER TABLE `table_rooms`
  MODIFY `RoomID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `table_tenant`
--
ALTER TABLE `table_tenant`
  MODIFY `TenantID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
