all: out.txt
	cat $<

out.txt: stdinout.exe  Makefile
	echo 1 2 3 4 5 | mono stdinout.exe > out.txt

stdinout.exe:stdinout.cs    
	mcs $<

.PHONY:clean

clean:
	rm -f *.exe out* 
