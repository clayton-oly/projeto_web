programa {
	
	// ATIVIDADE 2
	funcao inicio() {

		inteiro dias, anos, meses

		escreva ("Digite a sua idade em dias ")
		leia (dias)

		anos = dias/365
		meses = dias/30
		dias = (dias%365)%30
		
		escreva (anos, " anos\n", meses," meses\n", dias," dias")
		
	}
}

/* $$$ Portugol Studio $$$ 
 * 
 * Esta seção do arquivo guarda informações do Portugol Studio.
 * Você pode apagá-la se estiver utilizando outro editor.
 * 
 * @POSICAO-CURSOR = 265; 
 * @PONTOS-DE-PARADA = ;
 * @SIMBOLOS-INSPECIONADOS = ;
 * @FILTRO-ARVORE-TIPOS-DE-DADO = inteiro, real, logico, cadeia, caracter, vazio;
 * @FILTRO-ARVORE-TIPOS-DE-SIMBOLO = variavel, vetor, matriz, funcao;
 */