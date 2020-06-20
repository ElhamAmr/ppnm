using System;
using static System.Console;
using static System.Math;
public partial class qnewton{

//public static readonly double EPS=1.0/1048576;
//public static readonly double EPS=1.0/2097152;
public static readonly double EPS=1.0/4194304;

public static vector gradient(Func<vector,double>f, vector x){
	vector g=new vector(x.size);
	double fx=f(x);
	for(int i=0;i<x.size;i++){

		double dx=Abs(x[i])*EPS;
		if(Abs(x[i])<Sqrt(EPS)) dx=EPS;
		x[i]+=dx;
		g[i]=(f(x)-fx)/dx;	// gradient of the objective function eq. (3)
		x[i]-=dx;
	}
	return g;				
}//gradient


//The symmetric-rank-1 update (SR1) chosen in the form δB = vv^T
public static int sr1(Func<vector,double>f, ref vector x, double acc=1e-3){
	double fx=f(x);
	vector gx=gradient(f,x);		// gradient of function f
	matrix B=matrix.id(x.size);		// identity matrix
	int nsteps=0;
	while(nsteps<999){nsteps++;

		vector Dx=-B*gx;			// Newton's step eq. (6)
		if(Dx.norm()<EPS*x.norm()){ 
			break;
			}

		if(gx.norm()<acc){
			break;
			}

		vector z;
		double fz,lambda=1;
		while(true){				
			z=x+Dx*lambda;			// backtracking linesearch eq. (8): s = Dx*lambda dvs. z = x+s
			fz=f(z);
				if(fz<fx){			// eq. (9) φ(x + s)
					break; 				
					}

				if(lambda<EPS){
					B.setid();
					break; 			// accept anyway
					}
			lambda/=2;				// backtracking using hakf the stepsize
		}
		vector s=z-x;
		vector gz=gradient(f,z);	//  = ∇φ(x + s)
		vector y=gz-gx;				// y= ∇φ(x + s) − ∇φ(x)
		vector u=s-B*y;				// u= s − B*y
		double uTy=u%y;				// matrixmultiplikation

		if(Abs(uTy)>1e-6){
			B.update(u,u,1/uTy); 	// δB eq. (18) (SR1 update)
		}
		x=z;
		gx=gz;
		fx=fz;
	}
	return nsteps;
}//broyden

}//class
