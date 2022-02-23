programa {
	
	funcao inicio() {

		inteiro soma = 0

		para (inteiro n = 1; n <= 500; n++) { 
			
			se (n%2 != 0)	{
				se (n %3 == 0) {
				soma = soma + n			
				}
			}		
		}	
		escreva ("\n",soma)		
	}
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 205; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */