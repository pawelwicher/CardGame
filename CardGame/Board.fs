namespace CardGame

open Types

module Board =

    let createBoard () : Board =
        let empty() : BoardRow =
            Array.init 10 (fun _ -> EmptyField)
        {
            player1Side = { row1 = empty(); row2 = empty(); row3 = empty(); row4 = empty(); row5 = empty() }
            player2Side = { row1 = empty(); row2 = empty(); row3 = empty(); row4 = empty(); row5 = empty() }
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
                calculateRow side.row1
                calculateRow side.row2
                calculateRow side.row3
                calculateRow side.row4
                calculateRow side.row5
            ] |> List.sum

        (calculateSideScore board.player1Side, calculateSideScore board.player2Side)

    let changeField (id : BoardFieldId) (board : Board) (f : BoardField -> BoardField) : unit =
        match id with
        | N_A0 -> board.player1Side.row1.[0] <- f board.player1Side.row1.[0]
        | N_A1 -> board.player1Side.row1.[1] <- f board.player1Side.row1.[1]
        | N_A2 -> board.player1Side.row1.[2] <- f board.player1Side.row1.[2]
        | N_A3 -> board.player1Side.row1.[3] <- f board.player1Side.row1.[3]
        | N_A4 -> board.player1Side.row1.[4] <- f board.player1Side.row1.[4]
        | N_A5 -> board.player1Side.row1.[5] <- f board.player1Side.row1.[5]
        | N_A6 -> board.player1Side.row1.[6] <- f board.player1Side.row1.[6]
        | N_A7 -> board.player1Side.row1.[7] <- f board.player1Side.row1.[7]
        | N_A8 -> board.player1Side.row1.[8] <- f board.player1Side.row1.[8]
        | N_A9 -> board.player1Side.row1.[9] <- f board.player1Side.row1.[9]
        | N_B0 -> board.player1Side.row2.[0] <- f board.player1Side.row2.[0]
        | N_B1 -> board.player1Side.row2.[1] <- f board.player1Side.row2.[1]
        | N_B2 -> board.player1Side.row2.[2] <- f board.player1Side.row2.[2]
        | N_B3 -> board.player1Side.row2.[3] <- f board.player1Side.row2.[3]
        | N_B4 -> board.player1Side.row2.[4] <- f board.player1Side.row2.[4]
        | N_B5 -> board.player1Side.row2.[5] <- f board.player1Side.row2.[5]
        | N_B6 -> board.player1Side.row2.[6] <- f board.player1Side.row2.[6]
        | N_B7 -> board.player1Side.row2.[7] <- f board.player1Side.row2.[7]
        | N_B8 -> board.player1Side.row2.[8] <- f board.player1Side.row2.[8]
        | N_B9 -> board.player1Side.row2.[9] <- f board.player1Side.row2.[9]
        | N_C0 -> board.player1Side.row3.[0] <- f board.player1Side.row3.[0]
        | N_C1 -> board.player1Side.row3.[1] <- f board.player1Side.row3.[1]
        | N_C2 -> board.player1Side.row3.[2] <- f board.player1Side.row3.[2]
        | N_C3 -> board.player1Side.row3.[3] <- f board.player1Side.row3.[3]
        | N_C4 -> board.player1Side.row3.[4] <- f board.player1Side.row3.[4]
        | N_C5 -> board.player1Side.row3.[5] <- f board.player1Side.row3.[5]
        | N_C6 -> board.player1Side.row3.[6] <- f board.player1Side.row3.[6]
        | N_C7 -> board.player1Side.row3.[7] <- f board.player1Side.row3.[7]
        | N_C8 -> board.player1Side.row3.[8] <- f board.player1Side.row3.[8]
        | N_C9 -> board.player1Side.row3.[9] <- f board.player1Side.row3.[9]
        | N_D0 -> board.player1Side.row4.[0] <- f board.player1Side.row4.[0]
        | N_D1 -> board.player1Side.row4.[1] <- f board.player1Side.row4.[1]
        | N_D2 -> board.player1Side.row4.[2] <- f board.player1Side.row4.[2]
        | N_D3 -> board.player1Side.row4.[3] <- f board.player1Side.row4.[3]
        | N_D4 -> board.player1Side.row4.[4] <- f board.player1Side.row4.[4]
        | N_D5 -> board.player1Side.row4.[5] <- f board.player1Side.row4.[5]
        | N_D6 -> board.player1Side.row4.[6] <- f board.player1Side.row4.[6]
        | N_D7 -> board.player1Side.row4.[7] <- f board.player1Side.row4.[7]
        | N_D8 -> board.player1Side.row4.[8] <- f board.player1Side.row4.[8]
        | N_D9 -> board.player1Side.row4.[9] <- f board.player1Side.row4.[9]
        | N_E0 -> board.player1Side.row5.[0] <- f board.player1Side.row5.[0]
        | N_E1 -> board.player1Side.row5.[1] <- f board.player1Side.row5.[1]
        | N_E2 -> board.player1Side.row5.[2] <- f board.player1Side.row5.[2]
        | N_E3 -> board.player1Side.row5.[3] <- f board.player1Side.row5.[3]
        | N_E4 -> board.player1Side.row5.[4] <- f board.player1Side.row5.[4]
        | N_E5 -> board.player1Side.row5.[5] <- f board.player1Side.row5.[5]
        | N_E6 -> board.player1Side.row5.[6] <- f board.player1Side.row5.[6]
        | N_E7 -> board.player1Side.row5.[7] <- f board.player1Side.row5.[7]
        | N_E8 -> board.player1Side.row5.[8] <- f board.player1Side.row5.[8]
        | N_E9 -> board.player1Side.row5.[9] <- f board.player1Side.row5.[9]
        | S_A0 -> board.player2Side.row1.[0] <- f board.player2Side.row1.[0]
        | S_A1 -> board.player2Side.row1.[1] <- f board.player2Side.row1.[1]
        | S_A2 -> board.player2Side.row1.[2] <- f board.player2Side.row1.[2]
        | S_A3 -> board.player2Side.row1.[3] <- f board.player2Side.row1.[3]
        | S_A4 -> board.player2Side.row1.[4] <- f board.player2Side.row1.[4]
        | S_A5 -> board.player2Side.row1.[5] <- f board.player2Side.row1.[5]
        | S_A6 -> board.player2Side.row1.[6] <- f board.player2Side.row1.[6]
        | S_A7 -> board.player2Side.row1.[7] <- f board.player2Side.row1.[7]
        | S_A8 -> board.player2Side.row1.[8] <- f board.player2Side.row1.[8]
        | S_A9 -> board.player2Side.row1.[9] <- f board.player2Side.row1.[9]
        | S_B0 -> board.player2Side.row2.[0] <- f board.player2Side.row2.[0]
        | S_B1 -> board.player2Side.row2.[1] <- f board.player2Side.row2.[1]
        | S_B2 -> board.player2Side.row2.[2] <- f board.player2Side.row2.[2]
        | S_B3 -> board.player2Side.row2.[3] <- f board.player2Side.row2.[3]
        | S_B4 -> board.player2Side.row2.[4] <- f board.player2Side.row2.[4]
        | S_B5 -> board.player2Side.row2.[5] <- f board.player2Side.row2.[5]
        | S_B6 -> board.player2Side.row2.[6] <- f board.player2Side.row2.[6]
        | S_B7 -> board.player2Side.row2.[7] <- f board.player2Side.row2.[7]
        | S_B8 -> board.player2Side.row2.[8] <- f board.player2Side.row2.[8]
        | S_B9 -> board.player2Side.row2.[9] <- f board.player2Side.row2.[9]
        | S_C0 -> board.player2Side.row3.[0] <- f board.player2Side.row3.[0]
        | S_C1 -> board.player2Side.row3.[1] <- f board.player2Side.row3.[1]
        | S_C2 -> board.player2Side.row3.[2] <- f board.player2Side.row3.[2]
        | S_C3 -> board.player2Side.row3.[3] <- f board.player2Side.row3.[3]
        | S_C4 -> board.player2Side.row3.[4] <- f board.player2Side.row3.[4]
        | S_C5 -> board.player2Side.row3.[5] <- f board.player2Side.row3.[5]
        | S_C6 -> board.player2Side.row3.[6] <- f board.player2Side.row3.[6]
        | S_C7 -> board.player2Side.row3.[7] <- f board.player2Side.row3.[7]
        | S_C8 -> board.player2Side.row3.[8] <- f board.player2Side.row3.[8]
        | S_C9 -> board.player2Side.row3.[9] <- f board.player2Side.row3.[9]
        | S_D0 -> board.player2Side.row4.[0] <- f board.player2Side.row4.[0]
        | S_D1 -> board.player2Side.row4.[1] <- f board.player2Side.row4.[1]
        | S_D2 -> board.player2Side.row4.[2] <- f board.player2Side.row4.[2]
        | S_D3 -> board.player2Side.row4.[3] <- f board.player2Side.row4.[3]
        | S_D4 -> board.player2Side.row4.[4] <- f board.player2Side.row4.[4]
        | S_D5 -> board.player2Side.row4.[5] <- f board.player2Side.row4.[5]
        | S_D6 -> board.player2Side.row4.[6] <- f board.player2Side.row4.[6]
        | S_D7 -> board.player2Side.row4.[7] <- f board.player2Side.row4.[7]
        | S_D8 -> board.player2Side.row4.[8] <- f board.player2Side.row4.[8]
        | S_D9 -> board.player2Side.row4.[9] <- f board.player2Side.row4.[9]
        | S_E0 -> board.player2Side.row5.[0] <- f board.player2Side.row5.[0]
        | S_E1 -> board.player2Side.row5.[1] <- f board.player2Side.row5.[1]
        | S_E2 -> board.player2Side.row5.[2] <- f board.player2Side.row5.[2]
        | S_E3 -> board.player2Side.row5.[3] <- f board.player2Side.row5.[3]
        | S_E4 -> board.player2Side.row5.[4] <- f board.player2Side.row5.[4]
        | S_E5 -> board.player2Side.row5.[5] <- f board.player2Side.row5.[5]
        | S_E6 -> board.player2Side.row5.[6] <- f board.player2Side.row5.[6]
        | S_E7 -> board.player2Side.row5.[7] <- f board.player2Side.row5.[7]
        | S_E8 -> board.player2Side.row5.[8] <- f board.player2Side.row5.[8]
        | S_E9 -> board.player2Side.row5.[9] <- f board.player2Side.row5.[9]
        | UNKNOWN -> ()

    let stringToBoardFieldId (fieldId : string) : BoardFieldId =
        match fieldId with
        | "N_A0" -> N_A0
        | "N_A1" -> N_A1
        | "N_A2" -> N_A2
        | "N_A3" -> N_A3
        | "N_A4" -> N_A4
        | "N_A5" -> N_A5
        | "N_A6" -> N_A6
        | "N_A7" -> N_A7
        | "N_A8" -> N_A8
        | "N_A9" -> N_A9
        | "N_B0" -> N_B0
        | "N_B1" -> N_B1
        | "N_B2" -> N_B2
        | "N_B3" -> N_B3
        | "N_B4" -> N_B4
        | "N_B5" -> N_B5
        | "N_B6" -> N_B6
        | "N_B7" -> N_B7
        | "N_B8" -> N_B8
        | "N_B9" -> N_B9
        | "N_C0" -> N_C0
        | "N_C1" -> N_C1
        | "N_C2" -> N_C2
        | "N_C3" -> N_C3
        | "N_C4" -> N_C4
        | "N_C5" -> N_C5
        | "N_C6" -> N_C6
        | "N_C7" -> N_C7
        | "N_C8" -> N_C8
        | "N_C9" -> N_C9
        | "N_D0" -> N_D0
        | "N_D1" -> N_D1
        | "N_D2" -> N_D2
        | "N_D3" -> N_D3
        | "N_D4" -> N_D4
        | "N_D5" -> N_D5
        | "N_D6" -> N_D6
        | "N_D7" -> N_D7
        | "N_D8" -> N_D8
        | "N_D9" -> N_D9
        | "N_E0" -> N_E0
        | "N_E1" -> N_E1
        | "N_E2" -> N_E2
        | "N_E3" -> N_E3
        | "N_E4" -> N_E4
        | "N_E5" -> N_E5
        | "N_E6" -> N_E6
        | "N_E7" -> N_E7
        | "N_E8" -> N_E8
        | "N_E9" -> N_E9
        | "S_A0" -> S_A0
        | "S_A1" -> S_A1
        | "S_A2" -> S_A2
        | "S_A3" -> S_A3
        | "S_A4" -> S_A4
        | "S_A5" -> S_A5
        | "S_A6" -> S_A6
        | "S_A7" -> S_A7
        | "S_A8" -> S_A8
        | "S_A9" -> S_A9
        | "S_B0" -> S_B0
        | "S_B1" -> S_B1
        | "S_B2" -> S_B2
        | "S_B3" -> S_B3
        | "S_B4" -> S_B4
        | "S_B5" -> S_B5
        | "S_B6" -> S_B6
        | "S_B7" -> S_B7
        | "S_B8" -> S_B8
        | "S_B9" -> S_B9
        | "S_C0" -> S_C0
        | "S_C1" -> S_C1
        | "S_C2" -> S_C2
        | "S_C3" -> S_C3
        | "S_C4" -> S_C4
        | "S_C5" -> S_C5
        | "S_C6" -> S_C6
        | "S_C7" -> S_C7
        | "S_C8" -> S_C8
        | "S_C9" -> S_C9
        | "S_D0" -> S_D0
        | "S_D1" -> S_D1
        | "S_D2" -> S_D2
        | "S_D3" -> S_D3
        | "S_D4" -> S_D4
        | "S_D5" -> S_D5
        | "S_D6" -> S_D6
        | "S_D7" -> S_D7
        | "S_D8" -> S_D8
        | "S_D9" -> S_D9
        | "S_E0" -> S_E0
        | "S_E1" -> S_E1
        | "S_E2" -> S_E2
        | "S_E3" -> S_E3
        | "S_E4" -> S_E4
        | "S_E5" -> S_E5
        | "S_E6" -> S_E6
        | "S_E7" -> S_E7
        | "S_E8" -> S_E8
        | "S_E9" -> S_E9
        | _      -> UNKNOWN