SqlcecmdMobile
==============

SqlCeCmd inspired utility, that allows you to run scripts on Windows Mobile.

At work, i’m using SQL Server and sometimes i need to upgrade the production database.

SqlCmd is my friend for that kind of task and if you don’t know how it works you should really check it here: http://msdn.microsoft.com/en-us/library/ms162773.aspx

For a new project I wanted to have the SqlCmd version for SQL CE and I only found a version for Windows Desktop: http://sqlcecmd.codeplex.com/

Unfortunately (and I knew it), it doesn’t works on Windows Mobile…

So I tried to create a version of SqlCeCmd for Windows Mobile.

#The SqlCeCmd.Mobile application

The solution contains one console application project and I used the .NET Compact Framework 3.5 with the Windows Mobile 6.5.3 Professional DTK.

The application takes two parameters:

* The datasource
* The script file to execute

The first version executes only non query commands and you can only use a script file to execute the command.





Please read the "ReadMe.txt" file in the "Sample" directory.


If you want to have this tool for Windows (which provides more functionality), you can find The SQL Compact Command Line Tool on CodePlex: http://sqlcecmd.codeplex.com/
