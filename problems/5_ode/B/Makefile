
all: out.txt plot.svg outTc2.txt plot2.svg outTc14.txt plot14.svg outTc05.txt plot05.svg outTc12.txt plot12.svg

out.txt: main.exe
	mono $< 1> out.txt

outTc2.txt: main.exe
	mono $< 1> outTc2.txt

outTc14.txt: main.exe
	mono $< 1> outTc14.txt

outTc05.txt: main.exe
	mono $< 1> outTc05.txt

	
main.exe: main.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR = $(HOME)/Documents/Repository/ppnm/problems/5_ode/A
matlib.dll: driver.cs rkstep23.cs $(LIBDIR)/vector.cs
	mcs -target:library -out:$@ $^

clean:
	rm -f *.dll *.exe out* *.svg [Ll]og*

plot.svg: out.txt Makefile
	echo '\
	set term svg font ",14" background rgb "white";\
	set out "plot.svg";\
	set key center right;\
	set tics out;\
	set title "SIR-model: Prediction of development of COVID-19 epidemic in Denmark (T_c=4.7)";\
	set xlabel "Time [Days]";\
	set ylabel "Population Size";\
	plot \
	 "out.txt" using 1:2 with lines  title "Susceptible" \
	,"out.txt" using 1:3 with lines title "Infectious" \
	,"out.txt" using 1:4 with lines title "Removed (dead or recovered)" \
	'|gnuplot
	
plot2.svg: outTc2.txt Makefile
	echo '\
	set term svg font ",14" background rgb "white";\
	set out "plot2.svg";\
	set key bottom right;\
	set tics out;\
	set title "SIR-model: Prediction of development of COVID-19 epidemic in Denmark (T_c=2)";\
	set xlabel "Time [Days]";\
	set ylabel "Population Size";\
	plot \
	 "outTc2.txt" using 1:2 with lines  title "Susceptible" \
	,"outTc2.txt" using 1:3 with lines title "Infectious" \
	,"outTc2.txt" using 1:4 with lines title "Removed (dead or recovered)" \
	'|gnuplot

plot14.svg: outTc14.txt Makefile
	echo '\
	set term svg font ",14" background rgb "white";\
	set out "plot14.svg";\
	set key bottom right;\
	set tics out;\
	set title "SIR-model: Prediction of development of COVID-19 epidemic in Denmark (T_c=14)";\
	set xlabel "Time [Days]";\
	set ylabel "Population Size";\
	plot \
	 "outTc14.txt" using 1:2 with lines  title "Susceptible" \
	,"outTc14.txt" using 1:3 with lines title "Infectious" \
	,"outTc14.txt" using 1:4 with lines title "Removed" \
	'|gnuplot

plot05.svg: outTc05.txt Makefile
	echo '\
	set term svg font ",14" background rgb "white";\
	set out "plot05.svg";\
	set key center right;\
	set tics out;\
	set title "SIR-model: Prediction of development of COVID-19 epidemic in Denmark (T_c=0.5)";\
	set xlabel "Time [Days]";\
	set ylabel "Population Size";\
	plot \
	 "outTc05.txt" using 1:2 with lines  title "Susceptible" \
	,"outTc05.txt" using 1:3 with lines title "Infectious" \
	,"outTc05.txt" using 1:4 with lines title "Removed (dead or recovered)" \
	'|gnuplot
	
plot12.svg: outTc12.txt Makefile
	echo '\
	set term svg font ",14" background rgb "white";\
	set out "plot12.svg";\
	set key center right;\
	set tics out;\
	set title "SIR-model: Prediction of development of COVID-19 epidemic in Denmark (T_c=12)";\
	set xlabel "Time [Days]";\
	set ylabel "Population Size";\
	plot \
	 "outTc12.txt" using 1:2 with lines  title "Susceptible" \
	,"outTc12.txt" using 1:3 with lines title "Infectious" \
	,"outTc12.txt" using 1:4 with lines title "Removed (dead or recovered)" \
	'|gnuplot
			