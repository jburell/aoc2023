module Day1.Solution

open System
open System.Collections.Generic
open System.Text

type private ValuePair =
  | None
  | FoundOne of char
  | FoundTwo of char * char

let private textToNumber = [|
  ("one", "1" )
  ("two", "2")
  ("three", "3")
  ("four", "4")
  ("five", "5")
  ("six", "6")
  ("seven", "7")
  ("eight", "8")
  ("nine", "9")
  |]

let extractWithFixedPattern (patterns: string) (input: string)  =
  let builder = StringBuilder()
  let rec findPatterns acc (currentIndex: int) =
    let subs = input.Substring(currentIndex, input.Length)
    
    let hit =
      textToNumber
      |> Array.map fst
      |> Array.map (fun p -> (input.IndexOf(p, 0), p))
      |> Array.filter(fun v -> fst v >= 0)
    
    hit
    //let foundIndex = input.IndexOf(patterns, currentIndex)
    //if foundIndex >= 0 then
    //  findPatterns (foundIndex :: acc) (foundIndex + 1)
    //else
    //  List.rev acc

  findPatterns input 0
  //|> List.map (fun idx -> input.Substring(idx, patterns.Length))

let private extractValuePairs acc n =
  match acc with
  | None -> FoundOne n
  | FoundOne x -> FoundTwo (x, n)
  | FoundTwo (x, _) -> FoundTwo (x, n)

let private formatValuePair = function
  | None -> "0"
  | FoundOne x -> $"{x}{x}"
  | FoundTwo (x, y) -> $"{x}{y}"

//let replaceWordWithDigit

let private convertWordsToDigits line =
  line
  //|> replaceWordWithDigit

let private lineToValue line =
  line
  |> Seq.filter Char.IsDigit
  |> Seq.fold extractValuePairs None
  |> formatValuePair
  |> Int32.Parse

let runDay1a (data: IEnumerable<string>) = 
  data
  |> Seq.map lineToValue
  |> Seq.sum
 
let runDay1b (data: IEnumerable<string>) = 
  data
  |> Seq.map convertWordsToDigits
  |> Seq.map lineToValue
  |> Seq.sum