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
            string menu = "Please choose an option:\n(1) ping a website";
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

                Console.WriteLine(lineBreak);
                Console.WriteLine(menu);
            }
        }
    }
}
