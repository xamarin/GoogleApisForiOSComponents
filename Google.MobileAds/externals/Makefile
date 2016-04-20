
POD=pod

XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
WORKSPACE=./GADFieldExporter.xcworkspace
SCHEME=GADFieldExporter
BUILD_ROOT=build/Build/Products
VALID_ARCHS="armv7 armv7s arm64 i386 x86_64"

all: libGADFieldExporter.a

Podfile.lock :
	$(POD) install

libGADFieldExporter-i386.a: Podfile.lock
	$(XBUILD) -workspace $(WORKSPACE) -scheme $(SCHEME) -sdk iphonesimulator -arch i386 -configuration Release VALID_ARCHS=$(VALID_ARCHS) ONLY_ACTIVE_ARCH=NO EFFECTIVE_PLATFORM_NAME="-iphonesimulator" -derivedDataPath build clean build	
	mv $(BUILD_ROOT)/Release-iphonesimulator/libGADFieldExporter.a $@

libGADFieldExporter-x86_64.a: Podfile.lock
	$(XBUILD) -workspace $(WORKSPACE) -scheme $(SCHEME) -sdk iphonesimulator -arch x86_64 -configuration Release VALID_ARCHS=$(VALID_ARCHS) ONLY_ACTIVE_ARCH=NO EFFECTIVE_PLATFORM_NAME="-iphonesimulator" -derivedDataPath build clean build
	mv $(BUILD_ROOT)/Release-iphonesimulator/libGADFieldExporter.a $@

libGADFieldExporter-armv7.a: Podfile.lock
	$(XBUILD) -workspace $(WORKSPACE) -scheme $(SCHEME) -sdk iphoneos -arch armv7 -configuration Release -derivedDataPath build clean build
	mv $(BUILD_ROOT)/Release-iphoneos/libGADFieldExporter.a $@

libGADFieldExporter-armv7s.a: Podfile.lock
	$(XBUILD) -workspace $(WORKSPACE) -scheme $(SCHEME) -sdk iphoneos -arch armv7s -configuration Release -derivedDataPath build clean build
	mv $(BUILD_ROOT)/Release-iphoneos/libGADFieldExporter.a $@

libGADFieldExporter-arm64.a: Podfile.lock
	$(XBUILD) -workspace $(WORKSPACE) -scheme $(SCHEME) -sdk iphoneos -arch arm64 -configuration Release -derivedDataPath build clean build
	mv $(BUILD_ROOT)/Release-iphoneos/libGADFieldExporter.a $@

libGADFieldExporter.a: libGADFieldExporter-i386.a libGADFieldExporter-x86_64.a libGADFieldExporter-armv7.a libGADFieldExporter-armv7s.a libGADFieldExporter-arm64.a 
	lipo -create -output $@ $^	

clean:
	rm -rf Podfile.lock Pods libGADFieldExporter*.a build/ DerivedData/ GADFieldExporter/build/

.PHONY: all clean
