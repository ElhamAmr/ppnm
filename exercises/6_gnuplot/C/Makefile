TERM = png
PLOT = AbsGamma.$(TERM)
TMPPLOT = out.$(TERM)
SIZE = 1280,960

default: $(PLOT)
$(PLOT): $(TMPPLOT)
	convert $(TMPPLOT) -resize 50% $(PLOT)

$(TMPPLOT): gamma.gpi out.gamma.txt
	gnuplot $<

out.gamma.txt: main.exe
	mono $< > $@ 2>log

main.exe: main.cs matlib.dll
	mcs $< -reference:matlib.dll

LIBDIR=../../../matlib
SRC = $(LIBDIR)/complex/complex.cs
SRC += $(LIBDIR)/complex/cmath.cs
matlib.dll: gamma.cs $(SRC)
	mcs $^ -target:library -out:$@

clean:
	rm -rf *.exe *.dll *.svg *.pdf *.jpeg *.png out* log* gamma.gpi

gamma.gpi: Makefile
	cat /dev/null >$@
	echo 'set term $(TERM) size $(SIZE) \' >> $@
	echo 'font arial 28 background rgb "white"' >> $@
	echo 'set out "$(TMPPLOT)"'  >> $@
	echo 'set view ,310' >>$@
	echo 'set title "|Γ(z)|"' >>$@
	echo 'set hidden3d' >>$@
	echo 'set pm3d' >>$@
	echo 'set grid' >>$@
	echo 'set xlabel "Re(z)"' >>$@
	echo 'set ylabel "Im(z)"' >>$@
	echo '#set zlabel "|Gamma(z)|" rotate parallel' >>$@
	echo 'set contour both' >>$@
	echo 'set cntrlabel onecolor' >>$@
	echo 'set linetype 1 linecolor rgb "black"' >>$@
	echo 'zmax=6' >>$@
	echo 'set cntrparam levels incremental 0.0,0.25,zmax' >>$@
	echo 'set palette rgb 33,13,10' >>$@
	echo 'cut(z)=z>zmax?zmax:z' >>$@
	echo 'splot [][][:zmax]\' >>$@
	echo ' "out.gamma.txt" using 1:2:(cut($$3)) with lines notitle' >> $@

test:
	echo $(PI)