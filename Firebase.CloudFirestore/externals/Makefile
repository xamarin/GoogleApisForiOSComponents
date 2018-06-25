POD=pod
XCODEBUILD=$(shell xcrun --sdk iphoneos --find xcodebuild)

PROJECT_ROOT=./Pods
PROJECT=$(PROJECT_ROOT)/Pods.xcodeproj
TARGETS=FirebaseFirestore gRPC-ProtoRPC gRPC gRPC-Core gRPC-RxLibrary BoringSSL

all: Pods $(TARGETS)

Pods:
	$(POD) install

$(TARGETS):
	@ $(MAKE) $@-iphoneos
	@ $(MAKE) $@-iphonesimulator
	@ $(eval libraryName=$(shell \
	if [ "$@" == "gRPC-ProtoRPC" ]; then \
		echo "ProtoRPC"; \
	elif [ "$@" == "gRPC" ]; then \
		echo "GRPCClient"; \
	elif [ "$@" == "gRPC-Core" ]; then \
		echo "grpc"; \
	elif [ "$@" == "gRPC-RxLibrary" ]; then \
		echo "RxLibrary"; \
	elif [ "$@" == "BoringSSL" ]; then \
		echo "openssl"; \
	else \
		echo $@; \
	fi))
	@ lipo -create -output $(libraryName).framework/$(libraryName) $(libraryName).framework/$(libraryName) $@-iphonesimulator.framework/$(libraryName)
	@ rm -rf $@-iphonesimulator.framework

%-iphoneos:
	$(eval currentTarget=$(subst -iphoneos,,$@))
	$(XCODEBUILD) -project $(PROJECT) -target $(currentTarget) -sdk iphoneos -arch armv7 -arch arm64 -configuration Release clean build
	@ find ./build/Release-iphoneos/$(currentTarget) -type d -name "*.framework" | xargs -I % mv % ./

%-iphonesimulator:
	$(eval currentTarget=$(subst -iphonesimulator,,$@))
	$(XCODEBUILD) -project $(PROJECT) -target $(currentTarget) -sdk iphonesimulator -arch i386 -arch x86_64 -configuration Release clean build
	@ find ./build/Release-iphonesimulator/$(currentTarget) -type d -name "*.framework" | xargs -I % mv % $@.framework

clean:
	@ rm -rf Pods build *.framework

.PHONY: all clean
