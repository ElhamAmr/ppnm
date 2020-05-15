
using System;
using static System.Console;
using static func;

class main{
	static int Main(){
	WriteLine("(A)");

		WriteLine("(i)");
		int i=1; while(i+1>i) {i++;}
		Write("my max int = {0}\n",i);
		Write("int.MaxVal = {0}\n", int.MaxValue);

		WriteLine("(ii)");
		int j=-1; while(j-1<j) {j--;}
		Write("my min int = {0}\n",j);
		Write("int.MinVal = {0}\n", int.MinValue);
		
	WriteLine("(B)");
		double x=1; while(1+x!=1){x/=2;} x*=2;
		float y=1F; while((float)(1F+y) != 1F){y/=2F;} y*=2F;
		Write("double = {0}\n",x); //double har mindre præcision end float.
		Write("float = {0}\n",y); 

	WriteLine("(C)");
		WriteLine("(i)");
		int max=int.MaxValue/3;
		float float_sum_up=1F;
		for(int k=2;k<max;k++)float_sum_up+=1F/k;//lægger hele tiden en værdi til "float_sum_up" m. +=
		Write("float_sum_up={0}\n",float_sum_up);

		float float_sum_down=1F/max;
		for(int l=max-1;l>0;l--)float_sum_down+=1F/l;
		Write("float_sum_down={0}\n",float_sum_down);

		WriteLine("(ii)");
		Write("The floating point type is not precise (it has 7 significant digits). In 'float_sum_up', we start with the largest number and add smaller and smaller values, so more of the significant digits need to be dropped for the smallest added numbers, while in 'float_sum_down' we start with the smallest number and add larger and larger numbers, allowing the least significant decimals to accumulate.\n");
		
		WriteLine("(iii)");
		Write("The sum does not converge.");

		WriteLine("(iv)");
		//int max=int.MaxValue/3;
		double double_sum_up=1D;
		for(int m=2;m<max;m++)double_sum_up+=1D/m;//lægger hele tiden en værdi til "float_sum_up" m. +=
		Write("double_sum_up={0}\n",double_sum_up);

		double double_sum_down=1D/max;
		for(int n=max-1;n>0;n--)double_sum_down+=1D/n;
		Write("double_sum_down={0}\n",double_sum_down);
		Write("The double point type is more precise (it has 15 significant digits) than the float type, and hence, these sums are not as sensitive to the 'direction' in which the numbers are added, however, it does not return identical values.\n");

	WriteLine("(D)");
		double a =5.000000;
		double b =5.000124;
		Write($"{a} and {b} are equal with absolute or relative precision:");
		if(func.Approx(a,b)==true){
			Write("true\n");
		}
		else{
			Write("false\n");
		}


	return 0;
	}
}