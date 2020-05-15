using System;
//public static class ivector3dfunctions{
public class ivector3dfunctions{

public static double dot(ivector3d u, ivector3d v){
	return u.x*v.x+u.y*v.y+u.z*v.z;
	}

public static vector3d plus(ivector3d u, ivector3d v){
	return new vector3d (u.x+v.x,u.y+v.y,u.z+v.z);
	}

public static vector3d minus(ivector3d u, ivector3d v){
	return new vector3d(u.x-v.x,u.y-v.y,u.z-v.z);
	}

public static vector3d times(ivector3d u, double c){
	return new vector3d(u.x*c,u.y*c,u.z*c);
	}

public static vector3d times(double c, ivector3d u){
	return new vector3d(c*u.x,c*u.y,c*u.z);
	}

public static vector3d cross(ivector3d u, ivector3d v){
	return new vector3d(u.y*v.z-u.z*v.y,u.z*v.x-u.x*v.z,u.x*v.y-u.y*v.x);
	}

public static double magnitude(ivector3d u){
	return (Math.Sqrt(Math.Pow(u.x,2)+Math.Pow(u.y,2)+Math.Pow(u.z,2)));
	}




}