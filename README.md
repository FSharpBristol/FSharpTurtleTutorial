# F# Turtle Tutorial

101 Workshop for F#, building a Logo Turtle.  Influenced by this blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/

Based on "Logo", the original 1967 turtle program.  Here's an online version for reference: https://turtleacademy.com/playground/en

## Setup

Needs the .Net Core 1.0.4 onwards runtime installed locally.

If you don't already have this installed run the .NET Core SDK Installer (contains .NET Core 1.0.4 and 1.1.1) from here: https://www.microsoft.com/net/download/core

You'll also need Visual Studio Code, Ionide and the Visual F# Tools.  

[Go here](http://fsharp.org/use/windows/) and follow "Options 2: Install Visual Studio Code" then "Option 3: Install the free F# compiler and tools alone"

For the workshop we recommend using Visual Studio Code with Ionide for editing the script., to set this up (Windows specific):

* Install [Visual Studio Code](https://code.visualstudio.com/)
* Install [Visual F# Tools 4.0](https://www.microsoft.com/en-us/download/details.aspx?id=48179)
* Install the [Ionide F# Plugin](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-fsharp)

## Starting the Workshop

Firstly run `dotnet restore` and `dotnet build` in the "Exercise" folder

Then run `dotnet restore` in the "Unit-Tests" folder.

Now open the project at the root folder in Visual Studio Code.  If you installed Ionide from the Setup section you will have syntax highlighting of the ".fs" files, you will also be able to execute lines of the file using F# Interactive directly from VS Code (Select the lines and press Alt+Enter)

[The exercise tutorial can be found here](https://github.com/FSharpBristol/FSharpBristolPresentations/blob/master/slides/FSharpTurtleTutorial.md)

## Specifications

```gherkin
Given a turtle 
When provided a list of commands 
Then the turtle executes the commands in order

Given a turtle
When the pen down command is issued
And the move command is issued with a value of 10
Then the turtle moves 10 pixels
And the turtle draws a 10 pixel black line

Given a turtle 
When the pen up command is issued
And the move command is issued with a value of 10
Then the turtle moves 10 pixels
And the turtle does not draw a line 

Given a turtle 
When the turn left command is issued with a value of 90
Then the turtle rotates counter-clockwise 90 degress

Given a turtle 
When the turn right command is issued with a value of 90
Then the turtle rotates clockwise 90 degress

Given a turtle
When the pen down command is issued
And the set colour command is issued with a value of Red
And the move command is issued with a value of 10
Then the turtle draws a 10 pixel red line
```
