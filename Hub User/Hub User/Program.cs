using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hub
{
    class HUB_Tester
    {
        static void Main(string[] args)
        {
            HUB debug = HUB.HouseOfBeats;
            debug.Join("Oluokun Samson Opeyemi", "Male", true);
            HUB.User sammxin = HUB.users[0];
            sammxin.AddFriend(new HUB.User("Dawodu Oluwabusayomi", "Gay", DateTime.Now, true));
            sammxin.AddFriend(new HUB.User("Adekolu Mofe Joshua", "Male?", DateTime.Now, false));
            sammxin.AddFriend(new HUB.User("Abolarin Kasope", "Male", DateTime.Now, true));
            sammxin.AddFriend(new HUB.User("Ogungbe Ayobami", "Male", DateTime.Now, true));
            sammxin.AddTrack("We are coming back");
            sammxin.AddTrack("I feel no Love");

            Console.WriteLine(sammxin.Tracks);
            
            Console.ReadKey();

        }
    }
    class HUB
    {
        private static HUB hob;
        public string hub = @"[H'U'B] House of Beats";
        internal static List<User> users;
        private static List<User> backupUsers;
        private static bool active;
        private HUB()
        {
            users = new List<User>();
            backupUsers = new List<User>();
            active = true;
        }
        private HUB(List<User> users) : this()
        {
            foreach (User user in users)
            {
                HUB.users.Add(user);
            }
        }
        public User this[int index]
        {
            get { return users[index]; }
        }
        public static HUB HouseOfBeats
        {
            get
            {
                if (hob == null)
                {
                    if (backupUsers != null)
                    {
                        hob = new HUB(backupUsers);
                    }
                    else
                    {
                        hob = new HUB();
                    }
                }
                return hob;
            }
        }
        internal class User
        {
            public string name;
            public string sex;
            private DateTime accountCreated;
            public bool isProducer; //True for an HUB "HouseOfBeats" account (Producer account), False for Artist "LeadOfBeats" account "LEB".
            private List<User> friends;
            public List<BeatTrack> tracks;

            public User(string name, string sex, DateTime acctDate, bool isProducer)
            {
                this.name = name;
                this.sex = sex;
                this.accountCreated = acctDate;
                this.isProducer = isProducer;
                friends = new List<User>();
                tracks = new List<BeatTrack>();
            }

            public User(string name, string sex, DateTime acctDate, bool isProducer, List<User> previousFriends)
                : this(name, sex, acctDate, isProducer)
            {
                foreach (User user in previousFriends)
                {
                    friends.Add(user);
                }
            }

            public string Friends
            {   //Returns a string containing friends info in List Format.
                get
                {
                    StringBuilder friendsNames = new StringBuilder();
                    for (int i = 0; i < friendsNames.Length; i++)
                    {
                        friendsNames.AppendFormat(@"""{0}"", Name: {1}, Sex: {2}, {3} Friends.\r\n",
                            isProducer ? "Producer" : "Vocalist", name, sex, FriendsCount);
                    }
                    string friendList = friendsNames.ToString();
                    return friendList;
                }
            }

            public string Tracks
            {
                get
                {
                    StringBuilder trackNames = new StringBuilder();
                    for (int i = 0; i < tracks.Count; i++)
                    {
                        trackNames.AppendFormat("[{0}], Track Name: {1}, Artist: {2}, {3}.\r\n",
                            tracks[i].featuredTrack ? "Mix" : "Beat", tracks[i].Name, tracks[i].producer.name,
                            tracks[i].featuredTrack ? tracks[i].GetFeatureNames : "No features yet");
                    }
                    string trackList = trackNames.ToString();
                    return trackList;
                }
            }
            public int FriendsCount { get { return friends.Count; } }
            public string FriendName(int index)
            {
                return friends[index].name;
            }
            public void AddTrack(string trackName, params User[] features)
            {
                tracks.Add(new BeatTrack(this, trackName, features == null ? null : features));
            }
            public void AddFriend(User newUser)
            {
                friends.Add(newUser);
            }
        }
        internal class BeatTrack
        {
            internal User producer;
            internal List<User> features;
            private string trackName;
            public bool featuredTrack;
            public BeatTrack(User producer, string name)
            {
                this.producer = producer;
                trackName = name;
                features = new List<User>();
            }
            public BeatTrack(User producer, string name, params User[] artistsAndProducers)
                : this(producer, name)
            {
                if (artistsAndProducers != null)
                {
                    foreach (User feat in artistsAndProducers)
                    {
                        features.Add(feat);
                    }
                }
                featuredTrack = features.Count > 0 ? true : false;
            }

            public string Name
            {
                get { return trackName; }
            }
            public string GetFeatureNames
            {
                get
                {
                    StringBuilder stb = new StringBuilder();
                    foreach (User user in features)
                    {
                        stb.AppendFormat("{0}, ", user.name);
                    }
                    string result = stb.ToString();
                    result.TrimEnd();
                    result = result + ".";
                    return result;
                }
            }
        }
        public void Join(string namestring, string sex, bool isProducer)
        {
            DateTime now = DateTime.Now;
            //if (true)
            //{ If individual already has friends in the database
                    //Call new User > with Friends List
            //}
            User newUser = new User(hub, sex, now, isProducer);
            users.Add(newUser);
            backupUsers.Add(newUser);
        }
    }
}
