# language: pt-br
Funcionalidade: Cadastro de Modelos
	Para x
	Enquanto y
	Eu quero z

Cenário: Cadastra modelo com sucesso
	Dado que o código escolhido para o modelo foi de 'M01'
	E que o nome escolhido para o modelo foi de 'Modelo 01'
	Quando eu cadastrar o modelo
	Então um modelo deve ser cadastrado
	E o código do modelo cadastrado deve ser 'M01'
	E o nome do modelo cadastrado deve ser 'Modelo 01'
	
Cenário: Adiciona recurso de modelo sem recursos com sucesso
	Dado que um modelo foi cadastrado com sucesso
	E que um recurso de 'Tecido' foi necessário para esse modelo
	E que o custo desse recurso do modelo foi de R$ 12,00
	E que as unidades desse recurso do modelo foram de 1,2
	E que o tipo desse recurso do modelo foi 'Material'
	Quando eu adicionar esse recurso ao modelo
	Então esse modelo deve conter um recurso de 'Tecido' adicionado
	E o custo de produção desse modelo deve ser R$ 12,00
	E o custo desse recurso de modelo adicionado deve ser R$ 12,00
	E as unidades desse recurso de modelo adicionado devem ser 1,2
	E o custo por unidade desse recurso de modelo adicionado deve ser R$ 10,00
	E o tipo desse recurso de modelo adicionado deve ser 'Material'
	
Cenário: Adiciona recurso de modelo com recursos com sucesso
	Dado que um modelo foi cadastrado com sucesso
	E que 1,2 unidades do recurso 'Material' de 'Tecido' de R$ 12,00 foi adicionado para esse modelo
	E que um recurso de 'Zíper' foi necessário para esse modelo
	E que o custo desse recurso do modelo foi de R$ 1,50
	E que as unidades desse recurso do modelo foram de 2
	E que o tipo desse recurso do modelo foi 'Material'
	Quando eu adicionar esse recurso ao modelo
	Então esse modelo deve conter um recurso de 'Zíper' adicionado
	E o custo de produção desse modelo deve ser R$ 12,00
	E o custo desse recurso de modelo adicionado deve ser R$ 12,00
	E as unidades desse recurso de modelo adicionado devem ser 1,2
	E o custo por unidade desse recurso de modelo adicionado deve ser R$ 10,00
	E o tipo desse recurso de modelo adicionado deve ser 'Material'
