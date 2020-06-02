using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){
double rmax=8; //defining r_max
Error.WriteLine($"rmax={rmax}");

Func<vector,vector> M = delegate(vector v){
		double e=v[0];
		double f_rmax=hydrogen.Fe(e,rmax);
		return new vector(f_rmax);
	};

vector v_start= new vector(-1.0);
vector v_root=roots.newton(M,v_start,eps:1e-4);
double energy=v_root[0];
WriteLine($"e={energy}");
Write("\n\n");
WriteLine("#r \t Fe(e,r) \t exact");
for(double r=0; r<=rmax; r+=rmax/100)
	WriteLine($"{r} \t {hydrogen.Fe(energy,r)} \t {r*Exp(-r)}"); //til plot r, F(r), exact result

}//Main method
}//class