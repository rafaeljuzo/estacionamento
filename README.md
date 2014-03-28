Estacionamento Basanela
==============

Sistema de Gerenciamento de Estacionamento

	•	Objetivo do sistema
O Sistema tem o objetivo de informatizar o gerenciamento de entradas e saídas de veículos de um estacionamento, bem como manter cadastro destes veículos e de seus proprietários.

	•	Requisitos Funcionais
O sistema deverá cadastrar:
	•	Clientes;
	•	Veículos;
	•	Clientes podem ser mensalistas ou avulsos;
	
Para Avulsos:
Não serão armazenadas informações do proprietário, apenas do veículo;
Haverá um preço para cada período (manhã, tarde e noite), pré-estabelecido. Quando o operador lançar a saída do veículo, o sistema deverá calcular o valor com base no período de entrada;
Para Mensalistas:
Poderá ter vários veículos em seu nome sem que isso altera o valor da mensalidade;
Para cada vencimento, o sistema deverá gerar a fatura automaticamente (bem como cálculo de juros por atraso, se for o caso) restando ao operador apenas imprimir um recibo com as datas que o veículo ocupou uma vaga (via do cliente) e dar baixa na fatura;
O sistema deverá ser capaz de elaborar uma lista com todos os clientes avulsos e mensais que realizaram pagamento durante o dia (separados por período), ou no mês todo;

	•	Requisitos Não Funcionais
O sistema deverá ter uma interface minimalista, além de mensagens de notificação claras e objetivas;


Banco de Dados

	No projeto de banco de dados até aqui, temos estruturado todo controle de entrada e saída de veículos no estacionamento. Ele é composto por nove tabelas, que estão listadas abaixo:

Estado:
	•	Armazena os 26 estados e o Distrito Federal.
	•	Campos:  codEstado (INTEGER[PK]); uf(CHAR); descricao(VARCHAR);

Cidade:
	•	Armazena as cidades brasileiras.
	•	Campos: codCidade (INTEGER[PK]); codEstado(INTEGER[FK]); descricao (VARCHAR);

Tipo:
	•	Armazena o tipo de veículo que o estacionamento atende: Carro, moto, etc.
	•	Campos: codTipo (INTEGER[PK]); descricao (VARCHAR);

Marca:
	•	Armazena uma marca de veículo, independente do tipo.
	•	Campos: codMarca (INTEGER[PK]); marca (VARCHAR);

Modelo:
	•	Armazena o modelo do veículo. Também independe do tipo de veículo.
	•	Campos: codModelo(INTEGER[PK]); codMarca (INTEGER[FK]); descricao (VARCHAR);

Veículo:
	•	Armazena todas as informações relevantes do veículo.
	•	Campos: placa (VARCHAR[PK]); codTipo (INTEGER[FK]); codMarca (INTEGER[FK]); codModelo (INTEGER[FK]);

Cliente:
	•	Armazena os dados referentes  ao cliente.
	•	Campos: codCliente (INTEGER[PK]); nome (VARCHAR); endereco (VARCHAR); codEstado (INTEGER[FK]); codCidade (INTEGER[FK]); telefone (CHAR); celular (CHAR);

ClienteXveiculo:
	•	Tabela de cardinalidade MxN que armazena o(s) veículo(s) de cada cliente. Tabela voltada unicamente para clientes mensalistas.
	•	Campos: codCliente (INTEGER[FK]); codVeiculo (INTEGER[FK]);

Movimento:
	•	Armazena o movimento de um veículo no estacionamento, seja mensal ou avulso.
	•	Campos: codMovimento (INTEGER[PK]); codCliente (INTEGER[FK]); codVeiculo (INTEGER[FK]); dataInicio (DATETIME); dataTermino (DATETIME); valor (DOUBLE);


