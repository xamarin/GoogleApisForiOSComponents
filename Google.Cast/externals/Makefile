POD=pod

all: Podfile.lock

Podfile.lock :
	$(POD) install

clean:
	rm -rf Podfile.lock Pods

.PHONY: all clean
