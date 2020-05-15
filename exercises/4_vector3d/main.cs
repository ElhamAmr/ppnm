using static System.Console;
class main{
static void Main(){
	
	// constants
	double x = 2;
	vector3d u=new vector3d(1,2,3);
	vector3d v=new vector3d(4,5,6);


	u.print("vector3d u =");
	v.print("vector3d v =");

	double d=ivector3dfunctions.dot(u,u);
	WriteLine($"function call via ivector3d interface: dot(u,u)={d}");

	double e=ivector3dfunctions.dot(u,v);
	WriteLine($"function call via ivector3d interface: dot(u,v)={e}");

	vector3d f=ivector3dfunctions.plus(u,v);
	WriteLine("u+v={0} {1} {2}", f.x,f.y,f.z);

	vector3d g=ivector3dfunctions.minus(u,v);
	g.print("u-v=  ");

	vector3d h=ivector3dfunctions.times(u,x);
	h.print("u*x =  ");

	vector3d i=ivector3dfunctions.times(x,u);
	i.print ("x*u= ");

	vector3d j=ivector3dfunctions.cross(u,v);
	j.print("cross(u,v) =  ");

	double k=ivector3dfunctions.magnitude(u);
	WriteLine($"||u|| ={k}");


}
}


/*public interface IVector{     //vi laver metoderne her.

	vector operator*(vector v, double c){return new vector(c*v.x,c*v.y,c*v.z);}
}


public class vector3d : IVector{}    //Class, vi implementerer metoder på vores struct vector- Dette blive den nye vector vi arbejder 



class main{
 static int Main(){
// 	int n=3;
 	vector v=new vector();
 	vector u=new vector();

 v.x = 3;
 v.y = 4;
 v.z = 8;

 u.x = 8;
 u.y = 1;
 u.z = 4;

 System.Console.WriteLine("vector="+v);
// 	for(int i=0;i<n;i++){
// 		v[i]=i+1;
// 		u[i]=-2*i-1;
// 	}
// 	v.print("v   = ");
// 	u.print("u   = ");
// 	(u+v).print("u+v = ");
// 	vector w=u+v;
// 	w.print("w   = ");
// 	(v*2).print("2*v = ");
 return 0;
 }
 }
*/