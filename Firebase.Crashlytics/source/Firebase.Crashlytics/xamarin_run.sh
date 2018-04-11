export BUILT_PRODUCTS_DIR=""
export DWARF_DSYM_FILE_NAME=""
export DWARF_DSYM_FOLDER_PATH=""
export INFOPLIST_PATH=""
export PROJECT_DIR=""
export SRCROOT=""
export UNLOCALIZED_RESOURCES_FOLDER_PATH=""
export PLATFORM_NAME=""
export SDKROOT=""
export EXECUTABLE_PATH=""
export TARGETED_DEVICE_FAMILY=""

APP_NAME=""
DEVICE_SPECIFIC_OUTPUT_PATH=""
FABRIC_RUN_SCRIPT_PATH=""

usage () {
    echo >&2 "usage: ${0##*/} [-h|--help] [-n|--name \"Assembly/App name\"] [-p|--project-dir \"Path/to/your/iOS/project\"] [-o|--output-path \"Device/Specific/Output/Path/value\"] [-s|--fabric-script \"Path/to/Fabric/Run/Script\"] [-sdk \"Path/to/Xcode/SDK\"]"
}

help () {
    usage
    cat >&2 <<EOF

-h|--help		Show this help.
-n|--name		The Assembly Name of your iOS app.
-p|--project-dir	The Project Directory of your iOS project.
-o|--output-path	The Device Specific Output Path of your iOS project.
-s|--fabric-script  	The Fabric Run Script Path.
-sdk			The SDK Root value.

EOF
}

argumentMissing () {
    help
    exit 1
}

# Parse arguments.
for i in "$@"; do
    case $1 in
        -n|--name) APP_NAME="$2"; shift ;;
        -p|--project-dir) PROJECT_DIR="$2"; shift ;;
        -o|--output-path) DEVICE_SPECIFIC_OUTPUT_PATH="$2"; shift ;;
        -s|--fabric-script) FABRIC_RUN_SCRIPT_PATH="$2"; shift ;;
        -sdk) SDKROOT="$2"; shift ;;
        -h|--help) help; exit 0 ;;
        --) shift; break ;;
        *) break ;;
    esac
    shift
done

if [ "$APP_NAME" == "" ]; then
    echo "[-n|--name] argument was not set."
    argumentMissing
fi

if [ "$PROJECT_DIR" == "" ]; then
    echo "[-p|--project-dir] argument was not set."
    argumentMissing
fi

if [ "$DEVICE_SPECIFIC_OUTPUT_PATH" == "" ]; then
    echo "[-o|--output-path] argument was not set."
    argumentMissing
fi

if [ "$FABRIC_RUN_SCRIPT_PATH" == "" ]; then
    echo "[-s|--fabric-script] argument was not set."
    argumentMissing
fi

if [ "$SDKROOT" == "" ]; then
    echo "-sdk argument was not set."
    argumentMissing
fi

export BUILT_PRODUCTS_DIR=/Users/israelsoto/GitHub/SotoiGhost/GoogleApisForiOSComponents/Firebase.Crashlytics/samples/CrashlyticsSample/CrashlyticsSample/bin/iPhone/Debug/device-builds/iphone9.1-11.2.6
export DWARF_DSYM_FILE_NAME=CrashlyticsSample.app.dSYM
export DWARF_DSYM_FOLDER_PATH=/Users/israelsoto/GitHub/SotoiGhost/GoogleApisForiOSComponents/Firebase.Crashlytics/samples/CrashlyticsSample/CrashlyticsSample/bin/iPhone/Debug/device-builds/iphone9.1-11.2.6
export INFOPLIST_PATH=CrashlyticsSample.app/Info.plist
export PROJECT_DIR=/Users/israelsoto/GitHub/SotoiGhost/GoogleApisForiOSComponents/Firebase.Crashlytics/samples/CrashlyticsSample/CrashlyticsSample
export SRCROOT=/Users/israelsoto/GitHub/SotoiGhost/GoogleApisForiOSComponents/Firebase.Crashlytics/samples/CrashlyticsSample/CrashlyticsSample
export UNLOCALIZED_RESOURCES_FOLDER_PATH=CrashlyticsSample.app
export PLATFORM_NAME=iphoneos
export SDKROOT=/Applications/Xcode.app/Contents/Developer/Platforms/iPhoneOS.platform/Developer/SDKs/iPhoneOS11.3.sdk
export EXECUTABLE_PATH=CrashlyticsSample.app/CrashlyticsSample
export TARGETED_DEVICE_FAMILY=1,2

FULL_DEVICE_SPECIFIC_OUTPUT_PATH="$PROJECT_DIR/$DEVICE_SPECIFIC_OUTPUT_PATH"

BUILT_PRODUCTS_DIR=$FULL_DEVICE_SPECIFIC_OUTPUT_PATH
DWARF_DSYM_FILE_NAME="$APP_NAME.app.dSYM"
DWARF_DSYM_FOLDER_PATH=$FULL_DEVICE_SPECIFIC_OUTPUT_PATH
INFOPLIST_PATH="$APP_NAME.app/Info.plist"
SRCROOT=$PROJECT_DIR
UNLOCALIZED_RESOURCES_FOLDER_PATH="$APP_NAME.app"
PLATFORM_NAME="iphoneos"
EXECUTABLE_PATH="$APP_NAME.app/$APP_NAME"
TARGETED_DEVICE_FAMILY="1,2"

"$FABRIC_RUN_SCRIPT_PATH/run"
