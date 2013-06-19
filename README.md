Mobi Dev Scenario
=================

### The Problem ###
Write a number prettifier:
Write tested code (in any language) that accepts a numeric type and returns a truncated, "prettified" string version. The prettified version should include one number after the decimal when the truncated number is not an integer. It should prettify numbers greater than 6 digits and support millions, billions and trillions.
 
### Examples ###
```
  input: 1000000
  output: 1M

  input: 2500000.34
  output: 2.5M
 
  input: 532
  output: 532
 
  input: 1123456789
  output: 1.1B
```

### The Solution ###

#### Preamble ####
I've chosen the C# language and .NET platform.  This was easiest to work with, as I use this everyday at my job and required no additional setup.  I used very minimal fancy language features (like funcs or actions, or lamdas, or dynamics, etc) and few platform specific features so it would easily readable by people familiar with Java.

As I've discussed with Bryan, mobile software is a passion of mine, and I've written "apps" using HTML 5 + Javascript, Java, Scala, Objective C, and now C# (I plan to try out F# soon).  As I can't really show you the code from my current gig, I thought I would use this Code test as an opportunity to show you how you can truly, write once => run anywhere. With native binaries I might add.

I'm using this "Number Formatting" library inside of 2 applications. The first is a WPF application, the second is an Android application.  These applications are implemented using the MVVM design pattern.  In this example this pattern allows me to share 100% of the C# code between the 2 applications.  While each has it's own native XML based view implementation. (FYI I could have just as easily built a Mac OS X application, or an iOS application, but my time is limited).

#### Running the Application ####
The first thing I ALWAYS do when starting a new project is create build (and usually deploy) scripts.  It's just so critical to TDD in my humble opinion.  It also makes it really easy to hook it up to whatever build and release tools you are using.  For this application I'm using psake (powershell make), you can run this application by using the following at your powershell prompt.

Prerequisites include: Visual Studio 2012, .NET 4.5, Xamarin Studio (this is used for compilation of the Android application)

```
c:\Path\to\the\repo> .\build.ps1
```
#### The Approach ####
I've chosen, instead of using something like extension methods, or custom formatter types which are language and platform specific, to use a couple design patterns to help create a more generic solution.

I'm using a Chain of Responsibility pattern as I believe this allows me to easily show off Dependency Injection, and basic SOLID principles.

The TestViewModel itself can be rapidly extended by creating a new NumberFormatterBase subclass and registering it with the IoC container in the "Formatster.Core.App.cs" file.
``` C#
// Register my Chain of Reponsiblity
Mvx.RegisterSingleton<INumberFormatter>(
  new TrillionNumberFormatter()
    .AddFormatterToChain(new BillionNumberFormatter())
    .AddFormatterToChain(new MillionNumberFormatter())
    .AddFormatterToChain(new DefaultNumberFormatter()));
```
It’s an example of the Open/Closed Principle.  The behavior of the system can be altered by either adding formatters or changing the order of the formatters in the chain of responsibility without making any further code modifications to TestViewModel.

From a testability standpoint the CoR pattern can be beneficial because it lets you unit test in smaller chunks.  I purposely left the CanHandle() method accessible as a public method.  When you test really complicated conditional processing logic you can make the unit testing easier by separately testing the decision to do an action from the action itself.  In concrete terms, when we test a Formatter class we can write separate, simpler unit tests for CanHandle() and Handle(). 

Subclasses of NumberFormatter override the CanHandle() and Handle() abstract methods, but the general workflow is implemented in the abstract superclass.  That’s a textbook example of a Template pattern.  One thing to keep in mind is that patterns often occur together in the same class or cluster of classes.

#### Testing ####
I am a bit of pragmatist when it comes to testing.  I like tests because they help me to actually design the application itself, in addition to that I like to do the minimum required to adequately prove my application works.

In this solution I've created unit tests to verify the basic functionality of what I have created. If I was testing how my system interacted with external systems, I would create integration tests.  But they would be simple and test only the interaction.  Also in a more complex system with a lot of moving pieces I would use Mocks to help me create functional tests.  Also I might use stubs to help me create basic acceptance tests.

I don't believe in testing Model objects, or ViewModel objects.  Also as long as you have a QA team in place, I don't believe in writing GUI tests, as this is typically the realm of your QA's automated UI / regression tests.
