using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Net;


namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string url = "https://static.pexels.com/photos/104827/cat-pet-animal-domestic-104827.jpeg"; //url to download file from.
                using (WebClient client = new WebClient()) //Initialize the webclient class
                {
                    Console.WriteLine("Downloading file....");
                    client.DownloadFile(url, "Cat-Image.png"); // input the url and the desired filename
                    Console.WriteLine("Successfully Downloaded file from {0}", url); //This is displayed when the download is successful.                   
                }
                
                Console.ReadKey();
            }
            catch (ArgumentNullException)   //Catch possible exceptions
            {
                Console.WriteLine("There is something wrong with the URI of the File.");
            }
            catch (WebException)
            {
                Console.WriteLine("There is something wrong with the network.");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The file is not supported.");
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
