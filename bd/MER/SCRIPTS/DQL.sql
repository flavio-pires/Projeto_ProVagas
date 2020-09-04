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


-- COM INNER JOIN

-- Cidade
SELECT IdCidade as Cidade,NomeCidade, NomeEstado, Cidade.IdEstado as Estado
FROM Cidade
INNER JOIN Estado on Estado.IdEstado = Cidade.IdEstado

-- Usuario
SELECT U.IdUsuario as Usuario, Email, Senha, Telefone, Rua, Num as Número, Complemento, CEP, U.IdCidade as Cidade, NomeCidade, U.IdTipoUsuario as TipoUsuario, NomeTipoUsuario
FROM Usuario U
INNER JOIN Cidade C on C.IdCidade = U.IdCidade
INNER JOIN TipoUsuario TU on TU.IdTipoUsuario = U.IdCidade

-- Candidato
SELECT C.IdCandidato as Candidato, NomeCompletoCandidato, CPF, DataNascimento, C.IdUsuario as Usuario, Email, Senha, Telefone, Rua, Num as Número, Complemento, CEP, C.IdGenero as Genero, NomeGenero
FROM Candidato C
INNER JOIN Usuario U on U.IdUsuario = C.IdUsuario
INNER JOIN Genero G on G.IdGenero = C.IdGenero

--Administrador
SELECT A.IdAdministrador as Administrador, NomeCompletoAdmin, A.IdUsuario as Usuario, Email, Senha, Telefone, Rua, Num as Número, CEP
FROM Administrador A
INNER JOIN Usuario U on U.IdUsuario = A.IdUsuario

-- Empresa
SELECT E.IdEmpresa as Empresa, RazaoSocial, NomeFantasia, Porte, CNPJ, CNAE, E.IdUsuario as Usuario, Email, Senha, Telefone, Rua, Num as Número, Complemento, CEP
FROM Empresa E 
INNER JOIN Usuario U on U.IdUsuario = E.IdUsuario

-- Vaga
SELECT V.IdVaga as Vaga, NomeVaga, DescricaoAtividade, DescricaoRequisito, DataInicio, DataFinal, V.IdEmpresa as Empresa, RazaoSocial, NomeFantasia, Porte, CNPJ, CNAE, V.IdTipoVaga as TipoVaga, NomeTipoVaga
FROM Vaga V
INNER JOIN Empresa E on E.IdEmpresa = V.IdEmpresa
INNER JOIN TipoVaga TV on TV.IdTipoVaga = V.IdTipoVaga 

-- Inscricao
SELECT I.IdInscricao as Inscricao, NomeVaga, DescricaoAtividade, DescricaoRequisito, DataInicio, DataFinal, I.IdStatusInscricao as Status, NomeStatus, I.IdCandidato as Candidato, NomeCompletoCandidato, CPF, DataNascimento
FROM Inscricao I
INNER JOIN Vaga V on V.IdVaga = I.IdVAga
INNER JOIN StatusInscricao SI on SI.IdStatusInscricao = I.IdStatusInscricao
INNER JOIN Candidato C on C.IdCandidato = I.IdCandidato

-- Estagio
SELECT E.IdEstagio as Estagio, DataInicio, DataFim, E.IdCandidato as Candidato, NomeCompletoCandidato, CPF, DataNascimento, E.IdEmpresa as Empresa, RazaoSocial, NomeFantasia, Porte, CNPJ, CNAE
FROM Estagio E
INNER JOIN Candidato C on C.IdCandidato = E.IdCandidato
INNER JOIN Empresa Em on Em.IdEmpresa = E.IdEmpresa

-- BenefecioVaga
SELECT BV.IdBeneficioVaga as BenefecioXVaga, BV.IdBeneficio as Beneficio, NomeBeneficio, BV.IdVaga as Vaga, NomeVaga, DescricaoAtividade, DescricaoRequisito, DataInicio, DataFinal
FROM BeneficioxVaga BV
INNER JOIN Beneficio B on B.IdBeneficio = BV.IdBeneficio
INNER JOIN Vaga V on V.IdVaga = BV.IdVaga