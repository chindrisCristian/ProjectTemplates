CREATE PROCEDURE sp_ViewAccessGet
	AS
	BEGIN
		
		DECLARE @IdUser INT = 0
		SELECT @IdUser = Id FROM AppUser WHERE ContAD = SUSER_NAME()
		
		SELECT RMI.IdMenuItem, CAST(MIN(RMI.IsReadOnly) AS BIT) AS 'IsReadOnly'
		FROM User_Role as UR
		INNER JOIN Role_MenuItem as RMI ON UR.IdRole = RMI.IdRole
		GROUP BY UR.IdUser, RMI.IdMenuItem
		HAVING UR.IdUser = @IdUser

	END