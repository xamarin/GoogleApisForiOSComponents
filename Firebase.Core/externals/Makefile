POD=pod
XCODEBUILD=$(shell xcrun --sdk iphoneos --find xcodebuild)

PROJECT_ROOT=./Pods
PROJECT=$(PROJECT_ROOT)/Pods.xcodeproj
TARGETS=FirebaseCore GoogleToolboxForMac nanopb GTMSessionFetcher Protobuf leveldb-library

all: Pods $(TARGETS)

Pods:
	$(POD) install

$(TARGETS):
	@ $(eval libraryName=$(shell \
	if [ "$@" == "leveldb-library" ]; then \
		echo "leveldb"; \
	else \
		echo $@; \
	fi))
	@ if [ ! -d "./build/Release-iphoneos/$@/$(libraryName).framework" ]; then \
		$(MAKE) $@-iphoneos; \
		$(MAKE) $@-iphonesimulator; \
	fi
	@ if [ ! -d "./$(libraryName).framework" ]; then \
		cp -R ./build/Release-iphoneos/$@/$(libraryName).framework ./; \
		cp -R ./build/Release-iphonesimulator/$@/$(libraryName).framework/ ./$(libraryName)-iphonesimulator.framework; \
		lipo -create -output $(libraryName).framework/$(libraryName) $(libraryName).framework/$(libraryName) $(libraryName)-iphonesimulator.framework/$(libraryName); \
		rm -rf $(libraryName)-iphonesimulator.framework; \
	fi

%-iphoneos:
	@ $(eval currentTarget=$(subst -iphoneos,,$@))
	@ $(XCODEBUILD) -project $(PROJECT) -target $(currentTarget) -sdk iphoneos -arch armv7 -arch arm64 -configuration Release clean build

%-iphonesimulator:
	@ $(eval currentTarget=$(subst -iphonesimulator,,$@))
	@ $(XCODEBUILD) -project $(PROJECT) -target $(currentTarget) -sdk iphonesimulator -arch i386 -arch x86_64 -configuration Release clean build

clean:
	@ rm -rf Pods build *.framework

.PHONY: all clean
