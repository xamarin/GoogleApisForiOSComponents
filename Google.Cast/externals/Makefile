
### Temporary workaround. Removes the CFBundleExecutable key from Info.plist files that causes Apple rejection.
INFODIRS=Pods
###

POD=pod

all: Podfile.lock Info.plist

Podfile.lock :
	$(POD) install

### Temporary workaround. Removes the CFBundleExecutable key from Info.plist files that causes Apple rejection.
Info.plist:
	@for i in $(shell find $(INFODIRS) -name 'Info.plist'); do \
		(chmod 755 $$i && \
		plutil -convert xml1 $$i && \
		perl -pi -w -e 's/<key>CFBundleExecutable<\/key>\n/LineToDelete/g' $$i && \
		perl -pi -w -e 's/LineToDelete\t<string>\w*<\/string>\n/LineToDelete/g' $$i && \
		perl -pi -w -e 's/LineToDelete\t//g' $$i && \
		plutil -convert binary1 $$i && \
		chmod 555 $$i) \
	done
###

clean:
	rm -rf Podfile.lock Pods

.PHONY: all clean


