all: test.exe

test.exe: Axon.cs Cell.cs Clock.cs Test.cs
	mcs -out:test.exe *.cs

clean:
	rm -f test.exe
