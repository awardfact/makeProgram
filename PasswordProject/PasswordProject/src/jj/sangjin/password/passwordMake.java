package jj.sangjin.password;

public class passwordMake { // 패스워드를 만드는 메소드를 가지는 클래스 
	public int oneChange(int[] array,int number) {  // 각 자리는 동일한 방법으로 패스워드를 생성해 같은 평문을 넣으면 같은 암호가 나오게 함     
		int tmp = 0;
		for(int i = 0; i < number; i++) {
			tmp = tmp + array[i];
	}
		return (tmp % 93) + 33;
	}
	
	public int twoChange(int[] array,int number) {
		int tmp = 0; 	
		int count =0;
		for(int i =0; i < number; i++) {
			if(count % 2 == 0) tmp = tmp + (i * 21);
			tmp = tmp + i;
			count++;
		}
		return (tmp % 93) + 33;
	}
	
	public int threeChange(int[] array, int number) {
		int tmp = 0;
		tmp = array[0] * 10000;
		for(int i = 0; i < number; i++) {
			tmp = tmp - array[i];
		}
		return (tmp % 94) + 33;
	}
	
	public int fourChange(int[] array, int number) {
		int tmp = 0;
		for(int i = 0; i < number; i++) {
			if(i % 2 == 0)tmp = tmp + (array[i] * 5 + 1545312 - 12321);
			 tmp = tmp + array[i];
		}
		return (tmp % 94) + 33;
	}
	
	public int fiveChange(int[] array, int number) {
		int tmp = 0;
		int count = 0; 
		tmp = array[0] * 100;
		for(int i = 0; i < number; i++) {
			if(count % 3 == 0) tmp = tmp / 10;
			tmp = tmp + array[i] + (19211 + (array[i] *30) / 212); 
			count++;
		}
		return (tmp % 93) + 33;
	}
	
	
	public int sixChange(int[] array, int number) {
		int tmp = 1000000002;
		for(int i = 0; i < number; i++) {
			tmp = tmp - (array[i] * 6 + 23130);
		}
		return  (tmp % 93) + 33;
	}
	
	
	public int sevenChange(int[] array, int number) {
		int tmp = 0;
		int count = 0;
		for(int i = 0; i < number; i++) {
			if(count % 4 == 0)tmp = tmp -((array[i] * 63) / 21);
			if(count % 6 == 0)tmp = tmp + 21 + array[i] + (array[i] / 5);
			tmp = tmp + (array[i] * 2); 
			count++;
		}
		return (tmp % 93) + 33;
	}
	
	
	public int eightChange(int[] array, int number) {
		int tmp = 8888888;
		int count = 0;
		for(int i = 0; i < number; i++) {
			if(count % 2 == 0) tmp = (tmp + 233213) - array[i];
			tmp = tmp - array[i];
			count++;
		}
		return (tmp % 93) + 33;
	}
	
	
	public int nineChange(int[] array, int number) {
		int tmp = 128;
		int count = 0;
		for(int i = 0; i < number; i++) {
			if(count % 2 == 0) tmp = (tmp + array[i]) / 3;
			if(count % 5 == 0) tmp = tmp + (array[i] *10 / 12);
			tmp = tmp + (array[i] *32) - 3145 + 4531;
			count++;
		}
		return (tmp % 93) + 33;
	}
	
	
	public int tenChange(int[] array, int number) {
		int tmp = array[0] *10;
		for(int i = 0; i < number; i++) {
			tmp = oneChange(array, number);
			tmp = tmp + array[i];
		}
		return (tmp % 93) + 33;
	}
	
	
	public int elevenChange(int[] array, int number) {
		int tmp = array[0];
		int count = 0;
		for(int i = 0; i < number; i++) {
			if(count % 2 == 0)tmp =tmp + twoChange(array, number);
			tmp = tmp + 12312 + (array[i] *6 / 2 + 1282);
			count++;
		}
		return (tmp % 93) + 33;
	}
	
	
	public int twelveChange(int[] array, int number) {
		int tmp = array[0] *62;
		int count = 0; 
		for(int i =0; i < number; i++) {
			if(count % 4 == 0) tmp = tmp - (array[i] *12) + 1276769;
			if(count % 3 == 0) tmp = tmp + (array[i] *58) / 33;
			tmp = tmp + (array[i] *10) / 3;
			count++;
		}
		return (tmp % 93) + 33;
	}
	
