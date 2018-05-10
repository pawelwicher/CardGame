namespace CardGame

open System

module Game =

    type CardId =
        | Knight

    type CardTag =
        | Unit
        | Loyal
        | Soldier
        | Mage
        | Spy
        | Special
        | Spell
        | Item

    type Card = {
        id: CardId
        name: string
        description: string
        basePower: int
        currentPower: int
        tags: CardTag list
    }

    (*
            BOARD

            0 [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ] 🏰
            0 [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ] 🏰
            0 [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ] 🏹
        25  0 [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ] 🏹
            0 [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ] ⚔
            0 [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ] ⚔
              ------------------------------
            0 [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ] ⚔
            0 [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ] ⚔
        34  0 [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ] 🏹
            0 [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ] 🏹
            0 [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ] 🏰
            0 [ ][ ][ ][ ][ ][ ][ ][ ][ ][ ] 🏰
    *)

    type BoardRow = Card option array

    type BoardSide = {
        siege1: BoardRow
        siege2: BoardRow
        middle1: BoardRow
        middle2: BoardRow
        melee1: BoardRow
        melee2: BoardRow
        // rows, hand, deck, graveyard
    }

    type Board = {
        north: BoardSide
        south: BoardSide
    }

    let createEmptyRow() : BoardRow =
        Array.init 10 (fun _ -> None)

    let calculateRow (row : BoardRow) : int =
        row |> (Array.map (fun x -> if x.IsNone then 0 else x.Value.currentPower) >> Array.sum)

    let calculateSideScore (side : BoardSide) =
        [   
            side.siege1 |> calculateRow
            side.siege2 |> calculateRow
            side.middle1 |> calculateRow
            side.middle2 |> calculateRow
            side.melee1 |> calculateRow
            side.melee2 |> calculateRow
        ] |> List.sum

    let calculateScore (board : Board) : (int * int) =
         (calculateSideScore board.north, calculateSideScore board.south)

    let createKnight() : Card =
        let card = { 
            id = Knight
            name = "Knight"
            description = "Knight. 15 Power. Deal 7 Damage. Soldier. Loyal."
            basePower = 15
            currentPower = 15
            tags = [Unit; Loyal; Soldier]
        }
        card

    let createCard (id: CardId) : Card =
        match id with
        | Knight -> createKnight()

    let createBoard() : Board =
        let board = {
                north = {
                        siege1 = createEmptyRow()
                        siege2 = createEmptyRow()
                        middle1 = createEmptyRow()
                        middle2 = createEmptyRow()
                        melee1 = createEmptyRow()
                        melee2 = createEmptyRow()
                }
                south = {
                        siege1 = createEmptyRow()
                        siege2 = createEmptyRow()
                        middle1 = createEmptyRow()
                        middle2 = createEmptyRow()
                        melee1 = createEmptyRow()
                        melee2 = createEmptyRow()
                }
        }
        board