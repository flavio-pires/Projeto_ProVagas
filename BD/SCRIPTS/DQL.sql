-- DQL
-- Consultas sem INNERJOIN

USE ProVagas

GO

--TipoUsuario
SELECT IdTipoUsuario, NomeTipoUsuario as TipoUsuario FROM TipoUsuario
-- Genero
SELECT IdGenero as Genero, NomeGenero FROM Genero
-- Estado
SELECT IdEstado as Estado, NomeEstado FROM Estado
--TipoVaga
SELECT IdTipoVaga as TipoVaga, NomeTipoVaga FROM TipoVaga
--StatusInscricao
SELECT IdStatusInscricao as Status, NomeStatus FROM StatusInscricao
--Beneficio
SELECT IdBeneficio as Beneficio, NomeBeneficio FROM Beneficio
--NivelEscolaridade
SELECT IdNivelEscolaridade as NivelEscolaridade, Escolaridade FROM NivelEscolaridade
--NivelIngles
SELECT IdNivelIngles as NivelIngles, Ingles FROM NivelIngles
--StatusEstagio
SELECT IdStatusEstagio as StatusEstagio, NomeStatus as Status FROM StatusEstagio

-- COM INNER JOIN

-- Cidade
SELECT IdCidade as Cidade,NomeCidade, NomeEstado, Cidade.IdEstado as Estado
FROM Cidade
INNER JOIN Estado on Estado.IdEstado = Cidade.IdEstado

--Endereco

SELECT IdEndereco as Endereco, Telefone, Rua, Num as Numero, Bairro, Complemento, CEP, E.IdCidade
FROM Endereco E 
INNER JOIN Cidade C on C.IdCidade = E.IdCidade

-- Usuario
SELECT U.IdUsuario as Usuario, Email, Senha, U.IdEndereco as Endereco, Telefone, Rua, Num as Número, Bairro, Complemento, CEP, E.IdCidade as Cidade, 
U.IdTipoUsuario as TipoUsuario, NomeTipoUsuario
FROM Usuario U
INNER JOIN Endereco E on E.IdEndereco = U.IdEndereco
INNER JOIN TipoUsuario TU on TU.IdTipoUsuario = U.IdTipoUsuario

-- Candidato
SELECT C.IdCandidato as Candidato, NomeCompletoCandidato, CPF, DataNascimento, Linkedin, FotoPerfil, PossuiDeficiencia, 
Deficiencia, CursandoSENAI, Curso, Habilidades, NomeEmpresaExperienciaProfissional, Cargo, EmpregoAtual, Atividades, C.IdUsuario as Usuario, Email,
U.IdEndereco as Endereco, C.IdGenero as Genero, NomeGenero, C.IdNivelEscolaridade as NivelEscolaridade, Escolaridade, C.IdNivelIngles
as NivelIngles, Ingles
FROM Candidato C
INNER JOIN Usuario U on U.IdUsuario = C.IdUsuario
INNER JOIN Genero G on G.IdGenero = C.IdGenero
INNER JOIN NivelEscolaridade NE on NE.IdNivelEscolaridade = C.IdNivelEscolaridade
INNER JOIN NivelIngles NI ON NI.IdNivelIngles = C.IdNivelIngles

--Administrador
SELECT A.IdAdministrador as Administrador, NomeCompletoAdmin, NIF, UnidadeSenai, Departamento,  A.IdUsuario as Usuario, Email, Senha, U.IdEndereco as Endereco
FROM Administrador A
INNER JOIN Usuario U on U.IdUsuario = A.IdUsuario

-- Empresa
SELECT E.IdEmpresa as Empresa, RazaoSocial, NomeFantasia, PorteEmpresa as Porte, NomeParaContato, Linkedin, WebSite, CNPJ, CNAE, E.IdUsuario as Usuario, 
Email, U.IdEndereco as Endereco
FROM Empresa E 
INNER JOIN Usuario U on U.IdUsuario = E.IdUsuario

-- Vaga
SELECT V.IdVaga as Vaga, NomeVaga, DescricaoAtividade, DescricaoRequisito, DataInicio, DataFinal, V.IdEmpresa as Empresa, RazaoSocial, NomeFantasia, 
PorteEmpresa as Porte, NomeParaContato, Linkedin, WebSite, CNPJ, CNAE, V.IdTipoVaga as TipoVaga, NomeTipoVaga
FROM Vaga V
INNER JOIN Empresa E on E.IdEmpresa = V.IdEmpresa
INNER JOIN TipoVaga TV on TV.IdTipoVaga = V.IdTipoVaga 

-- Inscricao
SELECT I.IdInscricao as Inscricao, NomeVaga, DescricaoAtividade, DescricaoRequisito, DataInicio, DataFinal, I.IdStatusInscricao as Status, NomeStatus,
I.IdCandidato as Candidato, C.IdUsuario as Usuario, C.IdGenero as Genero, C.IdNivelEscolaridade as NivelEscolaridade, C.IdNivelIngles as NivelIngles
FROM Inscricao I
INNER JOIN Vaga V on V.IdVaga = I.IdVAga
INNER JOIN StatusInscricao SI on SI.IdStatusInscricao = I.IdStatusInscricao
INNER JOIN Candidato C on C.IdCandidato = I.IdCandidato

-- Estagio
SELECT E.IdEstagio as Estagio, E.DataInicio, E.DataFinal, E.IdStatusEstagio as StatusEstagio, NomeStatus as Status, E.IdInscricao as Inscricao,
DataInscricao, I.IdVaga as Vaga, I.IdStatusInscricao as StatusInscricao, NomeStatus as Status, I.IdCandidato as Candidato, I.IdVaga as Vaga, V.IdEmpresa as 
Empresa
FROM Estagio E
INNER JOIN StatusEstagio SE on SE.IdStatusEstagio = E.IdStatusEstagio
INNER JOIN Inscricao I on I.IdInscricao = E.IdInscricao
INNER JOIN Vaga V on V.IdVaga = I.IdVaga

-- BenefecioVaga
SELECT BV.IdBeneficioVaga as BenefecioXVaga, BV.IdBeneficio as Beneficio, NomeBeneficio, BV.IdVaga as Vaga, NomeVaga, DescricaoAtividade, DescricaoRequisito, DataInicio, DataFinal
FROM BeneficioxVaga BV
INNER JOIN Beneficio B on B.IdBeneficio = BV.IdBeneficio
INNER JOIN Vaga V on V.IdVaga = BV.IdVaga