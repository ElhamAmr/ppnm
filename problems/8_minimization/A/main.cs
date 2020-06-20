using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){
//Rosenbrock's valley function, f(x,y)=(1-x)2+100(y-x2)2.
	Func<vector,double> f1=(z)=>Pow(1-z[0],2)+100*Pow(z[1]-z[0]*z[0],2);
	double eps=1e-4;
	vector p = new vector("3 3");
	Write("SR1: Rosenbrock's valley function\n");
	p.print("start point:");
	int nsteps = qnewton.sr1(f1,ref p,eps);
	WriteLine($"nsteps={nsteps}");
	p.print("minimum    :");
	Write($"f(x_min)          = {(float)f1(p)}\n");
	vector g=qnewton.gradient(f1,p);
	Write($"|gradient| goal   = {(float)eps}\n");
	Write($"|gradient| actual = {(float)g.norm()}\n");
	if(g.norm()<eps)WriteLine("test passed");
	else            WriteLine("test failed");

//Himmelblau's function, f(x,y)=(x2+y-11)2+(x+y2-7)2.
	Func<vector,double> f2=(z)=>Pow(z[0]*z[0]+z[1]-11,2)+Pow(z[0]+z[1]*z[1]-7,2);
	eps=1e-4;
	p = new vector("5 3");
	Write("\nSR1: Himmelblau's function\n");
	p.print("start point:");
	nsteps = qnewton.sr1(f2,ref p,eps);
	WriteLine($"nsteps={nsteps}");
	p.print("minimum    :");
	Write($"f(x_min)          = {(float)f2(p)}\n");
	g=qnewton.gradient(f2,p);
	Write($"|gradient| goal   = {(float)eps}\n");
	Write($"|gradient| actual = {(float)g.norm()}\n");
	if(g.norm()<eps)WriteLine("test passed");
	else            WriteLine("test failed");

}
}
