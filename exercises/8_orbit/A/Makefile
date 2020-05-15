all: PlotA.svg


PlotA.svg: plotA.gpi out.A.txt
	gnuplot $<


out.A.txt : mainA.exe Makefile
	mono $< 2>log | sed -e "s/,/./g" 1>$@

mainA.exe : mainA.cs matlib.dll
	mcs -reference:matlib.dll $<

LIBDIR = $(HOME)/Documents/ppnm/matlib
matlib.dll: $(LIBDIR)/matrix/vector.cs $(LIBDIR)/ode/bak.ode.cs 
	mcs -target:library -out:$@ $^

# plotA.gpi:Makefile
# 	echo 'set term svg font ",18" background rgb "white"' >$@
# 	echo 'set title "Logistic Function"' >>$@
# 	echo 'set xlabel "x"' >>$@
# 	echo 'set ylabel "f(x)"' >>$@
# 	echo 'set xzeroaxis' >>$@
# 	echo 'set yzeroaxis' >>$@
# 	echo 'set key bottom right' >>$@
# 	echo 'set grid' >>$@
# 	echo 'plot "out.A.txt" u 1:2 t "Nummeric,A" w l\' >> $@
# 	echo ',"out.A.txt" u 1:3 t "Analytical,A"' >> $@
clean:
	rm -f *.dll *.exe log* out* *.svg
