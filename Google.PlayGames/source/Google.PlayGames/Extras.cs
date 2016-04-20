using System;
using Foundation;

namespace Google.Play.GameServices
{
    public partial class RealTimeRoom
    {

        public int SendReliableData (NSData data, RealTimeParticipant [] participants)
        {
            var array = NSArray.FromObjects (participants);
            return _SendReliableData (data, array);
        }

        public int SendReliableData (NSData data, string [] participantsId)
        {
            var array = NSArray.FromObjects (participantsId);
            return _SendReliableData (data, array);
        }

        public void SendUnreliableData (NSData data, RealTimeParticipant [] participants)
        {
            var array = NSArray.FromObjects (participants);
            _SendUnreliableData (data, array);
        }

        public void SendUnreliableData (NSData data, string [] participantsId)
        {
            var array = NSArray.FromObjects (participantsId);
            _SendUnreliableData (data, array);
        }
    }
}