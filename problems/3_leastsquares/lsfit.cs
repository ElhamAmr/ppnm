using System;
public class lsfit{
public vector c;
public matrix sigma;
public Func<double,double>[] f;
public lsfit(vector x, vector y, vector dy, Func<double,double>[] fs){
	f=fs;
	int n=x.size,m=fs.Length; 
	var A = new matrix(n,m);
	var b = new vector(n);
	for(int i=0;i<n;i++){
		b[i]=y[i]/dy[i]; //eq. (7) i pdf'en. 
		for(int k=0;k<m;k++)A[i,k] = f[k](x[i])/dy[i];
		}
	var q=new gramschmidt(A);			//vi bruger GramSchmidt for at finde A
	c=q.solve(b);						//løser systemet 

	var ai=q.inverse();
	sigma=ai*ai.T;						//eq. (14) i leastsq.pdf
	}
public double eval(double z){
	double s=0;
	for(int i=0;i<f.Length;i++)s+=c[i]*f[i](z); //eq. (5) for at fitte med den samlede linearkombinaton
	return s;
	}
}
