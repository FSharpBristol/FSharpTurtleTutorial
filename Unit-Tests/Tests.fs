module Tests

open System
open Xunit
open TurtleRunner
open Microsoft.FSharp.Reflection

let private getUnionTypeFromString<'a> (s:string, v:obj list Option) =
    let matchedType = FSharpType.GetUnionCases typeof<'a> 
                      |> Array.filter (fun case -> case.Name = s)
    match matchedType with
    |[|case|] -> match v with
                 | Some vals -> Some(FSharpValue.MakeUnion(case, vals |> Seq.toArray) :?> 'a)
                 | None -> Some(FSharpValue.MakeUnion(case,[||]) :?> 'a)
    |_ -> None

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
    | Some value -> let item = getUnionTypeFromString<Command>("Turn", Some [Left; 10.0])
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