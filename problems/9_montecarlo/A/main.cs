using System;
using static System.Console;
using static System.Math;
class main{
static void Main(){
	Func<vector,double> f1 = (x) => Sin(x[0])*Sin(x[0]);
	vector a1 = new vector(0.0);
	vector b1 = new vector(2*PI);
	int N1 = 10000;
	double exact1 = PI;
	WriteLine($"Integral: ∫_0^2π sin(x)^2 dx");
	vector mcresult1 = montecarloint.plainmc(f1,a1,b1,N1);
	WriteLine($"result= {mcresult1[0]}");
	WriteLine($"exact = {exact1}");
	WriteLine($"error = {mcresult1[1]}");

	Write("\n");


	Func<vector,double> f2 = (x) => 1/(PI*PI*PI)*1/(1-Cos(x[0])*Cos(x[1])*Cos(x[2]));
	vector a2 = new vector(0.0,0.0,0.0);
	vector b2 = new vector(PI,PI,PI);
	int N2 = 100000;
	double exact2 = 1.3932039296856768591842462603255;
	WriteLine($"Integral: ∫_0^π dx/π ∫_0^π dy/π ∫_0^π dz/π 1/(1-cos(x)*cos(y)*cos(z)");
	vector mcresult2 = montecarloint.plainmc(f2,a2,b2,N2);
	WriteLine($"result= {mcresult2[0]}");
	WriteLine($"exact = {exact2}");
	WriteLine($"error = {mcresult2[1]}");
	

	Write("\n");

	Func<vector,double> f3 = (x) => Log(1/x[0]);
	vector a3 = new vector(0.0);
	vector b3 = new vector(1.0);
	int N3 = 10000;
	double exact3 = 1;
	WriteLine($"Integral: ∫_0^2π Ln(1/x) dx");
	vector mcresult3 = montecarloint.plainmc(f3,a3,b3,N3);
	WriteLine($"result= {mcresult3[0]}");
	WriteLine($"exact = {exact3}");
	WriteLine($"error = {mcresult3[1]}");

	Write("\n");

}
}