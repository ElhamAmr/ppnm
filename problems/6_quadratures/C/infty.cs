using static System.Math;
using System;
using static System.Double;

public static partial class quad{

//integral limits from -inf to inf into 0 to 1:
public static double infty_inflimits(Func<double,double> f, double a, double b, double acc, double eps){
Func<double, double> h = (x) => 1.0/(x*x) * ( f((1.0-x)/x) + f(- (1.0-x)/x)); //eq. (58)
return adapt4(h,0,1,acc,eps);
}

//integral limits from a to +inf into 0 and 1:
public static double infty_upper(Func<double,double> f, double a, double b, double acc, double eps){
Func<double, double> h = (x) => f(a + (1.0-x)/x)/(x*x); //eq. (60)
return adapt4(h,0,1,acc,eps);
}

//integral limits from --inf to b into 0 and 1:
public static double infty_lower(Func<double,double> f, double a, double b, double acc, double eps){
Func<double, double> h = (x) => f(b - (1.0-x)/x)/(x*x); //eq. (62) in pdf
return adapt4(h,0,1,acc,eps);
}


}//class:quad