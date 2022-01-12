-- Usefull mappings for roles and access types

CREATE TABLE AccessRole(
	Id INT PRIMARY KEY IDENTITY(1,1),
	RoleName NVARCHAR(256) NOT NULL)

CREATE TABLE User_Role(
	IdUser INT NOT NULL,
	IdRole INT NOT NULL)

CREATE TABLE Role_MenuItem(
	IdRole INT NOT NULL,
	IdMenuItem INT NOT NULL,
	IsReadOnly TINYINT NOT NULL)
