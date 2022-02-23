programa{

    funcao inicio(){
    	
        inteiro vetor[10] = {4,6,2,5,6,3,5,1,4,2}
        inteiro media= 0
        inteiro soma= 0
        inteiro p= 0 

        para (inteiro i = 0; i<= 9; i++){
        	escreva("\nOs lançamentos do dado foram: " + vetor[i])
        	soma = soma + vetor[i]
        	media = soma / 10
          se(vetor[i] == 6){
             p++
        	}
        }
        escreva("\n\n A média é: " + media)
        escreva("\n\n A quantidade do número de maior pontuação foi: " + p)
    }
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 391; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */