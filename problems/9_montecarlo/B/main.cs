using static System.Console;
using static System.Math;
using System;
class main{
static void Main(){
	Func<vector,double> f = (x) => x%x;
	vector a=new vector(0.0,0.0,0.0);
	vector b=new vector(3.0,3.0,3.0);
	double exact=243.0;
	int N=50000;
	int dN=10;
	double[] integral=montecarloint.plainmc(f,a,b,N);
	double scale=Sqrt(N)*integral[1];	// we use the scaling for the plot (to scale O(1/sqrt(N)))
	for(int n=N-dN;n>0;n-=dN){
		double[] integraln=montecarloint.plainmc(f,a,b,n);
		double error=integraln[1];
		double difference=Abs(exact-integraln[0]);
		WriteLine($"{n} {scale/Sqrt(n)} {error} {difference}");
	}
}//Main
}//main