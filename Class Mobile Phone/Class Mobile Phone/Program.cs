using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Class_Mobile_Phone
{
    class Phone
    {
        public string model, manufacturer, price, owner;
        public static string OS { get { return "Android 6.0.1 (Marshmallow)"; } } 
        Features features;
        public Functions functions;
        private static Phone nokiaN95 = new Phone("Nokia N95", "Nokia Coorperation", "$200");
        //Initialization of the Class fields.
        public static Phone Nokia { get { return nokiaN95; } }
        public Phone() : this("Unknown model")
        {}

        public Phone(string model) : this(model, "Unknown")
        {}

        public Phone(string model, string manufacturer) : this(model, manufacturer, "Unknown Price")
        {}

        public Phone(string model, string manufacturer, string price)
            : this(model, manufacturer, price, "Lost Phone")
        {}
        //Reusing constructors to initiate object.
        public Phone(string model, string manufacturer, string price, string owner)
            : this(model, manufacturer, price, owner, "Unknown", "Unknown", "Unknown", "Unknown", false)
        { }

        public Phone(string model, string manufacturer, string price, string owner, string batteryModel,
            string batteryIdleTime, string batteryTalkTime, string batterySize, bool batisColoured)
        {   //Main Constructor.
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            features = new Features(model, batteryIdleTime, batteryTalkTime, batterySize, batisColoured);
            functions = new Functions();
        }
        
        public override string ToString()
        {
            string obj = string.Format("Phone model and name: {0} ({1}).\r\nPhone owner: {2}" + 
                         "\r\nPrice : {3}", this.model, this.manufacturer, this.owner, this.price);
            return obj;
        }

        public static void ShowInfo(Phone phone)
        {   //Displays any object's properties
            Console.WriteLine();
            Console.WriteLine("Phone model: {0}.\r\nManufacturer: {1}.\r\nPrice: {2}", phone.model, phone.manufacturer, phone.price);
            Console.WriteLine("\"{0}\" is the owner of this phone.", phone.owner);
            Console.ReadKey(false);
            Console.WriteLine();
        }

        public void AddCall(string dt, string strt, string dur)
        {
            //string[] formats = {"dd/MM/yy h-m-s", "dd/MM/yy hh-mm-ss", "dd/MM/yyyy hh-mm-ss",
            //    "d/MM/yyyy hh-mm-ss", "dd-MM-yyyy hh-mm-ss", "d-MM-yyyy hh-mm-ss", "dd-MM-yyyy hh mm ss", "dd MM yyyy hh mm ss",
            //    "dd MM yy hh mm ss", "d MM yy hh mm ss"};
            DateTime date = DateTime.ParseExact(dt, "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
            DateTime start = DateTime.ParseExact(strt, "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
            DateTime duration = DateTime.ParseExact(dur, "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
            functions.PhoneCall.CallHistory.Add(new Functions.Call(date, start, duration));
        }

        public void DeleteCall(int index)
        {
            functions.PhoneCall.CallHistory.RemoveAt(index);
        }
        
        public string TotalCall(double price = 0.37d)
        {
            List<Functions.Call> tmp = functions.PhoneCall.CallHistory;
            int count = tmp.Count;
            int minutes = 0;
            for (int i = 0; i < tmp.Count; i++)
            {
                minutes += tmp[i].Duration;
            }
            minutes = Math.Abs(minutes);
            string text = string.Format("The total number of call(s) is {0}, {1} minutes," +
                "\r\nand all the cost is ${2} at the price of {3} per minute.", count, minutes, price * minutes, price);
            return text;
        }

        public void ClearCalls()
        {
            functions.PhoneCall.CallHistory.Clear();
        }

        public class Functions
        {
            private Call call = new Call();
            public Call PhoneCall { get { return call; } }
            public class Call
            {   
                private readonly DateTime date;
                private readonly DateTime start;
                private readonly DateTime end;
                private List<Call> callHistory = new List<Call>();   //static Call history record.
                public Call()
                {

                }
                public Call(DateTime date, DateTime start, DateTime end)
                {   //Call constuctor
                    this.date = date;
                    this.start = start;
                    this.end = end;
                }
                public List<Call> CallHistory { get { return callHistory; } }
                public Call this[int index]
                {   //
                    get { return callHistory[index]; }
                    //set { callHistory[index] = value; }
                }

                public DateTime Date
                {
                    get { return date; }
                }

                public DateTime Start
                {
                    get { return start; }
                }
                public int Duration
                {
                    get
                    {
                        DateTime tmp = start;
                        DateTime tmp2 = end;
                        return tmp2.Minute - tmp.Minute;
                    }
                }
            }
        }

        public struct Features
        {
            Battery battery;
            Screen screen;

            public Features(string model) 
                : this(model, "Unknown")
            {}

            public Features(string model, string idleTime) 
                : this(model, idleTime, "Unknown")
            {}

            public Features(string model, string idleTime, string talkTime) 
                : this(model, idleTime, talkTime, "Unknown")
            {}
            //Resuing constructors to create object.
            public Features(string model, string idleTime, string talkTime, string size) 
                : this(model, idleTime, talkTime, size, false)
            {}

            public Features(string model, string idleTime, string talkTime, string size, bool isColoured)
            {   //Main Constructors.
                battery = new Battery(model, idleTime, talkTime);
                screen = new Screen(size, isColoured);
            }
            
            public struct Battery
            {
                private string model;
                private string idleTime;
                private string talkTime;
                public enum BatteryType
                {
                    LiIon, NiMH, NiCd
                }

                internal Battery(string model, string idleTime, string talkTime)
                {   //Constructor for the Battery sub-class.
                    this.model = model;
                    this.idleTime = idleTime;
                    this.talkTime = talkTime;
                }
                public string Model
                {
                    get { return model; }
                }
                public string IdleTime
                {
                    get { return idleTime; }
                }
                public string TalkTime
                {
                    get { return talkTime; }
                }
            }

            public struct Screen
            {
                private string size;
                private bool isColoured;
                internal Screen(string size, bool isColoured)
                {   //Constructor for the Screen sub-class.
                    this.size = size;
                    this.isColoured = isColoured;
                }
                public string Size
                {
                    get { return this.size; }
                }
                public bool IsColoured
                {
                    get { return this.isColoured; }
                }
            }
        }
    }

    class Program
    {
        static StreamWriter writer;
        static StreamReader reader;
        static Phone userPhone;
        static void Main(string[] args)
        {
            try
            {
                userPhone = new Phone("S9", "Samsung Mobile.");
                ManagePhones();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
                Main(args);
            }
            
        }

        //static void PhoneCallTest(Phone userPhone)
        //{ ////Method to test the functionality of the created Call objects, the cost of each call and to delete the longest call
        //    Phone tmp = userPhone;
        //    string date = "17/10/2017 00:00:00", start = "17/10/2017 05:53:00", stop = "17/10/2017 05:59:00";
        //    tmp.AddCall(date, start, stop);
        //    tmp.AddCall(date, start, stop);
        //    tmp.AddCall(date, start, stop);
        //    tmp.AddCall(date, start, stop);
        //    tmp.AddCall("17/10/2017 00:00:00", "17/10/2017 05:53:00", "17/10/2017 06:00:00");
        //    string total = tmp.TotalCall(0.37d);
        //    int temp = 0;
        //    int ind = 0;
        //    List<Phone.Functions.Call> list = tmp.functions.PhoneCall.CallHistory;
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        if (list[i].Duration > temp)
        //        {
        //            temp = list[i].Duration;
        //            ind = i;
        //        }
        //    }
        //    tmp.DeleteCall(ind);

        //}

        static void ManagePhones()
        {
            Console.WriteLine("To Load previously created phones, Press \"1\".");
            Console.WriteLine("To Delete a Phone, Press \"2\".");
            Console.Write("To create a new phone, simply press \"3\"\r\n : ");
            string swt = Console.ReadLine().Trim();
            if (String.IsNullOrEmpty(swt) || String.IsNullOrWhiteSpace(swt))
            {
                Console.WriteLine("Input is incorrect.");
                ManagePhones();
            }
            switch (swt)    //To switch between creating a new object or load previous objects from files'
            {
                case "1":
                    LoadPhone();
                    break;
                case "2": DeletePhone(); break;
                case "3":
                    AppInterface();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    ManagePhones();
                    break;
            }
        }

        static void LoadPhone()
        {
            Console.Write("Enter Username: ");
            string file = Console.ReadLine().Trim().ToLower();

            if (String.IsNullOrEmpty(file) || String.IsNullOrWhiteSpace(file))
            {
                Console.WriteLine("Input is incorrect.");
                LoadPhone();
            }

            if (CheckPhone(file))   //To load a previous phone, we check the app memory.
            {
                userPhone = RetrievePhone(file);    //Retrieve phone from log.
            }
            else
            {
                Console.WriteLine("Phone not found.");
                return;
            }

            if (userPhone == null)
            {
                throw new Exception("Phone not found.");
            }
            Console.WriteLine("100% Loading successful..");
            Phone.ShowInfo(userPhone);  //Display new loaded Phone
        }

        static Phone RetrievePhone(string file)
        {
            List<string> list = new List<string>();
            using (reader = new StreamReader("phones/" + file +".log"))
            {
                while (!reader.EndOfStream)
                {
                    list.Add(reader.ReadLine().Trim());
                }   //Retrieving Previously saved Phone object information from app memory.
            }
            Phone tempPhone = null;
            switch (list.Count)
            {
                case 0: return null;
                case 1: tempPhone = new Phone(list[0]);
                    break;
                case 2: tempPhone = new Phone(list[0], list[1]);
                    break;
                case 3: tempPhone = new Phone(list[0], list[1], list[2]);
                    break;
                case 4: tempPhone = new Phone(list[0], list[1], list[2], list[3]);
                    break;
                case 9: tempPhone = new Phone(list[0], list[1], list[2], list[3], list[4],
                        list[5], list[6], list[7], bool.Parse(list[8]));
                    break;  //Initializing a new object to hold retrieved object state.
                default: Console.WriteLine("Sorry there is no such Phone in the database.");
                    break;
            }
            return tempPhone;
        }

        static void AppInterface()
        {
            try
            {
                Console.Write("Please input the Username you'll use to access the Phone later (e.g \"Opeyemi\")\r\n : ");
                string file = Console.ReadLine().Trim().ToLower();

                if (!CheckPhone(file))      //Check if user doesn't already exist.
                {
                    List<string> tmp = CreatePhone();
                    AddPhoneToDB(file, tmp);
                }
                else
                {
                    Console.WriteLine("Sorry, this phone already exists in the system. Try another Filename.");
                    AppInterface();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        static bool CheckPhone(string file)
        {
            try
            {
                using (reader = new StreamReader("users/users.log"))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine().Trim('/', '\r', '\n');
                        if (file == line)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The Application log file cannot be found.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Something must be wrong with the memory log file.");
            }
            return false;
        }

        static void AddPhoneToDB(string name, List<string> phone)
        {

            using (StreamWriter append = new StreamWriter("users/users.log", true))
            {
                append.WriteLine(name);
            }

            using (StreamWriter write = new StreamWriter("phones/" + name + ".log", false))
            {
                for (int i = 0; i < phone.Count; i++)
                {
                    write.WriteLine(phone[i]);
                }
            }
        }

        static void DeletePhone()
        {
            Console.Write("Please enter your Username: ");
            string name = Console.ReadLine().Trim().ToLower();
            if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Input is incorrect.");
                DeletePhone();
            }
            if (CheckPhone(name))   //Check if username is in log file before proceeding.
            {
                try
                {
                    File.Delete("phones/" + name + ".log"); //Delete the memory file used to store the object's state.
                    List<string> list = new List<string>();
                    using (reader = new StreamReader("users/users.log"))
                    {
                        while (!reader.EndOfStream)     //Get the current users list.
                        {
                            list.Add(reader.ReadLine().Trim());
                        }
                    }
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] == name)    //Check if list contains value.
                        {
                            list.RemoveAt(i);
                        }
                    }
                    
                    using (writer = new StreamWriter("users/users.log", false))
                    {
                        if (list.Count == 0)
                        {
                            File.Delete("users/users.log");
                            File.Create("users/users.log");
                        }
                        else
                        {
                            for (int i = 0; i < list.Count; i++)    //Replace old log with updated log.
                            {
                                writer.WriteLine(list[i]);
                            }
                        }
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Cannot load saved phone.");
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("Unable to delete phone. Directory not found.");
                }

                Console.WriteLine("Phone Deleted successfully.");
            }
            else
            {
                Console.WriteLine("This username does not exist.");
            }
        }

        static List<string> CreatePhone()
        {
            Phone myPhone = null;
            List<string> tmp = null;
            Console.WriteLine("Please input the following features of your new phone.");
            Console.Write("Enter model: ");
            string model = Console.ReadLine().Trim();
            Console.Write("Enter Manufacturer: ");
            string manufacturer = Console.ReadLine().Trim();
            Console.Write("Enter Price: ");
            string price = Console.ReadLine().Trim();       //Collect information required to create object.
            Console.Write("Name of owner: ");
            string owner = Console.ReadLine().Trim();
            Console.WriteLine("If you would like to include a Battery and Screen, press 1. If not press 2.");
            string swt = Console.ReadLine().Trim();
            if (String.IsNullOrEmpty(swt) || String.IsNullOrWhiteSpace(swt))
            {
                Console.WriteLine("Input is incorrect.");
                throw new ArgumentException("It is unclear if or not you want to include extra features in your phone.");
            }

            switch (swt)        //Option to include extra features.
            {
                case "1": //With Battery and Screen
                    Console.Write("Enter Battery model: ");
                    string baModel = Console.ReadLine().Trim();
                    Console.Write("Enter IdleTime: ");
                    string idleTime = Console.ReadLine().Trim();
                    Console.Write("Enter Talktime: ");
                    string talkTime = Console.ReadLine().Trim();
                    Console.Write("Screen size: ");
                    string size = Console.ReadLine().Trim();
                    Console.WriteLine("Is the screen coloured? (Enter True or False).");
                    bool color = bool.Parse(Console.ReadLine().Trim());
                    myPhone = new Phone(model, manufacturer, price, owner, baModel, idleTime, talkTime, size, color);
                    Console.WriteLine("Phone created succesfully.");
                    tmp = new List<string> { model, manufacturer, price, owner, baModel, idleTime, talkTime, size, color.ToString() };
                    break;
                case "2":   //Without battery and screen.
                    myPhone = new Phone(model, manufacturer, price, owner);
                    Console.WriteLine("Phone created successfully.");
                    tmp = new List<string> { model, manufacturer, price, owner };
                    break;
                default: Console.WriteLine("Invalid input");
                    break;
                    
            }
            userPhone = myPhone;
            return tmp;
        }
    }
}
