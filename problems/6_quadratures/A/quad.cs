using System;
using static System.Math;
using static System.Double;
public static partial class quad{
public static double adapt4(

	Func<double,double> f,double a,double b,
	double acc=1e-3, double eps=1e-3, int limit=99,
	double f2=NaN, double f3=NaN)
{
	double f1=f(a+(b-a)/6), f4=f(a+5*(b-a)/6);
	if( IsNaN(f2) ){ f2=f(a+2*(b-a)/6); f3=f(a+4*(b-a)/6);}
	double Q=(2*f1+f2+f3+2*f4)/6*(b-a);
	double q=(f1+f2+f3+f4)/4*(b-a);
	double err=Abs(Q-q)/1.4;

	if(limit==0){
		Console.Error.WriteLine($"adapt: limit reached: a={a} b={b}");
		return Q;
		}

	if(err<acc+eps*Abs(Q)){
		return Q;
		}
	else{
		double Q1=adapt4(f,a,(a+b)/2,acc/Sqrt(2),eps,limit-1,f1,f2);
		double Q2=adapt4(f,(a+b)/2,b,acc/Sqrt(2),eps,limit-1,f3,f4);
		return Q1+Q2;
		}
}//adap
}//quad
