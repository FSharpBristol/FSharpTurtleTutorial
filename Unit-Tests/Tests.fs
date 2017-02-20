module Tests

open System
open Xunit
open TurtleRunner
open Microsoft.FSharp.Reflection

let private getUnionTypeFromString<'a> (s:string) =
    match FSharpType.GetUnionCases typeof<'a> |> Array.filter (fun case -> case.Name = s) with
    |[|case|] -> Some(FSharpValue.MakeUnion(case,[||]) :?> 'a)
    |_ -> None

[<Theory>]
[<InlineData("Up")>]
[<InlineData("Down")>]
let ``Expected PenState types are defined`` expectedType = 
    let item = getUnionTypeFromString<PenState>(expectedType)
    Assert.True(item.IsSome)

[<Theory>]
[<InlineData("Black")>]
[<InlineData("Red")>]
[<InlineData("Blue")>]
[<InlineData("Green")>]
let ``Expected Colour types are defined`` expectedType = 
    let item = getUnionTypeFromString<Colour>(expectedType)
    Assert.True(item.IsSome)

[<Theory>]
[<InlineData("Left")>]
[<InlineData("Right")>]
let ``Expected TurnDirection types are defined`` expectedType = 
    let item = getUnionTypeFromString<TurnDirection>(expectedType)
    Assert.True(item.IsSome)