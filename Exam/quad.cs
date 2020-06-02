/*Exam project #10: 
Adaptive integrator with subdivision into three subintervals :
Implement a (one-dimensional) adaptive integrator which at each iteration 
subdivides the interval not into two, but into three sub-intervals. */

using System;
using static System.Math;
using static System.Double;
public static partial class quad{
public static double adaptint(										// recursiv funktion, der kalder på sig selv igen og igen indtil den når limit/eller når et tilpas akkurat resultat. 

	Func<double,double> f,double a,double b,
	double acc=1e-3, double eps=1e-3, int limit=99,
	double f2=NaN		 											// genbruger punkt f2 og hvis ikke der er et punkt (dvs. NaN), så har vi defineret, hvordan de skal regnes ud. 
	){
	double f1=f(a+(b-a)/6), f3=f(a+5*(b-a)/6);						// x_i = 1/6{1,3,5}   w_i = 1/8{3,2,3} v_i = 1/3{1,1,1}
	
	if( IsNaN(f2) ){ f2=f(a+3*(b-a)/6); } //måske ligger fejlen i præcision her.. 

	double Q=(3*f1+2*f2+3*f3)/8*(b-a);								// higher order quadrature for subdivision into three subintervals
	double q=(f1+f2+f3)/3*(b-a);									// lower order quadrature for subdivision into three subintervals
	double err=Abs(Q-q)/Sqrt(2);									// rescaled absolute accuracy goal: d/sqrt(2)

	if(limit==0){
		//Console.Error.WriteLine($"adapt: limit reached: a={a} b={b}"); //Behøves ikke
		return Q;
		}

	if(err<acc+eps*Abs(Q)){											// if error estimate is acceptable, return Q:						
		return Q;
		}
	else{
		double Q1=adaptint(f,a,a+(b-a)/2,acc/Sqrt(2),eps,limit-1,f1);// partition into three subintervals within interval [a,b], such that 
		double Q2=adaptint(f,a+(b-a)/2,a+2*(b-a)/2,acc/Sqrt(2),eps,limit-1,f2);// a < a+(b-a)/2 < a+2*(b-a)/2 <b
		double Q3=adaptint(f,a+2*(b-a)/2,b,acc/Sqrt(2),eps,limit-1,f3);
		return Q1+Q2+Q3;
		}
}//adapt4


}//quad
