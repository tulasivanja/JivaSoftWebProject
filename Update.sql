CREATE PROCEDURE spUpdateWidget
    @WidgetID INT,
    @InventoryCode NVARCHAR(50),
    @Description NVARCHAR(MAX),
    @QuantityOnHand INT,
    @ReorderQuantity INT
AS
BEGIN
    UPDATE Widget
    SET InventoryCode = @InventoryCode,
        Description = @Description,
        QuantityOnHand = @QuantityOnHand,
        ReorderQuantity = @ReorderQuantity
    WHERE WidgetID = @WidgetID;
END
