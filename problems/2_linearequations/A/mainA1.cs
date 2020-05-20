using System;
using static System.Console;
class main{
static void Main(){
	int n=4,m=3; 
	matrix A=new matrix(n,m); //4x3 matrix laves
	var rnd=new Random(1); //pseudo-random generering
	for(int i=0;i<n;i++)
	for(int j=0;j<m;j++)
		A[i,j]=2*(rnd.NextDouble()-0.5); //udfylder værdier ind i matricen. kalder på den næste værdi i rækken af "tilfældige" tal
	A.print($"QR-decomposition:\nrandom {n}x{m} matrix A:");
	var qra=new gramschmidt(A);
	var Q=qra.Q;
	var R=qra.R;
	R.print("matrix R:");
	Q.print("matrix Q:");
	(Q.T*Q).print("Q^T*Q:");
	(Q*R).print("Q*R:");
	if(A.approx(Q*R))Write("Q*R=A, test passed\n");
	else Write("Q*R!=A, test failed\n");
}
}
