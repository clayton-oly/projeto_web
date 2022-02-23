programa {
	
	funcao inicio(){

		inteiro maior = 0
		inteiro vetor [5]
		
		para (inteiro i = 0; i<= 4; i++){
			escreva ("Digite um valor ")
			leia(vetor[i])
			se(vetor[i] > maior) {
				maior = vetor[i]
			}
		}
		escreva ("O valor maior e ", maior)
	}
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 191; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = {vetor, 6, 10, 5};
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */