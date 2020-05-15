all: out-fileinout.txt
	cat $<

INPUT = input.txt

out-fileinout.txt: fileinout.exe $(INPUT) Makefile
	mono $< $(INPUT) $@              # overwrite the file with stdout
	#mono $< $$(cat $(INPUT)) >> $@    # append, not overwrite


fileinout.exe:fileinout.cs    
	mcs $<

.PHONY:clean

clean:
	rm -f *.exe out* input.txt
