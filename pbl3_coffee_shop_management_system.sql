-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 21, 2024 at 07:02 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pbl3_coffee_shop_management_system`
--

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `ID` char(6) NOT NULL,
  `Name` text NOT NULL,
  `PhoneNum` text NOT NULL,
  `Email` text NOT NULL,
  `Points` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`ID`, `Name`, `PhoneNum`, `Email`, `Points`) VALUES
('1', 'Nguyễn Hữu Hùng Dũng', '1', 'a@gmail.com', 0),
('2', 'Nguyễn Văn Thương', '2', 'b@gmail.com', 500),
('3', 'a', '3', 'c@gmail.com', 0),
('4', 'b', '4', 'd@gmail.com', 20),
('5', 'c', '3', 'a', 0),
('6', 'd', '7', 'g', 0),
('7', 'e', 'c', '3', 0),
('8', 'sdf', '22', 'fsfsf', 0),
('9', 'Khoa bú dái', '100', 'a@gmail.com', 0);

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `ID` char(6) NOT NULL,
  `Name` text NOT NULL,
  `Gender` tinyint(1) NOT NULL,
  `DateOfBirth` date NOT NULL,
  `Address` text NOT NULL,
  `PhoneNum` text NOT NULL,
  `Email` text NOT NULL,
  `isFullTime` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`ID`, `Name`, `Gender`, `DateOfBirth`, `Address`, `PhoneNum`, `Email`, `isFullTime`) VALUES
('E00001', 'Nguyễn Văn Thương', 0, '2014-05-14', 'a', '4', 'f', 1),
('M00001', 'Nguyễn Hữu Hùng Dũng', 0, '2014-02-05', 'a', '1', 'a@gmail.com', 1);

-- --------------------------------------------------------

--
-- Table structure for table `hoursworkedinmonth`
--

CREATE TABLE `hoursworkedinmonth` (
  `Month` tinyint(4) NOT NULL,
  `EmployeeID` char(6) NOT NULL,
  `HoursWorked` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `logindetails`
--

CREATE TABLE `logindetails` (
  `ID` char(6) NOT NULL,
  `UserName` text NOT NULL,
  `Password` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `logindetails`
--

INSERT INTO `logindetails` (`ID`, `UserName`, `Password`) VALUES
('E00001', 'employee', 'employee'),
('M00001', 'admin', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `ID` char(6) NOT NULL,
  `Name` text NOT NULL,
  `SellPrice` int(11) NOT NULL,
  `Unit` text NOT NULL,
  `TypeID` char(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`ID`, `Name`, `SellPrice`, `Unit`, `TypeID`) VALUES
('1', 'Cà phê đen', 12000, 'Ly', '1'),
('2', 'Cà phê sữa', 15000, 'Ly', '1'),
('3', 'Cà phê đen Sài Gòn', 18000, 'Ly', '1'),
('4', 'Cà phê sữa Sài Gòn', 20000, 'Ly', '1'),
('5', 'Bạc xỉu', 22000, 'Ly', '1'),
('6', 'Bánh sừng bò', 15000, 'Cai', '2'),
('7', 'Bánh bông lan', 15000, 'Cai', '2');

-- --------------------------------------------------------

--
-- Table structure for table `producttype`
--

CREATE TABLE `producttype` (
  `ID` char(6) NOT NULL,
  `Type` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `producttype`
--

INSERT INTO `producttype` (`ID`, `Type`) VALUES
('1', 'Đồ uống'),
('2', 'Thức ăn');

-- --------------------------------------------------------

--
-- Table structure for table `receipt`
--

CREATE TABLE `receipt` (
  `ID` char(6) NOT NULL,
  `TransactionTime` datetime NOT NULL,
  `EmployeeID` char(6) NOT NULL,
  `CustomerID` char(6) DEFAULT NULL,
  `TableNum` int(11) NOT NULL,
  `Discount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `receipt`
--

INSERT INTO `receipt` (`ID`, `TransactionTime`, `EmployeeID`, `CustomerID`, `TableNum`, `Discount`) VALUES
('1', '2014-05-29 09:40:04', 'E00001', '1', 15, 0),
('2', '2015-12-02 09:40:04', 'M00001', '2', 3, 15000),
('3', '2024-05-21 11:18:16', 'M00001', NULL, 4, 0),
('4', '2024-05-21 11:26:21', 'M00001', '9', 1, 0),
('5', '2024-05-21 11:41:52', 'M00001', '9', 10, 0);

-- --------------------------------------------------------

--
-- Table structure for table `receiptdetails`
--

CREATE TABLE `receiptdetails` (
  `ReceiptID` char(6) NOT NULL,
  `ProductID` char(6) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `Total` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `receiptdetails`
--

INSERT INTO `receiptdetails` (`ReceiptID`, `ProductID`, `Quantity`, `Total`) VALUES
('1', '2', 1, 15000),
('2', '4', 1, 20000),
('2', '6', 2, 30000),
('3', '4', 1, 20000),
('3', '5', 1, 22000),
('3', '6', 1, 15000),
('4', '4', 1, 20000),
('4', '7', 1, 15000),
('5', '3', 1, 18000);

-- --------------------------------------------------------

--
-- Table structure for table `salary`
--

CREATE TABLE `salary` (
  `EmployeeID` char(6) NOT NULL,
  `Position` text NOT NULL,
  `Salary` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `salary`
--

INSERT INTO `salary` (`EmployeeID`, `Position`, `Salary`) VALUES
('E00001', 'Nhân viên full time', 4000000);

-- --------------------------------------------------------

--
-- Table structure for table `shiftdetails`
--

CREATE TABLE `shiftdetails` (
  `WorkshiftID` char(6) NOT NULL,
  `EmployeeID` char(6) NOT NULL,
  `Day` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `workshift`
--

CREATE TABLE `workshift` (
  `ID` char(6) NOT NULL,
  `StartTime` time NOT NULL,
  `EndTime` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `workshift`
--

INSERT INTO `workshift` (`ID`, `StartTime`, `EndTime`) VALUES
('FT0001', '06:30:00', '14:30:00'),
('FT0002', '14:30:00', '22:30:00'),
('PT0001', '06:30:00', '12:30:00'),
('PT0002', '12:30:00', '17:30:00'),
('PT0003', '17:30:00', '22:30:00');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `hoursworkedinmonth`
--
ALTER TABLE `hoursworkedinmonth`
  ADD PRIMARY KEY (`Month`,`EmployeeID`),
  ADD KEY `EmployeeID` (`EmployeeID`);

--
-- Indexes for table `logindetails`
--
ALTER TABLE `logindetails`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `UserName` (`UserName`) USING HASH;

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `producttype`
--
ALTER TABLE `producttype`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `receipt`
--
ALTER TABLE `receipt`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `receiptdetails`
--
ALTER TABLE `receiptdetails`
  ADD PRIMARY KEY (`ReceiptID`,`ProductID`),
  ADD KEY `ProductID` (`ProductID`);

--
-- Indexes for table `salary`
--
ALTER TABLE `salary`
  ADD PRIMARY KEY (`EmployeeID`);

--
-- Indexes for table `shiftdetails`
--
ALTER TABLE `shiftdetails`
  ADD PRIMARY KEY (`WorkshiftID`,`EmployeeID`,`Day`),
  ADD KEY `EmployeeID` (`EmployeeID`);

--
-- Indexes for table `workshift`
--
ALTER TABLE `workshift`
  ADD PRIMARY KEY (`ID`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `hoursworkedinmonth`
--
ALTER TABLE `hoursworkedinmonth`
  ADD CONSTRAINT `hoursworkedinmonth_ibfk_1` FOREIGN KEY (`EmployeeID`) REFERENCES `employee` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `logindetails`
--
ALTER TABLE `logindetails`
  ADD CONSTRAINT `logindetails_ibfk_1` FOREIGN KEY (`ID`) REFERENCES `employee` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `receiptdetails`
--
ALTER TABLE `receiptdetails`
  ADD CONSTRAINT `receiptdetails_ibfk_1` FOREIGN KEY (`ReceiptID`) REFERENCES `receipt` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `receiptdetails_ibfk_2` FOREIGN KEY (`ProductID`) REFERENCES `product` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `salary`
--
ALTER TABLE `salary`
  ADD CONSTRAINT `salary_ibfk_1` FOREIGN KEY (`EmployeeID`) REFERENCES `employee` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `shiftdetails`
--
ALTER TABLE `shiftdetails`
  ADD CONSTRAINT `shiftdetails_ibfk_1` FOREIGN KEY (`EmployeeID`) REFERENCES `employee` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `shiftdetails_ibfk_2` FOREIGN KEY (`WorkshiftID`) REFERENCES `workshift` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
