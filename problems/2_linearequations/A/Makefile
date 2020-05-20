all:A1.txt A2.txt

A1.txt: mainA1.exe ; mono $< > $@
A2.txt: mainA2.exe ; mono $< > $@


DLLS = gramschmidt.dll matlib.dll
mainA1.exe: mainA1.cs $(DLLS)
	mcs $< -reference:$(call clist,$(DLLS))
mainA2.exe: mainA2.cs $(DLLS)
	mcs $< -reference:$(call clist,$(DLLS))


LIBDIR = $(HOME)/Documents/Repository/ppnm/matlib
LIBSRC = \
	$(LIBDIR)/matrix/vector.cs\
	$(LIBDIR)/matrix/matrix.cs
matlib.dll: $(LIBSRC)
	mcs $^ -target:library -out:$@

SRC=gramschmidt.cs backsubst.cs solve.cs
gramschmidt.dll:$(SRC) matlib.dll
	mcs $(SRC) -target:library -out:$@ -reference:$(lastword $^)

clean:
	$(RM) *.dll *.exe out* log* Out* A* B* C*

comma:=,
empty:=
space:=$(empty) $(empty)
clist = $(subst $(space),$(comma),$(1))
