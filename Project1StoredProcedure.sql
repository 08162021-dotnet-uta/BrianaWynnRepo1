-- test sample database
--find the order history for a single store
-- user-defined function with storeId as a variable

CREATE FUNCTION dbo.ViewSpecificStoreHistory(@storeId as int )
RETURNS TABLE
AS
	
RETURN select Orders.OrderId,Customers.FirstName, Products.[Name],Products.Price
	from Customers
	inner join Orders
	on Orders.CustomerId = Customers.CustomerId
	inner join ProductOrders
	on Orders.OrderId = ProductOrders.OrderId
	inner join Products
	on Products.ProductId = ProductOrders.ProductId
	where StoreId = @storeId;
	

select * from dbo.ViewSpecificStoreHistory(1);


select * from Orders


--List<object> orderhistorylist = context.FromSqlRaw($"select * from dbo.ViewSpecificStoreHistory( storeid)).ToList();
--foreach(var x in orderhistorylist){
--how to not print the orderid twice
--}
