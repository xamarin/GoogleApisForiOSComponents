
VERSION=4_0_1
SDK_FOLDER=google_signin_sdk_$(VERSION)

all: GoogleSignIn GoogleSignIn.bundle

GoogleSignIn:
	curl -O https://developers.google.com/identity/sign-in/ios/sdk/google_signin_sdk_$(VERSION).zip
	unzip -p $(SDK_FOLDER).zip '$(SDK_FOLDER)/GoogleSignIn.framework/GoogleSignIn' > GoogleSignIn
	unzip -p $(SDK_FOLDER).zip '$(SDK_FOLDER)/GoogleSignInDependencies.framework/GoogleSignInDependencies' > GoogleSignInDependencies
	unzip -p $(SDK_FOLDER).zip '$(SDK_FOLDER)/GoogleAppUtilities.framework/GoogleAppUtilities' > GoogleAppUtilities

GoogleSignIn.bundle:
	unzip $(SDK_FOLDER).zip '$(SDK_FOLDER)/GoogleSignIn.bundle/*' -d ./
	mv $(SDK_FOLDER)/GoogleSignIn.bundle/ ./
	rm -rf $(SDK_FOLDER)
	rm $(SDK_FOLDER).zip

clean:
	rm -rf [Gg]oogle* Resources/

.PHONY: all clean


