LIBDIR=$(HOME)/Documents/Repository/ppnm/matlib
LIBSRC=\
	$(LIBDIR)/matrix/vector.cs\
	$(LIBDIR)/matrix/matrix.cs\
	$(LIBDIR)/qr/qr.cs

all:Out.txt
Out.txt:main.exe
	mono $< >$@ 2>Log

main.exe:main.cs roots.dll matlib.dll
	mcs $< -r:$(call clist,$(filter %.dll,$^))

matlib.dll:$(LIBSRC)
	mcs $^ -target:library -out:$@

SRC := $(HOME)/Documents/Repository/ppnm/matlib/roots/bak
roots.dll:$(SRC)/jacobian.cs $(SRC)/newton.cs matlib.dll
	src="$(filter %.cs,$^)"; libs="$(call clist,$(filter %.dll,$^))";\
	mcs $$src -t:library -r:$$libs -out:$@

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og*

comma:=,
empty:=
space:=$(empty) $(empty)
clist = $(subst $(space),$(comma),$(1))
