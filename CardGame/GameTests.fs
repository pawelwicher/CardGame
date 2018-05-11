namespace CardGameTests

open System
open Xunit
open CardGame.Game

module CardGameTests =

    [<Fact>]
    let ``Create 'Knight' card.`` () =
        let expected = createKnight()        
        let actual = createCard Knight

        Assert.Equal(expected, actual)

    [<Fact>]
    let ``Create two 'Knight' cards, they should be equal but not the same instance.`` () =        
        let knight1 = createCard Knight
        let knight2 = createCard Knight

        Assert.Equal(knight1, knight2)
        Assert.NotSame(knight1, knight2)

    [<Fact>]
    let ``Calculated score of the empty board should be 0 : 0.`` () =
        let board = createBoard()
        let actual = calculateScore board

        Assert.Equal((0, 0), actual)

    [<Fact>]
    let ``Calculated score of the board with a 'Knight' put on the north should be 15 : 0.`` () =
        let board = createBoard()
        let knight = createCard Knight
        board.north.melee1.[5] <- Some knight

        let actual = calculateScore board

        Assert.Equal((15, 0), actual)

    [<Fact>]
    let ``Calculated score of the board with a 'Knight' put on the south should be 0 : 15.`` () =
        let board = createBoard()
        let knight = createCard Knight
        board.south.melee1.[5] <- Some knight

        let actual = calculateScore board

        Assert.Equal((0, 15), actual)

    [<Fact>]
    let ``Calculated score of the board with a 'Knight' put on the north and south should be 15 : 15.`` () =
        let board = createBoard()
        let knight1 = createCard Knight
        let knight2 = createCard Knight
        board.north.melee1.[5] <- Some knight1
        board.south.melee1.[5] <- Some knight2

        let actual = calculateScore board

        Assert.Equal((15, 15), actual)

    [<Fact>]
    let ``Calculated score of the board with two 'Knight' units on the north and one on the south should be 30 : 15.`` () =
        let board = createBoard()
        let knight1 = createCard Knight
        let knight2 = createCard Knight
        let knight3 = createCard Knight
        board.north.melee1.[5] <- Some knight1
        board.north.melee2.[5] <- Some knight2
        board.south.melee1.[5] <- Some knight3

        let actual = calculateScore board

        Assert.Equal((30, 15), actual)