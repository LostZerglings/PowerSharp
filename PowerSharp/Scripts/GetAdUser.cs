namespace PowerSharp.Scripts
{
    using System;
    using System.Management.Automation;

    class GetAdUser
    {
        /// <summary>
        /// 
        /// A simple script that will fetch a AD user's Name from AD using PowerShell. 
        /// A username is required to run this script. 
        /// 
        /// It's assumed the device you are running this on can already run the script (has a Active Directory connection)
        /// If the script doesn't work in powershell, it won't work in C# either. C# is calling powershell to run the requested script.
        /// A tool like RSAT (remote server administration tools) can establish this connection if you don't already have it.
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>

        public static string GetAdUserResult(string userName)
        {
            try
            {
                string name = "";

                //load a powershell instance
                using (PowerShell powerShell = PowerShell.Create())
                {
                    //Instead of AddScript we will use AddCommand this time to specify the command and the argument. 
                    //Both options work. It's up to you to decide which works best in your situation.
                    powerShell.AddCommand("Get-ADUser").AddArgument(userName);

                    //iterate through the results. Instead of result.BaseObject we will access the individual members and find the exact one we are looking for. (Name)
                    foreach (PSObject result in powerShell.Invoke())
                        name = Convert.ToString(result.Members["Name"].Value);
                }

                //return the matching name
                return name;
            }
            catch(CommandNotFoundException)
            {
                return "You do not have The active directory module on this device - AD commands will not work.";
            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }
    }
}
