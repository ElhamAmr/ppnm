out.txt:main.exe
	mono $< > $@ 
main.exe:main.cs matlib.dll
	mcs $(filter %.cs,$^) -reference:$(filter %.dll,$^)

matlib.dll:quad.cs 
	mcs $^ -target:library -out:$@

clean:
	$(RM) *.dll *.exe [Oo]ut* 
