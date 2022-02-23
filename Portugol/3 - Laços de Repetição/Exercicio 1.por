programa {

	inclua biblioteca Matematica --> mat
	
	funcao inicio() {

		inteiro salario = 0, filhos, mediaSalario = 0, mediaFilhos = 0, maiorSal = 0
		inteiro salariototal = 0, filhostotal = 0
		real por = 0.0, qtd = 0.0
		
		para (inteiro n = 0; n <4 ;n++) {
			escreva("\nDigite o salario ")
			leia(salario)
			
			escreva("\nDigite o numero de filhos ")
			leia(filhos)

			salariototal = salario + salariototal
			filhostotal = filhos + filhostotal
			mediaSalario = salariototal/3
			mediaFilhos = filhostotal/3

			se (salario <= 100){
				qtd = qtd + 1
			}
			se (salario > maiorSal){
				maiorSal = salario
			}
			por  = (qtd/3)*100
		}
		escreva("\nMedia do salario da populacao ", mediaSalario)
		escreva("\nMedia do numero de filhos ", mediaFilhos)
		escreva("\nMaior salario ", maiorSal)
		escreva("\nPercentual de pessoas com salario ate R$100,00 ",mat.arredondar(por,2), "%")
	}
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 645; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */