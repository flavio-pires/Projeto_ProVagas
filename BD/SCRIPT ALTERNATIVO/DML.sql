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
	'Prefiro não informar'
)

GO


INSERT INTO Estado VALUES (
		'São Paulo'
	), (
		'Santa Catarina'
	), (
		'Minas Gerais'
	), (
		'Goiás'
	),  (
		'Bahia'
	),
	 (
		'Paraná'
	),
	 (
		'Ceará'
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
		'Pará'
	),
	 (
		'Mato Grosso'
	),
	 (
		'Paraíba'
	),
	 (
		'Sergipe'
	),
	 (
		'Espirito Santo'
	),
	 (
		'Piauí'
	),
	 (
		'Maranhão'
	),
	 (
		'Rio Grande do Norte'
	),
	 (
		'Rondônia'
	), (
		'Amapá'
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
		'Brasília'
	), (
		'Acre'
)

GO

INSERT INTO Cidade VALUES (
	'São Paulo',1
), (
	'Florianópolis',2
), (
	'Belo Horizonte',3
), (
	'Goiânia',4
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
'Basico'), ('Intermediario'), ('Tecnico'), ('Avançado')
GO

INSERT INTO Candidato VALUES 
('Hebert richard', '51687947888', '28/02/2002', 'ydgeygdye', '', 0, 'Não possui deficiencia', 1, 'Desenvolvimento de sistemas', 'SENAI', 'FULLSTACK', '14/08/2020', '14/08/2022', 0, 'HFHFHFUERFHU',1,2,1,2)
GO

INSERT INTO Habilidades VALUES ('C#'), ('ANGULAR')
GO

INSERT INTO HabilidadeXCandidato VALUES (1,1)

INSERT INTO Administrador VALUES (
	'José Pereira','238475867','Unidade Ferrozópolis','Educação',1
)
GO

INSERT INTO Empresa VALUES (
	'Escola SENAI de Informática','SENAI de Informática','Médio','Lissandra Gomes','linkedin.com/senainfo',null,'74856475867475','6473875',1
)
GO

INSERT INTO TipoVaga VALUES (
	'CLT'
), (
	'PJ'
), (
	'Estágio'
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
	'Vale Refeição'
), (
	'Vale Alimentação'
), (
	'Vale Transporte'
), (
	'Estacionamento no local'
), (
	'Assistência Médica'
), (
	'Assistência Odontológica'
), (
	'Cesta Básica'
), (
	'Seguro de Vida'
),  (
	'Horário Flexível'
), (
	'Auxílio Creche'
)

GO

INSERT INTO BeneficioXVaga VALUES (
	1,1
)