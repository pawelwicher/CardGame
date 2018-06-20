namespace CardGame

open System
open Xunit
open FsUnit.Xunit
open Types
open Board
open Cards
open Game

module Tests =

    [<Fact>]
    let ``when board is empty, score should be 0 : 0.`` () =
        let board = createBoard()

        let actual = calculateScore board

        actual |> should equal (0, 0)

    [<Fact>]
    let ``when there is one Knight on the north, score should be 15 : 0.`` () =
        let board = createBoard()

        let knight = createCard Knight
        
        playCard knight N_A5 [S_A5] board

        let actual = calculateScore board

        actual |> should equal (15, 0)

    [<Fact>]
    let ``when there is one Knight on the south, score should be 0 : 15.`` () =
        let board = createBoard()

        let knight = createCard Knight
        
        playCard knight S_A5 [N_A5] board

        let actual = calculateScore board

        actual |> should equal (0, 15)

    [<Fact>]
    let ``when there is one Knight on the south, and he hits himself, score should be 0 : 8.`` () =
        let board = createBoard()
        let knight = createCard Knight
        
        playCard knight S_A5 [S_A5] board

        let actual = calculateScore board

        actual |> should equal (0, 8)

    [<Fact>]
    let ``when there is one Knight on the north and one Knight on the south, score should be 15 : 15.`` () =
        let board = createBoard()

        let knight1 = createCard Knight
        let knight2 = createCard Knight

        playCard knight1 N_A5 [S_A0] board
        playCard knight2 S_A5 [N_A0] board

        let actual = calculateScore board

        actual |> should equal (15, 15)

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

        actual |> should equal (30, 15)

    [<Fact>]
    let ``when the Knight from the north attacks the Knight from the south, score should be 15 : 8.`` () =
        let board = createBoard()

        let southKnight = createCard Knight
        playCard southKnight S_A5 [N_A0] board

        let northKnight = createCard Knight
        playCard northKnight N_A5 [S_A5] board

        let actual = calculateScore board

        actual |> should equal (15, 8)

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

        actual |> should equal (15, 20)

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

        actual |> should equal (30, 15)

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

        actual |> should equal (69, 8)

    [<Fact>]
    let ``when there is one Knight and the Thunderbolt hits him, score should be 5 : 0.`` () =
        let board = createBoard()

        let knight = createCard Knight
        let thunderbolt = createCard Thunderbolt

        playCard knight N_A5 [S_A0] board
        playCard thunderbolt S_A5 [N_A5] board

        let actual = calculateScore board

        actual |> should equal (5, 0)

    [<Fact>]
    let ``when game is created player's decks should not be empty.`` () =
        let actual = createGame()

        actual.player1Deck.cards |> should not' (be Empty)
        actual.player2Deck.cards |> should not' (be Empty)

    [<Fact>]
    let ``when game is created player's hands should not be empty.`` () =
        let actual = createGame()

        actual.player1Hand.cards |> should not' (be Empty)
        actual.player2Hand.cards |> should not' (be Empty)

    [<Fact>]
    let ``when game is created player's graveyards should not be empty.`` () =
        let actual = createGame()

        actual.player1Graveyard.cards |> should be Empty
        actual.player2Graveyard.cards |> should be Empty

    [<Fact>]
    let ``when stringToBoardFieldId is called with "S_A5" string, value S_A5 expected.`` () =
        let actual = stringToBoardFieldId "S_A5"

        actual |> should equal S_A5

    [<Fact>]
    let ``when stringToBoardFieldId is called with "N_A5" string, value N_A5 expected.`` () =
        let actual = stringToBoardFieldId "N_A5"

        actual |> should equal N_A5

    [<Fact>]
    let ``when stringToBoardFieldId is called with "123" string, value UNKNOWN expected.`` () =
        let actual = stringToBoardFieldId "123"

        actual |> should equal UNKNOWN

    [<Fact>]
    let ``when parseCommand is called with "qwerty" created Command should not be valid.`` () =
        let actual = parseCommand "qwerty"

        actual.isValid |> should equal false

    [<Fact>]
    let ``when parseCommand is called with "1 S_A5 N_A1" created Command should be valid.`` () =
        let actual = parseCommand "1 S_A5 N_A1"
        let expected = { isValid = true; cardNumber = 1; cardField = S_A5; cardTargetFields = [N_A1] }

        actual |> should equal expected

    [<Fact>]
    let ``when parseCommand is called with "1 S_A5 N_A1,N_A2,N_A3" created Command should be valid.`` () =
        let actual = parseCommand "1 S_A5 N_A1,N_A2,N_A3"
        let expected = { isValid = true; cardNumber = 1; cardField = S_A5; cardTargetFields = [N_A1; N_A2; N_A3] }

        actual |> should equal expected

    [<Fact>]
    let ``when processGameCommand is called and player to play is Player1 and he sends invalid command he should get a message.`` () =
        let game = createGame()
        
        processGameCommand game Player1 "test"

        game.playerToPlay |> should equal Player1
        game.player1Messages |> should equal ["Player1 turn"; "Invalid command"]
        game.player2Messages |> should equal ["Player1 turn"]

    [<Fact>]
    let ``when processGameCommand is called and player to play is Player1 and he sends valid command player to play should be switched.`` () =
        let game = createGame()
        
        processGameCommand game Player1 "1 S_A5 N_A1,N_A2,N_A3"

        game.playerToPlay |> should equal Player2
        game.player1Messages |> should equal ["Player2 turn"]
        game.player2Messages |> should equal ["Player2 turn"]