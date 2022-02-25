package br.com.generation;

import java.util.Scanner;

public class Exercicio1 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		Scanner leia = new Scanner (System.in);
		
		int anos, meses, dias;
		
		System.out.println("Digite sua idade em anos");
		anos = leia.nextInt();
		
		System.out.println("Digite sua idade em meses");
		meses = leia.nextInt();
		
		System.out.println("Digite sua idade em dias");
		dias = leia.nextInt();
		
		dias = (dias +(anos*365)+(meses*30));
		
		System.out.println("sua idade tem " + dias + " dias");
		
		leia.close();
	}

}
