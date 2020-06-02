all: B_plot.svg

B_plot.svg: b_plot.gpi data.txt
	gnuplot $<

data.txt: main.exe
	mono $< 1> $@ 2> logB.txt


DLLS = matlib.dll roots.dll
main.exe:	main.cs hydrogen.cs $(DLLS)
	mcs main.cs hydrogen.cs -reference:$(call clist,$(DLLS))

#### Root finder ####
SRC := $(HOME)/Documents/Repository/ppnm/matlib/roots/bak
roots.dll:$(SRC)/jacobian.cs $(SRC)/newton.cs matlib.dll
	src="$(filter %.cs,$^)"; libs="$(call clist,$(filter %.dll,$^))";\
	mcs $$src -t:library -r:$$libs -out:$@

####   Matlib + Solver   ####
LIBDIR=$(HOME)/Documents/Repository/ppnm/matlib
LIBSRC=\
	$(LIBDIR)/matrix/vector.cs\
	$(LIBDIR)/matrix/matrix.cs\
	$(LIBDIR)/ode/driver.cs\
	$(LIBDIR)/ode/rkstep23.cs\
	$(LIBDIR)/gramschmidt/backsubst.cs\
	$(LIBDIR)/gramschmidt/gramschmidt.cs\
	$(LIBDIR)/gramschmidt/inverse.cs\
	$(LIBDIR)/gramschmidt/solve.cs\
	$(LIBDIR)/qr/qr.cs\

matlib.dll: $(LIBSRC)
	mcs $^ -target:library -out:$@


clean:
	rm -f *.exe out* *.dll

comma:=,
empty:=
space:=$(empty) $(empty)
clist = $(subst $(space),$(comma),$(1))