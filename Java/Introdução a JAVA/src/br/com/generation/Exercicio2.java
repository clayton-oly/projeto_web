package br.com.generation;

import java.util.Scanner;

public class Exercicio2 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		int dias, anos, meses;
		Scanner leia = new Scanner(System.in);
		
		System.out.println("Digite sua idade em dias");
		dias = leia.nextInt();
		
		anos = dias/365;
		meses = dias/30;
		dias = (dias%365)%30;
		
		System.out.println(dias + " dias");
		System.out.println(meses + " meses");
		System.out.println(anos + " anos");
		
		leia.close();

	}

}
