FMT = svg
OPT = font "Arial,15" size 1024,600
PLOTNAME = qspline
PLOTFILE=$(PLOTNAME).$(FMT)
DATA = out.data
ECHO=/bin/echo

$(PLOTFILE): $(DATA) Makefile
	$(ECHO) '\
	set term $(FMT) $(OPT) background rgb "white";\
	set out "$(PLOTFILE)";\
	set multiplot layout 2,2 title "qspline, derivative, integral" font ",18";\
	set key top right;\
	set xtics 1;\
	set grid;\
	set rmargin 0;\
	plot [][-1.5:1.5]\
	 "$(DATA)" index 0 with points pointtype 7 title "points"\
	,"$(DATA)" index 1 u 1:2 with lines title "exact"\
	,"$(DATA)" index 1 u 1:3 with lines title "qspline";\
	set key center top;\
	set ytics 1;\
	set rmargin;\
	plot [][-2:1.5]\
	 "$(DATA)" index 2 u 1:2 with lines title "exact derivative"\
	,"$(DATA)" index 2 u 1:3 with lines title "spline derivative";\
	set ytics 1;\
	set key top right;\
	set rmargin 0;\
	plot [][0:2.5]\
	 "$(DATA)" index 3 u 1:2 with lines title "exact integral"\
	,"$(DATA)" index 3 u 1:3 with lines title "spline integral";\
	unset multiplot;\
	'| gnuplot

$(DATA): main.exe
	mono $< >$@

main.exe: main.cs matlib.dll
	mcs $< -reference:$(lastword $^)

matlib.dll: qspline.cs
	mcs $< -target:library -out:$@

clean:
	rm -f *.exe *.dll $(PLOTFILE) $(DATA) *.gpi *.svg out*
