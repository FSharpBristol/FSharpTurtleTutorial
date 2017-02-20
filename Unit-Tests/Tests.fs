module Tests

open System
open Xunit
open TurtleRunner
open Microsoft.FSharp.Reflection
open System.Reflection

// These tests rely heavily on reflection 
// This is to allow the tests to compile and fail with an incomplete solution

let private getUnionTypeFromString<'a> (s:string, v:obj list Option) =
    let matchedType = FSharpType.GetUnionCases typeof<'a> 
                      |> Array.filter (fun case -> case.Name = s)
    match matchedType with
    |[|case|] -> match v with
                 | Some vals -> Some(FSharpValue.MakeUnion(case, vals |> Seq.toArray) :?> 'a)
                 | None -> Some(FSharpValue.MakeUnion(case,[||]) :?> 'a)
    |_ -> None

let private getRecordType<'a> (v:obj list) =
    try
        Some (FSharpValue.MakeRecord(typeof<'a>, v |> Seq.toArray) :?> 'a)
    with
    | _ -> None

let private moduleInfo = 
  typeof<Turtle>.GetTypeInfo().Assembly.GetTypes()
  |> Seq.find (fun t -> t.Name = "TurtleRunner")

let private invokeFunction (functionName:string, v:obj list) =
    try
        Some (moduleInfo.GetMethod(functionName).Invoke(null, v |> Seq.toArray))
    with
    | _ -> None
    
let private testProcessCommand command = 
    let penState = getUnionTypeFromString<PenState>("Up", None)
    let colour = getUnionTypeFromString<Colour>("Red", None)

    match (penState, colour, command) with
    | (Some penVal, Some colourVal, Some commandVal) 
        -> let record = getRecordType<Turtle>([0.0; 0.0; 90.0; Up; Red])
           match record with 
           | Some r -> let result = invokeFunction("processCommand", [r; commandVal])
                       Assert.True(result.IsSome)
           | None -> Assert.True(false, "")
    | _ -> Assert.True(false, "Must define the PenState, Colour or Command dependencies")

[<Theory>]
[<InlineData("Up")>]
[<InlineData("Down")>]
let ``Expected PenState union types are defined`` expectedType = 
    let item = getUnionTypeFromString<PenState>(expectedType, None)
    Assert.True(item.IsSome)

[<Theory>]
[<InlineData("Black")>]
[<InlineData("Red")>]
[<InlineData("Blue")>]
[<InlineData("Green")>]
let ``Expected Colour union types are defined`` expectedType = 
    let item = getUnionTypeFromString<Colour>(expectedType, None)
    Assert.True(item.IsSome)

[<Theory>]
[<InlineData("Left")>]
[<InlineData("Right")>]
let ``Expected TurnDirection union types are defined`` expectedType = 
    let item = getUnionTypeFromString<TurnDirection>(expectedType, None)
    Assert.True(item.IsSome)

[<Fact>]
let ``Expected Command union type of Move is defined``() = 
    let item = getUnionTypeFromString<Command>("Move", Some [10.0])
    Assert.True(item.IsSome)

[<Fact>]
let ``Expected Command union type of Turn is defined``() = 
    let direction = getUnionTypeFromString<TurnDirection>("Left", None)

    match direction with
    | Some value -> let item = getUnionTypeFromString<Command>("Turn", Some [value; 10.0])
                    Assert.True(item.IsSome)
    | None -> Assert.True(false, "Must define TurnDirection Left first")

[<Fact>]
let ``Expected Command union type of SetPen is defined``() = 
    let penState = getUnionTypeFromString<PenState>("Up", None)

    match penState with
    | Some value -> let item = getUnionTypeFromString<Command>("SetPen", Some [value])
                    Assert.True(item.IsSome)
    | None -> Assert.True(false, "Must define PenState Up first")

[<Fact>]
let ``Expected Command union type of SetColour is defined``() = 
    let colour = getUnionTypeFromString<Colour>("Red", None)

    match colour with
    | Some value -> let item = getUnionTypeFromString<Command>("SetColour", Some [value])
                    Assert.True(item.IsSome)
    | None -> Assert.True(false, "Must define Colour Red first")

[<Fact>]
let ``Expected Turtle record type is defined``() =
    let penState = getUnionTypeFromString<PenState>("Up", None)
    let colour = getUnionTypeFromString<Colour>("Red", None)

    match (penState, colour) with
    | (Some penVal, Some colourVal) 
        -> let record = getRecordType<Turtle>([0.0; 0.0; 90.0; Up; Red])
           Assert.True(record.IsSome)
    | (None, Some _) -> Assert.True(false, "Must define PenState Up first")
    | (Some _, None) -> Assert.True(false, "Must define Colour Red first")
    | (None, None) -> Assert.True(false, "Must define PenState Up & Colour Red first")

[<Fact>]
let ``Expected processCommand function accepts a Move command``() =
    let command = getUnionTypeFromString<Command>("Move", Some [10.0])
    testProcessCommand command

[<Fact>]
let ``Expected processCommand function accepts a Turn command``() =
    let direction = getUnionTypeFromString<TurnDirection>("Left", None)

    match direction with
    | Some value -> let command = getUnionTypeFromString<Command>("Turn", Some [value; 90.0])
                    testProcessCommand command
    | None -> Assert.True(false, "Must define TurnDirection Left first")

[<Fact>]
let ``Expected processCommand function accepts a SetPen command``() =
    let penState = getUnionTypeFromString<PenState>("Up", None)

    match penState with
    | Some value -> let command = getUnionTypeFromString<Command>("SetPen", Some [value])
                    testProcessCommand command
    | None -> Assert.True(false, "Must define PenState Up first")

[<Fact>]
let ``Expected processCommand function accepts a SetColour command``() =
    let colour = getUnionTypeFromString<Colour>("Red", None)

    match colour with
    | Some value -> let command = getUnionTypeFromString<Command>("SetColour", Some [value])
                    testProcessCommand command
    | None -> Assert.True(false, "Must define SetColour Red first")