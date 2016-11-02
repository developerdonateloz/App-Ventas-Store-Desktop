CREATE DATABASE [VentasBD] ON  PRIMARY
( NAME = 'Sales', FILENAME = 'E:\BD\VentasBD.mdf' , 
  SIZE = 5MB , MAXSIZE = unlimited, FILEGROWTH = 1MB )
LOG ON 
( NAME = 'Sales_log', FILENAME = 'E:\BD\VentasBD_log.ldf' , 
  SIZE = 2MB , MAXSIZE = unlimited , FILEGROWTH = 10%)
GO
--