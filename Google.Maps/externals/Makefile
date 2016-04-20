
POD=pod
XCODEBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
#WORKSPACE=./FieldExporter.xcworkspace
#SCHEME=FieldExporter
#BUILD_ROOT=build/Build/Products
#VALID_ARCHS="armv7 armv7s arm64 i386 x86_64"

PROJECT_ROOT=./FieldExporter
PROJECT=$(PROJECT_ROOT)/FieldExporter.xcodeproj
TARGET=FieldExporter


all: libFieldExporter.a

Podfile.lock :
	$(POD) --no-integrate install

libFieldExporter-i386.a: Podfile.lock
	$(XCODEBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libFieldExporter-x86_64.a: Podfile.lock

libFieldExporter-armv7.a: Podfile.lock
	$(XCODEBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libFieldExporter-armv7s.a: Podfile.lock
	$(XCODEBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7s -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libFieldExporter-arm64.a: Podfile.lock
	$(XCODEBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch arm64 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libFieldExporter.a: libFieldExporter-i386.a  libFieldExporter-armv7.a libFieldExporter-armv7s.a libFieldExporter-arm64.a 
	lipo -create -output $@ $^	

clean:
	rm -rf Podfile.lock Pods libFieldExporter*.a build/ DerivedData/ FieldExporter/build/

.PHONY: all clean
