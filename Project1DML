SELECT * FROM dbo.Customers
Select * FROM dbo.Stores
SELECT * FROM dbo.Products
SELECT * FROM dbo.Orders
SELECT * FROM dbo.ProductOrders
SELECT * FROM dbo.Stores
SELECT * FROM dbo.ProductStores
--test sql commands to make sure you have functionality from database

INSERT INTO Customers(FirstName,LastName,email,pWord,cardNumber)
VALUES
	('Briana', 'Wynn','bnwynn16@gmail.com','sumthim1@!',2000510030004000),
	('Brittany', 'Whyte','bnwhyte92@hotmail.com','password1',5000409730002000),
	('Charley', 'Lyda','lydalydabiglyda@yahoo.com','lydabigpimpin',3002500040005000);

--create a few stores 
INSERT INTO Stores([address])
VALUES
	('1523 N Halsted Blvd. Liesburg, Illinois 60246'),
	('33 Pillsbury Lane Gatlyn, Washington 98109'),
	('225 S Turkeyhill Drive Martinville, Nebraska 79145');

--insert some products that can be bought
INSERT INTO Products([Name], [Description],Price)
VALUES
	('Dice','Handcarved Wooden Dice set',15.99),
	('Rolling Tray','Leather Rolling Tray for dice roll releases',25.00),
	('D&D Player''s Handbook','Rule book for all D&D related adventures',19.99),
	('Dungeon Master Screen','Screen for protecting Dungeon Master secrets',10.00),
	('Blue Swirl Dice','Blue-Colored Resin Dice Set',9.99),
	('Red Moon Dice','Red-Colored Resin Dice Set',9.99),
	('Death March Valley','March through the hills and valleys of Scrim and faceoff against deadly bandits and orc tribes',39.99),
	('Return of The Mad Tyrant','Face off against Mecadar, The Mad Tyrant, to protect the city of Keltizar. ',39.99),
	('The Force Reborn','It''s been 50 years since the force mysteriously disappeared from the galaxy. Can you restore the force?',59.99),
	('Elvish Rogue Figurine','Original 1970s handcrafted figurine',89.99),
	('Halforc Wizard Figurine','Plastic figurine of a female halforc',5.99),
	('Dwarf Fighter Figurine','Plastic figurine of a male dwarf',5.99);


--create some orders to play with
INSERT INTO Orders(CustomerId,StoreId)
VALUES
	(1, 1),
	(2, 1 ),
	(3, 2 ),
	(1, 2),
	(1, 1),
	(3, 1); 

--add some products to each order in the junction table
INSERT INTO ProductOrders(OrderId, ProductId, Quantity)
VALUES
	('0A5D1C9A-2C65-461B-BE77-04C08DF695C7', 14, 2),
	('0A5D1C9A-2C65-461B-BE77-04C08DF695C7', 10, 1),
	('0A5D1C9A-2C65-461B-BE77-04C08DF695C7', 15, 1)

INSERT INTO ProductOrders(OrderId, ProductId, Quantity)
VALUES
	('4DB3B13F-76F5-43C4-949C-257533B2D5B3', 17, 1),
	('4DB3B13F-76F5-43C4-949C-257533B2D5B3', 10, 1),
	('D17D76B4-3493-4753-853C-26F0F64F5322', 18, 1),
	('EED7C821-24B0-4709-9054-5B8C4D3D2097', 19, 1),
	('0E8029EB-256C-4CE5-984A-BC83E3753035', 21, 10),
	('0E8029EB-256C-4CE5-984A-BC83E3753035', 20, 10),
	('AB2AA745-1DD2-4CF1-BCAD-CE2311DCC6FB', 17, 1);

--add some store inventory for each store

INSERT INTO ProductStores(StoreId, ProductId)
VALUES
	(1,10),
	(1,14),
	(1,15),
	(2,18),
	(1,19),
	(1,20),
	(1,21),
	(2,17),
	(3,11),
	(3,12),
	(1,12),
	(2,12),
	(2,14),
	(2,16),
	(3,21),
	(3,10),
	(3,15),
	(2,13),
	(2,20),
	(3,20),
	(3,18);
