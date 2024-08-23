package fiboTest;

import java.util.HashMap;

public class FiboHash {
	
	private static HashMap<Integer, Long> memo = new HashMap<Integer,Long>();
	
	private static long fibo1(int num)
	{
		if(num <= 0)
			return 0;
		if(num <= 2)
			return 1;
		return fibo(num-2) + fibo(num-1);
	}	
	private static long fibo(int num)
	{
		if(num <= 0)
			return 0;
		if(num <= 2)
			return 1;
		if(memo.containsKey(num))
			return memo.get(num);
		else
		{
			long value = fibo(num-2) + fibo(num-1);
			memo.put(num, value);
			return value;
		}
			
	}


	public static void main(String[] args) {
		// TODO Auto-generated method stub
		long t1 = System.nanoTime();
		System.out.println(fibo1(50));
		long t1_end = System.nanoTime();
		long t2 = System.nanoTime();
		System.out.println(fibo(50));
		long t2_end = System.nanoTime();
		System.out.println(t1_end - t1);
		System.out.println(t2_end - t2);
	}

}
