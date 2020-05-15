using System;
using static System.Math;
using static cmath;
public partial class cfunc{

public static complex sinh(complex x){
		return (exp(x)-exp(-x))/2;
}

public static complex cosh(complex x){
		return (exp(x)+exp(-x))/2;
}

public static complex csqrt(complex x){
		complex I = new complex(0,1);
		double r = abs(x);
		double phi = arg(x);
		return sqrt(r)*exp(I*phi/2);
}
}