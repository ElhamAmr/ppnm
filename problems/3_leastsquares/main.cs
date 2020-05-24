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
	
	Error.WriteLine("Results: \n");	
	var fit=new lsfit(x,y,dy,f); 
	double lambda=fit.c[1]; //ln(y)=ln(a)-λt
	double dlambda=Sqrt(fit.sigma[1,1]);
	Error.WriteLine($"lambda={lambda:f5}, dlambda={dlambda:f5}"); //Error.Writeline --> sender teksten til B.txt m. usikkerheder 
	
	double T=-Log(2.0)/lambda; //halvveringstiden
	double dT=Abs(dlambda/lambda/lambda); //usikkerhed
	Error.WriteLine($"\nCalculated ThX half-life = {T:f1} +- {dT:f1} days");

	Error.WriteLine("Modern value ThX half-life = 3.6319 +- 23 days \nSource: https://en.wikipedia.org/wiki/Isotopes_of_radium"); /*halveringstid 224-Ra: 3.6319(23)d kilde: https:// en.wikipedia.org/wiki/Isotopes_of_radium. */
	
/*Del B: 
	Covariance matrix (14) can be calculated as Σ = (A^T A)^−1 = (VS^2 V^T )^−1 = VS^−2 V^T */
	matrix sigma = fit.sigma; //sigma.print("Covariance matrix\n");
	Error.WriteLine($"Covariance Matrix Σ :\n {sigma[0,0]:f6} {sigma[0,1]:f6}\n{sigma[1,0]:f6} {sigma[1,1]:f6}");

	Error.WriteLine("Parameters incl. uncertainties");
	vector err = new vector(sigma.size1);
	for(int i=0;i<sigma.size1;i++){
		err[i] = Sqrt(sigma[i,i]);
		Error.WriteLine($"{fit.c[i]} +- {err[i]}");
	};

//Del C:

	for(int i=0;i<x.size;i++)
		WriteLine($"{xo[i]} {yo[i]} {dyo[i]}");

	int k,N=100;
	double z, step=(x[x.size-1]-x[0])/(N-1);

	WriteLine(); WriteLine(); //giver space
	for(z=x[0], k=0;k<N;z=x[0]+(++k)*step)
		WriteLine($"{z} {Exp(fit.eval(z))}");

	
	WriteLine(); WriteLine();
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
