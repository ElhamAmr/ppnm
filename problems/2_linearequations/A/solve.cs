public partial class gramschmidt{
public vector solve(vector b){
	var c=Q%b; //% svarer til at gange med den transponerede matrix (def. i matlib)
	backsubst(c); //backsubstitution defineret i .cs
	matrix()
	return c;
	}//solve
}//class gramschmidt
