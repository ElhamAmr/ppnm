public partial class gramschmidt{
public readonly matrix Q,R; //Q,R bliver ikke lavet om andre steder, hvor den bliver defineret. 
public gramschmidt(matrix A){
	Q=A.copy(); int m=Q.size2; //def. Q som den samme matrix som A
	R=new matrix(m,m); //matrix med 0 i alle indgange
	for(int i=0;i<m;i++){
		R[i,i]=Q[i].norm(); //definerer indgangene i diagonalen
		Q[i]/=R[i,i]; //Q[i]=Q[i]/R[i,i]. vector; (hele søjler)
		
		//definerer indgange over diagonalen
		for(int j=i+1;j<m;j++){ //+1 lægges til j i hvert trin, dvs. for i=1 --> j=1+1=2, j=2+1=3, ..
			R[i,j]=Q[i]%Q[j]; //"%" definerer dot.product af to vektorer og returnerer en skalar
			Q[j]-=Q[i]*R[i,j]; //Q[j]= Q[j]-Q[i]*R[i,j];
			}
		}
	}//gramschmidt
}//class gramschmidt

/*matrix R:
     0.845     0.0412    0.0583 
         0       1.54   -0.147 
         0          0    0
