-- DDL
CREATE  DATABASE ProVagas
GO

USE ProVagas
GO

CREATE TABLE TipoUsuario (
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	NomeTipoUsuario VARCHAR (255) NOT NULL 
)
GO

CREATE TABLE Usuario (
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR (255) NOT NULL UNIQUE,
	Telefone VARCHAR (20),
	Senha VARCHAR (32) NOT NULL,
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(IdTIpoUsuario),
)
GO

CREATE TABLE Endereco (
	IdEndereco INT PRIMARY KEY IDENTITY,
	Rua VARCHAR (255) NOT NULL,
	Numero VARCHAR (10) NOT NULL,
	Bairro VARCHAR (100) NOT NULL,
	Complemento VARCHAR (20),
	CEP CHAR(9) NOT NULL,
	NomeCidade VARCHAR (255) NOT NULL,
	NomeEstado VARCHAR (255) NOT NULL,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario)
)
GO
INSERT INTO Endereco VALUES
('Rua Carlos Alves',  '12', 'Vila do chaves', 123, '000000000', 'São Paulo','São Paulo',1), 
('Avenida Barão de Limeira',  '539 ', 'Santa Cecilia', null, '01202001', 2,2)
GO

CREATE TABLE NivelEscolaridade (
	IdNivelEscolaridade INT PRIMARY KEY IDENTITY,
	Escolaridade VARCHAR (60) 
)
GO

CREATE TABLE Candidato (
	IdCandidato INT PRIMARY KEY IDENTITY,
	NomeCompletoCandidato VARCHAR (255) NOT NULL,
	CPF CHAR (11) UNIQUE NOT NULL,
	DataNascimento DATE NOT NULL,
	Linkedin VARCHAR (200),
	FotoPerfil IMAGE,
	Curriculo BINARY,
	NomeGenero VARCHAR (255) NOT NULL,
	PossuiDeficiencia BIT NOT NULL,
	NomeDeficiencia VARCHAR (255),
	NomeIdioma VARCHAR (255),
	NomeNivel VARCHAR (255),
	CursandoSenai BIT NOT NULL,
	Curso VARCHAR(255) NOT NULL,
	TesteDePersonalidade VARCHAR (255), 
	IdEndereco INT FOREIGN KEY REFERENCES Endereco (IdEndereco),
	IdNivelEscolaridade INT FOREIGN KEY REFERENCES NivelEscolaridade (IdNivelEscolaridade)
)
GO
select *from NivelEscolaridade
SELECT * FROM Candidato
INSERT INTO Candidato VALUES 
('Hebert Richard', '04533335080', '2000-10-20', 'linkedin/hebertrichard', null, null, 'Masculino', 1, null, null, null, 1,'Devops',null,1, 2)
GO

CREATE TABLE ExperienciaProfissional (
	IdExperienciaProfissional INT PRIMARY KEY IDENTITY,
	NomeExperiencia VARCHAR (255),
	NomeEmpresa VARCHAR (255),
	Cargo VARCHAR (100),
	DataInicio DATE,
	DataFim DATE,
	EmpregoAtual BIT,
	DescricaoAtividade TEXT,
	IdCandidato INT FOREIGN KEY REFERENCES Candidato (IdCandidato)
)
GO

CREATE TABLE Habilidade (
	IdHabilidade INT PRIMARY KEY IDENTITY,
	NomeHabilidade VARCHAR(80) NOT NULL
)
GO

CREATE TABLE HabilidadeXCandidato
(
	IdHabilidadeCandidato INT PRIMARY KEY IDENTITY,
	IdHabilidade INT FOREIGN KEY REFERENCES HabIlidade (IdHabilidade),
	IdCandidato INT FOREIGN KEY REFERENCES Candidato (IdCandidato)
)
GO

CREATE TABLE Administrador (
	IdAdministrador INT PRIMARY KEY IDENTITY,
	NomeCompletoAdmin VARCHAR (255) NOT NULL,
	NIF CHAR(9) UNIQUE NOT NULL,
	UnidadeSenai VARCHAR (255),
	Departamento VARCHAR (255),
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario)
)
GO
Select * from Empresa
CREATE TABLE Empresa (
	IdEmpresa INT PRIMARY KEY IDENTITY,
	RazaoSocial VARCHAR (255) NOT NULL,
	NomeFantasia VARCHAR (255) NOT NULL,
	DescricaoEmpresa TEXT NOT NULL,
	NomeParaContato VARCHAR (255),
	Linkedin VARCHAR (255),
	Website VARCHAR (255),
	CNPJ CHAR (15) NOT NULL UNIQUE,
	CNAE CHAR (8) NOT NULL,
	NomePorte VARCHAR (20),
	IdEndereco INT FOREIGN KEY REFERENCES Endereco(IdEndereco)
)
GO
select * from Endereco

