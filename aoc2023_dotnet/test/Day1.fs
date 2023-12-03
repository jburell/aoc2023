module Day1.Test

open System
open System.Collections
open System.IO
open NUnit.Framework

let dataDay1a = File.ReadLines(Path.Combine(TestContext.CurrentContext.TestDirectory, "data", "Day1a.txt"))
let dataDay1b = File.ReadLines(Path.Combine(TestContext.CurrentContext.TestDirectory, "data", "Day1b.txt"))

[<Test>]
let Day1a () =
    // Arrange
    let expected = 54338
    
    // Act
    let answer: int = dataDay1a |> Solution.runDay1a
    
    // Assert
    Assert.AreEqual(expected, answer)
    
[<Test>]
let Day1b () =
    // Arrange
    let expected = 54338
    
    // Act
    let answer: int = dataDay1b |> Solution.runDay1b
    
    // Assert
    Assert.AreEqual(expected, answer)
    
[<Test>]
let temp () =
    // Arrange
    let expected = 54338
    
    // Act
    "two1five2three" |> Solution.extractWithFixedPattern "five" |> fun s -> Console.WriteLine($"%A{s}")
    
    // Assert
    Assert.Pass()