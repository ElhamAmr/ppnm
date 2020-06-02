using System;
using static System.Math;
using static System.Double;
public static partial class quad{
//Clenshaw-Curtis quadrature

public static double CC(Func<double,double> f, double a, double b, double acc, double eps){
	Func<double, double> u = (x) => 0.5*(b-a)*f(0.5*(a+b)+(0.5*(b-a)*x)); //Transforming the interval to [-1,2] via. = 1/2*(b-a) + f(1/2(a+b)+1/2*(a-b)xi)
	Func<double, double> v = (theta) => u(Cos(theta))*Sin(theta);

	return adapt4(v, 0, PI, acc, eps); //Integration from:∫_0^π g(cos(θ))*sinθ dθ
}//CC
} //partial class

