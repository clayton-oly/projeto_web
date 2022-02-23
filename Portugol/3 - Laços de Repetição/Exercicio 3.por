programa
 {
	
	funcao inicio(){

		real num, soma = 0.0, media = 0.0, quant = 0.0

		escreva("Digite um numero ")
		leia(num)
		
		enquanto (num >= 0) {
			soma = num + soma
			quant = quant+1
			media = soma/quant
			escreva("Digite um numero ")
			leia(num)
		}
			escreva("\nSoma total ", soma)	
			escreva("\nQuantidade de valores digitados ",quant)
			escreva("\nMedia ",media)
	}
}

/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 289; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */