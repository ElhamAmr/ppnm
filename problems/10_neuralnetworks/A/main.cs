using System;
using static System.Math;
using static System.Console;
class main{
static Func<double,double> f=(x)=>x*Exp(-x*x); // activation function
static Func<double,double> g=(x)=>Cos(x); // function to fit
static void Main(){
	int n=5;
	var ann=new network(n,f); //ann: Artificial Neural Network
	double a=-1.5,b=1.5;
	int nx=38;
	var xs=new double[nx];
	var ys=new double[nx];
	for(int i=0;i<nx;i++){
		xs[i]=a+(b-a)*i/(nx-1); //xs defined as values in between a and b. 
		ys[i]=g(xs[i]); 		// values of function to fit
		Write($"{xs[i]} {ys[i]}\n");
		}
	Write("\n\n");
	for(int i=0;i<ann.n;i++){
		ann.p[3*i+0]=a+(b-a)*i/(ann.n-1);
		ann.p[3*i+1]=1;
		ann.p[3*i+2]=1;
	}
	ann.p.fprint(Console.Error,"p=");
	ann.train(xs,ys);
	ann.p.fprint(Console.Error,"p=");
	for(double z=a;z<=b;z+=1.0/64)
		Write($"{z} {ann.feed(z)}\n");	//calling "feed" which returns the output signal
}//Main
}//main