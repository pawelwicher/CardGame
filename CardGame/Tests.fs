namespace CardGame

open Xunit
open Types
open Board
open Cards

module Tests =

    [<Fact>]
    let ``Calculated score of the empty board should be 0 : 0.`` () =
        let board = createBoard()
        let actual = calculateScore board

        Assert.Equal((0, 0), actual)

    [<Fact>]
    let ``Calculated score of the board with a 'Knight' put on the north should be 15 : 0.`` () =
        let board = createBoard()
        let knight = createCard Knight
        board.north.row1.[5] <- Field knight

        let actual = calculateScore board

        Assert.Equal((15, 0), actual)

    [<Fact>]
    let ``Calculated score of the board with a 'Knight' put on the south should be 0 : 15.`` () =
        let board = createBoard()
        let knight = createCard Knight
        board.south.row1.[5] <- Field knight

        let actual = calculateScore board

        Assert.Equal((0, 15), actual)

    [<Fact>]
    let ``Calculated score of the board with a 'Knight' put on the north and south should be 15 : 15.`` () =
        let board = createBoard()
        let knight1 = createCard Knight
        let knight2 = createCard Knight
        board.north.row1.[5] <- Field knight1
        board.south.row1.[5] <- Field knight2

        let actual = calculateScore board

        Assert.Equal((15, 15), actual)

    [<Fact>]
    let ``Calculated score of the board with two 'Knight' units on the north and one on the south should be 30 : 15.`` () =
        let board = createBoard()
        let knight1 = createCard Knight
        let knight2 = createCard Knight
        let knight3 = createCard Knight
        board.north.row1.[5] <- Field knight1
        board.north.row2.[5] <- Field knight2
        board.south.row1.[5] <- Field knight3

        let actual = calculateScore board

        Assert.Equal((30, 15), actual)

    [<Fact>]
    let ``The 'Knight' from the north attacks the 'Knight' from the south, score should be 15 : 8.`` () =
        let board = createBoard()

        let emptyField = board.north.row1.[0]
        let southKnight = createCard Knight
        board.south.row1.[5] <- Field southKnight
        board.north.row1.[5] <- (targetBoard southKnight [emptyField]).[0]

        let northKnight = createCard Knight
        board.north.row1.[5] <- Field northKnight
        board.south.row1.[5] <- (targetBoard northKnight [Field southKnight]).[0]

        let actual = calculateScore board

        Assert.Equal((15, 8), actual)

    [<Fact>]
    let ``The 'Knight' from the north attacks the 'Knight' from the south, then the 'Druid' heals him, score should be 15 : 20.`` () =
        let board = createBoard()

        let emptyField = board.north.row1.[0]
        let southKnight = createCard Knight
        board.south.row1.[5] <- Field southKnight
        board.north.row1.[5] <- (targetBoard southKnight [emptyField]).[0]

        let northKnight = createCard Knight
        board.north.row1.[5] <- Field northKnight
        board.south.row1.[5] <- (targetBoard northKnight [Field southKnight]).[0]

        let southDruid = createCard Druid
        board.south.row1.[4] <- Field southDruid
        board.south.row1.[5] <- (targetBoard southDruid [Field southKnight]).[0]

        let actual = calculateScore board

        Assert.Equal((15, 20), actual)