using ObjCRuntime;

namespace Google.InstanceID
{   
    [Native]
    public enum OperationErrorCode : ulong
    {
        InvalidRequest = 0,
        Authentication = 1,
        NoAccess = 2,
        Timeout = 3,
        Network = 4,
        OperationInProgress = 5,
        Unknown = 7,
        MissingAPNSToken = 1001,
        MissingAPNSServerType = 1002,
        InvalidAuthorizedEntity = 1003,
        InvalidScope = 1004,
        InvalidStart = 1005,
        InvalidKeyPair = 1006,
        MissingKeyPair = 2001
    }

    public enum LogLevel : sbyte
    {
        Debug,
        Info,
        Error,
        Assert,
    }
}