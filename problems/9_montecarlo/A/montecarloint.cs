using static System.Math;
using static System.Console;
using System;

public class montecarloint{

	public static vector plainmc(Func<vector, double> f, vector a, vector b, int N){
		var rand = new Random(); 			// Randomn generator between a & b
		Func<vector> randomx = delegate() {
			vector x = new vector(a.size);
			for(int i = 0; i < x.size; i++) {
				x[i] = a[i] + rand.NextDouble()*(b[i] - a[i]);
			}
			return x;
		};
		
		double volume = 1.0;				// 2: Calculate the integration volume Ω
		for(int i = 0; i < a.size; i++) {
			volume *= b[i] - a[i];			//∆V 
		}
		 
		double sum = 0, sum2 = 0;
		for(int i = 0; i < N; i++) {
			vector thisx = randomx();
			double fx = f(thisx);
			sum += fx;
			sum2 += fx*fx;
		}

		double mean = sum/N;						// <f_i>	
		double sigma = Sqrt(sum2/N - mean*mean); 	// sigma: σ² = <(f_i)²> - <f_i>² eq. (4) 
		double SIGMA = sigma/Sqrt(N); 				// SIGMA: Σ² = <Q²> - <Q>²

		double result = mean*volume; 				// eq. (2)
		double error = SIGMA*volume;				// eq. (3)

		return new vector(result, error); 
	}
}