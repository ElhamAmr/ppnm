/*Exam project #10: 
Adaptive integrator with subdivision into three subintervals :
Implement a (one-dimensional) adaptive integrator which at each iteration 
subdivides the interval not into two, but into three sub-intervals. */

using System;
using static System.Math;
using static System.Double;
public static partial class quad{
public static double adaptint(										// recursiv funktion, der kalder på sig selv igen og igen indtil den når limit/eller når et accurat resultat. 

	Func<double,double> f,double a,double b,
	double acc=1e-3, double eps=1e-3, int limit=99,
	double f2=NaN, double f3=NaN 									// genbruger punkterne f2 og f3 fra tidligere, og hvis ikke der er et punkt (dvs. NaN), så har vi defineret, hvordan de skal regnes ud. 
	){
	double f1=f(a+(b-a)/6), f4=f(a+5*(b-a)/6);						// eq. (48)&(51) - definerer f(x1), f(x2),..
	if( IsNaN(f2) ){ f2=f(a+2*(b-a)/6); f3=f(a+4*(b-a)/6);}
	double Q=(2*f1+f2+f3+2*f4)/6*(b-a);								// trapezium rule eq.(49) in pdf
	double q=(f1+f2+f3+f4)/4*(b-a);									// rectangle rule eq.(50) in pdf
	double err=Abs(Q-q)/Sqrt(2);									// rescaled absolute accuracy goal: d/sqrt(2)

	if(limit==0){
		//Console.Error.WriteLine($"adapt: limit reached: a={a} b={b}");
		return Q;
		}

	if(err<acc+eps*Abs(Q)){											// if error estimate is acceptable, return Q:						
		return Q;
		}
	else{
		double Q1=adaptint(f,a,(a+b)/2,acc/Sqrt(2),eps,limit-1,f1,f2);// vi opsplitter det i en ny, aka. Q1 & Q2
		double Q2=adaptint(f,(a+b)/2,b,acc/Sqrt(2),eps,limit-1,f3,f4);// husk det rekursive træ
		return Q1+Q2;
		}
}//adapt4
}//quad
