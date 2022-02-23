programa
{
	//Atividade 2 - Exercicio 1
	funcao inicio()
	{
		real p, m = 0.0 , ex = 0.0

		escreva ("Digite o peso em quilos ")
		leia (p)

		se (p > 50) {
			ex = p - 50
			m = ex * 4
			escreva ("o valor da multa e ", m, "\npeso em excesso e ", ex, "\no peso e ", p)
		}
		senao {
			escreva ("o valor da multa e ", m, "\npeso em excesso e ", ex, "\no peso e ", p)
			}
		
	}
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 39; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */