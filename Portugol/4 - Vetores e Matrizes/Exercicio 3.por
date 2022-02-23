programa {

    funcao inicio(){
    	
        inteiro n1 [4][6] = {{1, 2, 3, 4, 5, 6},
                         {1, 2, 3, 4, 5, 6},
                         {1, 2, 3, 4, 5, 6},
                         {1, 2, 3, 4, 5, 6}}

        inteiro n2 [4][6] = {{6, 5, 4, 3, 2, 1},
                         {6, 5, 4, 3, 2, 1},
                         {6, 5, 4, 3, 2, 1},
                         {6, 5, 4, 3, 2, 1}}

        inteiro m1 [4][6]
        inteiro m2 [4][6]

	   escreva ("\nMATRIZ DE SOMA\n")
	   
        para(inteiro i = 0; i<=3; i++){
            para(inteiro a = 0; a<=5; a++){
            	m1 [i][a] = n1 [i][a] + n2[i][a]
			escreva (m1[i][a] + "|")
            }
            escreva ("\n")
        }

	   escreva ("\nMATRIZ DE SUBTRACAO\n")
        para(inteiro i = 0; i<=3; i++){
            para(inteiro a = 0; a<=5; a++){
            	m2 [i][a] = n1 [i][a] - n2[i][a]
			escreva (m2[i][a] + "|")
            }
            escreva ("\n")
        }
    }
}
/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 950; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */