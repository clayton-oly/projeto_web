package br.com.generation;

import java.lang.Math;
import java.util.Scanner;

public class Exercicio4 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		int a, b, c;
		double r, s, d;
		Scanner leia = new Scanner(System.in);
		
		System.out.println("Digite o valor do A");
		a = leia.nextInt();
		
		System.out.println("Digite o valor do B");
		b = leia.nextInt();
		
		System.out.println("Digite o valor do C");
		c = leia.nextInt();
		
		r = (a+b);
		s = (b+c)^2;
		d = (r+s)/2;
		
		r = Math.pow(r,2);
		
		System.out.println("O valor da variavel R e " + r);
		System.out.println("O valor da variavel S e " + s);
		System.out.println("O valor da variavel D e " + d);
		
		leia.close();

	}

}
