POD=pod
XCODEBUILD=$(shell xcrun --sdk iphoneos --find xcodebuild)

PROJECT_ROOT=./Pods
PROJECT=$(PROJECT_ROOT)/Pods.xcodeproj
TARGETS=FirebaseFirestore gRPC gRPC-C++ gRPC-Core gRPC-ProtoRPC gRPC-RxLibrary BoringSSL

all: Pods $(TARGETS)

Pods:
	$(POD) install

$(TARGETS):
	@ $(eval libraryName=$(shell \
	if [ "$@" == "gRPC" ]; then \
		echo "GRPCClient"; \
	elif [ "$@" == "gRPC-C++" ]; then \
		echo "grpcpp"; \
	elif [ "$@" == "gRPC-Core" ]; then \
		echo "grpc"; \
	elif [ "$@" == "gRPC-ProtoRPC" ]; then \
		echo "ProtoRPC"; \
	elif [ "$@" == "gRPC-RxLibrary" ]; then \
		echo "RxLibrary"; \
	elif [ "$@" == "BoringSSL" ]; then \
		echo "openssl"; \
	else \
		echo $@; \
	fi))
	@ if [ ! -d "./$(libraryName).framework" ]; then \
		$(MAKE) $@-iphoneos; \
		cp -R ./build/Release-iphoneos/$@/$(libraryName).framework ./; \
		$(MAKE) $@-iphonesimulator; \
		cp -R ./build/Release-iphonesimulator/$@/$(libraryName).framework/ ./$(libraryName)-iphonesimulator.framework; \
		lipo -create -output $(libraryName).framework/$(libraryName) $(libraryName).framework/$(libraryName) $(libraryName)-iphonesimulator.framework/$(libraryName); \
		rm -rf $(libraryName)-iphonesimulator.framework; \
	fi

%-iphoneos:
	@ $(eval currentTarget=$(subst -iphoneos,,$@))
	@ $(XCODEBUILD) -project $(PROJECT) -target $(currentTarget) -sdk iphoneos -arch armv7 -arch arm64 -configuration Release build

%-iphonesimulator:
	@ $(eval currentTarget=$(subst -iphonesimulator,,$@))
	@ $(XCODEBUILD) -project $(PROJECT) -target $(currentTarget) -sdk iphonesimulator -arch i386 -arch x86_64 -configuration Release build

clean:
	@ rm -rf Pods build *.framework

.PHONY: all clean
