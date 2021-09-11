CREATE DATABASE Project1_StoreApplicationDB
GO



CREATE TABLE Customers(
CustomerId INT PRIMARY KEY IDENTITY(1,1),
FirstName nvarchar(50) NOT NULL,
LastName nvarchar(50) NOT NULL,
email nvarchar(100),
pWord nvarchar(100),
cardNumber bigInt
);

CREATE TABLE Stores(
StoreId INT PRIMARY KEY IDENTITY(1,1),
[address] nvarchar(100) NOT NULL,
[NAME] nvarchar(50) NOT NULL,
);

CREATE TABLE Orders(
OrderId uniqueidentifier NOT NULL DEFAULT newid() PRIMARY KEY,
CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerId) ON DELETE CASCADE,
StoreId INT NOT NULL FOREIGN KEY REFERENCES Stores(StoreId) ON DELETE CASCADE,
OrderDate DATE NOT NULL DEFAULT GETDATE());

CREATE TABLE Products(
ProductId INT PRIMARY KEY IDENTITY(1,1),
[Name] nvarchar(50) NOT NULL,
[Description] nvarchar(300) NOT NULL,
Price decimal(19,4) NOT NULL);

CREATE TABLE ProductOrders(
OrderId uniqueidentifier NOT NULL FOREIGN KEY REFERENCES Orders(OrderId) ON DELETE CASCADE,
ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(ProductId) ON DELETE CASCADE,
Quantity INT NOT NULL
PRIMARY KEY(OrderId, ProductId)
);

CREATE TABLE ProductStores(
ProductId INT NOT NULL FOREIGN KEY REFERENCES Products(ProductId) ON DELETE CASCADE,
StoreId INT NOT NULL FOREIGN KEY REFERENCES Stores(StoreId) ON DELETE CASCADE
);
