Plot.svg: plot.data Makefile
	gnuplot -e "\
	set term svg background rgb 'white';\
	set title 'Higgs production signal';\
	set xlabel 'Energy [GeV]';\
	set ylabel 'Signal [arb.u.]';\
	plot 'higgs.txt' using 1:2:3 with errorbars title 'exp'\
	, '$<' using 1:2 with lines title 'fit' ;\
	" > $@

plot.data:main.exe
	mono $< <higgs.txt 1>Log 2>$@

main.exe:main.cs qnewton.dll matlib.dll
	src="$(filter %.cs,$^)"; libs="$(call clist,$(filter %.dll,$^))";\
	mcs $$src -t:exe -r:$$libs -out:$@

LIBDIR=$(HOME)/Documents/Repository/ppnm/matlib
LIBSRC=\
	$(LIBDIR)/matrix/vector.cs\
	$(LIBDIR)/matrix/matrix.cs
matlib.dll:$(LIBSRC)
	mcs $^ -target:library -out:$@

qnewton.dll: ../A/qnewton.cs matlib.dll
	src="$(filter %.cs,$^)"; libs="$(call clist,$(filter %.dll,$^))";\
	mcs $$src -t:library -r:$$libs -out:$@

clean:
	$(RM) *.exe *.dll [Oo]ut* [Ll]og* *.svg

comma:=,
empty:=
space:=$(empty) $(empty)
clist = $(subst $(space),$(comma),$(1))
