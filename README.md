# PowerSharp

The PowerSharp repository is a collection of various powershell scripts that are invoked through C# code. 

The code and subsequent script methods should give you everything you need to get started running powershell code through C#. 

One of the advantages or running the scripts through C# is that you can not only add additional verifications, logic, and visuals to the tool, but you could also streamline complex scripts into a contained tool so a basic user would be able to run them.

### Getting Started

To get strted just load the solution. The code is formated as a console application with a menu.
The purpose of this solution is to provide samples on how to code more complex applications yourself. NOT to function as that tool. 

You can find the various scripts under the Scripts folder.

### Prerequisites

When trying to code with powershell you will need the System.Management.Automation reference. 

### What it covers
Ping Script:
Demonstrates how to run a simple command using the AddScript command and access the base result to return the entire output

GetAdUser Script:
Shows how to run an active directory script and return a specific value instead of the entire script output 

GetFileLength Script:
Shows how to return multiple specified values from a script run against the local machine

### How The Code Works

In order to call a powershell script you'll first need to initialize an instance of powershell. Since it can be disposed, I'd recommmend you wrap it in a using block. 

```
using (PowerShell powerShell = PowerShell.Create())
{

}

```

Then you can add any powershell script to the code just by adding it as a scring to your powershell object.

```
powerShell.AddScript("My Script Goes Here");
```
**Note:** 
you may need to do some formating if your script has quotes or escape characters or load the script from a file using a stream. 

Finally you'll need to invoke the script. If you want to access individual objects of the result you'll want to look through them using a foreach loop. 

```
foreach (PSObject result in powerShell.Invoke())
{
    //do something with the results
}
```
