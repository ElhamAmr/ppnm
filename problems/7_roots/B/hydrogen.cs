using System;
public class hydrogen{

public static double Fe(double e,double r){
	double rmin=1e-3;
	if(r<rmin) return r-r*r; 			//f(r → 0) = r-r²

	Func<double,vector,vector> s_wave = delegate(double x,vector y){      // Defining equation for ODE ( -1/2 f'' - 1/r f = e f)
		//return new vector(y[1],-2*(e*y[0]+y[1]/x));
		return new vector(y[1],-2*(e*y[0]+y[0]/x));
	};
	
	//initial conditions
	vector y_rmin= new vector(rmin-rmin*rmin, 1-2*rmin); //f(r -> 0) = r - r*r ==>  f'(r ->0) = 1-2*r
	
	//integrating the ODE in finding the solution at ymax
	vector y_rmax= ode.rk23(s_wave,rmin,y_rmin,r,h:0.001);
	return y_rmax[0];

}// F_e
}//class: hydrogen