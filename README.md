# ContactForm

## Description

**ContactForm** is a simple contact form that uses **ASP.NET Core MVC**, **ADO.NET** and **Microsoft SQL Server**.

⚠ **IMPORTANT NOTICE!** The application does not send e-mails over the Internet; instead it saves them inside: `.\ContactForm\wwwrooot\EmailPickupDirectory\` directory.

![ContactForm-screenshot_01](.readme/ContactForm-screenshot-01.png?raw=true "screenshot")

## Installation

### Setup

Make sure that **.NET Core 3.0 SDK** is installed:

```console
dotnet --version
```

Clone the repository into a new directory:

```console
git clone https://github.com/mroczekdotdev/ContactForm/
```

or download the repository, then extract the files:

| https://github.com/mroczekdotdev/ContactForm/archive/master.zip |
| --------------------------------------------------------------- |


Initialize **Microsoft SQL Server** database with `.\sqlserver.init.sql` script, e.g.:

```console
sqlcmd -S myServer\instanceName -i sqlserver.init.sql
```

### Configure

Specify the connection string for `SqlServer` inside `.\ContactForm\appsettings.json` file.

### Run

From the root of the repository execute following command:

```console
dotnet run -p ContactForm -c Release --launch-profile Production

```

Type `localhost` inside address bar of a web browser:

| http://localhost |
| ---------------- |

