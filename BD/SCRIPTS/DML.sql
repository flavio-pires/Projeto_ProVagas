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

INSERT INTO Usuario VALUES (
	'a@email.com','xxx','999999999','Sauna','231','Calor','bloco x apto x','32112332',1,1
), (
	'b@email.com','xxx','999999998','Fogo','2314','Calor','Sem complementos','32112333',2,1
), (
	'c@email.com','xxx','999999997','Terra','23132','Barro','bloco x apto x','32112334',3,2
), (
	'd@email.com','xxx','999999996','Agua','4312','Mar','Sem complementos','32112335',4,2
), (
	'e@email.com','xxx','999999995','Ar','423','Vento','bloco x apto x','32112336',1,3
), (
	'f@email.com','xxx','999999994','Bichos','231','Natureza','bloco x apto x','32112332',2,3
)

GO

INSERT INTO Candidato VALUES (
	'Roberto da Silva', '21323423412', '1980/07/12','Ensino Medio Completo','Básico','linkedin.com/a',null,'0',null,'1','Redes','Conhecimento avançado em JS',null,null,null,null,5,1
), (
	'Marina Barbosa', '87465748576', '1990/09/23','Cursando Ensino Superior','Avançado','linkedin.com/b',null,'1','Sou cega','0',null,'Conhecimento basico em C#','Tech Digital','Desenvolvedora C# Junior','1',null,6,4
)
GO


INSERT INTO Administrador VALUES (
	'José Pereira','238475867','Unidade Ferrozópolis','Educação',1
), (
	'Luana Matias','284958675','Unidade Paraíso','Educação',2
)

GO

INSERT INTO Empresa VALUES (
	'Escola SENAI de Informática','SENAI de Informática','Médio','Lissandra Gomes','linkedin.com/senainfo',null,'74856475867475','6473875',2
), (
	'Escola SENAI de Mecânica','SENAI Mecânica','Grande','Julio Santos Silveira','linkedin.com/senaimech','empresa.com','74857485769374','7485693',4
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

INSERT INTO Vaga VALUES (
	'CLT .Net Junior','Buscando profissional qualificado nos recursos básicos de .NET','Conhecimento em lógica de programação e linguagem C#','2020/09/04 00:00:00','2020/10/04 00:00:00',5,3
), (
	'PJ Java Senior','Buscando profissional qualificado nos recursos avançados de Java','Conhecimento em lógica de programação e linguagem Java','2020/09/04 00:00:00','2020/10/04 00:00:00',6,1
)

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
	1,1,3
), (
	2,2,4
)

GO

INSERT INTO Estagio VALUES (
	'2020/09/04','2022/09/04',3,5
), (
	'2020/09/14','2022/09/14',4,6
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
), (
	2,1
), (
	3,2
)