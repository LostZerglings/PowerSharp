namespace PowerSharp.Scripts
{
    using System;
    using System.IO;
    using System.Management.Automation;

    class GetFileLength
    {
        /// <summary>
        /// 
        /// A simple script that will get the length of a file at a specified path as well as the name and return them both. 
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>

        public static string FileLengthResult(string path)
        {
            try
            {
                //verify file exists
                if (!File.Exists(path))
                    return "File not found";

                var length = "";
                var name = "";

                //load a powershell instance
                using (PowerShell powerShell = PowerShell.Create())
                {
                    //add the script to the instance
                    powerShell.AddScript($@"Get-ItemProperty -Path {path}");

                    //iterate through the results
                    foreach (PSObject result in powerShell.Invoke())
                    {
                        length = result.Members["length"].Value.ToString();
                        name = result.Members["Name"].Value.ToString();
                    }
                }

                //return the result formated as a string 
                return $"The file name is {name} and file length is {length} characters!";
            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }
    }
}