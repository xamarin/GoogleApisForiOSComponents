using System;
using ObjCRuntime;

namespace Firebase.Functions
{
    [Native]
    public enum FunctionsErrorCode : long
    {
        FunctionsErrorCodeOK = 0,
        FunctionsErrorCodeCancelled = 1,
        FunctionsErrorCodeUnknown = 2,
        FunctionsErrorCodeInvalidArgument = 3,
        FunctionsErrorCodeDeadlineExceeded = 4,
        FunctionsErrorCodeNotFound = 5,
        FunctionsErrorCodeAlreadyExists = 6,
        FunctionsErrorCodePermissionDenied = 7,
        FunctionsErrorCodeResourceExhausted = 8,
        FunctionsErrorCodeFailedPrecondition = 9,
        FunctionsErrorCodeAborted = 10,
        FunctionsErrorCodeOutOfRange = 11,
        FunctionsErrorCodeUnimplemented = 12,
        FunctionsErrorCodeInternal = 13,
        FunctionsErrorCodeUnavailable = 14,
        FunctionsErrorCodeDataLoss = 15,
        FunctionsErrorCodeUnauthenticated = 16,
    }
}
