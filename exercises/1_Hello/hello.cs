using System;
using static System.Console;

class hello{
	static void Main(){
		Write("Hello world\n");
		Write("Hello {0}\n", Environment.UserName);
	}
}