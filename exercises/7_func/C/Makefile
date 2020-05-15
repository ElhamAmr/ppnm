FMT = svg
PLOT=Plot.$(FMT)
DATA=out.txt

$(PLOT): plot.gpi $(DATA)
	gnuplot $<

$(DATA): main.exe
	mono $< > $@ 2>log

main.exe:main.cs matlib.dll
	mcs $< -reference:$(lastword $^)

DIR=$(HOME)/Documents/ppnm/matlib/integration/quado8.cs ##Ændret
#SRC=$(DIR)
matlib.dll: $(DIR)
	mcs $^ -target:library -out:$@

clean:
	rm -f out.txt main.exe matlib.dll log Plot.svg plot.gpi

plot.gpi: Makefile
	cat /dev/null > $@
	echo 'set term $(FMT) font ",18" background rgb "white"'>> $@
	echo 'set out "$(PLOT)"' >>$@
	echo 'set title "Quantum osciallator variational energy"' >>$@
	echo 'set xlabel "Variational parameter α"' >>$@
	echo 'set ylabel "Energy (natural units)"' >>$@
	echo 'set tics out' >>$@ #sætter mærker på akserne udaf
	echo 'set key bottom' >>$@
	echo 'set grid ' >>$@
					#	echo 'set monochrome ' >>$@ #ensfarvet
	echo 'plot [0:4][0:1] \'>>$@
	echo ' "$(DATA)" with lines title "E(α)"\' >>$@
	echo ',0.5 with dots title "exact"\' >>$@

