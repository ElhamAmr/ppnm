using System;
using static System.Console;
using static System.Math;
class main{
static void Main(){
	var xo =new vector(new double[]{1  ,2  ,3 ,4 ,6 ,9   ,10  ,13  ,15  });
	var yo =new vector(new double[]{117,100,88,72,53,29.5,25.2,15.2,11.1});
	var dyo=0.05*yo; //usikkerhed
	var f = new Func<double,double>[]{t=>1,t=>t};
	int n=xo.size;

	var x=new vector(n);
	var y=new vector(n);
	var dy=new vector(n);
	
	for(int i=0;i<n;i++){
		x[i]=xo[i]; //fylder t og y ud med de samme værdier 
		y[i]=Log(yo[i]);//log til y
		dy[i]=dyo[i]/yo[i]; // eq. (7) i leastsq.pdf
		}
		
	var fit=new lsfit(x,y,dy,f);
	double lambda=fit.c[1];
	double dlambda=Sqrt(fit.sigma[1,1]);
	Error.WriteLine($"lambda={lambda:f5}, dlambda={dlambda:f5}"); //Error.Writeline --> sender teksten til B.txt m. usikkerheder 
	double T=-Log(2.0)/lambda; //halvveringstid
	double dT=Abs(dlambda/lambda/lambda);
	Error.WriteLine($"\nThX half-life = {T:f1} +- {dT:f1} days");
	for(int i=0;i<x.size;i++)
		WriteLine($"{xo[i]} {yo[i]} {dyo[i]}");

	int k,N=100;
	double z, step=(x[x.size-1]-x[0])/(N-1);

	WriteLine(); WriteLine(); //giver space
	for(z=x[0], k=0;k<N;z=x[0]+(++k)*step)
		WriteLine($"{z} {Exp(fit.eval(z))}");

	/*WriteLine(); WriteLine();
	fit.c[0]+=Sqrt(fit.sigma[0,0]);
	for(z=x[0], k=0;k<N;z=x[0]+(++k)*step)
		WriteLine($"{z} {Exp(fit.eval(z))}");

	WriteLine(); WriteLine();
	fit.c[0]-=2*Sqrt(fit.sigma[0,0]);
	for(z=x[0], k=0;k<N;z=x[0]+(++k)*step)
		WriteLine($"{z} {Exp(fit.eval(z))}");

	fit.c[0]+=Sqrt(fit.sigma[0,0]);

	WriteLine(); WriteLine();
	fit.c[1]+=Sqrt(fit.sigma[1,1]);
	for(z=x[0], k=0;k<N;z=x[0]+(++k)*step)
		WriteLine($"{z} {Exp(fit.eval(z))}");

	WriteLine(); WriteLine();
	fit.c[1]-=2*Sqrt(fit.sigma[1,1]);
	for(z=x[0], k=0;k<N;z=x[0]+(++k)*step)
		WriteLine($"{z} {Exp(fit.eval(z))}");

}
}
