open System
open CardGame.Types
open CardGame.Board
open CardGame.Cards
open CardGame.DebugHelper

[<EntryPoint>]
let main argv =
    let board = createBoard()

    let emptyField = board.north.row1.[0]
    let southKnight = createCard Knight
    board.south.row1.[5] <- Field southKnight
    board.north.row1.[5] <- (targetBoard southKnight [emptyField]).[0]
    (printBoard board) |> Console.WriteLine

    let northKnight = createCard Knight
    board.north.row1.[5] <- Field northKnight
    board.south.row1.[5] <- (targetBoard northKnight [Field southKnight]).[0]
    (printBoard board) |> Console.WriteLine

    let southDruid = createCard Druid
    board.south.row1.[4] <- Field southDruid
    board.south.row1.[5] <- (targetBoard southDruid [Field southKnight]).[0]
    (printBoard board) |> Console.WriteLine

    let northKnight2 = createCard Knight
    board.north.row1.[4] <- Field northKnight2
    board.south.row1.[4] <- (targetBoard northKnight2 [Field southDruid]).[0]
    (printBoard board) |> Console.WriteLine

    Console.ReadKey() |> ignore
    0