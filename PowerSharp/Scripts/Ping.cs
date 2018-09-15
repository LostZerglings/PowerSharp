namespace PowerSharp.Scripts
{
    using System;
    using System.Management.Automation;

    class Ping
    {
        /// <summary>
        /// 
        /// A simple script that will ping a given website and return the results as a string. 
        /// If no url is given the script will ping google.com
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>

        public static string PingResult(string url = "google.com")
        {
            try
            {
                string pingResult = string.Empty;

                //load a powershell instance
                using (PowerShell powerShell = PowerShell.Create())
                {
                    //add the script to the instance
                    powerShell.AddScript($@"ping {url}");

                    //iterate through the results
                    foreach (PSObject result in powerShell.Invoke())
                    {
                        pingResult += result.BaseObject.ToString() + Environment.NewLine;
                    }
                }

                //return the results
                return pingResult;
            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }
    }
}
