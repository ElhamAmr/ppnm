using System;
using System.IO;
using static System.Math;
class stdinout{
	static int Main(){
		TextReader stdin = Console.In; //Her læses fra standard-input.  
		TextWriter stdout = Console.Out; 

		string s = stdin.ReadLine(); //det jeg skriver ind i min tekst-streng, konverterer den så til double variabler(aka. tal)
		string[] data = s.Split(' ',',','\t' );// string[] => en vektor med mange strenge
		
		Console.WriteLine("# x sin(x) cos(x)");

		foreach(var points in data){
			double x = double.Parse(points);
			stdout.WriteLine("{0} {1} {2}",x,Sin(x),Cos(x));
		}//foreach
		
		
return 0;
	}//main
}//class
