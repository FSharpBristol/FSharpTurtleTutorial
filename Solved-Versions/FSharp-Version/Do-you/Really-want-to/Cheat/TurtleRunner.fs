module TurtleRunner

open System

// Basic discriminted unions - think enums
type PenState = Up | Down
type Colour = Black | Red | Blue | Green
type TurnDirection = Left | Right

// Record type - translates to a sealed class with readonly, immutable properties
type Turtle = {
    xpos:float
    ypos:float
    angle:float
    penState:PenState
    colour:Colour
}

// Discriminated unions with values - think enums on steroids
type Command = 
    | Move of float
    | Turn of TurnDirection * float 
    | SetPen of PenState 
    | SetColour of Colour

// Function to apply state changes in a Command to a Turtle
let processCommand turtle command = 
    match command with
    | Move distance -> let angleInRads = turtle.angle * (Math.PI/180.0) * 1.0
                       {turtle with 
                            xpos = turtle.xpos + (distance * Math.Cos(angleInRads))
                            ypos = turtle.ypos + (distance * Math.Sin(angleInRads))}
    | Turn(direction, degrees) -> match direction with 
                                  | Left ->  {turtle with angle = turtle.angle + degrees} 
                                  | Right -> {turtle with angle = turtle.angle - degrees} 
    | SetPen state ->  {turtle with penState=state}
    | SetColour colour -> {turtle with colour=colour}

// List of Commands to apply
let commands = [
    Move 20.0
    Turn(Left, 90.0)
    Move 20.0
    Turn(Right, 90.0)
    SetColour Red 
    Move 20.0
    Turn(Right, 90.0)
    SetPen Up 
    Move 40.0
]

// // Our initial Turtle instance
// let turtle = {xpos=0.0; ypos=0.0; angle=90.0; penState=Down; colour=Black}

// // Apply all the commands to the Turtle in turn
// let movedTurtle = commands |> List.fold processCommand turtle