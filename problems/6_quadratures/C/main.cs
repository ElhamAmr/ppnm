using System;
using static System.Math;
using static System.Console;
using  System.IO;
class main{
static void Main(){
	double posInf = double.PositiveInfinity;
	double negInf = double.NegativeInfinity;
	double acc=1e-3,eps=1e-3;

//func: 1/(1+x*x)
	{
	int calls=0;
	Func<double,double> f=delegate(double x){calls++;return 1/(1+x*x);};
	WriteLine($"integral_-∞ ^∞ of 1/1+x² dx, acc={acc} eps={eps}");
	double exact=PI; 
	double Q=quad.infty_inflimits(f,negInf,posInf,acc,eps);
	double aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	Write($"Result:					{Q:f6}\n");
	Write($"Exact result:				{exact:f6}\n");
	Write($"Specified tolerance:			{tol :e3}\n");
	Write($"Number of calls:			{calls}\n");
	Write($"error:					{aerr:e3},\n ");
	if(aerr<tol)WriteLine("test passed :)");
	else WriteLine("TEST FAILED :(");
	WriteLine($"The result deviates {aerr:e3} from the exact solution with {calls} evaluations");
	}
		{ //comparing to 'o8.av'
		int calls=0;
		Func<double,double> f=delegate(double x){calls++;return 1/(1+x*x);};
		double exact=PI; 
		double Q=quad.o8av(f,negInf,posInf,acc,eps);
		double aerr=Abs(Q-exact);
		WriteLine("Comparing to 'o8.av'");
		WriteLine($"The result from 'o8.av' is {Q:f6}, with {calls} recursive calls and error ={aerr:e3}\n");
		}
//Func sin(x)/x
	{
	int calls=0;
	Func<double,double> f=delegate(double x){calls++;return 1/(x*x);};
	WriteLine($"integral_1 ^∞ of 1/x² dx, acc={acc} eps={eps}");
	double exact=1; 
	double Q=quad.infty_upper(f,1,posInf,acc,eps);
	double aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	Write($"Result:					{Q:f6}\n");
	Write($"Exact result:				{exact:f6}\n");
	Write($"Specified tolerance:			{tol :e3}\n");
	Write($"Number of calls:			{calls}\n");
	Write($"error:					{aerr:e3},\n ");
	if(aerr<tol)WriteLine("test passed :)");
	else WriteLine("TEST FAILED :(");
	WriteLine($"The result deviates {aerr:e3} from the exact solution with {calls} evaluations");
	}
		{ //comparing to 'o8.av'
		int calls=0;
		Func<double,double> f=delegate(double x){calls++;return 1/(x*x);};
		double exact=1; 
		double Q=quad.o8av(f,1,posInf,acc,eps);
		double aerr=Abs(Q-exact);
		WriteLine("Comparing to 'o8.av'");
		WriteLine($"The result from 'o8.av' is {Q:f6}, with {calls} recursive calls and error ={aerr:e3}\n");
		}

//Func 1/2*x*exp(x)
	{
	int calls=0;
	Func<double,double> f=delegate(double x){calls++;return x*Exp(x);};
	WriteLine($"integral_-∞ ^0 of 0.5*x*exp(x) dx, acc={acc} eps={eps}");
	double exact=-1; 
	double Q=quad.infty_lower(f,negInf,0,acc,eps);
	double aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	Write($"Result:					{Q:f6}\n");
	Write($"Exact result:				{exact:f6}\n");
	Write($"Specified tolerance:			{tol :e3}\n");
	Write($"Number of calls:			{calls}\n");
	Write($"error:					{aerr:e3},\n ");
	if(aerr<tol)WriteLine("test passed :)");
	else WriteLine("TEST FAILED :(");
	WriteLine($"The result deviates {aerr:e3} from the exact solution with {calls} evaluations");
	}
		{ //comparing to 'o8.av'
		int calls=0;
		Func<double,double> f=delegate(double x){calls++;return x*Exp(x);};
		double exact=-1; 
		double Q=quad.o8av(f,negInf,0,acc,eps);
		double aerr=Abs(Q-exact);
		WriteLine("Comparing to 'o8.av'");
		WriteLine($"The result from 'o8.av' is {Q:f6}, with {calls} recursive calls and error ={aerr:e3}\n");
		}		
}
}
