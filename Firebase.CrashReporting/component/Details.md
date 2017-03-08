### **Important note:** *This component is only compatible with Xamarin Studio and Visual Studio for Mac.*

Firebase Crash Reporting uses shell scripts to upload symbols to Firebase Console, but scripts use commands that are only available in Mac. Therefore, this component is only compatible with Xamarin Studio and Visual Studio for Mac.

# Firebase Crash Reporting on iOS

Comprehensive and actionable information to help diagnose and fix problems in your app.

Crash Reporting creates detailed reports of the errors in your app. Errors are grouped into clusters of similar stack traces and triaged by the severity of impact on your users. In addition to automatic reports, you can log custom events to help capture the steps leading up to a crash.

## Key capabilities

* **Monitor fatal errors:** Monitor fatal errors in iOS. Reports are triaged by the severity of impact on users.
* **Collect the data you need to diagnose problems:** Each report contains a full stack trace as well as device characteristics, performance data, and user circumstances when the error took place. Similar reports are automatically clustered to make it easier to identify related bugs.
* **Email alerts:** Enable email alerts to receive frequent updates when new crashes are uncovered or regressions are detected.
* **Integrate with Analytics:** Errors captured are set as **app_exception** events in Firebase Analytics, allowing you to filter audiences based on who sees errors. In addition to stack traces, Crash Reporting also integrates with Analytics to provide you with the list of events that preceded a crash. This information helps to simplify your debugging process.
* **Free and easy:** Crash Reporting is free to use. Once you've added Firebase to your app, it's just a few lines of code to enable comprehensive error reporting.

## User privacy

Firebase Crash Reporting does not itself collect any personally identifiable information (such as names, email addresses, or phone numbers). Developers can collect additional data using Crash Reporting with log and exception messages. Such data collected through Crash Reporting should not contain information that personally identifies an individual to Google.

Here is an example of a log message that does not contain personally identifiable information:

```csharp
Firebase.CrashReporting.CrashReporting.Log ("SQL database failed to initialize");
```

And here is another one that does contain personally identifiable information:

```csharp
Firebase.CrashReporting.CrashReporting.Log ($"{user.Email} purchased product {product.Id}");
```

If identifying a user is necessary to diagnose an issue, then you must use adequate obfuscation measures to render the data you send to Google anonymous.

<sub>_Portions of this page are modifications based on work created and [shared by Google](https://developers.google.com/readme/policies/) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/). Click [here](https://firebase.google.com/docs/crash/) to see original Firebase documentation._</sub>
