/*Exam project #10: 
Adaptive integrator with subdivision into three subintervals :
Implement a (one-dimensional) adaptive integrator which at each iteration 
subdivides the interval not into two, but into three sub-intervals. */

using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){
	int calls=0;
	double a=0,b=1,acc=1e-3,eps=1e-3;

	{
	Func<double,double> f=delegate(double x){calls++;return Sqrt(x);};
	WriteLine($"integral_{a}^{b} Sqrt(x) dx, acc={acc} eps={eps}");
	double exact=2.0/3.0;
	double Q=quad.adaptint(f,a,b,acc,eps);
	double aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	Write($"Result:					{Q:f6}\n");
	Write($"Exact result:				{exact:f6}\n");
	Write($"Deviation from analytical result:	{Q-exact:e3}\n");
	Write($"Specified tolerance:			{tol :e3}\n");
	Write($"Number of calls:			{calls}\n");
	Write($"error:					{aerr:e3},\n ");
	if(aerr<tol)WriteLine("test passed :)\n");
	else WriteLine("TEST FAILED :(\n");
	}


	{
	Func<double,double> f=delegate(double x){calls++;return Log(x)/Sqrt(x);};
	WriteLine($"integral_{a}^{b} Ln(x)/sqrt(x) dx, acc={acc} eps={eps}");
	double exact=-4;
	double Q=quad.adaptint(f,a,b,acc,eps);
	double aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	Write($"Result:					{Q:f6}\n");
	Write($"Exact result:				{exact:f6}\n");
	Write($"Deviation from analytical result:	{Q-exact:e3}\n");
	Write($"Specified tolerance:			{tol :e3}\n");
	Write($"Number of calls:			{calls}\n");
	Write($"error:					{aerr:e3},\n ");
	if(aerr<tol)WriteLine("test passed :)\n");
	else WriteLine("TEST FAILED :(\n");
	}
}
}