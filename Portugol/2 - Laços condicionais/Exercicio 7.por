programa {
	
	funcao inicio(){
		
		real base, altura, resultado

		escreva ("Digite o valor da base do triangulo ")
		leia(base)
		
		escreva ("Digite o valor da altura do triangulo ")
		leia(altura)

		se (base > 0 e altura > 0){
		resultado = base*altura
		resultado = resultado/2
		escreva ("o valor da area do triangulo e ", resultado, " cm")
		}
		senao {
		escreva ("Numero digitado menor ou igual a zero")
		}
		
	}
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 301; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */