using System;
using static System.Console;
public partial class roots{

public static vector newton(Func<vector,vector> f, vector x, double eps=1e-3, double dx=1e-7){
	int n=x.size;
	vector fx=f(x);
	vector z;
	vector fz;

	while(true){
		matrix J=jacobian(f,x,fx); 				// Jacobian matrix is defined
		qrdecomposition qrJ=new qrdecomposition(J);
		matrix B=qrJ.inverse();					// GR-decomp done to provide solution. Inverse to solve the equation
		vector Dx=-B*fx; 						// Newton's step eq. (5) in roots.pdf
		
		double s=1;								// lambda
			while(true){							// backtracking linesearch
				z=x+Dx*s;
				fz=f(z);							// eq. (8)
				if(fz.norm()<(1-s/2)*fx.norm()){break;} // stop if step is good
				if(s<1.0/32){break;}				// stop if minimum stepsize is reached //accept anyway
				s/=2; 								// backtrack by making half a step [s/=2 --> s=s/2]
			}

		x=z;
		fx=fz;
		if(fx.norm()<eps)break; 				// until converged (e.g. ||f(X)|| < tolerance)
	}
	return x;
}//newton

}//class
