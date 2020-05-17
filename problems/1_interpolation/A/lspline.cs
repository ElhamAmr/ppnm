using System;
using System.Diagnostics;
public class lspline{

double[] x,y,p;

public static int binsearch(double[] x, double z){
	int i=0, j=x.Length-1;/* locate the interval for z by bisection */ 
	while(j-i>1){ int mid=(i+j)/2; if(z>x[mid]) i=mid; else j=mid;}
	return i;
	}

public lspline(double[] xs,double[] ys){
	int n=xs.Length; Trace.Assert(ys.Length>=n);
	x=new double[n];
	y=new double[n];
	p=new double[n-1];
	for(int i=0;i<n;i++){
		x[i]=xs[i];y[i]=ys[i];
	}
	for(int i=0;i<n-1;i++){
		p[i]=(y[i+1]-y[i])/(x[i+1]-x[i]); Trace.Assert(x[i+1]-x[i]>0);
	}
}//constructor

public double eval(double z){/* evaluation of the spline at point z */
	Trace.Assert(z>=x[0] && z<=x[x.Length-1]);
	int i=binsearch(x,z);
	double dx=z-x[i];/* calculate the inerpolating spline : */
	return y[i]+dx*(p[i]);} /* s[i](x)=y[i]+p[i]*(x-x[i]) */



public double integ(double z){/* derivative of the spline at point z */
	Trace.Assert(z>=x[0] && z<=x[x.Length-1]);
	int iz=binsearch(x,z);
	double sum=0,dx;
	for(int i=0;i<iz;i++){
		dx=x[i+1]-x[i];
		p[i]=(y[i+1]-y[i])/dx;
		sum+=dx*(y[i]+dx*(p[i])/2);
		}
	dx=z-x[iz]; //spørgsmål til her: hvorfor dette skridt, når vi allerede har defineret sum(& dx ovenover)?
	sum+=dx*(y[iz]+dx*(p[iz])/2);
	return sum;
	}

}//lspline
