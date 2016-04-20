
POD=pod
XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
WORKSPACE=./GAIFieldExporter.xcworkspace
SCHEME=GAIFieldExporter
BUILD_ROOT=build/Build/Products
VALID_ARCHS="armv7 armv7s arm64 i386 x86_64"

all: libGAIFieldExporter.a

Podfile.lock :
	$(POD) install

libGAIFieldExporter-i386.a: Podfile.lock
	$(XBUILD) -workspace $(WORKSPACE) -scheme $(SCHEME) -sdk iphonesimulator -arch i386 -configuration Release VALID_ARCHS=$(VALID_ARCHS) ONLY_ACTIVE_ARCH=NO EFFECTIVE_PLATFORM_NAME="-iphonesimulator" -derivedDataPath build clean build	
	mv $(BUILD_ROOT)/Release-iphonesimulator/libGAIFieldExporter.a $@

libGAIFieldExporter-x86_64.a: Podfile.lock
	$(XBUILD) -workspace $(WORKSPACE) -scheme $(SCHEME) -sdk iphonesimulator -arch x86_64 -configuration Release VALID_ARCHS=$(VALID_ARCHS) ONLY_ACTIVE_ARCH=NO EFFECTIVE_PLATFORM_NAME="-iphonesimulator" -derivedDataPath build clean build
	mv $(BUILD_ROOT)/Release-iphonesimulator/libGAIFieldExporter.a $@

libGAIFieldExporter-armv7.a: Podfile.lock
	$(XBUILD) -workspace $(WORKSPACE) -scheme $(SCHEME) -sdk iphoneos -arch armv7 -configuration Release -derivedDataPath build clean build
	mv $(BUILD_ROOT)/Release-iphoneos/libGAIFieldExporter.a $@

libGAIFieldExporter-arm64.a: Podfile.lock
	$(XBUILD) -workspace $(WORKSPACE) -scheme $(SCHEME) -sdk iphoneos -arch arm64 -configuration Release -derivedDataPath build clean build
	mv $(BUILD_ROOT)/Release-iphoneos/libGAIFieldExporter.a $@

libGAIFieldExporter.a: libGAIFieldExporter-i386.a libGAIFieldExporter-x86_64.a libGAIFieldExporter-armv7.a libGAIFieldExporter-arm64.a 
	lipo -create -output $@ $^	

deletePods:
	rm Podfile.lock
	rm -rf Pods/
	$(POD) install

clean:
	rm -rf Podfile.lock Pods libGAIFieldExporter*.a build/ DerivedData/ FieldExporter/build/

.PHONY: all clean
