using System;
using static System.Math;
class cmdline{
static int Main(string[] args){
	Console.WriteLine("# x sin(x) cos(x)");
	foreach(var s in args){
		double x=double.Parse(s);
		Console.WriteLine($"{x} sin({x})={Sin(x)} cos({x})={Cos(x)}");	
	}
return 0;
}
}