namespace CardGame

open System
open System.Text
open Types
open Board
open Cards
open Game

module GameHelpers =

    let boardToString (board : Board) : string =
        let sb = new StringBuilder()
        let cardToString (card : Card) : string =
            card.name + " " + card.currentPower.ToString()
        let fieldToString (field : BoardField) : string =
            match field with
            | EmptyField -> String.Format("{0,10}", "|")
            | Field card -> String.Format("{0,-9}|", cardToString card)
        let (s1, s2) = calculateScore board

        sb.Append("---") |> ignore
        ([0 .. 9] |> List.iter (fun i -> sb.AppendFormat("--- {0} ----", i) |> ignore)) |> ignore
        sb.AppendLine() |> ignore
        sb.Append("|E|") |> ignore
        board.player1Side.row5 |> Array.iter (fun x -> sb.Append(fieldToString x) |> ignore)
        sb.AppendLine() |> ignore
        sb.Append("|D|") |> ignore
        board.player1Side.row4 |> Array.iter (fun x -> sb.Append(fieldToString x) |> ignore)
        sb.AppendLine() |> ignore
        sb.Append("|C|") |> ignore
        board.player1Side.row3 |> Array.iter (fun x -> sb.Append(fieldToString x) |> ignore)
        sb.AppendFormat("  {0}", s1) |> ignore
        sb.AppendLine() |> ignore
        sb.Append("|B|") |> ignore
        board.player1Side.row2 |> Array.iter (fun x -> sb.Append(fieldToString x) |> ignore)
        sb.AppendLine() |> ignore
        sb.Append("|A|") |> ignore
        board.player1Side.row1 |> Array.iter (fun x -> sb.Append(fieldToString x) |> ignore)
        sb.AppendLine() |> ignore
        sb.AppendLine("-" |> String.replicate 103) |> ignore
        sb.Append("|A|") |> ignore
        board.player2Side.row1 |> Array.iter (fun x -> sb.Append(fieldToString x) |> ignore)
        sb.AppendLine() |> ignore
        sb.Append("|B|") |> ignore
        board.player2Side.row2 |> Array.iter (fun x -> sb.Append(fieldToString x) |> ignore)
        sb.AppendLine() |> ignore
        sb.Append("|C|") |> ignore
        board.player2Side.row3 |> Array.iter (fun x -> sb.Append(fieldToString x) |> ignore)
        sb.AppendFormat("  {0}", s2) |> ignore
        sb.AppendLine() |> ignore
        sb.Append("|D|") |> ignore
        board.player2Side.row4 |> Array.iter (fun x -> sb.Append(fieldToString x) |> ignore)
        sb.AppendLine() |> ignore
        sb.Append("|E|") |> ignore
        board.player2Side.row5 |> Array.iter (fun x -> sb.Append(fieldToString x) |> ignore)
        sb.AppendLine() |> ignore
        sb.Append("---") |> ignore
        ([0 .. 9] |> List.iter (fun i -> sb.AppendFormat("--- {0} ----", i) |> ignore)) |> ignore
        sb.ToString()

    let handToString (hand : Hand) : string =
        String.Join(", ", hand.cards |> List.map(fun x -> x.name))

    let gameToString (game : Game) (player : Player) : string =
        let sb = new StringBuilder()
        sb.AppendFormat("[{0}] {1}", player, String.Join(", ", game.messages)) |> ignore
        sb.AppendLine() |> ignore
        sb.AppendLine() |> ignore
        sb.Append(boardToString game.board) |> ignore
        sb.AppendLine() |> ignore
        sb.AppendLine() |> ignore
        sb.AppendFormat("Cards: {0}", handToString (if player = Player1 then game.player1Hand else game.player2Hand)) |> ignore
        sb.AppendLine() |> ignore
        sb.AppendLine() |> ignore
        sb.Append("> ") |> ignore
        sb.ToString()