	public int thirteenChange(int[] array, int number) {
		int tmp = 0;
		int count = 0; 
		for(int i = 0; i < number; i++) {
			if(count % 3 == 0) tmp = tmp + threeChange(array,number);
			tmp = tmp + (array[i] *75);
			tmp = tmp - ((array[i] + 452)/ 130);
			tmp = tmp + (array[i]);
			count++;
		}
		return (tmp % 93) + 32;
	}
	
	public int fourteenChange(int[] array, int number) {
		int tmp = 5000000;
		int count =0;
		for(int i = 0; i < number; i++) {
			if(count % 2 == 0) tmp = tmp + ((array[i] * 43 + 213)/50);
			tmp = tmp + (array[i] *4 /3 *2 /6);
			tmp = tmp - array[i];
		}
		return (tmp % 93) + 32;
	}
	
	public int fifteenChange(int[] array, int number) {
		int tmp = 0;
		for(int i = 0; i < number; i++) {
			tmp = tmp + (array[i]* 5);
			tmp = tmp - (array[i] / 3);
			tmp = tmp + (array[i] + 203 *2);
			tmp = tmp - ((array[i] + 50) / 20);
		}
		return (tmp % 93) + 33;
	}
	
	public int sixteenChange(int[] array, int number) {
		int tmp = 0;
		int count = 0; 
		for(int i = 0; i < number; i++) {
			if(count % 3 == 0) tmp = tmp + threeChange(array,number);
			tmp = tmp + (array[i] * 18);
			tmp = tmp - (array[i] *9);
			count++;
		}
		return (tmp % 93) + 33;
	}
	
	public int seventeenChange(int[] array, int number) {
		int tmp = 0;
		int count = 0; 
		for(int i = 0; i < number; i++) {
			if(count % 2 == 0) tmp = tmp + 75123 + (array[i] - (array[i] + 30) / 40);
			tmp = tmp + (array[i] * 17) + 170;
			tmp = tmp - ((array[i] +71) / 21);
			count++;
		}
		return (tmp % 93) + 33;
	}
	
	
	public int eighteenChange(int[] array, int number) {
		int tmp = 0;
		int count = 0; 
		for(int i = 0; i < number; i++) {
			if(count % 2 == 0) tmp = tmp + oneChange(array,number);
			if(count % 3 == 0) tmp = tmp + twoChange(array, number);
			if(count % 4 == 0) tmp = tmp + threeChange(array, number);
			tmp = tmp + (array[i]* 4);
			tmp = tmp - (array[i] / 2);
			tmp = tmp + (array[i] + 203 *5);
			tmp = tmp - ((array[i] + 50) / 25);
			tmp = tmp + array[i];
			count++;
		}
		return (tmp % 93) + 33;
	}
	
	public int nineteenChange(int[] array, int number) {
		int tmp = 0;
		int count = 0; 
		for(int i = 0; i < number; i++) {
			tmp = tmp + (array[i] * 19 + 23156);
			tmp = tmp - ((array[i] + 21345) / 30);
			tmp = tmp + (array[i] * 11) + 7510;
			tmp = tmp - ((array[i] +1354) / 32);
		}
		return (tmp % 93) + 33;
	}
	
	
	public int twentyChange(int[] array, int number) {
		int tmp = 0;
		int count = 0;
		for(int i = 0; i < number; i++) {
			if(count % 2 == 0) tmp = tmp + oneChange(array,number);
			if(count % 3 == 0) tmp = tmp + twoChange(array, number);
			if(count % 4 == 0) tmp = tmp + threeChange(array, number);
			tmp = tmp + (array[i]* 20);
			tmp = tmp - ((array[i] + 213556)  / 27);
			tmp = tmp + (array[i] + 2031 *3);
			tmp = tmp - ((array[i] + 4134) / 46);
			tmp = tmp + array[i];
			count++;
		}
		return (tmp % 93) + 33;
	}
	
}
