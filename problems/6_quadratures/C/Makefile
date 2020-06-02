all: Out.txt 

Out.txt:main.exe
	mono $< 1> Out.txt

main.exe:main.cs matlib.dll
	mcs $(filter %.cs,$^) -reference:$(filter %.dll,$^)


LIBDIR = ../A
SCR := $(HOME)/Documents/Repository/ppnm/matlib/integration/quado8.cs
matlib.dll: infty.cs $(LIBDIR)/quad.cs $(SCR)
	mcs $^ -target:library -out:$@

clean:
	$(RM) *.dll *.exe [Oo]ut* [Ll]og*
