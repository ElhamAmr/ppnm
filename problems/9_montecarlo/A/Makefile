all: out.txt

out.txt: main.exe
	mono $< 1>out.txt 2>Log

main.exe: main.cs montecarloint.cs matlib.dll
	mcs $(filter %.cs,$^) $(addprefix -r:,$(filter %.dll,$^))

LIBDIR=$(HOME)/Documents/Repository/ppnm/matlib
LIBSRC=\
	$(LIBDIR)/matrix/vector.cs\
	$(LIBDIR)/matrix/matrix.cs\
	$(LIBDIR)/minimum/simplex.cs\
	$(LIBDIR)/minimum/qnewton.cs

matlib.dll: $(LIBSRC)
	mcs -target:library -out:$@ $^

clean:
	$(RM) .exe *.dll [Oo]ut [Ll]og* *.svg *.png