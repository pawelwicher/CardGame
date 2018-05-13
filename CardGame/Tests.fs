namespace CardGame

open Xunit
open Types
open Board
open Cards

module Tests =

    [<Fact>]
    let ``when board is empty, score should be 0 : 0.`` () =
        let board = createBoard()

        let actual = calculateScore board

        Assert.Equal((0, 0), actual)

    [<Fact>]
    let ``when there is one Knight on the north, score should be 15 : 0.`` () =
        let board = createBoard()

        let knight = createCard Knight
        
        playCard knight N_A5 [S_A5] board

        let actual = calculateScore board

        Assert.Equal((15, 0), actual)

    [<Fact>]
    let ``when there is one Knight on the south, score should be 0 : 15.`` () =
        let board = createBoard()

        let knight = createCard Knight
        
        playCard knight S_A5 [N_A5] board

        let actual = calculateScore board

        Assert.Equal((0, 15), actual)

    [<Fact>]
    let ``when there is one Knight on the south, and he hits himself, score should be 0 : 8.`` () =
        let board = createBoard()
        let knight = createCard Knight
        
        playCard knight S_A5 [S_A5] board

        let actual = calculateScore board

        Assert.Equal((0, 8), actual)

    [<Fact>]
    let ``when there is one Knight on the north and one Knight on the south, score should be 15 : 15.`` () =
        let board = createBoard()

        let knight1 = createCard Knight
        let knight2 = createCard Knight

        playCard knight1 N_A5 [S_A0] board
        playCard knight2 S_A5 [N_A0] board

        let actual = calculateScore board

        Assert.Equal((15, 15), actual)

    [<Fact>]
    let ``when there are two Knight units on the north and one Knight on the south, score should be 30 : 15.`` () =
        let board = createBoard()

        let knight1 = createCard Knight
        let knight2 = createCard Knight
        let knight3 = createCard Knight

        playCard knight1 N_A5 [S_A0] board
        playCard knight2 N_B5 [S_B0] board
        playCard knight3 S_A5 [N_A0] board

        let actual = calculateScore board

        Assert.Equal((30, 15), actual)

    [<Fact>]
    let ``when the Knight from the north attacks the Knight from the south, score should be 15 : 8.`` () =
        let board = createBoard()

        let southKnight = createCard Knight
        playCard southKnight S_A5 [N_A0] board

        let northKnight = createCard Knight
        playCard northKnight N_A5 [S_A5] board

        let actual = calculateScore board

        Assert.Equal((15, 8), actual)

    [<Fact>]
    let ``when the Knight from the north attacks the Knight from the south, then the Druid from the south heals him, score should be 15 : 20.`` () =
        let board = createBoard()

        let southKnight = createCard Knight
        playCard southKnight S_A5 [N_A0] board

        let northKnight = createCard Knight
        playCard northKnight N_A5 [S_A5] board

        let southDruid = createCard Druid
        playCard southDruid S_A4 [S_A5] board

        let actual = calculateScore board

        Assert.Equal((15, 20), actual)

    [<Fact>]
    let ``when the Knight from the north attacks the Knight from the south, then the Druid from the south heals him, then another north Knight hits the south druid, score should be 30 : 15.`` () =
        let board = createBoard()

        let southKnight = createCard Knight
        playCard southKnight S_A5 [N_A0] board

        let northKnight1 = createCard Knight
        playCard northKnight1 N_A5 [S_A5] board

        let southDruid = createCard Druid
        playCard southDruid S_A4 [S_A5] board

        let northKnight2 = createCard Knight
        playCard northKnight2 N_A4 [S_A4] board

        let actual = calculateScore board

        Assert.Equal((30, 15), actual)

    [<Fact>]
    let ``when there are five Knight units on the north and the archer from the south attacks them, score should be 30 : 15.`` () =
        let board = createBoard()
        
        let northKnight1 = createCard Knight
        playCard northKnight1 N_C1 [S_C0] board

        let northKnight2 = createCard Knight
        playCard northKnight2 N_C2 [S_C0] board

        let northKnight3 = createCard Knight
        playCard northKnight3 N_C3 [S_C0] board

        let northKnight4 = createCard Knight
        playCard northKnight4 N_C4 [S_C0] board

        let northKnight5 = createCard Knight
        playCard northKnight5 N_C5 [S_C0] board

        let southArcher = createCard Archer
        playCard southArcher S_E5 [N_C1;N_C2;N_C3;N_C4;N_C5] board

        let actual = calculateScore board

        Assert.Equal((69, 8), actual)

    [<Fact>]
    let ``when there is one Knight and the Thunderbolt hits him, score should be 5 : 0.`` () =
        let board = createBoard()

        let knight = createCard Knight
        let thunderbolt = createCard Thunderbolt

        playCard knight N_A5 [S_A0] board
        playCard thunderbolt S_A5 [N_A5] board

        let actual = calculateScore board

        Assert.Equal((5, 0), actual)