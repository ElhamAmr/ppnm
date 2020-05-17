all:ms.pdf

ms.pdf: ms.tex plot-exp.tex
	pdflatex $<
	pdflatex $<

main.exe: main.cs matlib.dll
	mcs -out:$@ -reference:matlib.dll $<
	
plot-exp.tex: plot-exp.gpi out-exp.txt #out-table.txt
	gnuplot $<

out-exp.txt: main.exe
	mono $< > $@

LIBDIR = $(HOME)/Documents/Repository/ppnm/matlib
SRC := $(LIBDIR)/integration/quado8.cs

matlib.dll: $(SRC)
	mcs $^ -target:library -out:$@ $^

clean:
	$(RM) *.log *.aux *.pdf *.dvi out* *.eps plot-exp.tex *.exe *.dll

test:
	echo $(SRC)
