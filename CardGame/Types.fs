namespace CardGame

module Types =

    type CardId =
        | Knight
        | Archer
        | Druid
        | Thunderbolt

    type CardTag =
        | Unit
        | Loyal
        | Soldier
        | Mage
        | Support
        | Spy
        | Special
        | Spell
        | Item

     type BoardFieldId =
        | N_A0 | N_A1 | N_A2 | N_A3 | N_A4 | N_A5 | N_A6 | N_A7 | N_A8 | N_A9
        | N_B0 | N_B1 | N_B2 | N_B3 | N_B4 | N_B5 | N_B6 | N_B7 | N_B8 | N_B9
        | N_C0 | N_C1 | N_C2 | N_C3 | N_C4 | N_C5 | N_C6 | N_C7 | N_C8 | N_C9
        | N_D0 | N_D1 | N_D2 | N_D3 | N_D4 | N_D5 | N_D6 | N_D7 | N_D8 | N_D9
        | N_E0 | N_E1 | N_E2 | N_E3 | N_E4 | N_E5 | N_E6 | N_E7 | N_E8 | N_E9
        | S_A0 | S_A1 | S_A2 | S_A3 | S_A4 | S_A5 | S_A6 | S_A7 | S_A8 | S_A9
        | S_B0 | S_B1 | S_B2 | S_B3 | S_B4 | S_B5 | S_B6 | S_B7 | S_B8 | S_B9
        | S_C0 | S_C1 | S_C2 | S_C3 | S_C4 | S_C5 | S_C6 | S_C7 | S_C8 | S_C9
        | S_D0 | S_D1 | S_D2 | S_D3 | S_D4 | S_D5 | S_D6 | S_D7 | S_D8 | S_D9
        | S_E0 | S_E1 | S_E2 | S_E3 | S_E4 | S_E5 | S_E6 | S_E7 | S_E8 | S_E9

    type BoardField =
        | EmptyField
        | Field of Card

    and Card = {
        id: CardId
        name: string
        description: string
        basePower: int
        currentPower: int
        tags: CardTag list
        deploy: Card -> BoardFieldId -> BoardFieldId list -> Board -> unit
    }

    and Hand = {
        cards: Card list
    }

    and BoardRow =
        BoardField array

    and BoardSide = {
        row1: BoardRow
        row2: BoardRow
        row3: BoardRow
        row4: BoardRow
        row5: BoardRow
    }

    and Board = {
        north: BoardSide
        south: BoardSide
        player1Hand: Hand
        player2Hand: Hand
    }

    type Player =
        | Player1
        | Player2

    type Game = {
        board: Board
        mutable playerToPlay: Player
        mutable message: string
        mutable state: string
    }