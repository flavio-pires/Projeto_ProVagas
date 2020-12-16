-- DML

USE ProVagas

GO


INSERT INTO TipoUsuario VALUES (
	'Candidato'
), (
	'Empresa'
), (
	'Administrador'
)

GO

INSERT INTO Usuario VALUES 
('gugugacasco@gmail.com', '(11) 970707070', '123456789', 1), 
('posarle@hotmail.com', '(11) 970707070', '123456789', 3),
('brq@brq.com', '(11) 954616677', '123456789', 2)
GO

INSERT INTO Endereco VALUES
('Rua Carlos Alves',  '12', 'Vila do chaves', null, '000000010', 'S�o Paulo', 'S�o Paulo', 1),
('Alameda Bar�o de Limeira',  '539', 'Santa Cecilia', null, '01202-001', 'S�o Paulo', 'SP', 2),
('R. Boa Vista', '254', 'Centro Hist�rico de S�o Paulo', null, '01014-000', 'S�o Paulo', 'SP', 3 )
GO

INSERT INTO NivelEscolaridade VALUES 
('Fundamental'), ('M�dio'), ('Tecnico'), ('Gradua��o'), ('P�s-gradua��o'), ('Mestrado'), ('Doutorado')
GO

INSERT INTO Candidato VALUES 
('Hebert12 Richard', '04533130080', '2000-10-20', 'linkedin/hebertrichard', null, null,'masculino', 0, null, null, null, 1,'Desenvolvimento de Sistemas', null, 1, 3)
GO


INSERT INTO ExperienciaProfissional VALUES 
('Desenvolvedor junior BACK-END', 'BRQ', 'Desenvolvedor junior', '2020-08-15', '2022-08-15', 0,'IDEJFIEIEJDEDJEDEJDIEJDEIJDEI', 1)
GO

INSERT INTO Habilidade VALUES 
('C#'), ('Angular'), ('Phyton'), ('JavaScript'), ('ReactJs'), ('MongoDB'), ('SqlServer')
GO

INSERT INTO HabilidadeXCandidato VALUES
(1, 1), (2,1)
GO

INSERT INTO Administrador VALUES 
('Roberto Possarle', '123456789', 'Unidade Santa Cecilia', 'Gest�o de pessoas', 2)
GO


INSERT INTO Empresa VALUES 
('BRQ SOLUCOES EM INFORMATICA S.A', 'BRQ', 'Paix�o em transformar neg�cios com tecnologia.'
, 'Justus', 'linkedin/BRQ', NULL, '365420250001640', '62040000', 'Grande', 3)
GO

INSERT INTO TipoVaga VALUES 
('CLT'), ('Estagio'), ('Pj')
GO

INSERT INTO NivelVaga VALUES  ('Junior'), ('Pleno'), ('Senior')
GO

INSERT INTO Vaga VALUES 
('Estagio em desenvolvimento de sistemas', ' Executar o desenvolvimento de sistemas informatizados',
'17/12/2020', '30/12/2020', 40, 'S�o Paulo', 'R$ 1080,00', 0, 1, 2, 1)
GO


INSERT INTO Requisito VALUES 
('C#')
GO

INSERT INTO RequisitoXVaga VALUES
(1,2)
GO

INSERT INTO StatusInscricao VALUES
('Aprovado'), ( 'Cancelado'), ('Reprovado'), ('Em aguardo')
GO

INSERT INTO Inscricao VALUES 
('31/08/2020',1,4,4)
GO

SELECT * FROM Candidato

INSERT INTO Estagio VALUES 
('2020/09/04','2022/09/04','Em andamento', 1)
GO

INSERT INTO Beneficio VALUES
('Vale Refei��o'), ('Vale Alimenta��o'), ('Vale Transporte'), ('Estacionamento no local'), ('Assist�ncia M�dica'), ('Assist�ncia Odontol�gica'), ('Cesta B�sica'), ('Seguro de Vida'),  ('Hor�rio Flex�vel'), ('Aux�lio Creche')
GO

INSERT INTO BeneficioXVaga VALUES 
(1,2)
GO

INSERT INTO Contratos VALUES
('2020/09/04','2022/09/04', 'Teste', 'Teste')
GO
SELECT * FROM Vaga

--------------INSERT DAS TABELAS ANTIGAS------------------------

/*

INSERT INTO Genero VALUES (
	'Masculino'
), (
	'Feminino'
), (
	'Outros'
), (
	'Prefiro n�o informar'
)

GO

INSERT INTO Estado VALUES (
		'S�o Paulo'
	), (
		'Santa Catarina'
	), (
		'Minas Gerais'
	), (
		'Goi�s'
	),  (
		'Bahia'
	),
	 (
		'Paran�'
	),
	 (
		'Cear�'
	),
	 (
		'Rio Grande do Sul'
	),
	 (
		'Amazonas'
	),
	 (
		'Pernambuco'
	),
	 (
		'Par�'
	),
	 (
		'Mato Grosso'
	),
	 (
		'Para�ba'
	),
	 (
		'Sergipe'
	),
	 (
		'Espirito Santo'
	),
	 (
		'Piau�'
	),
	 (
		'Maranh�o'
	),
	 (
		'Rio Grande do Norte'
	),
	 (
		'Rond�nia'
	), (
		'Amap�'
	),  (
		'Tocantins'
	),
	 (
		'Alagoas'
	), (
		'Rio de Janeiro'
	), (
		'Mato Grosso do Sul'
	), (
		'Roraima'
	), (
		'Bras�lia'
	), (
		'Acre'
)

GO


INSERT INTO Cidade VALUES (
	'S�o Paulo',1
), (
	'Florian�polis',2
), (
	'Belo Horizonte',3
), (
	'Goi�nia',4
)

GO

INSERT INTO PCD VALUES 
('Defici�ncia f�sica'), ('Defici�ncia auditiva'), ('Defici�ncia visual'), ('Defici�ncia mental'), ('Defici�ncia m�ltipla'), ('Nenhuma')
GO

INSERT INTO PcdXCandidato VALUES 
(0, 1, 6)
GO

INSERT INTO NivelIdioma VALUES 
('Basico'), ('Tecnico'), ('Intermediario'), ('Avan�ado')
GO

INSERT INTO Idioma VALUES 
('Ingl�s', 2,1)
GO

INSERT INTO CursoSENAI VALUES 
(1, 'Tecnico em desenvolvimento de sistemas', 1)
GO

INSERT INTO CursoExtraCurricular VALUES 
('MBA - Ges�o de projeto', 'MBA', null, '2015-08-14', '2018-12-20', 1)
GO

INSERT INTO PorteEmpresa VALUES 
('Pequena'), ('M�dio'), ('Grande')
GO

INSERT INTO StatusEstagio VALUES
('Evadido'), ('Em andamento'), ('Concluido')
GO


*/