
# #
# out.txt : main.exe              # out.txt depends on hello.exe
# 	mono main.exe > out.txt # run hello.exe, send output to out.txt

# main.exe : main.cs             # hello.exe depends on hello.cs
# 	mcs main.cs             # compile hello.cs into hello.exe

# clean:                           # a phoney target, no dependencies
# 	rm -f out.txt main.exe  # remove secondary files

CSFLAGS = -warn:4

out.txt : main.exe
	mono main.exe > out.txt

main.exe : main.cs func.dll
	mcs $(CSFLAGS) -reference:func.dll -out:main.exe main.cs

func.dll : func.cs
	mcs $(CFLAGS) -target:library -out:$@ $^ 

.PHONEY:clean
clean:
	rm --force out* *.dll *.exe