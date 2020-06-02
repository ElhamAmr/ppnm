public partial class gramschmidt{
public matrix inverse(){
	int n=Q.size1,m=Q.size2;
	var B=new matrix(m,n);
	var e=new vector(n);
	for(int i=0;i<n;i++){
		e[i]=1; //unit-vector
		B[i]=solve(e);
		e[i]=0; //for at undgå at overwrite vores unit-vector, "nulstilles" den her. Ellers ender vi med [1,1,1,1] til sidst. 
		}
	return B; //returnerer den inverse aka. løsningen
	}//solve
}//class gramschmidt
