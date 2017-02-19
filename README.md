# F# Turtle Tutorial

101 Workshop for F#, building a Logo Turtle.  Influenced by this blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/

Based on "Logo", the original 1967 turtle program.  Here's an online version for reference: https://turtleacademy.com/playground/en

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

## Additional points to note 

* Worth pointing out the F# Repl for quick debugging

## What's missing from the current example solution?

* Doesn't demonstrate the Option type
* Doesn't show a lot of pipe forward operator use
* Doesn't show off type providers