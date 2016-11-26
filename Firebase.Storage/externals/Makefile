
POD=pod
XCODEBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild

PROJECT_ROOT=./Pods
PROJECT=$(PROJECT_ROOT)/Pods.xcodeproj
GTM_SESSION_FETCHER_TARGET=GTMSessionFetcher

all: Podfile.lock GTMSessionFetcher

Podfile.lock:
	$(POD) install

GTMSessionFetcher: GTMSessionFetcher-iphoneos GTMSessionFetcher-iphonesimulator
	lipo -create -output $@ $^

GTMSessionFetcher-iphoneos:
	$(XCODEBUILD) -project $(PROJECT) -target $(GTM_SESSION_FETCHER_TARGET) -sdk iphoneos -arch armv7 -arch arm64 -configuration Release clean build
	-mv ./build/Release-iphoneos/GTMSessionFetcher/lib$(GTM_SESSION_FETCHER_TARGET).a $@

GTMSessionFetcher-iphonesimulator:
	$(XCODEBUILD) -project $(PROJECT) -target $(GTM_SESSION_FETCHER_TARGET) -sdk iphonesimulator -arch i386 -arch x86_64 -configuration Release clean build
	-mv ./build/Release-iphonesimulator/GTMSessionFetcher/lib$(GTM_SESSION_FETCHER_TARGET).a $@

clean:
	rm -rf Podfile.lock Pods GTMSessionFetcher* build

.PHONY: all clean


