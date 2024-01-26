CREATE TABLE Widget (
WidgetID INT IDENTITY(1,1) NOT NULL,
InventoryCode NVARCHAR(50) NOT NULL,
Description NVARCHAR(MAX) NULL,
QuantityOnHand INT NOT NULL,
ReorderQuantity INT NULL)