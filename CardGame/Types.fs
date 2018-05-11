namespace CardGame

module Types =

    type CardId =
        | Knight
        | Druid

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

    type Card = {
        id: CardId
        name: string
        description: string
        basePower: int
        currentPower: int
        tags: CardTag list
    }

    type BoardField =
        | EmptyField
        | Field of Card

    type BoardRow =
        BoardField array

    type BoardSide = {
        row1: BoardRow
        row2: BoardRow
        row3: BoardRow
        row4: BoardRow
        row5: BoardRow
    }

    type Board = {
        north: BoardSide
        south: BoardSide
    }