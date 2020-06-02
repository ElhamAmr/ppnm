using System;
using static System.Math;
using static System.Console;
using  System.IO;
class main{
static void Main(){
	double a=0,b=1,acc=1e-3,eps=1e-3;
//1/sqrt(x) with Clenshaw Curtis
	{
	int calls=0;
	Func<double,double> f=delegate(double x){calls++;return 1/Sqrt(x);};
	WriteLine($"integral_{a}^{b} of 1/Sqrt(x) dx, acc={acc} eps={eps} [Clenshaw-Curtis]");
	double exact=2; 
	double Q=quad.CC(f,a,b,acc,eps);
	double aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	Write($"Result:					{Q:f6}\n");
	Write($"Exact result:				{exact:f6}\n");
	Write($"Specified tolerance:			{tol :e3}\n");
	Write($"Number of calls:			{calls}\n");
	Write($"error:					{aerr:e3},\n ");
	if(aerr<tol)WriteLine("test passed :)");
	else WriteLine("TEST FAILED :(");
	WriteLine($"The result deviates {aerr:e3} from the exact solution with {calls} evaluations\n");
	}
//1/sqrt(x) with the adaptive integrator
	{
	int calls=0;
	Func<double,double> f=delegate(double x){calls++;return 1/Sqrt(x);};
	WriteLine($"integral_{a}^{b} of 1/Sqrt(x) dx, acc={acc} eps={eps} [adaptive]");
	double exact=2; 
	double Q=quad.adapt4(f,a,b,acc,eps);
	double aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	Write($"Result:					{Q:f6}\n");
	Write($"Exact result:				{exact:f6}\n");
	Write($"Specified tolerance:			{tol :e3}\n");
	Write($"Number of calls:			{calls}\n");
	Write($"error:					{aerr:e3},\n ");
	if(aerr<tol)WriteLine("test passed :)");
	else WriteLine("TEST FAILED :(");
	WriteLine($"The result deviates {aerr:e3} from the exact solution with {calls} evaluations\n");
	}

//ln(x)/sqrt(x) with Clenshaw Curtis
	{
	int calls=0;
	Func<double,double> f=delegate(double x){calls++;return Log(x)/Sqrt(x);};
	WriteLine($"integral_{a}^{b} of Ln(x)/Sqrt(x) dx, acc={acc} eps={eps} [Clenshaw-Curtis]");
	double exact=-4; 
	double Q=quad.CC(f,a,b,acc,eps);
	double aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	Write($"Result:					{Q:f6}\n");
	Write($"Exact result:				{exact:f6}\n");
	Write($"Specified tolerance:			{tol :e3}\n");
	Write($"Number of calls:			{calls}\n");
	Write($"error:					{aerr:e3},\n ");
	if(aerr<tol)WriteLine("test passed :)");
	else WriteLine("TEST FAILED :(");
	WriteLine($"The result deviates {aerr:e3} from the exact solution with {calls} evaluations\n");
	}
//ln(x)/sqrt(x) with the adaptive integrator
	{
	int calls=0;
	Func<double,double> f=delegate(double x){calls++;return Log(x)/Sqrt(x);};
	WriteLine($"integral_{a}^{b} of Ln(x)/Sqrt(x) dx, acc={acc} eps={eps} [adaptive]");
	double exact=-4; 
	double Q=quad.adapt4(f,a,b,acc,eps);
	double aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	Write($"Result:					{Q:f6}\n");
	Write($"Exact result:				{exact:f6}\n");
	Write($"Specified tolerance:			{tol :e3}\n");
	Write($"Number of calls:			{calls}\n");
	Write($"error:					{aerr:e3},\n ");
	if(aerr<tol)WriteLine("test passed :)");
	else WriteLine("TEST FAILED :(");
	WriteLine($"The result deviates {aerr:e3} from the exact solution with {calls} evaluations\n");
	}

	WriteLine($"CONCLUSION: The Clenshaw-Curtis transformation clearly reduces the number of recursive calls without significantly increasing the error.");

StreamWriter outB2 = new StreamWriter("outB2.txt",append:false);
		{
	int calls=0;
	Func<double,double> f=delegate(double x){calls++;return 4*Sqrt(1-(x*x));};
	outB2.WriteLine($"integral_{a}^{b} of 4*Sqrt(1-x²)dx, acc={acc} eps={eps} [Clenshaw-Curtis]");
	double exact=PI; 
	double Q=quad.CC(f,a,b,acc,eps);
	double aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	outB2.Write($"Result:					{Q:f6}\n");
	outB2.Write($"Exact result:				{exact:f6}\n");
	outB2.Write($"Specified tolerance:			{tol :e3}\n");
	outB2.Write($"Number of calls:			{calls}\n");
	outB2.Write($"error:					{aerr:e3},\n ");
	if(aerr<tol)outB2.WriteLine("test passed :)");
	else outB2.WriteLine("TEST FAILED :(");
	outB2.WriteLine($"The result deviates {aerr:e3} from the exact solution with {calls} evaluations\n");
	}
//without Clenshaw-Curtis
	{
	int calls=0;
	Func<double,double> f=delegate(double x){calls++;return 4*Sqrt(1-(x*x));};
	outB2.WriteLine($"integral_{a}^{b} of 4*Sqrt(1-x²)dx, acc={acc} eps={eps} [adaptive]");
	double exact=PI; 
	double Q=quad.adapt4(f,a,b,acc,eps);
	double aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	outB2.Write($"Result:					{Q:f6}\n");
	outB2.Write($"Exact result:				{exact:f6}\n");
	outB2.Write($"Specified tolerance:			{tol :e3}\n");
	outB2.Write($"Number of calls:			{calls}\n");
	outB2.Write($"error:					{aerr:e3},\n ");
	if(aerr<tol)outB2.WriteLine("test passed :)");
	else outB2.WriteLine("TEST FAILED :(");
	outB2.WriteLine($"The result deviates {aerr:e3} from the exact solution with {calls} evaluations\n");
	}

//with quado8.av
		{
	int calls=0;
	Func<double,double> f=delegate(double x){calls++;return 4*Sqrt(1-(x*x));};
	outB2.WriteLine($"integral_{a}^{b} of 4*Sqrt(1-x²)dx, acc={acc} eps={eps} [o8.av]");
	double exact=PI; 
	double Q=quad.o8av(f,a,b,acc,eps);
	double aerr=Abs(Q-exact),tol=acc+eps*Abs(Q);
	outB2.Write($"Result:					{Q:f6}\n");
	outB2.Write($"Exact result:				{exact:f6}\n");
	outB2.Write($"Specified tolerance:			{tol :e3}\n");
	outB2.Write($"Number of calls:			{calls}\n");
	outB2.Write($"error:					{aerr:e3},\n ");
	if(aerr<tol)outB2.WriteLine("test passed :)");
	else outB2.WriteLine("TEST FAILED :(");
	outB2.WriteLine($"The result deviates {aerr:e3} from the exact solution with {calls} evaluations.\n The result from 'o8.av' is much faster in terms of evaluations but is not as accurate as the Clenshaw-Curtis transformation. Though this can be fixed by adjusting the parameters for acc and eps.");
	}

outB2.Close();

}
}
