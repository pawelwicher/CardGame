namespace CardGame

open Types

module Board =

    let createBoard() : Board =
        let empty() : BoardRow =
            Array.init 10 (fun _ -> EmptyField)
        {
            north = { row1 = empty(); row2 = empty(); row3 = empty(); row4 = empty(); row5 = empty() }
            south = { row1 = empty(); row2 = empty(); row3 = empty(); row4 = empty(); row5 = empty() }
        }

    let calculateScore (board : Board) : (int * int) =
        let calculateSideScore (side : BoardSide) =
            let calculateRow (row : BoardRow) : int =
                let mapBoardField (field : BoardField) : int =
                    match field with
                    | EmptyField -> 0
                    | Field card -> card.currentPower
                row |> (Array.map mapBoardField >> Array.sum)
            [   
                side.row1 |> calculateRow
                side.row2 |> calculateRow
                side.row3 |> calculateRow
                side.row4 |> calculateRow
                side.row5 |> calculateRow
            ] |> List.sum

        (calculateSideScore board.north, calculateSideScore board.south)