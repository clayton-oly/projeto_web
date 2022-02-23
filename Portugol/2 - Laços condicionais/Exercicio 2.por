programa
{
	//Atividade 2 - Exercicio 2
	funcao inicio()
	{
		inteiro c 
		real n, ex = 0.0, salarioTotal = 0.0, salarioExcedente = 0.0


		escreva ("Digite seu codigo ")
		leia (c)

		escreva ("Digite o numero de horas trabalhadas ")
		leia (n)

		

		se (n > 50) {
			ex = n - 50
			salarioTotal = 50.0 * 10
			salarioExcedente = ex * 20
			salarioTotal = salarioTotal + salarioExcedente
			
			escreva ("o Salario total e ", salarioTotal, "\nSalario Excedente ", salarioExcedente)	
		}
		senao {
			salarioTotal = n * 10
			escreva ("o Salario total e ", salarioTotal, "\nSalario Excedente ", salarioExcedente)
			}	
	}
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 266; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */