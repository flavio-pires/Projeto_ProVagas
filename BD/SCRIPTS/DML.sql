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
	'Roberto da Silva', '21323423412', '1980/07/12','Ensino Medio Completo','B�sico','linkedin.com/a',null,'0',null,'1','Redes','Conhecimento avan�ado em JS',null,null,null,null,5,1
), (
	'Marina Barbosa', '87465748576', '1990/09/23','Cursando Ensino Superior','Avan�ado','linkedin.com/b',null,'1','Sou cega','0',null,'Conhecimento basico em C#','Tech Digital','Desenvolvedora C# Junior','1',null,6,4
)
GO


INSERT INTO Administrador VALUES (
	'Jos� Pereira','238475867','Unidade Ferroz�polis','Educa��o',1
), (
	'Luana Matias','284958675','Unidade Para�so','Educa��o',2
)

GO

INSERT INTO Empresa VALUES (
	'Escola SENAI de Inform�tica','SENAI de Inform�tica','M�dio','Lissandra Gomes','linkedin.com/senainfo',null,'74856475867475','6473875',2
), (
	'Escola SENAI de Mec�nica','SENAI Mec�nica','Grande','Julio Santos Silveira','linkedin.com/senaimech','empresa.com','74857485769374','7485693',4
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

INSERT INTO Vaga VALUES (
	'CLT .Net Junior','Buscando profissional qualificado nos recursos b�sicos de .NET','Conhecimento em l�gica de programa��o e linguagem C#','2020/09/04 00:00:00','2020/10/04 00:00:00',5,3
), (
	'PJ Java Senior','Buscando profissional qualificado nos recursos avan�ados de Java','Conhecimento em l�gica de programa��o e linguagem Java','2020/09/04 00:00:00','2020/10/04 00:00:00',6,1
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
), (
	2,1
), (
	3,2
)