select * from Empresa
INSERT INTO Empresa VALUES 
('BRQ SOLUCOES EM INFORMATICA S.A', 'BRQ', 'Justus','Admin', 'linkedin/BRQ', NULL, '365420250001640', '62040000', 3, 1)
GO

CREATE TABLE TipoVaga (
	IdTipoVaga INT PRIMARY KEY IDENTITY,
	NomeTipoVaga VARCHAR (255) NOT NULL
)
GO

CREATE TABLE NivelVaga (
	IdNivelVaga INT PRIMARY KEY IDENTITY,
	NomeNivelVaga VARCHAR (255) NOT NULL
)
GO

CREATE TABLE Vaga (
	IdVaga INT PRIMARY KEY IDENTITY,
	NomeVaga VARCHAR (255) NOT NULL,
	DescricaoAtividade TEXT NOT NULL,
	DataInicio DATE NOT NULL,
	DataFinal DATE NOT NULL,
	LimiteDeInscricao INT,
	Localizacao VARCHAR (255) NOT NULL,
	Salario VARCHAR (255) NOT NULL,
	AceitaTrabalhoRemoto BIT,
	IdEmpresa INT FOREIGN KEY REFERENCES Empresa (IdEmpresa),
	IdTipoVaga INT FOREIGN KEY REFERENCES TipoVaga(IdTipoVaga),
	IdNivelVaga INT FOREIGN KEY REFERENCES NivelVaga(IdNivelVaga)
)
GO
select * from Vaga
INSERT INTO Vaga VALUES 
('Estagio em desenvolvimento de sistemas', 'jdhihedwodwijjdwijiw','17/12/2020', '30/12/2020', 40, 'Sâo Paulo', 'R$ 1080,00', 0, 3,2,null)
GO

CREATE TABLE Requisito
(
	IdRequisito INT PRIMARY KEY IDENTITY,
	NomeRequisito VARCHAR (200) NOT NULL
)
GO

CREATE TABLE RequisitoXVaga
(
	IdRequisitoVaga INT PRIMARY KEY IDENTITY,
	IdRequisito INT FOREIGN KEY REFERENCES Requisito (IdRequisito),
	IdVaga INT FOREIGN KEY REFERENCES Vaga (IdVaga)
)
GO

CREATE TABLE StatusInscricao (
	IdStatusInscricao INT PRIMARY KEY IDENTITY,
	NomeStatus VARCHAR (255) NOT NULL
)
GO

CREATE TABLE Inscricao (
	IdInscricao INT PRIMARY KEY IDENTITY,
	DataInscricao DATE NOT NULL,
	IdVaga INT FOREIGN KEY REFERENCES Vaga(IdVaga),
	IdStatusInscricao INT FOREIGN KEY REFERENCES StatusInscricao(IdStatusInscricao),
	IdCandidato INT FOREIGN KEY REFERENCES Candidato(IdCandidato)
)
GO



SELECT * FROM Inscricao
go
INSERT INTO Inscricao VALUES 
('31/08/2020',7,4,1)
GO


SELECT * FROM StatusInscricao

SELECT * FROM Vaga
INSERT INTO Vaga VALUES 
('Estagio em desenvolvimento de sistemas', 'jdhihedwodwijjdwijiw','17/12/2020', '30/12/2020', 40, 'Sâo Paulo', 'R$ 1080,00', 0, 1,2,null)
GO

SELECT * FROM Empresa

SELECT * FROM Candidato
INSERT INTO Candidato VALUES 
('Hebert Richard', '04533335080', '2000-10-20', 'linkedin/hebertrichard', null, null, null, 1, 1, 2)
GO


CREATE TABLE Estagio (
	IdEstagio INT PRIMARY KEY IDENTITY,
	DataInicio DATE NOT NULL,
	DataFinal DATE,
	NomeStatus VARCHAR (255) NOT NULL,
	IdInscricao INT FOREIGN KEY REFERENCES Inscricao (IdInscricao)
)
GO

CREATE TABLE Beneficio (
	IdBeneficio INT PRIMARY KEY IDENTITY,
	NomeBeneficio VARCHAR (255) NOT NULL
)
GO

CREATE TABLE BeneficioXVaga (
	IdBeneficioVaga INT PRIMARY KEY IDENTITY,
	IdBeneficio INT FOREIGN KEY REFERENCES Beneficio (IdBeneficio),
	IdVaga INT FOREIGN KEY REFERENCES Vaga (IdVaga)
)
GO
