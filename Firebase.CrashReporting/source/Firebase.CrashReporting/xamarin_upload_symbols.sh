BIN_PATH=""
INFO_PLIST=""
GOOGLE_PLIST=""
APP_NAME=""
SERVICE_ACCOUNT_FILE=""
MATCH_O=""
BASE_DIR=$(dirname $0)
SCRIPTS="$(find $BASE_DIR -type f -name \*)"

usage () {
    echo >&2 "usage: ${0##*/} [-h] [-b|--bin-path \"Path/to/bin\"] [-i|--info-plist \"Path/to/Info.plist\"] [-n|--name \"App name\"] [-p|--google-plist \"Path/to/GoogleService-Info.plist\"] [-s|--service-account \"Path/to/service-account.json\"]"
}

help () {
    usage
    cat >&2 <<EOF

-b|--bin-path                   The Build Output Directory of your iOS project.
-h|--help                       Show this help.
-i|--info-plist                 Location of Info.plist.
-n|--name                       The name of your app.
-p|--google-plist               Location of GoogleService-Info.plist.
-s|--service-account [optional] JSON file containing account information.

EOF
}

argumentMissing () {
    help
    exit 1
}

# Parse arguments.
for i in "$@"; do
    case $1 in
        -b|--bin-path) BIN_PATH="$2"; shift ;;
        -i|--info-plist) INFO_PLIST="$2"; shift ;;
        -n|--name) APP_NAME="$2"; shift ;;
        -p|--google-plist) GOOGLE_PLIST="$2"; shift ;;
        -s|--service-account) SERVICE_ACCOUNT_FILE="$2"; shift ;;
        -h|--help) help; exit 0 ;;
        --) shift; break ;;
        *) break ;;
    esac
    shift
done

if [ "$BIN_PATH" == "" ]; then
    echo "[-b|--bin-path] argument was not set."
    argumentMissing
fi

if [ "$INFO_PLIST" == "" ]; then
    echo "[-i|--info-plist] argument was not set."
    argumentMissing
fi

if [ "$APP_NAME" == "" ]; then
    echo "[-n|--name] argument was not set."
    argumentMissing
fi

if [ "$GOOGLE_PLIST" == "" ]; then
    echo "[-p|--google-plist] argument was not set."
    argumentMissing
fi

MATCH_O="$(find $BIN_PATH -type d -name $APP_NAME.app)"

if [ "$MATCH_O" != "" ]; then
    "$BASE_DIR"/batch-upload -p "$GOOGLE_PLIST" -i "$INFO_PLIST" "$SERVICE_ACCOUNT_FILE" "$MATCH_O/$APP_NAME"
fi
