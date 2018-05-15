using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dr.Samm
{
    class Program
    {
        static IDictionary<string, bool> friends = new Dictionary<string, bool>();
        static IDictionary<string, string> myData = new Dictionary<string, string>();
        static IDictionary<string, string> interests = new Dictionary<string, string>();
        private static IDictionary<string, string> samAI = new Dictionary<string, string>();
        
        static void Main(string[] args)
        {
            Intro();
            Sport();
            Console.ReadLine();
        }

        static void Intro()
        {
            Console.WriteLine("Hello, my name is Sam");
            Console.WriteLine("We should start with an introduction.");
            Console.WriteLine("What is your Surname?");
            myData.Add("Surname", Console.ReadLine());
            Console.WriteLine("What is your First name?");
            myData.Add("Firstname", Console.ReadLine());
            Console.WriteLine("Hello {0} {1}, nice to meet you.", myData[ "Surname"], myData["Firstname"]);
        }

        static bool[] No(string ans)
        {
            bool[] isValid = { false, false };
            string[] no =  {"no", "absolutely not", "certainly not", "most certainly not",
                                "of course not", "under no circumstances", "by no means",
                                "not at all", "negative", "never", "not really", "nope",
                                "uh-uh", "nah", "nope", "nop", "no way", "not on your life",
                                "not at all", "i cant", "i can't", "cant", "can't",
                                "oh no", "i wont", "i won't", "wont", "won't", "to no extent",
                                "noes", "nan", "at all", "nana", "non", "none", "na", "not ever", "nada", "nothing"};
            for (int i = 0; i < no.Length; i++)
            {
                if (ans ==  no[i])
                {
                    isValid[1] = false;
                    break;
                }
                else
                {
                    isValid[1] = true;
                }
            }
            return isValid;
        }

        static bool[] Yes(string ans)
        {
            bool[] isValid = No(ans);
            string[] yes =  {"yes", "yeah", "okay", "accept", "i accept",
                                 "i agree", "i know", "agree", "yep", "yup",
                                 "all right","very well", "of course",
                                 "by all means", "sure","certainly",
                                 "absolutely","indeed","right","affirmative",
                                 "agreed","roger","aye aye","yeh","yop","ya",
                                 "uh-huh","ok","okey-dokey","okey-doke","yea",
                                 "aye", "i hear", "i heard", "ive heard", "i've heard" };
            for (int i = 0; i < yes.Length; i++)
            {
                if (ans == yes[i])
                {
                    isValid[0] = true;
                    break;
                }
                else
                {
                    isValid[0] = false;
                }
            }
            return isValid;
        }
        
        static bool YesOrNo(string ans)
        {
            bool reply;
            if (Yes(ans)[0] || Yes(ans)[1])
            {
                reply = true;
            }
            else 
            {
                reply = false;
            }
            return reply;
        }

        static void Sport()
        {
            Console.WriteLine("So {0}, tell me more about you", myData["Firstname"]);
            Console.WriteLine("Are you a Sports person?");
            string sport = Console.ReadLine();
            if (YesOrNo(sport))
            {
                GetSport();
            }
            else
            {

                return;
            }
        }

        static void GetSport()
        {
            Console.WriteLine("What is your Favorite sport?");
            interests.Add("Fav sport", Console.ReadLine());
            Console.WriteLine("What {0} Team is your Favorite?", interests["Fav sport"]);
            interests.Add("Fav team", Console.ReadLine());
            Console.WriteLine("Okay {0}, you like {1} and {2} is your Favorite team", myData["Firstname"], interests["Fav sport"], interests["Fav team"]);
        }
        static void Sam()
        {
            samAI.Add("Name:", "Sam");
            samAI.Add("Real name:", "Oluokun Samson");
            samAI.Add("Version:", "1.0");
        }
        
        
        

    }
}
              
            