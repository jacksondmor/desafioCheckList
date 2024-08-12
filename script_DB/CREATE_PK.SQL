-- ''
-- ' ************************************************************************************'
-- ' *  Teste Técnico .NET                                                              *'
-- ' ************************************************************************************'
-- ' *  Descricao:   Script para criacao de chaves primarias das tabelas.               *'
-- ' *  Data:        11/08/2024                                                         *'
-- ' *  Responsável: Jackson Morais 													*'
-- ' *  Informacoes: jackson.dmor@gmail.com                                             *'
-- ' ************************************************************************************'
-- ''

-- '' 
-- ' *====================================================================*'
-- ' * Criando a chave primaria da tabela User.                           *'
-- ' *====================================================================*'
-- '' 
ALTER TABLE dbo."User"
ADD CONSTRAINT pkUser PRIMARY KEY (Id)
GO

-- '' 
-- ' *====================================================================*'
-- ' * Criando a chave primaria da tabela VehicleType.                    *'
-- ' *====================================================================*'
-- '' 
ALTER TABLE dbo.VehicleType
ADD CONSTRAINT pkVehicleType PRIMARY KEY (Id)
GO

-- '' 
-- ' *====================================================================*'
-- ' * Criando a chave primaria da tabela InspectionList.                 *'
-- ' *====================================================================*'
-- '' 
ALTER TABLE dbo.InspectionList
ADD CONSTRAINT pkInspectionList PRIMARY KEY (Id)
GO

-- '' 
-- ' *====================================================================*'
-- ' * Criando a chave primaria da tabela Vehicle_InspectionList.         *'
-- ' *====================================================================*'
-- '' 
ALTER TABLE dbo.Vehicle_InspectionList
ADD CONSTRAINT pkVehicle_InspectionList PRIMARY KEY (Id)
GO

-- '' 
-- ' *====================================================================*'
-- ' * Criando a chave primaria da tabela CheckList.                      *'
-- ' *====================================================================*'
-- '' 
ALTER TABLE dbo.CheckList
ADD CONSTRAINT pkCheckList PRIMARY KEY (Id)
GO

-- '' 
-- ' *====================================================================*'
-- ' * Criando a chave primaria da tabela CheckListItem.                  *'
-- ' *====================================================================*'
-- '' 
ALTER TABLE dbo.CheckListItem
ADD CONSTRAINT pkCheckListItem PRIMARY KEY (Id)
GO