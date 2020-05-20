public partial class gramschmidt{
public vector solve(vector b){
	var c=Q%b; //SPØRGSMÅL: hvorfor er Q ikke transponeret: Q.T%b? jf. (7) i lineq.pdf
	backsubst(c); //backsubstitution defineret i .cs
	return c;
	}//solve
}//class gramschmidt
