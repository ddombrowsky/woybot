all: test.exe

test.exe: Axon.cs Cell.cs Clock.cs Test.cs Sensor.cs VisCell.cs OutputCell.cs
	mcs -pkg:gtk-sharp-2.0 -out:test.exe *.cs

clean:
	rm -f test.exe
