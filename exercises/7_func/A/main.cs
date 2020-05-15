using static System.Math;
using static System.Console;
class main{
const double inf=double.PositiveInfinity;
public static bool approx
(double x, double y, double acc=1e-6, double eps=1e-6){
        if(Abs(x-y)<acc)return true;
        if(Abs(x-y)<eps*(Abs(x)+Abs(y))/2)return true;
        return false;
}
static int Main(){

int ncalls=0,ierr=0;
double q,exact,acc,eps;
System.Func<double,double> f;

/*Func<double,double> f1 = (x) => Log(x)/Sqrt(x);
double a1=0; double b1=1; double acc1=1e-5; double eps1=1e-5;
double result1=quad.o8av(f1,a1,b1,acc1,eps1);
WriteLine("Integral: ∫_0^1 ln(x)/sqrt(x) dx\n");
WriteLine($"	Calculated result: {result1}");
WriteLine("	True result: -4.00000000000\n");
Write($"	Accuracy requirement ({acc1}): ");
if(approx(result1,-4.00000000000,acc1,eps1))Write("passed\n");
else {Write("failed\n");}*/

WriteLine("(A)");
acc=1e-5; eps=0; exact = -4;
WriteLine($"o8av: ∫_0^1 Log(x)/Sqrt(x)dx={exact}, acc={acc} eps={eps}");
f = delegate(double x){ ncalls++; return Log(x)/Sqrt(x);};
ncalls=10; q=quad.o8av(f,0,2,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
if(approx(q,exact,acc,eps))WriteLine("test passed\n");
else {ierr++;WriteLine("test failed\n");}

acc=1e-6; eps=0; exact = Sqrt(PI);
WriteLine($"o8av: testing ∫_-∞^∞ exp(-x^2)dx={exact},acc={acc},eps={eps}");
f = delegate(double x){ ncalls++; return Exp(-x*x);};
ncalls=0; q=quad.o8av(f,-inf,inf,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
if(approx(q,exact,acc,eps))WriteLine("test passed\n");
else {ierr++;WriteLine("test failed\n");}

acc=1e-6; eps=0; exact = Sqrt(PI)/2;
WriteLine($"o8av: testing ∫_0^∞ exp(-x^2)dx={exact},acc={acc},eps={eps}");
f = delegate(double x){ ncalls++; return Exp(-x*x);};
ncalls=0; q=quad.o8av(f,0,inf,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
if(approx(q,exact,acc,eps))WriteLine("test passed\n");
else {ierr++;WriteLine("test failed\n");}

acc=1e-6; eps=0; exact = 2;
WriteLine($"o8av: testing ∫_0^1 ln(1/x)^2 dx={exact},acc={acc},eps={eps}");
f = delegate(double x){ ncalls++; return Pow(Log(1/x),2); };
ncalls=0; q=quad.o8av(f,0,1,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
if(approx(q,exact,acc,eps))WriteLine("test passed\n");
else {ierr++;WriteLine("test failed\n");}

acc=1e-6; eps=0; exact = 6;
WriteLine($"o8av: testing ∫_0^1 ln(1/x)^3 dx={exact},acc={acc},eps={eps}");
f = delegate(double x){ ncalls++; return Pow(Log(1/x),3); };
ncalls=0; q=quad.o8av(f,0,1,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
if(approx(q,exact,acc,eps))WriteLine("test passed\n");
else {ierr++;WriteLine("test failed\n");}

acc=1e-6; eps=0; exact = Sqrt(PI)/2;
WriteLine($"o8av: testing ∫_0^1 ln(1/x)^0.5 dx={exact},acc={acc},eps={eps}");
f = delegate(double x){ ncalls++; return Sqrt(Log(1/x)); };
ncalls=0; q=quad.o8av(f,0,1,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
if(approx(q,exact,acc,eps))WriteLine("test passed\n");
else {ierr++;WriteLine("test failed\n");}



WriteLine($"failed tests: {ierr}");
return ierr;
}
}
