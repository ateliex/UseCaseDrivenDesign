# language: pt-br
Funcionalidade: Planejamento Comercial

Cenário: Cria plano comercial com sucesso
	Dado que o código escolhido para o plano comercial foi 'P01'
	E que o nome escolhido para o plano comercial foi de 'Atacado'
	E que a data escolhida para o plano comercial foi de '31/12/2021'
	E que a renda mensal bruta declarada para o plano comercial foi de R$ 6.000,00
	Quando eu criar o plano comercial
	Então um plano comercial deve ser criado
	E o código do plano comercial criado deve ser 'P01'
	E o nome do plano comercial criado deve ser 'Atacado'
	E a data do plano comercial criado deve ser '31/12/2021'
	E a renda mensal bruta declarada no plano comercial criado deve ser de R$ 6.000,00