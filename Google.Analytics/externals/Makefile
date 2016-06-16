POD=pod

all: Podfile.lock

Podfile.lock:
	$(POD) --no-integrate install

clean:
	rm -rf Podfile.lock Pods

.PHONY: all clean
