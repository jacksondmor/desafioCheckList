# Desafio CheckList - Gestran

# Instruções para Criação de Banco de Dados no SQL Server

Este documento fornece instruções para criar um banco de dados no SQL Server.

## Pré-requisitos

- Ter o SQL Server instalado em seu sistema.
- Acesso ao SQL Server Management Studio (SSMS) ou uma ferramenta similar.
- Permissões necessárias para criar bancos de dados no servidor.

## Passos para Criar um Banco de Dados

### 1. Acessar o SQL Server Management Studio (SSMS)

- Abra o SSMS e conecte-se ao seu servidor SQL Server.

### 2. Criar um Novo Banco de Dados

- No painel do Object Explorer, clique com o botão direito na pasta `Databases`.
- Selecione `New Database...`.

### 3. Configurar as Propriedades do Banco de Dados

- Na janela que abrir, digite o nome 'desafioCheckList' no campo `Database name`.

### 4. Criar o Banco de Dados

- Após configurar as propriedades desejadas, clique em `OK` para criar o banco de dados.

### 5. Verificar a Criação do Banco de Dados

- No painel do Object Explorer, expanda a pasta `Databases` para verificar se o novo banco de dados aparece na lista.

## Criar tabelas referente ao projeto

### 1. Conectar ao novo Banco de Dados

- Conecte-se ao banco 'desafioCheckList' utilizando a credencial "Autenticação do Windows"

### 2. Execução dos scripts

- No painel do Object Explorer, clique com o botão direito no banco 'desafioCheckList'
- Selecione `New Query`.
- Execute os scripts existentes na pasta script_DB, da raiz do repositório, na seguinte ordem:
	- CREATE_DB.SQL
	- CREATE_PK.SQL
	- CREATE_FK.SQL
	- CREATE_DATA.SQL
	
	

# Instruções para Execução da API em .NET Core 8

## Pré-requisitos

- .NET SDK 8.0
- Visual Studio 2022 ou superior (opcional)
- Postman ou ferramenta similar (opcional)

## Passos para Execução

1. **Clonar o Repositório**
   - Abra o terminal.
   - Navegue até o diretório desejado.
   - Execute:
     ```
     git clone https://github.com/jacksondmor/desafioCheckList
     ```
   - Navegue para o diretório do projeto:
     ```
     cd nome-do-projeto
     ```

2. **Restaurar Pacotes**
   - Execute:
     ```
     dotnet restore
     ```

3. **Configurar o Banco de Dados**
   - Abra `appsettings.json` e configure a string de conexão conforme necessário.


4. **Executar a API**
   - Execute:
     ```
     dotnet run
     ```
   - Acesse a API em:
     ```
     http://localhost:64244/swagger/index.html
     ```

5. **Testar a API**
   - Utilize o swagger da aplicação ou outra ferramenta para testar os endpoints disponíveis.




