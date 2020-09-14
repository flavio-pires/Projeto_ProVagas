-- DML

USE ProVagas

GO

INSERT INTO TipoUsuario VALUES (
	'Administrador'
), (
	'Empresa'
), (
	'Candidato'
)

GO

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

INSERT INTO Endereco VALUES ('Rua narnia', '327', 'Vila nova savoia', null, '00000000', 1)

GO

INSERT INTO Usuario VALUES ('gagag@gmail.com', null, '1234', 3, 1)

GO

iNSERT INTO NivelEscolaridade VALUES (
'Ensino medio completo'), ('Ensino superior')
GO 

iNSERT INTO NivelIngles VALUES (
'Basico'), ('Intermediario'), ('Tecnico'), ('Avan�ado')
GO

INSERT INTO Candidato VALUES 
('Hebert richard', '51687947888', '28/02/2002', 'ydgeygdye', '', 0, 'N�o possui deficiencia', 1, 'Desenvolvimento de sistemas', 'SENAI', 'FULLSTACK', '14/08/2020', '14/08/2022', 0, 'HFHFHFUERFHU',1,2,1,2)
GO

INSERT INTO Habilidades VALUES ('C#'), ('ANGULAR')
GO

INSERT INTO HabilidadeXCandidato VALUES (1,1)

INSERT INTO Administrador VALUES (
	'Jos� Pereira','238475867','Unidade Ferroz�polis','Educa��o',1
)
GO

INSERT INTO Empresa VALUES (
	'Escola SENAI de Inform�tica','SENAI de Inform�tica','M�dio','Lissandra Gomes','linkedin.com/senainfo',null,'74856475867475','6473875',1
)
GO

INSERT INTO TipoVaga VALUES (
	'CLT'
), (
	'PJ'
), (
	'Est�gio'
)

GO

INSERT INTO Vaga VALUES ('Estagio fullstack', 'dhfgegfehgf', '31/08/2020', '18/09/2020', 1, 3)

GO

INSERT INTO Requisitos VALUES ('C#')
GO

INSERT INTO RequisitosXVaga VALUES (1,1)
GO

INSERT INTO StatusInscricao VALUES (
	'Aprovado'
), ( 
	'Cancelado'
), (
	'Reprovado'
), (
	'Em aguardo'
)

GO

INSERT INTO Inscricao VALUES (
'31/08/2020',	1,1,1
)

GO

INSERT INTO StatusEstagio VALUES ('Evadido'), ('Em andamento'), ('Concluido')
GO

INSERT INTO Estagio VALUES (
	'2020/09/04','2022/09/04',1,1
)
GO

INSERT INTO Beneficio VALUES (
	'Vale Refei��o'
), (
	'Vale Alimenta��o'
), (
	'Vale Transporte'
), (
	'Estacionamento no local'
), (
	'Assist�ncia M�dica'
), (
	'Assist�ncia Odontol�gica'
), (
	'Cesta B�sica'
), (
	'Seguro de Vida'
),  (
	'Hor�rio Flex�vel'
), (
	'Aux�lio Creche'
)

GO

INSERT INTO BeneficioXVaga VALUES (
	1,1
)