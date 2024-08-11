-- ''
-- ' ************************************************************************************'
-- ' *  Teste Técnico .NET                                                              *'
-- ' ************************************************************************************'
-- ' *  Descricao:   Script inicial de criação de tabelas do sistema.                   *'
-- ' *  Data:        11/08/2024                                                         *'
-- ' *  Responsável: Jackson Morais 													*'
-- ' *  Informacoes: jackson.dmor@gmail.com                                             *'
-- ' ************************************************************************************'
-- ''

-- ' '
-- ' *====================================================================*'
-- ' * Criando tabela User.                                               *'
-- ' *====================================================================*'
-- ' '
CREATE TABLE dbo."User"(
	Id INT IDENTITY(1,1) NOT NULL,
	Name VARCHAR(50) NOT NULL,
	Login VARCHAR(20) NOT NULL,
	Password VARCHAR(20) NOT NULL,
	DateCreated DATETIME DEFAULT GETDATE(),
	DateUpdated DATETIME NULL
	)
GO

-- ' '
-- ' *====================================================================*'
-- ' * Criando tabela VehicleType.                                        *'
-- ' *====================================================================*'
-- ' '
CREATE TABLE dbo.VehicleType(
	Id INT IDENTITY(1,1) NOT NULL,
	Code VARCHAR(50) NOT NULL,
	Description VARCHAR(255) NOT NULL
	)
GO

-- ' '
-- ' *====================================================================*'
-- ' * Criando tabela InspectionList.                                     *'
-- ' *====================================================================*'
-- ' '
CREATE TABLE dbo.InspectionList(
	Id INT IDENTITY(1,1) NOT NULL,
	Code VARCHAR(50) NOT NULL,
	Description VARCHAR(255) NOT NULL
	)
GO

-- ' '
-- ' *====================================================================*'
-- ' * Criando tabela Vehicle_InspectionList.                             *'
-- ' *====================================================================*'
-- ' '
CREATE TABLE dbo.Vehicle_InspectionList(
	Id INT IDENTITY(1,1) NOT NULL,
	IdVehicleType INT NOT NULL,
	IdInspectionList INT NOT NULL,
	"Parameter" VARCHAR(20), 
	DateCreated DATETIME DEFAULT GETDATE(),
	DateUpdated DATETIME NULL,
	Actived INT DEFAULT 1 -- 1 - Yes; 0 - No 
	)
GO

-- ' '
-- ' *====================================================================*'
-- ' * Criando tabela CheckList.                                          *'
-- ' *====================================================================*'
-- ' '
CREATE TABLE dbo.CheckList(
	Id INT IDENTITY(1,1) NOT NULL,
	IdUser INT NOT NULL,
	IdVehicleType INT NOT NULL,
	Plate VARCHAR(7) NOT NULL,
	DriverName VARCHAR(50) NOT NULL,
	Approver VARCHAR(50) NOT NULL,
	Status CHAR(1) DEFAULT '', -- "I" - In progress; "A" - Awaiting Approval; "F" - Finished;
	Approved INT, -- 1 - Yes; 0 - No 
	GeneralObservation VARCHAR(255),
	DateCreated DATETIME DEFAULT GETDATE(),
	DateUpdated DATETIME NULL
	)
GO

-- ' '
-- ' *====================================================================*'
-- ' * Criando tabela CheckListItem.                                      *'
-- ' *====================================================================*'
-- ' '
CREATE TABLE dbo.CheckListItem(
	Id INT IDENTITY(1,1) NOT NULL,
	IdCheckList INT NOT NULL,
	IdVehicle_InspectionList INT NOT NULL,
	Status INT, -- 1 - OK; 0 - nOK 
	Observation VARCHAR(255),
	DateCreated DATETIME DEFAULT GETDATE(),
	DateUpdated DATETIME NULL
	)
GO