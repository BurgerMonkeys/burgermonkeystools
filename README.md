# BurgerMonkey.Tools

* Converters
* Generators
* TimeMonitor
* Tools
* Validators

## Support

* Feel free to open an issues.

## Installation

[NuGet package](//link)

* In Visual Studio - Tools > NuGet Package Manager > Manage Packages for Solution
* Select the Browse tab, search for BurguerMonkeys.Tools
* Select BurguerMonkeys.Tools
* Install into each project within your solution

## Usage

### Converters
- Base types

```csharp
//Boolean
bool x = any.ToBollean(); 

//Short
short x = any.ToShort();

//Int
int x = any.ToInt();

//Long
long x = any.ToLong();

//Decimal
decimal x = any.ToDecimal();

//Float
float x = any.ToFloat();

//Double
double x = any.ToDouble();

//Char
char x = any.ToChar();
```

- Concat
```csharp
string[] as = { "a", "b", "c" };

//Default separator
string x = as.ArrayStringToString();
x = "a,b,c,d"

//With separator
string x = as.ArrayStringToString("/");
x = "a/b/c/d"
```
- Image

```csharp
byte[] image;

string imageBase64 = image.ByteArrayImageToBase64();
imageBase64 = "GjTCyUBbuBUhUH...";
```

```csharp
string urlImage = "https://upload.wikimedia.org/wikipedia/commons/4/4e/Macaca_nigra_self-portrait_large.jpg";

//For normal use
string imageBase64 = urlImage.UrlImageToBase64();
imageBase64 = "GjTCyUBbuBUhUH...";

//For WebView
string imageBase64 = urlImage.UrlImageToBase64(true);
imageBase64 = "data:image/jpeg;base64,GjTCyUBbuBUhUH...";
```
```csharp
string imageBase64;
byte[] x = imageBase64.Base64ToByteArray();
```
- Date

```csharp
string date = "22/10/2019";
string hour = "15:30";

DateTimeOffset dh = Converter.StringToDateTimeOffSet (date ,hour);
DateTimeOffset d = Converter.StringToDateTimeOffSet(date);
DateTimeOffset h = Converter.StringToDateTimeOffSet(hour);
```

```csharp
DateTimeOffSet x;

string hour = x.DateTimeOffsetToHour();
hour = "14:30"
```

```csharp
DateTimeOffSet x;

//Default "pt-br"
string date = x.DateTimeOffSetToDateFormat();
date = "15/03/2019"

//Formated culture
string date = x.DateTimeOffSetToDateFormat("en-us");
date = "03/15/2019"
```
- Angle
```csharp
string a = "120° 10' 20";
double x = a.AngleToDecimal(); 
```

```csharp
string angle = any.AngleToString();
angle = "50° 0' 0";
```

### TimeMonitor
- To measure the execution time of an encoding code, you can use TimeMonitor this way.
```csharp
using(new TimerMonitor("Name to be shown on console")
{
   for (int i = 0; i < 500; i++)
   {
       var x = i;
   }
}

//Console
$Name to be shown on console time elapsed: 100ms
```

### Validator
- Validate a string with a regular expression
```csharp
string x = "#FFFFFF";
bool valid = x.IsMatch("#?([\da-fA-F]{2})([\da-fA-F]{2})([\da-fA-F]{2})");
```

- Validate a email string
```csharp
string x = "mariazinha@gmail.com";
bool valid = x.IsEmail();
```
