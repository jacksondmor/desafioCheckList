-- ''
-- ' ************************************************************************************'
-- ' *  Teste Técnico .NET                                                              *'
-- ' ************************************************************************************'
-- ' *  Descricao:   Script para criacao de dados iniciais do banco.                    *'
-- ' *  Data:        11/08/2024                                                         *'
-- ' *  Responsável: Jackson Morais 													*'
-- ' *  Informacoes: jackson.dmor@gmail.com                                             *'
-- ' ************************************************************************************'
-- ''

-- '' 
-- ' *====================================================================*'
-- ' * Criando usuarios iniciais do sistema.                              *'
-- ' *====================================================================*'
-- '' 
INSERT INTO dbo."User" (Name, Login, Password) VALUES ('Usuário 01', 'user01', 'user01@2024');
GO

INSERT INTO dbo."User" (Name, Login, Password) VALUES ('Usuário 02', 'user02', 'user02@2024');
GO

-- '' 
-- ' *====================================================================*'
-- ' * Criando tipos de veiculos iniciais do sistema.                     *'
-- ' *====================================================================*'
-- '' 
INSERT INTO dbo.VehicleType (Code, Description) VALUES ('VEH001', 'Caminhão 3/4');
GO

INSERT INTO dbo.VehicleType (Code, Description) VALUES ('VEH002', 'Caminhão Toco');
GO

INSERT INTO dbo.VehicleType (Code, Description) VALUES ('VEH003', 'Caminhão Truck');
GO

INSERT INTO dbo.VehicleType (Code, Description) VALUES ('VEH004', 'Carreta 5 Eixos');
GO

INSERT INTO dbo.VehicleType (Code, Description) VALUES ('VEH005', 'Carreta Eixo Extendido');
GO

-- '' 
-- ' *====================================================================*'
-- ' * Criando inspecoes iniciais do sistema.                             *'
-- ' *====================================================================*'
-- '' 
INSERT INTO dbo.InspectionList (Code, Description) VALUES ('INS001', 'Nivel óleo motor');
GO

INSERT INTO dbo.InspectionList (Code, Description) VALUES ('INS002', 'Nivel água de arref. motor');
GO

INSERT INTO dbo.InspectionList (Code, Description) VALUES ('INS003', 'Buzina');
GO

INSERT INTO dbo.InspectionList (Code, Description) VALUES ('INS004', 'Cinto de Segurança');
GO

INSERT INTO dbo.InspectionList (Code, Description) VALUES ('INS005', 'Espelho Retrovisor');
GO

INSERT INTO dbo.InspectionList (Code, Description) VALUES ('INS006', 'Extintor de Incêndio');
GO

INSERT INTO dbo.InspectionList (Code, Description) VALUES ('INS007', 'Macaco/ Triângulo');
GO

INSERT INTO dbo.InspectionList (Code, Description) VALUES ('INS008', 'Pára-brisas');
GO

INSERT INTO dbo.InspectionList (Code, Description) VALUES ('INS009', 'Condições Pedais');
GO

INSERT INTO dbo.InspectionList (Code, Description) VALUES ('INS010', 'Pneus/ Estepe');
GO

INSERT INTO dbo.InspectionList (Code, Description) VALUES ('INS011', 'Farol/ Farolete');
GO

INSERT INTO dbo.InspectionList (Code, Description) VALUES ('INS012', 'Limpador de Pára-brisas');
GO

INSERT INTO dbo.InspectionList (Code, Description) VALUES ('INS013', 'Setas');
GO

INSERT INTO dbo.InspectionList (Code, Description) VALUES ('INS014', 'Luz de Freio');
GO

INSERT INTO dbo.InspectionList (Code, Description) VALUES ('INS015', 'Pisca de Alerta');
GO

INSERT INTO dbo.InspectionList (Code, Description) VALUES ('INS016', 'Antena Telescópia - 3 metros');
GO

INSERT INTO dbo.InspectionList (Code, Description) VALUES ('INS017', 'Rádio de Comunicação');
GO

INSERT INTO dbo.InspectionList (Code, Description) VALUES ('INS018', 'Tacógrafo');
GO

-- ' '
-- ' *====================================================================*'
-- ' * Criando inspecoes para tipo de veiculo.                            *'
-- ' *====================================================================*'
-- ' '
-- Tipo veiculo 'Caminhão 3/4'
INSERT 
  INTO Vehicle_InspectionList
       (IdVehicleType, IdInspectionList)
VALUES ((SELECT Id FROM dbo.VehicleType WHERE Code = 'VEH001'), 
		(SELECT Id FROM dbo.InspectionList WHERE Code = 'INS001'))
GO

INSERT 
  INTO Vehicle_InspectionList
       (IdVehicleType, IdInspectionList)
VALUES ((SELECT Id FROM dbo.VehicleType WHERE Code = 'VEH001'), 
		(SELECT Id FROM dbo.InspectionList WHERE Code = 'INS003'))
GO

INSERT 
  INTO Vehicle_InspectionList
       (IdVehicleType, IdInspectionList)
