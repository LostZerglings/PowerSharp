namespace PowerSharp
{
    using System;

    class Program
    {
        /// <summary>
        /// 
        /// The following code shows a simple example of how to run a powershell script and dispaly the reponse in a console window. 
        /// 
        /// The Main method displays a menu of available scripts. 
        /// 
        /// The individual scripts are located in the Scripts Folder.
        /// 
        /// </summary>

        static void Main(string[] args)
        {
            //Display initial menu
            string menu = "Please choose an option:\n(1) Ping a website\n(2) Get user's name from AD\n(3) Get File Length";
            string lineBreak = "\n============================================\n";
            Console.WriteLine(menu);

            var command = string.Empty;
            while(command != "exit")
            {
                command = Console.ReadLine();
                Console.WriteLine(lineBreak);

                //Run the matching script
                if (command == "1")
                    Console.WriteLine(Scripts.Ping.PingResult());
                else if (command == "2")
                {
                    Console.WriteLine("Please enter a username:");
                    string userName = Console.ReadLine().Trim();
                    Console.WriteLine(Scripts.GetAdUser.GetAdUserResult(userName));
                }
                else if (command == "3")
                {
                    Console.WriteLine("Please enter the path:");
                    string path = Console.ReadLine().Trim();
                    Console.WriteLine(Scripts.GetFileLength.FileLengthResult(path));
                }

                Console.WriteLine(lineBreak);
                Console.WriteLine(menu);
            }
        }
    }
}
