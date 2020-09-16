-- DDL
use master;

drop database ProVagas;

CREATE DATABASE ProVagas

GO

USE ProVagas

GO

CREATE TABLE TipoUsuario (
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	NomeTipoUsuario VARCHAR (255) NOT NULL 
)

GO

CREATE TABLE Genero (
	IdGenero INT PRIMARY KEY IDENTITY,
	NomeGenero VARCHAR (255) NOT NULL
)

GO

CREATE TABLE Estado (
	IdEstado INT PRIMARY KEY IDENTITY,
	NomeEstado VARCHAR (255) NOT NULL
)

GO

CREATE TABLE  Cidade (
	IdCidade INT PRIMARY KEY IDENTITY,
	NomeCidade VARCHAR (255) NOT NULL,
	IdEstado INT FOREIGN KEY REFERENCES Estado(IdEstado) 
)

GO

CREATE TABLE Endereco (
	IdEndereco INT PRIMARY KEY IDENTITY,
	Rua VARCHAR (255) NOT NULL,
	Num VARCHAR (10) NOT NULL,
	Bairro VARCHAR (100) NOT NULL,
	Complemento VARCHAR (20),
	CEP CHAR(8) NOT NULL,
	IdCidade INT FOREIGN KEY REFERENCES Cidade(IdCIdade)
)

GO

CREATE TABLE Usuario (
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR (255) NOT NULL UNIQUE,
	Telefone VARCHAR (20),
	Senha VARCHAR (64) NOT NULL,
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(IdTIpoUsuario),
	IdEndereco INT FOREIGN KEY REFERENCES Endereco(IdEndereco) 
)

GO

CREATE TABLE NivelEscolaridade (
	IdNivelEscolaridade INT PRIMARY KEY IDENTITY,
	Escolaridade VARCHAR (60) 
)

GO

CREATE TABLE NivelIngles (
	IdNivelIngles INT PRIMARY KEY IDENTITY,
	Ingles VARCHAR (30)
)

GO

CREATE TABLE Candidato (
	IdCandidato INT PRIMARY KEY IDENTITY,
	NomeCompletoCandidato VARCHAR (255) NOT NULL,
	CPF CHAR (11) UNIQUE NOT NULL,
	DataNascimento DATE NOT NULL,
	Linkedin VARCHAR (200),
	FotoPerfil IMAGE,
	PossuiDeficiencia BIT NOT NULL,
	Deficiencia VARCHAR (255),
	CursandoSENAI BIT NOT NULL,
	Curso VARCHAR(255) not null,
	NomeEmpresaExperienciaProfissional VARCHAR (255),
	Cargo VARCHAR (50),
	DataInicio DATE,
	DataFim DATE,
	EmpregoAtual BIT,
	DescriçãoAtividades TEXT,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario (IdUsuario),
	IdGenero INT FOREIGN KEY REFERENCES Genero (IdGenero),
	IdNivelIngles INT FOREIGN KEY REFERENCES NivelIngles (IdNivelIngles),
	IdNivelEscolaridade INT FOREIGN KEY REFERENCES NivelEscolaridade (IdNivelEscolaridade)
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
	UnidadeSENAI VARCHAR (255),
	Departamento VARCHAR (255),
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario)
)

GO

CREATE TABLE Empresa (
	IdEmpresa INT PRIMARY KEY IDENTITY,
	RazaoSocial VARCHAR (255) NOT NULL,
	NomeFantasia VARCHAR (255) NOT NULL,
	PorteEmpresa VARCHAR (255) NOT NULL,
	NomeParaContato VARCHAR (255),
	Linkedin VARCHAR (255),
	Website VARCHAR (255),
	CNPJ CHAR (15) NOT NULL UNIQUE,
	CNAE CHAR (8) NOT NULL UNIQUE,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) 
)

GO

CREATE TABLE TipoVaga (
	IdTipoVaga INT PRIMARY KEY IDENTITY,
	NomeTipoVaga VARCHAR (255) NOT NULL
)

GO

CREATE TABLE Vaga (
	IdVaga INT PRIMARY KEY IDENTITY,
	NomeVaga VARCHAR (255) NOT NULL,
	DescricaoAtividade TEXT NOT NULL,
	DataInicio DATE NOT NULL,
	DataFinal DATE NOT NULL,
	IdEmpresa INT FOREIGN KEY REFERENCES Empresa (IdEmpresa),
	IdTipoVaga INT FOREIGN KEY REFERENCES TipoVaga(IdTipoVaga)
)

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

CREATE TABLE StatusEstagio (
	IdStatusEstagio INT PRIMARY KEY IDENTITY,
	NomeStatus VARCHAR (255) NOT NULL
)

GO

CREATE TABLE Estagio (
	IdEstagio INT PRIMARY KEY IDENTITY,
	DataInicio DATE NOT NULL,
	DataFinal DATE,
	IdInscricao INT FOREIGN KEY REFERENCES Inscricao (IdInscricao),
	IdStatusEstagio INT FOREIGN KEY REFERENCES StatusEstagio (IdStatusEstagio)
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

