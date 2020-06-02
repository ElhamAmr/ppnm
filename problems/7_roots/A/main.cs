using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){

	
int ncalls=0;
Func<vector,vector> f = delegate(vector z){
		ncalls++;
		vector r=new vector(2); 			//Rosenbrock function: ((1-x)*(1-x)) + b*((y-x*x)*(y-x*x))
		double x=z[0],y=z[1],b=100;			//Calculating gradient such that r=[df/dx, df/dy]
		r[0]=2*(1-x)+2*100*(y-x*x)*(-2*x); //d/dx ((1-x)²+b*(y-x²)²)
		r[1]=b*2*(y-x*x); //d/dy ((1-x)²+b*(y-x²)²)
		return r;
	};

double eps=1e-4;
vector p = new vector(2);
		p[0]=1.5; p[1]=0.7;

ncalls=0;
p.print("\nNewton's method:\nLooking for extremum of Rosenbrock function starting at:");
	vector root = roots.newton(f,p,eps);
	WriteLine($"Evaluations: 					{ncalls}");
	root.print("Found extremum:				");
	f(root).print("Function at extremum points:			");
	WriteLine($"Reqested accuracy:				{eps}");
	WriteLine($"Norm of derivative at root:			{f(root).norm()}");
	if(f(root).norm()<eps)WriteLine("test passed :)");
	else                  WriteLine("test failed :(");
}
}
