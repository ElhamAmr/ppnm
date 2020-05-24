all:A.svg Results.txt C.svg

A.svg: out.txt Makefile
	#rm fit.log
	echo '\
	set term svg font ",18" background rgb "white";\
	set out "$@";\
	set title "Rutherford and Soddy experiment";\
	set xlabel "Time in Days";\
	set ylabel "Per-cent Activity";\
	a=100;b=0.2;c=1;\
	f(x)=a*exp(-b*x)+c;\
	fit f(x) "$<" u 1:2:3 yerrors via a,b,c;\
	plot "$<" with errorbars title "experimental data"\
	,"$<" index 1 with lines title "exponential fit"\
	,f(x) with lines title "gnuplot fit"\
	' | gnuplot

C.svg: out.txt Makefile
	echo '\
	set term svg font ",18" background rgb "white";\
	set out "$@";\
	set title "Rutherford and Soddy experiment";\
	set log y;\
	set xlabel "Time in Days";\
	set ylabel "Per-cent Activity";\
	plot "$<" with errorbars title "experimental data"\
	,"$<" index 1 with lines title "best fit"\
	,"$<" index 2 with lines title "c_0+dc_0"\
	,"$<" index 3 with lines title "c_0-dc_0"\
	,"$<" index 4 with lines title "c_1+dc_1"\
	,"$<" index 5 with lines title "c_1-dc_1"\
	' | gnuplot

out.txt Results.txt :main.exe
	mono $< 1> out.txt 2>Results.txt

main.exe: main.cs lsfit.cs matlib.dll
	mcs $(filter-out %.dll,$^) -reference:$(lastword $^)

SRC := \
$(HOME)/Documents/Repository/ppnm/matlib/matrix/vector.cs\
$(HOME)/Documents/Repository/ppnm//matlib/matrix/matrix.cs\
$(HOME)/Documents/Repository/ppnm/problems/2_linearequations/B/gramschmidt.cs\
$(HOME)/Documents/Repository/ppnm/problems/2_linearequations/B/backsubst.cs\
$(HOME)/Documents/Repository/ppnm/problems/2_linearequations/B/solve.cs\
$(HOME)/Documents/Repository/ppnm/problems/2_linearequations/B/inverse.cs\

matlib.dll: $(SRC)
	mcs $^ -target:library -out:$@

clean:
	rm -f *.dll *.exe A* B* C* log*

comma:=,
empty:=
space:=$(empty) $(empty)
clist = $(subst $(space),$(comma),$(1))
