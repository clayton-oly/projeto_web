programa
{
	//Atividade 2 - Exercicio 3
	funcao inicio()
	{
		real n1, n2, n3, n4, r1, r2, r3, r4

		escreva ("Digite o primeiro numero ")
		leia (n1)
		
		escreva ("Digite o segundo numero ")
		leia (n2)

		escreva ("Digite o terceiro numero ")
		leia (n3)

		escreva ("Digite o quarto numero ")
		leia (n4)

		r1 = n1 * n1
		r2 = n2 * n2
		r3 = n3 * n3
		r4 = n4 * n4

		se (r3 >=1000){
			escreva ("o resultado do terceiro quadrado e ", r3)
		}
		senao {
			escreva ("O valor lido e ", n1 , " o resultado do primeiro quadrado e ", r1)
			escreva ("\nO valor lido e ", n2 , " o resultado do segundo quadrado e ", r2)
			escreva ("\nO valor lido e ", n3 , " o resultado do terceiro quadrado e ", r3)
			escreva ("\nO valor lido e ", n4 , " o resultado do quarto quadrado e ", r4)
			}
			
	}
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 143; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */