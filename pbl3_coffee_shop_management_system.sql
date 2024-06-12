-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 12, 2024 at 06:48 PM
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
('C00001', 'Nguyễn Hữu Hùng Dũng', '1', 'a@gmail.com', 0),
('C00002', 'Nguyễn Văn Thương', '2', 'b@gmail.com', 46);

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
('E00002', 'Võ Tiến Khoa', 0, '2014-05-05', 'dddd', '333', 'l@gmail.com', 0),
('M00001', 'Nguyễn Hữu Hùng Dũng', 0, '2014-02-05', 'a', '1', 'a@gmail.com', 1);

-- --------------------------------------------------------

--
-- Table structure for table `hoursworkedinmonth`
--

CREATE TABLE `hoursworkedinmonth` (
  `Month` char(7) NOT NULL,
  `EmployeeID` char(6) NOT NULL,
  `HoursWorked` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `hoursworkedinmonth`
--

INSERT INTO `hoursworkedinmonth` (`Month`, `EmployeeID`, `HoursWorked`) VALUES
('05/2024', 'E00001', 16),
('05/2024', 'E00002', 5),
('05/2024', 'M00001', 8);

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
('E00002', 'pt', 'pt'),
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
('P00001', 'Cà phê đen', 12000, 'Ly', 'PC0001'),
('P00002', 'Cà phê sữa', 15000, 'Ly', 'PC0001'),
('P00003', 'Cà phê đen Sài Gòn', 18000, 'Ly', 'PC0001'),
('P00004', 'Cà phê sữa Sài Gòn', 20000, 'Ly', 'PC0001'),
('P00005', 'Bạc xỉu', 22000, 'Ly', 'PC0001'),
('P00006', 'Bánh sừng bò', 15000, 'Cai', 'PC0002'),
('P00007', 'Bánh bông lan', 15000, 'Cai', 'PC0002');

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
('PC0001', 'Đồ uống'),
('PC0002', 'Thức ăn');

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
('R00001', '2014-05-29 09:40:04', 'E00001', '1', 15, 0),
('R00002', '2015-12-02 09:40:04', 'M00001', '2', 3, 15000),
('R00003', '2024-05-24 11:18:16', 'M00001', NULL, 4, 0),
('R00004', '2024-05-23 11:26:21', 'M00001', '9', 1, 0),
('R00005', '2024-05-21 11:41:52', 'M00001', '9', 10, 0),
('R00006', '2024-05-22 16:25:34', 'M00001', '2', 14, 0),
('R00007', '2024-05-25 16:28:33', 'M00001', '2', 1, 0),
('R00008', '2024-05-27 16:30:42', 'M00001', '2', 1, 50000),
('R00009', '2024-05-28 16:35:08', 'M00001', '2', 19, 50000),
('R00010', '2024-06-12 16:58:04', 'E00001', NULL, 9, 0),
('R00011', '2024-06-12 17:02:02', 'E00002', NULL, 8, 0),
('R00012', '2024-06-12 17:02:12', 'E00002', NULL, 19, 0);

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
('R00001', 'P00002', 1, 15000),
('R00002', 'P00004', 1, 20000),
('R00002', 'P00006', 2, 30000),
('R00003', 'P00004', 1, 20000),
('R00003', 'P00005', 1, 22000),
('R00003', 'P00006', 1, 15000),
('R00004', 'P00004', 1, 20000),
('R00004', 'P00007', 1, 15000),
('R00005', 'P00003', 1, 18000),
('R00006', 'P00003', 1, 18000),
('R00006', 'P00005', 1, 22000),
('R00007', 'P00002', 2, 30000),
('R00007', 'P00003', 2, 36000),
('R00007', 'P00004', 3, 60000),
('R00007', 'P00005', 1, 22000),
('R00007', 'P00006', 1, 15000),
('R00007', 'P00007', 2, 30000),
('R00008', 'P00005', 5, 110000),
('R00009', 'P00002', 1, 15000),
('R00009', 'P00003', 1, 18000),
('R00009', 'P00004', 1, 20000),
('R00009', 'P00005', 2, 44000),
('R00009', 'P00006', 2, 30000),
('R00009', 'P00007', 1, 15000),
('R00010', 'P00007', 1, 15000),
('R00011', 'P00006', 1, 15000),
('R00012', 'P00004', 1, 20000);

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
('E00001', 'Nhân viên full time', 4000000),
('E00002', 'Nhân viên part time', 17000);

-- --------------------------------------------------------

--
-- Table structure for table `shiftdetails`
--

CREATE TABLE `shiftdetails` (
  `WorkshiftID` char(6) NOT NULL,
  `EmployeeID` char(6) NOT NULL,
  `Day` date NOT NULL,
  `isCompleted` bit(1) DEFAULT b'0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `shiftdetails`
--

INSERT INTO `shiftdetails` (`WorkshiftID`, `EmployeeID`, `Day`, `isCompleted`) VALUES
('FT0001', 'E00001', '2024-05-20', b'0'),
('FT0001', 'E00001', '2024-05-21', b'0'),
('FT0001', 'E00001', '2024-05-22', b'0'),
('FT0001', 'E00001', '2024-05-23', b'1'),
('FT0001', 'E00001', '2024-05-24', b'1'),
('FT0001', 'E00001', '2024-05-29', b'0'),
('FT0001', 'M00001', '2024-05-25', b'0'),
('FT0002', 'E00001', '2024-06-05', b'0'),
('FT0002', 'M00001', '2024-05-21', b'0'),
('FT0002', 'M00001', '2024-05-23', b'1'),
('FT0002', 'M00001', '2024-05-26', b'0'),
('FT0002', 'M00001', '2024-05-31', b'0'),
('PT0003', 'E00002', '2024-05-20', b'0'),
('PT0003', 'E00002', '2024-05-24', b'1');

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
