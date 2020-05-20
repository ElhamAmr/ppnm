all:B.txt


B.txt : mainB.exe  ; mono $< > $@

DLLS = gramschmidt.dll matlib.dll
mainB.exe: mainB.cs $(DLLS)
	mcs $< -reference:$(call clist,$(DLLS))

LIBDIR = $(HOME)/Documents/Repository/ppnm/matlib
LIBSRC = \
	$(LIBDIR)/matrix/vector.cs\
	$(LIBDIR)/matrix/matrix.cs
matlib.dll: $(LIBSRC)
	mcs $^ -target:library -out:$@

SRC=gramschmidt.cs backsubst.cs solve.cs inverse.cs
gramschmidt.dll:$(SRC) matlib.dll
	mcs $(SRC) -target:library -out:$@ -reference:$(lastword $^)

clean:
	$(RM) *.dll *.exe out* log* Out* A* B* C*

comma:=,
empty:=
space:=$(empty) $(empty)
clist = $(subst $(space),$(comma),$(1))
