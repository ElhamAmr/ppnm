using System;
using static System.Math;
using static System.Console;
static class main{

	static double pow(this double x,int n){return Pow(x,n);}
	static double pow(this double x,double n){return Pow(x,n);}				//easy power-function

	static System.Collections.Generic.List<double> energy,signal,error;		//create list 

	static double chi2(vector x){											//minimization by deviation function
		double m = x[0];
		double G = x[1];
		double A = x[2];
		double sum=0;
		for(int i=0;i<energy.Count;i++){
			double e=energy[i];
			double y=signal[i];
			double u=error[i];
			sum+=(A*breitwigner(e,m,G)-y).pow(2)/u/u; // D(m,Γ,A)=Σi(F(Ei|m,Γ,A)-σi)2
			}
		return sum;
		}

	static double breitwigner(double e, double m, double G){
		return 1/((e-m).pow(2)+G.pow(2)/4); //F(E|m,Γ,A)=A/((E-m)²+Γ²/4) (without A)
	}

static void Main(){
	energy = new System.Collections.Generic.List<double>();					//Reading in data
	signal = new System.Collections.Generic.List<double>();
	error  = new System.Collections.Generic.List<double>();
	System.IO.TextReader stdin = Console.In;

	do{
		string s=stdin.ReadLine();
		if(s==null)break;
		char[] separators = new char[] {' '};
		string[] w=s.Split(separators,StringSplitOptions.RemoveEmptyEntries);
		energy.Add(double.Parse(w[0]));
		signal.Add(double.Parse(w[1]));
		error.Add (double.Parse(w[2]));
		}while(true);

vector p=new vector("120 2 6");												//initial values for minimization
int nsteps=qnewton.sr1(chi2,ref p,acc:1e-3);
double m=p[0];	//mass
double G=p[1];	//Γ: the widths of the sought resonance
double A=p[2];	//scale factor
Write($"nsteps       ={nsteps}\n");
Write($"mass         ={m}\n");
Write($"Gamma        ={G}\n");
Write($"Sqrt(chi^2/n)={Sqrt(chi2(p)/energy.Count)}\n");

for(double e=energy[0];e<=energy[energy.Count-1];e+=1.0/8)
	Error.WriteLine($"{e} {A*breitwigner(e,m,G)}");

}//Main
}//main
