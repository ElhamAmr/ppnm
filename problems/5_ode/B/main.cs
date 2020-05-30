using System;
using System.IO;
using static System.Console;
using static System.Math;
using System.Collections;
using System.Collections.Generic;

class main{

// SIR-modellen (Susceptible, Infectiuos, Recovered)
static Func<double,vector,vector> SIR(double N, double T_c, double T_r){
	return (x,y) => {
		vector ydiff = new vector(3);					// vector y indeholder S,I,R i hver række. 
		ydiff[0] =-(y[1]*y[0])/(N*T_c); 				// dS/dt = - IS/NTc ,
		ydiff[1] =(y[1]*y[0])/(N*T_c)-(y[1]/T_r);		// dI/dt = IS/NTc - I/Tr
		ydiff[2] = y[1]/T_r;							// dR/dt = I/Tr
		return ydiff;
	};
	}

static void Main(){

	double N = 5824857; 								// Befolkningstallet. Tal fra Danmarks Statistik
	double T_c = 4.7; 									// Typisk tid mellem kontakt. Tal fra Statens Serum institut
	double T_r = 14; 									// Typisk tid for helbredelse [dage]

	double Istart = 500;
	vector ya = new vector(new double[] {N-Istart, Istart, 0}); //startværdier

	double a=0;
	double b=250; 										//dage man går frem til i modellen
	double h=0.01,acc=1e-3,eps=1e-3;
	

	var xs=new List<double>();
	var ys=new List<vector>();

vector y=ode.rk23(SIR(N,T_c,T_r),a,ya,b,acc:acc,eps:eps,h:h,xlist:xs,ylist:ys);
	for(int i=0;i<xs.Count;i++)
		WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]} {ys[i][2]}");

// T_c = 2
double Tc2 = 2;
		var xs2=new List<double>();						//nye xs for ikke at overskrive de andre
		var ys2=new List<vector>();
		vector y2=ode.rk23(SIR(N,Tc2,T_r),a,ya,b,acc:acc,eps:eps,h:h,xlist:xs2,ylist:ys2);
StreamWriter outTc2 = new StreamWriter("outTc2.txt", append:false);
	for(int i=0;i<xs2.Count;i++){
	outTc2.WriteLine($"{xs2[i]} {ys2[i][0]} {ys2[i][1]} {ys2[i][2]}");
	};
outTc2.Close();

// T_c = 14
double Tc14 = 14; 
		var xs14=new List<double>();
		var ys14=new List<vector>();
		vector y14=ode.rk23(SIR(N,Tc14,T_r),a,ya,b,acc:acc,eps:eps,h:h,xlist:xs14,ylist:ys14);
StreamWriter outTc14 = new StreamWriter("outTc14.txt", append:false);
	for(int i=0;i<xs14.Count;i++){
	outTc14.WriteLine($"{xs14[i]} {ys14[i][0]} {ys14[i][1]} {ys14[i][2]}");
	};
outTc14.Close();

// T_c = 0.5
double Tc05 = 0.5;
		var xs05=new List<double>();
		var ys05=new List<vector>();
		vector y05=ode.rk23(SIR(N,Tc05,T_r),a,ya,b,acc:acc,eps:eps,h:h,xlist:xs05,ylist:ys05);
StreamWriter outTc05 = new StreamWriter("outTc05.txt", append:false);	
	for(int i=0;i<xs05.Count;i++){
	outTc05.WriteLine($"{xs05[i]} {ys05[i][0]} {ys05[i][1]} {ys05[i][2]}");
	};
outTc05.Close();

// T_c = 12
double Tc12 = 12; 
double b12	= 3*365;
		var xs12=new List<double>();
		var ys12=new List<vector>();
		vector y12=ode.rk23(SIR(N,Tc12,T_r),a,ya,b12,acc:acc,eps:eps,h:h,xlist:xs12,ylist:ys12);
StreamWriter outTc12 = new StreamWriter("outTc12.txt", append:false);
	for(int i=0;i<xs12.Count;i++){
	outTc12.WriteLine($"{xs12[i]} {ys12[i][0]} {ys12[i][1]} {ys12[i][2]}");
	};
outTc12.Close();







}
}
