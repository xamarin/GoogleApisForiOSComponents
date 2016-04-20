using System;
using System.Threading.Tasks;
using Foundation;

namespace Google.InstanceID
{
    public partial class InstanceId
    {
        public Task<string> GetIDAsync ()
        {
            var tcsId = new TaskCompletionSource<string> ();

            this.GetID ((identity, error) => {
                if (error != null) {
                    tcsId.TrySetException (new NSErrorException (error));
                } else {
                    tcsId.TrySetResult (identity);
                }
            });

            return tcsId.Task;
        }

        public Task DeleteIDAsync ()
        {
            var tcsId = new TaskCompletionSource<object> ();

            this.DeleteID (error => {
                if (error != null && error.Code == 1)
                    return;
                
                Console.WriteLine ("Delete ID Callback");
                if (error != null)
                    tcsId.TrySetException (new NSErrorException (error));
                else
                    tcsId.TrySetResult (null);
            });

            return tcsId.Task;
        }
    }
}

