
POD=pod

XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
WORKSPACE=./GPGFieldExporter.xcworkspace
SCHEME=GPGFieldExporter
BUILD_ROOT=build/Build/Products
VALID_ARCHS="armv7 armv7s arm64 i386 x86_64"

all: libGPGFieldExporter.a

Podfile.lock :
	$(POD) install

libGPGFieldExporter-i386.a: Podfile.lock
	$(XBUILD) -workspace $(WORKSPACE) -scheme $(SCHEME) -sdk iphonesimulator -arch i386 -configuration Release VALID_ARCHS=$(VALID_ARCHS) ONLY_ACTIVE_ARCH=NO EFFECTIVE_PLATFORM_NAME="-iphonesimulator" -derivedDataPath build clean build	
	mv $(BUILD_ROOT)/Release-iphonesimulator/libGPGFieldExporter.a $@

libGPGFieldExporter-x86_64.a: Podfile.lock
	$(XBUILD) -workspace $(WORKSPACE) -scheme $(SCHEME) -sdk iphonesimulator -arch x86_64 -configuration Release VALID_ARCHS=$(VALID_ARCHS) ONLY_ACTIVE_ARCH=NO EFFECTIVE_PLATFORM_NAME="-iphonesimulator" -derivedDataPath build clean build
	mv $(BUILD_ROOT)/Release-iphonesimulator/libGPGFieldExporter.a $@

libGPGFieldExporter-armv7.a: Podfile.lock
	$(XBUILD) -workspace $(WORKSPACE) -scheme $(SCHEME) -sdk iphoneos -arch armv7 -configuration Release -derivedDataPath build clean build
	mv $(BUILD_ROOT)/Release-iphoneos/libGPGFieldExporter.a $@

libGPGFieldExporter-arm64.a: Podfile.lock
	$(XBUILD) -workspace $(WORKSPACE) -scheme $(SCHEME) -sdk iphoneos -arch arm64 -configuration Release -derivedDataPath build clean build
	mv $(BUILD_ROOT)/Release-iphoneos/libGPGFieldExporter.a $@

libGPGFieldExporter.a: libGPGFieldExporter-i386.a libGPGFieldExporter-x86_64.a libGPGFieldExporter-armv7.a libGPGFieldExporter-arm64.a 
	lipo -create -output $@ $^	

clean:
	rm -rf Podfile.lock Pods libGPGFieldExporter*.a build/ DerivedData/ FieldExporter/build/

.PHONY: all clean
