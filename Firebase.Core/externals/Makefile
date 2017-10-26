POD=pod
XCODEBUILD=$(shell xcrun --sdk iphoneos --find xcodebuild)

PROJECT_ROOT=./Pods
PROJECT=$(PROJECT_ROOT)/Pods.xcodeproj
TARGETS=GoogleToolboxForMac nanopb GTMSessionFetcher Protobuf

all: Podfile.lock $(TARGETS)

Podfile.lock:
	$(POD) install

$(TARGETS):
	$(MAKE) $@-iphoneos
	$(MAKE) $@-iphonesimulator
	lipo -create -output $@ $@-iphoneos $@-iphonesimulator

%-iphoneos:
	$(eval currentTarget=$(subst -iphoneos,,$@))
	$(XCODEBUILD) -project $(PROJECT) -target $(currentTarget) -sdk iphoneos -arch armv7 -arch arm64 -configuration Release clean build
	-mv ./build/Release-iphoneos/$(currentTarget)/lib$(currentTarget).a $@

%-iphonesimulator:
	$(eval currentTarget=$(subst -iphonesimulator,,$@))
	$(XCODEBUILD) -project $(PROJECT) -target $(currentTarget) -sdk iphonesimulator -arch i386 -arch x86_64 -configuration Release clean build
	-mv ./build/Release-iphonesimulator/$(currentTarget)/lib$(currentTarget).a $@

clean:
	@ rm -rf Podfile.lock Pods build
	@ for target in $(TARGETS); do \
        rm -f $$target*; \
	done

.PHONY: all clean
