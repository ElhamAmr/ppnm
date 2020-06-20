using System;
using static System.Math;
using static System.Console;
public class network{

public vector p;
public Func<double,double> f;		// activiation function
public readonly int n;

public network(int n, Func<double,double> f){
	this.n=n;
	this.f=f;
	this.p=new vector(3*n); // p={ai,bi,wi}i=1..n is the set of parameters of the network
	}

public double feed(double x){
	double sum=0;
	for(int i=0;i<n;i++){
		double a=p[3*i+0];
		double b=p[3*i+1];
		double w=p[3*i+2];
		sum+=w*f((x-a)/b); //output signal y=f((x-ai)/bi)*wi,
		}
	return sum;
	}

public void train(double[] xs,double[] ys){
	int ncalls=0;
	Func<vector,double> mismatch=(u)=>{
		ncalls++;
		p=u;
		double sum=0;
		for(int k=0;k<xs.Length;k++)
			sum+=Pow(feed(xs[k])-ys[k],2);  //deviation δ(p)=∑k=1..N(Fp(xk)-yk)²
Error.Write($"mismatch={sum/xs.Length}\n");
		return sum/xs.Length;
		};
	vector v=p;
	//int nsteps=qnewton.sr1(mismatch,ref v,1e-2);								//minimization of deviation (using quasi-newton SR1 minimization routine)
	int nsteps=simplex.downhill(mismatch,ref v,step:0.2,dx:1e-2,maxsteps:3000);	//minimization of deviation (using downhill simplex minimization routine)
	p=v;
Error.Write($"ncalls={ncalls}\n");
Error.Write($"nsteps={nsteps}\n");
	}

}//network
