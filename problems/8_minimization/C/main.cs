using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){
	vector c = new vector("1 1");
	int n=c.size;
	matrix A = new matrix(n,n);
	var rnd=new System.Random(1);
	for(int i=0;i<n;i++)
	for(int j=0;j<n;j++)A[i,j]=2*(rnd.NextDouble()-0.5);
	int ncalls=0;
	Func<vector,double> f;

	f = (z)=>{
		ncalls++;
		vector q=(A*(z-c)).map(t=>t*t);
		return Sqrt(q%q);
		};

	vector p;


	ncalls=0;
//Himmelblau's function, f(x,y)=(x2+y-11)2+(x+y2-7)2.
	f=(z)=>{ncalls++; return Pow(z[0]*z[0]+z[1]-11,2)+Pow(z[0]+z[1]*z[1]-7,2);};
	double dx=1e-3;
	p = new vector("0 1");
	Write("\nSR1: Himmelblau's function\n");
	p.print("start point:");
	double psize = simplex.downhill(f,ref p,dx:dx);
	WriteLine($"simplex size ={(float)psize}");
	WriteLine($"ncalls = {ncalls}");
	p.print("minimum    :");
	Write($"f(x_min)          = {(float)f(p)}\n");


	ncalls=0;
	f=(z)=>{ncalls++; return Pow(1-z[0],2)+100*Pow(z[1]-z[0]*z[0],2);};
	double dx1=1e-3;
	p = new vector("2 3");
	Write("\nsimplex.downhill: Rosenbrock's valley function\n");
	p.print("start point:");
	double psize1= simplex.downhill(f,ref p,dx:dx1);
	WriteLine($"simplex size ={(float)psize1}");
	WriteLine($"ncalls = {ncalls}");
	p.print("minimum    :");
	Write($"f(x_min)          = {(float)f(p)}\n");

}
}