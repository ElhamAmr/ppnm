all: out-cmdline.txt
	cat $<

out-cmdline.txt: cmdline.exe
	mono $< 1 2 3 4 5 > $@              # overwrite the file with stdout
	#mono $< $$(cat $(INPUT)) >> $@  # append, not overwrite

cmdline.exe:cmdline.cs    
	mcs $<

.PHONY:clean

clean:
	rm -f *.exe out* 
