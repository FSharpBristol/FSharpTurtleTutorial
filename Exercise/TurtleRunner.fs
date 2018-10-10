module TurtleRunner

open System

// Basic discriminted unions - think enums
type PenState = FillInThePenStates
type Colour = FillInTheColours
type TurnDirection = FillInTheTurnDirections

// Record type - translates to a sealed class with readonly, immutable properties
type Turtle = {
    turtleProperty:string
}

// Discriminated unions with values - think enums on steroids
type Command = FillInTheAvailableCommands

// Function to apply state changes in a Command to a Turtle
// Uses pattern matching to deconstruct the command into the different cases
let processCommand turtle command = 
    match command with
    | _ -> failwith "Command pattern matching not applied"

// --- Uncomment this section to run a full test ---
(*
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
// Our initial Turtle instance
let turtle = {xpos=0.0; ypos=0.0; angle=90.0; penState=Down; colour=Black}
// Apply all the commands to the Turtle in turn
let movedTurtle = 
    commands 
    |> List.fold (fun agg command -> processCommand agg command) turtle
*)