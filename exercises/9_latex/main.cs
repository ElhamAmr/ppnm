using System;
using static System.Math;
using static System.Console;
class main{
	
static int Main(){
	Func<double, double> f = (t) => Exp(-t*t);
	Func<double,double> err = (x) => quad.o8av(f,-x,x)*(1/Sqrt(PI));
	
	//ALTERNATIV
	/*Func<double,double> err=delegate(double x){
		Func<double,double> f=(t) => Exp(-t*t);
		return quad.o8av(f,-x,x)*(1/Sqrt(PI));
	};*/

	for(double x=-3; x<=3; x+=0.01){
	WriteLine($"{x} {err(x)}");}

return 0;
}//main
}//class
