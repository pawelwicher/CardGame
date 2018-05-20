namespace CardGame

open Types

module Board =

    let createBoard () : Board =
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

    let changeField (id : BoardFieldId) (board : Board) (f : BoardField -> BoardField) : unit =
        match id with
        | N_A0 -> board.north.row1.[0] <- f board.north.row1.[0]
        | N_A1 -> board.north.row1.[1] <- f board.north.row1.[1]
        | N_A2 -> board.north.row1.[2] <- f board.north.row1.[2]
        | N_A3 -> board.north.row1.[3] <- f board.north.row1.[3]
        | N_A4 -> board.north.row1.[4] <- f board.north.row1.[4]
        | N_A5 -> board.north.row1.[5] <- f board.north.row1.[5]
        | N_A6 -> board.north.row1.[6] <- f board.north.row1.[6]
        | N_A7 -> board.north.row1.[7] <- f board.north.row1.[7]
        | N_A8 -> board.north.row1.[8] <- f board.north.row1.[8]
        | N_A9 -> board.north.row1.[9] <- f board.north.row1.[9]
        | N_B0 -> board.north.row2.[0] <- f board.north.row2.[0]
        | N_B1 -> board.north.row2.[1] <- f board.north.row2.[1]
        | N_B2 -> board.north.row2.[2] <- f board.north.row2.[2]
        | N_B3 -> board.north.row2.[3] <- f board.north.row2.[3]
        | N_B4 -> board.north.row2.[4] <- f board.north.row2.[4]
        | N_B5 -> board.north.row2.[5] <- f board.north.row2.[5]
        | N_B6 -> board.north.row2.[6] <- f board.north.row2.[6]
        | N_B7 -> board.north.row2.[7] <- f board.north.row2.[7]
        | N_B8 -> board.north.row2.[8] <- f board.north.row2.[8]
        | N_B9 -> board.north.row2.[9] <- f board.north.row2.[9]
        | N_C0 -> board.north.row3.[0] <- f board.north.row3.[0]
        | N_C1 -> board.north.row3.[1] <- f board.north.row3.[1]
        | N_C2 -> board.north.row3.[2] <- f board.north.row3.[2]
        | N_C3 -> board.north.row3.[3] <- f board.north.row3.[3]
        | N_C4 -> board.north.row3.[4] <- f board.north.row3.[4]
        | N_C5 -> board.north.row3.[5] <- f board.north.row3.[5]
        | N_C6 -> board.north.row3.[6] <- f board.north.row3.[6]
        | N_C7 -> board.north.row3.[7] <- f board.north.row3.[7]
        | N_C8 -> board.north.row3.[8] <- f board.north.row3.[8]
        | N_C9 -> board.north.row3.[9] <- f board.north.row3.[9]
        | N_D0 -> board.north.row4.[0] <- f board.north.row4.[0]
        | N_D1 -> board.north.row4.[1] <- f board.north.row4.[1]
        | N_D2 -> board.north.row4.[2] <- f board.north.row4.[2]
        | N_D3 -> board.north.row4.[3] <- f board.north.row4.[3]
        | N_D4 -> board.north.row4.[4] <- f board.north.row4.[4]
        | N_D5 -> board.north.row4.[5] <- f board.north.row4.[5]
        | N_D6 -> board.north.row4.[6] <- f board.north.row4.[6]
        | N_D7 -> board.north.row4.[7] <- f board.north.row4.[7]
        | N_D8 -> board.north.row4.[8] <- f board.north.row4.[8]
        | N_D9 -> board.north.row4.[9] <- f board.north.row4.[9]
        | N_E0 -> board.north.row5.[0] <- f board.north.row5.[0]
        | N_E1 -> board.north.row5.[1] <- f board.north.row5.[1]
        | N_E2 -> board.north.row5.[2] <- f board.north.row5.[2]
        | N_E3 -> board.north.row5.[3] <- f board.north.row5.[3]
        | N_E4 -> board.north.row5.[4] <- f board.north.row5.[4]
        | N_E5 -> board.north.row5.[5] <- f board.north.row5.[5]
        | N_E6 -> board.north.row5.[6] <- f board.north.row5.[6]
        | N_E7 -> board.north.row5.[7] <- f board.north.row5.[7]
        | N_E8 -> board.north.row5.[8] <- f board.north.row5.[8]
        | N_E9 -> board.north.row5.[9] <- f board.north.row5.[9]
        | S_A0 -> board.south.row1.[0] <- f board.south.row1.[0]
        | S_A1 -> board.south.row1.[1] <- f board.south.row1.[1]
        | S_A2 -> board.south.row1.[2] <- f board.south.row1.[2]
        | S_A3 -> board.south.row1.[3] <- f board.south.row1.[3]
        | S_A4 -> board.south.row1.[4] <- f board.south.row1.[4]
        | S_A5 -> board.south.row1.[5] <- f board.south.row1.[5]
        | S_A6 -> board.south.row1.[6] <- f board.south.row1.[6]
        | S_A7 -> board.south.row1.[7] <- f board.south.row1.[7]
        | S_A8 -> board.south.row1.[8] <- f board.south.row1.[8]
        | S_A9 -> board.south.row1.[9] <- f board.south.row1.[9]
        | S_B0 -> board.south.row2.[0] <- f board.south.row2.[0]
        | S_B1 -> board.south.row2.[1] <- f board.south.row2.[1]
        | S_B2 -> board.south.row2.[2] <- f board.south.row2.[2]
        | S_B3 -> board.south.row2.[3] <- f board.south.row2.[3]
        | S_B4 -> board.south.row2.[4] <- f board.south.row2.[4]
        | S_B5 -> board.south.row2.[5] <- f board.south.row2.[5]
        | S_B6 -> board.south.row2.[6] <- f board.south.row2.[6]
        | S_B7 -> board.south.row2.[7] <- f board.south.row2.[7]
        | S_B8 -> board.south.row2.[8] <- f board.south.row2.[8]
        | S_B9 -> board.south.row2.[9] <- f board.south.row2.[9]
        | S_C0 -> board.south.row3.[0] <- f board.south.row3.[0]
        | S_C1 -> board.south.row3.[1] <- f board.south.row3.[1]
        | S_C2 -> board.south.row3.[2] <- f board.south.row3.[2]
        | S_C3 -> board.south.row3.[3] <- f board.south.row3.[3]
        | S_C4 -> board.south.row3.[4] <- f board.south.row3.[4]
        | S_C5 -> board.south.row3.[5] <- f board.south.row3.[5]
        | S_C6 -> board.south.row3.[6] <- f board.south.row3.[6]
        | S_C7 -> board.south.row3.[7] <- f board.south.row3.[7]
        | S_C8 -> board.south.row3.[8] <- f board.south.row3.[8]
        | S_C9 -> board.south.row3.[9] <- f board.south.row3.[9]
        | S_D0 -> board.south.row4.[0] <- f board.south.row4.[0]
        | S_D1 -> board.south.row4.[1] <- f board.south.row4.[1]
        | S_D2 -> board.south.row4.[2] <- f board.south.row4.[2]
        | S_D3 -> board.south.row4.[3] <- f board.south.row4.[3]
        | S_D4 -> board.south.row4.[4] <- f board.south.row4.[4]
        | S_D5 -> board.south.row4.[5] <- f board.south.row4.[5]
        | S_D6 -> board.south.row4.[6] <- f board.south.row4.[6]
        | S_D7 -> board.south.row4.[7] <- f board.south.row4.[7]
        | S_D8 -> board.south.row4.[8] <- f board.south.row4.[8]
        | S_D9 -> board.south.row4.[9] <- f board.south.row4.[9]
        | S_E0 -> board.south.row5.[0] <- f board.south.row5.[0]
        | S_E1 -> board.south.row5.[1] <- f board.south.row5.[1]
        | S_E2 -> board.south.row5.[2] <- f board.south.row5.[2]
        | S_E3 -> board.south.row5.[3] <- f board.south.row5.[3]
        | S_E4 -> board.south.row5.[4] <- f board.south.row5.[4]
        | S_E5 -> board.south.row5.[5] <- f board.south.row5.[5]
        | S_E6 -> board.south.row5.[6] <- f board.south.row5.[6]
        | S_E7 -> board.south.row5.[7] <- f board.south.row5.[7]
        | S_E8 -> board.south.row5.[8] <- f board.south.row5.[8]
        | S_E9 -> board.south.row5.[9] <- f board.south.row5.[9]