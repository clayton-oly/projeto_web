package br.com.generation;

import java.util.Scanner;

public class Exercicio3 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		int minutos, segundos, hora;
		Scanner leia = new Scanner(System.in);
		
		System.out.println("Digite o tempo do eventos em segundos");
		segundos = leia.nextInt();
		

		hora = segundos/3600;
		minutos = (segundos%3600)/60;
		segundos = (segundos%3600)%60;
		
		System.out.println(hora + " hora");
		System.out.println(minutos + " minutos");
		System.out.println(segundos + " segundos");
		
		leia.close();


	}

}
