-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 14, 2024 at 12:29 PM
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
('9', 'ádasd', 'bbb', '3', 0);

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
('M00001', 'Nguyễn Hữu Hùng Dũng', 0, '2014-05-14', 'a', '1', 'a@gmail.com', 1);

-- --------------------------------------------------------

--
-- Table structure for table `hoursworkedinmonth`
--

CREATE TABLE `hoursworkedinmonth` (
  `Month` date NOT NULL,
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
  `TypeID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`ID`, `Name`, `SellPrice`, `Unit`, `TypeID`) VALUES
('1', 'Cà phê đen', 12000, 'Ly', 1),
('2', 'Cà phê sữa', 15000, 'Ly', 1),
('3', 'Cà phê đen Sài Gòn', 18000, 'Ly', 1),
('4', 'Cà phê sữa Sài Gòn', 20000, 'Ly', 1),
('5', 'Bạc xỉu', 22000, 'Ly', 1),
('6', 'Bánh sừng bò', 15000, 'Cai', 2),
('7', 'Bánh bông lan', 15000, 'Cai', 2);

-- --------------------------------------------------------

--
-- Table structure for table `producttype`
--

CREATE TABLE `producttype` (
  `ID` char(6) NOT NULL,
  `Type` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `receipt`
--

CREATE TABLE `receipt` (
  `ID` char(6) NOT NULL,
  `TransactionTime` datetime NOT NULL,
  `EmployeeID` char(6) NOT NULL,
  `CustomerID` char(6) NOT NULL,
  `TableNum` int(11) NOT NULL,
  `Discount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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

-- --------------------------------------------------------

--
-- Table structure for table `salary`
--

CREATE TABLE `salary` (
  `EmployeeID` char(6) NOT NULL,
  `Position` text NOT NULL,
  `Salary` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `shiftdetails`
--

CREATE TABLE `shiftdetails` (
  `WorkshiftID` char(6) NOT NULL,
  `EmployeeID` char(6) NOT NULL
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
  ADD PRIMARY KEY (`Month`,`EmployeeID`);

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
  ADD PRIMARY KEY (`ReceiptID`,`ProductID`);

--
-- Indexes for table `salary`
--
ALTER TABLE `salary`
  ADD PRIMARY KEY (`EmployeeID`);

--
-- Indexes for table `shiftdetails`
--
ALTER TABLE `shiftdetails`
  ADD PRIMARY KEY (`WorkshiftID`,`EmployeeID`);

--
-- Indexes for table `workshift`
--
ALTER TABLE `workshift`
  ADD PRIMARY KEY (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
