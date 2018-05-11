namespace CardGame

open System
open System.Text
open Types
open Board

module DebugHelper =

    let printBoard (board : Board) : string =
        let sb = new StringBuilder()
        let fieldToString (field : BoardField) : string =
            match field with
            | EmptyField -> String.Format("{0,10}", "|")
            | Field card -> String.Format("{0,-9}|", card.name + " " + card.currentPower.ToString())

        sb.AppendLine("-" |> String.replicate 110) |> ignore
        sb.Append("|row5    |") |> ignore
        board.north.row5 |> Array.iter (fun x -> sb.Append(fieldToString x) |> ignore)
        sb.AppendLine() |> ignore
        sb.Append("|row4    |") |> ignore
        board.north.row4 |> Array.iter (fun x -> sb.Append(fieldToString x) |> ignore)
        sb.AppendLine() |> ignore
        sb.Append("|row3    |") |> ignore
        board.north.row3 |> Array.iter (fun x -> sb.Append(fieldToString x) |> ignore)
        sb.AppendLine() |> ignore
        sb.Append("|row2    |") |> ignore
        board.north.row2 |> Array.iter (fun x -> sb.Append(fieldToString x) |> ignore)
        sb.AppendLine() |> ignore
        sb.Append("|row1    |") |> ignore
        board.north.row1 |> Array.iter (fun x -> sb.Append(fieldToString x) |> ignore)
        sb.AppendLine() |> ignore

        sb.AppendLine("-" |> String.replicate 110) |> ignore

        sb.Append("|row1    |") |> ignore
        board.south.row1 |> Array.iter (fun x -> sb.Append(fieldToString x) |> ignore)
        sb.AppendLine() |> ignore
        sb.Append("|row2    |") |> ignore
        board.south.row2 |> Array.iter (fun x -> sb.Append(fieldToString x) |> ignore)
        sb.AppendLine() |> ignore
        sb.Append("|row3    |") |> ignore
        board.south.row3 |> Array.iter (fun x -> sb.Append(fieldToString x) |> ignore)
        sb.AppendLine() |> ignore
        sb.Append("|row4    |") |> ignore
        board.south.row4 |> Array.iter (fun x -> sb.Append(fieldToString x) |> ignore)
        sb.AppendLine() |> ignore
        sb.Append("|row5    |") |> ignore
        board.south.row5 |> Array.iter (fun x -> sb.Append(fieldToString x) |> ignore)
        sb.AppendLine() |> ignore

        sb.AppendLine("-" |> String.replicate 110) |> ignore

        sb.AppendLine((calculateScore board).ToString()) |> ignore

        sb.ToString()