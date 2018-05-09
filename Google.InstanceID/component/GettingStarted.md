
## Generating / Fetching an Instance ID

Before attempting to generate or fetch an Instance ID, you must start the InstanceID engine and pass it an instance of `Config`.  You can use the Default instance of `Config`:

```csharp
InstanceId.SharedInstance.Start (Config.DefaultConfig);
```

After you've called `Start (..)`, generating and fetching an InstanceID is done the same way:

```csharp
var instanceId = await InstanceId.SharedInstance.GetIDAsync ();
```

This call may take several seconds to complete, so you should plan on not blocking the UI when making this call.  You should always receive the same Instance ID value back after the first time you call this method.

## Deleting an Instance ID

It is possible to delete an Instance ID.  Once you have deleted a particular Instance ID the next time you call `GetID` or `GetIDAsync` to generate an Instance ID, you will receive a new value.

To delete an instance ID, simply call `DeleteID` or `DeleteIDAsync`:

```csharp
await InstanceId.SharedInstance.DeleteIDAsync ();
```

**Important Note**: In this version of Instance ID, Google is internally invoking the callback handler that you pass into the `DeleteID` method.  They first call back with a non-null error value (error Code 1), and then immediately call back again with a null error, indicating the call succeeded.  To work around this, the `DeleteIDAsync` call ignores

## Know issues

* Error `Native linking failed, duplicate symbol '_main'` appears when you try to build for **iPhoneSimulator**. A workaround for this is to change the behavior of the **Registrar**:
	1. Open your project settings
	2. Go to **Build** tab
	3. Select **iOS Build** option
	4. Type `--registrar:static` in **Additional mtouch arguments** textbox
	5. Click on **Ok**

	Don't forget to add this in **Release** and **Debug** configuration of **iPhoneSimulator** platform.
	