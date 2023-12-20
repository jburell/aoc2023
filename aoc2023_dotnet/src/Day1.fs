module Day1.Solution

open System
open System.Collections.Generic
open System.Text
open FParsec
open FParsec.Pipes

type private ValuePair =
  | None
  | FoundOne of char
  | FoundTwo of char * char

type Patterns = (string * string) list
let textToNumber: Patterns = [
  ("one", "1")
  ("two", "2")
  ("three", "3")
  ("four", "4")
  ("five", "5")
  ("six", "6")
  ("seven", "7")
  ("eight", "8")
  ("nine", "9")
  ]

let rec parseNumTxt patterns =
  patterns
  |> List.map fst
  //|> List.toSeq
  |> List.map pstring
  //|> fun s -> CharParsers.pint32 :: s
  |> fun s -> List.append [CharParsers.pint32]
  |> choice
  

let extractWithFixedPattern (patterns: Patterns) (input: string)  =
  let findFirstAndLastWord (word: string, sub) =
    let pos = input.IndexOf(word)
    let posLast = input.LastIndexOf(word)
    if (pos + word.Length) > posLast
    then (pos, posLast, (word, sub)) // Overlap case
    else (pos, posLast, (word, sub))
  
  let cuts =
    patterns
    |> List.map findFirstAndLastWord
    |> List.filter (fun (pos, _, _) -> pos >= 0)
    //|> List.sortBy (fun (_, last, _) -> last)
    |> List.sortBy (fun (pos, _, _) -> pos)
    |> List.map (fun (a, _b, c) -> (a, c))
    |> List.distinct
  
  StringBuilder()
  |> fun b ->
    cuts
    |> List.fold (fun (pos, acc: StringBuilder) (curr, cut) ->
        let keep =
          if pos = curr
          then ""
          else input.Substring(pos, curr - pos)
        let pos = curr + (fst cut).Length 
        let acc = acc.Append(keep).Append(snd cut)
        (pos, acc)
      ) (0, b)
  |> fun (_, b) -> b.ToString()
  |> fun a -> Console.WriteLine a; a

let private extractValuePairs acc n =
  match acc with
  | None -> FoundOne n
  | FoundOne x -> FoundTwo (x, n)
  | FoundTwo (x, _) -> FoundTwo (x, n)

let private formatValuePair = function
  | None -> "0"
  | FoundOne x -> $"{x}{x}"
  | FoundTwo (x, y) -> $"{x}{y}"

let private convertWordsToDigits line =
  extractWithFixedPattern textToNumber line

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
  |> Seq.indexed
  |> Seq.map (fun (i, a) -> Console.WriteLine $"{i}: {a}"; a)
  |> Seq.map convertWordsToDigits
  |> Seq.map lineToValue
  |> Seq.sum