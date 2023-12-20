module Day1.Test

open System
open System.Collections
open System.IO
open FParsec
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
let ``Test pattern match for number text``() =
  let res = run (Solution.parseNumTxt Solution.textToNumber) "1one24threeight two"
  Assert.AreEqual("test", res)
    
[<Test>]
let Day1bExample () =
  // Arrange
  let expected = 281
  let data = """
two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen
"""
  
  // Act
  let answer: int = data.Split([|'\n'; '\r'|]) |> Seq.filter (fun s -> s.Length > 0) |> Solution.runDay1b
  
  // Assert
  Assert.AreEqual(expected, answer)
    
[<Test>]
let temp () =
  // Arrange
  let expected = "21523"
  
  // Act
  let answer = "two1five2three" |> Solution.extractWithFixedPattern Solution.textToNumber |> fun s -> Console.WriteLine($"%A{s}"); s
  
  // Assert
  Assert.AreEqual(expected, answer)