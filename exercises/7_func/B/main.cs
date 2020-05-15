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

WriteLine("(B)");

acc=1e-6; eps=0; exact = Sqrt(PI)/2;
WriteLine($"o8av: testing ∫_0^∞ Sqrt(x)exp(-x)dx={exact},acc={acc},eps={eps}");
f = delegate(double x){ ncalls++; return Sqrt(x)*Exp(-x);};
ncalls=0; q=quad.o8av(f,0,inf,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
if(approx(q,exact,acc,eps))WriteLine("test passed\n");
else {ierr++;WriteLine("test failed\n");}

acc=1e-6; eps=0; exact = PI*PI/6;
WriteLine($"o8av: testing ∫_0^∞ x/(exp(x)-1)dx={exact},acc={acc},eps={eps}");
f = delegate(double x){ ncalls++; return x/(Exp(x)-1);};
ncalls=0; q=quad.o8av(f,0,inf,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
if(approx(q,exact,acc,eps))WriteLine("test passed\n");
else {ierr++;WriteLine("test failed\n");}

acc=1e-6; eps=0; exact = PI/4;
WriteLine($"o8av: testing ∫_0^PI/2 Sin(x)^2 dx={exact},acc={acc},eps={eps}");
f = delegate(double x){ ncalls++; return Sin(x)*Sin(x);};
ncalls=0; q=quad.o8av(f,0,PI/2,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
if(approx(q,exact,acc,eps))WriteLine("test passed\n");
else {ierr++;WriteLine("test failed\n");}

acc=1e-6; eps=0; exact = 0.78343051071213;
WriteLine($"o8av: testing ∫_0^1 x^x dx={exact},acc={acc},eps={eps}");
f = delegate(double x){ ncalls++; return Pow(x,x);};
ncalls=0; q=quad.o8av(f,0,1,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
if(approx(q,exact,acc,eps))WriteLine("test passed\n");
else {ierr++;WriteLine("test failed\n");}

acc=1e-6; eps=0; exact = 1.29128599706266;
WriteLine($"o8av: testing ∫_0^1 x^(-x) dx={exact},acc={acc},eps={eps}");
f = delegate(double x){ ncalls++; return Pow(x,-x);};
ncalls=0; q=quad.o8av(f,0,1,acc,eps);
WriteLine($"result = {q}, result/exact={q/exact} ncalls={ncalls}");
if(approx(q,exact,acc,eps))WriteLine("test passed\n");
else {ierr++;WriteLine("test failed\n");}

WriteLine($"failed tests: {ierr}");
return ierr;
}
}
