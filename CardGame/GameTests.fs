namespace CardGame.Tests

open System
open Xunit
open CardGame.Game

module CardTests =

    [<Fact>]
    let ``Create 'Knight' card`` () =
        let card = {
            id = Knight
            name = "Knight"
            description = "Knight. 15 Power. Deal 7 Damage. Soldier. Loyal."
            basePower = 15
            currentPower = 15
            tags = [Unit; Loyal; Soldier]
        }
        
        let actual = createCard Knight

        Assert.Equal(card, actual)

    [<Fact>]
    let ``Calculate score of the empty board should be 0 : 0`` () =
        let board = createBoard()
        let actual = calculateScore board

        Assert.Equal(actual, (0, 0))

    [<Fact>]
    let ``Calculate score of the board with a 'Knight' put on the north should be 15 : 0`` () =
        let board = createBoard()
        let knight = createCard Knight
        board.north.melee1.[5] <- Some knight

        let actual = calculateScore board

        Assert.Equal(actual, (15, 0))

    [<Fact>]
    let ``Calculate score of the board with a 'Knight' put on the south should be 0 : 15`` () =
        let board = createBoard()
        let knight = createCard Knight
        board.south.melee1.[5] <- Some knight

        let actual = calculateScore board

        Assert.Equal(actual, (0, 15))

    [<Fact>]
    let ``Calculate score of the board with a 'Knight' put on the north and south should be 15 : 15`` () =
        let board = createBoard()
        let knight1 = createCard Knight
        let knight2 = createCard Knight
        board.north.melee1.[5] <- Some knight1
        board.south.melee1.[5] <- Some knight2

        let actual = calculateScore board

        Assert.Equal(actual, (15, 15))