VALUES ((SELECT Id FROM dbo.VehicleType WHERE Code = 'VEH001'), 
		(SELECT Id FROM dbo.InspectionList WHERE Code = 'INS005'))
GO

INSERT 
  INTO Vehicle_InspectionList
       (IdVehicleType, IdInspectionList)
VALUES ((SELECT Id FROM dbo.VehicleType WHERE Code = 'VEH001'), 
		(SELECT Id FROM dbo.InspectionList WHERE Code = 'INS007'))
GO

INSERT 
  INTO Vehicle_InspectionList
       (IdVehicleType, IdInspectionList)
VALUES ((SELECT Id FROM dbo.VehicleType WHERE Code = 'VEH001'), 
		(SELECT Id FROM dbo.InspectionList WHERE Code = 'INS009'))
GO

-- Tipo veiculo 'Caminhão Toco'
INSERT 
  INTO Vehicle_InspectionList
       (IdVehicleType, IdInspectionList)
VALUES ((SELECT Id FROM dbo.VehicleType WHERE Code = 'VEH002'), 
		(SELECT Id FROM dbo.InspectionList WHERE Code = 'INS002'))
GO

INSERT 
  INTO Vehicle_InspectionList
       (IdVehicleType, IdInspectionList)
VALUES ((SELECT Id FROM dbo.VehicleType WHERE Code = 'VEH002'), 
		(SELECT Id FROM dbo.InspectionList WHERE Code = 'INS004'))
GO

INSERT 
  INTO Vehicle_InspectionList
       (IdVehicleType, IdInspectionList)
VALUES ((SELECT Id FROM dbo.VehicleType WHERE Code = 'VEH002'), 
		(SELECT Id FROM dbo.InspectionList WHERE Code = 'INS006'))
GO

INSERT 
  INTO Vehicle_InspectionList
       (IdVehicleType, IdInspectionList)
VALUES ((SELECT Id FROM dbo.VehicleType WHERE Code = 'VEH002'), 
		(SELECT Id FROM dbo.InspectionList WHERE Code = 'INS008'))
GO

INSERT 
  INTO Vehicle_InspectionList
       (IdVehicleType, IdInspectionList)
VALUES ((SELECT Id FROM dbo.VehicleType WHERE Code = 'VEH002'), 
		(SELECT Id FROM dbo.InspectionList WHERE Code = 'INS010'))
GO

-- Tipo veiculo 'Caminhão Truck'
INSERT 
  INTO Vehicle_InspectionList
       (IdVehicleType, IdInspectionList)
VALUES ((SELECT Id FROM dbo.VehicleType WHERE Code = 'VEH003'), 
		(SELECT Id FROM dbo.InspectionList WHERE Code = 'INS010'))
GO

INSERT 
  INTO Vehicle_InspectionList
       (IdVehicleType, IdInspectionList)
VALUES ((SELECT Id FROM dbo.VehicleType WHERE Code = 'VEH003'), 
		(SELECT Id FROM dbo.InspectionList WHERE Code = 'INS011'))
GO

INSERT 
  INTO Vehicle_InspectionList
       (IdVehicleType, IdInspectionList)
VALUES ((SELECT Id FROM dbo.VehicleType WHERE Code = 'VEH003'), 
		(SELECT Id FROM dbo.InspectionList WHERE Code = 'INS012'))
GO

INSERT 
  INTO Vehicle_InspectionList
       (IdVehicleType, IdInspectionList)
VALUES ((SELECT Id FROM dbo.VehicleType WHERE Code = 'VEH003'), 
		(SELECT Id FROM dbo.InspectionList WHERE Code = 'INS013'))
GO

INSERT 
  INTO Vehicle_InspectionList
       (IdVehicleType, IdInspectionList)
VALUES ((SELECT Id FROM dbo.VehicleType WHERE Code = 'VEH003'), 
		(SELECT Id FROM dbo.InspectionList WHERE Code = 'INS014'))
GO

INSERT 
  INTO Vehicle_InspectionList
       (IdVehicleType, IdInspectionList)
VALUES ((SELECT Id FROM dbo.VehicleType WHERE Code = 'VEH003'), 
		(SELECT Id FROM dbo.InspectionList WHERE Code = 'INS015'))
GO

INSERT 
  INTO Vehicle_InspectionList
       (IdVehicleType, IdInspectionList)
VALUES ((SELECT Id FROM dbo.VehicleType WHERE Code = 'VEH003'), 
		(SELECT Id FROM dbo.InspectionList WHERE Code = 'INS016'))
GO

INSERT 
  INTO Vehicle_InspectionList
       (IdVehicleType, IdInspectionList)
VALUES ((SELECT Id FROM dbo.VehicleType WHERE Code = 'VEH003'), 
		(SELECT Id FROM dbo.InspectionList WHERE Code = 'INS017'))
GO

INSERT 
  INTO Vehicle_InspectionList
       (IdVehicleType, IdInspectionList)
VALUES ((SELECT Id FROM dbo.VehicleType WHERE Code = 'VEH003'), 
		(SELECT Id FROM dbo.InspectionList WHERE Code = 'INS018'))
GO