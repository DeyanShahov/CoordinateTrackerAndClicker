using Google.Cloud.Firestore;

namespace CoordinateTrackerAndClicker.Users
{
    [FirestoreData]
    internal class UserData
    {
        [FirestoreProperty]
        public string UserName { get; set; }

        [FirestoreProperty]
        public string Password { get; set; }
    }
}
