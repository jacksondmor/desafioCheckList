-- ''
-- ' ************************************************************************************'
-- ' *  Teste Técnico .NET                                                              *'
-- ' ************************************************************************************'
-- ' *  Descricao:   Script para criacao de chaves estrangeiras.                        *'
-- ' *  Data:        11/08/2024                                                         *'
-- ' *  Responsável: Jackson Morais 													*'
-- ' *  Informacoes: jackson.dmor@gmail.com                                             *'
-- ' ************************************************************************************'
-- ''

-- '' 
-- ' *====================================================================*'
-- ' * Criando as chaves estrangeiras da tabela Vehicle_InspectionList.   *'
-- ' *====================================================================*'
-- '' 
ALTER TABLE dbo.Vehicle_InspectionList WITH CHECK ADD CONSTRAINT fkVehicle_InspectionList_VehicleType FOREIGN KEY(IdVehicleType)
REFERENCES dbo.VehicleType(Id)
GO

ALTER TABLE dbo.Vehicle_InspectionList WITH CHECK ADD CONSTRAINT fkVehicle_InspectionList_InspectionList FOREIGN KEY(IdInspectionList)
REFERENCES dbo.InspectionList(Id)
GO

-- '' 
-- ' *====================================================================*'
-- ' * Criando as chaves estrangeiras da tabela CheckList.                *'
-- ' *====================================================================*'
-- '' 
ALTER TABLE dbo.CheckList WITH CHECK ADD CONSTRAINT fkCheckList_User FOREIGN KEY(IdUser)
REFERENCES dbo."User"(Id)
GO

ALTER TABLE dbo.CheckList WITH CHECK ADD CONSTRAINT fkCheckList_VehicleType FOREIGN KEY(IdVehicleType)
REFERENCES dbo.VehicleType(Id)
GO

-- '' 
-- ' *====================================================================*'
-- ' * Criando as chaves estrangeiras da tabela CheckListItem.            *'
-- ' *====================================================================*'
-- '' 
ALTER TABLE dbo.CheckListItem WITH CHECK ADD CONSTRAINT fkCheckListItem_CheckList FOREIGN KEY(IdCheckList)
REFERENCES dbo.CheckList(Id)
GO

ALTER TABLE dbo.CheckListItem WITH CHECK ADD CONSTRAINT fkCheckListItem_Vehicle_InspectionList FOREIGN KEY(IdVehicle_InspectionList)
REFERENCES dbo.Vehicle_InspectionList(Id)
GO