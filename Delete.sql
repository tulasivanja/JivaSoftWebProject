CREATE PROCEDURE spDeleteWidget
    @WidgetID INT
AS
BEGIN
    DELETE FROM Widget WHERE WidgetID = @WidgetID;
END
