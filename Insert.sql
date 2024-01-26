CREATE PROCEDURE spInsertWidget
    @InventoryCode NVARCHAR(50),
    @Description NVARCHAR(MAX),
    @QuantityOnHand INT,
    @ReorderQuantity INT
AS
BEGIN
    INSERT INTO Widget (InventoryCode, Description, QuantityOnHand, ReorderQuantity)
    VALUES (@InventoryCode, @Description, @QuantityOnHand, @ReorderQuantity);
END
