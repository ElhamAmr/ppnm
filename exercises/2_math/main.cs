using System;
using static System.Console;
using static System.Math;
using static cmath;
class main{
	static int Main(){
		double x=2;
	//DEL A	
		WriteLine("(A)");
		Write($"sqrt({x})={Sqrt(x)}\n");
		complex I = new complex(0,1); // definerer en ny variabel, i, der har værdien 0_reel 1_imaginær
		Write($"e^(i) = {exp(I)}\n");
		complex eipi = exp(I*PI); //definerer produktet af exp(i*pi)
		Write($"e^(i*pi) = {eipi.Re}+{eipi.Im:f0}i\n"); //pæn udskrift
		// i^i har den alternative form exp(-pi/2)
		Write($"i^i = {exp(-PI/2)}\n");
		Write($"sin(i*pi) = {sin(I*PI)}");

	// DEL B
		WriteLine("(B)");
		Write($"sinh(i) = {cfunc.sinh(I)}\n");
		Write($"cosh(i) = {cfunc.cosh(I)}\n");
		Write($"sqrt(i)= {cfunc.csqrt(I)}\n");
		complex sqrtminus1 = cfunc.csqrt(-1);
		Write($"sqrt(-1) = {0:f0}+{1}i\n",sqrtminus1.Re, sqrtminus1.Im);

	return 0;
	}
}