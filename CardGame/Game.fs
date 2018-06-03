namespace CardGame

open Types
open Board
open Cards

module Game =

    let createDeck (player: Player) : Deck =
        match player with
        | Player1 -> { cards = [createCard Knight; createCard Archer] }
        | Player2 -> { cards = [createCard Archer; createCard Druid] }

    let createHand (deck : Deck) : Hand =
        { cards = [createCard Knight; createCard Archer] }

    let createGraveyard () : Graveyard =
        { cards = [] }

    let coinFlip () : Player =
        Player1

    let createGame () =
        let deck1 = createDeck Player1
        let hand1 = createHand deck1
        let graveyard1 = createGraveyard()
        let deck2 = createDeck Player1
        let hand2 = createHand deck1
        let graveyard2 = createGraveyard()
        let game = {
            board = createBoard()
            player1Deck = deck1
            player1Hand = hand1
            player1Graveyard = graveyard1
            player2Deck = deck2
            player2Hand = hand2
            player2Graveyard = graveyard2
            playerToPlay = coinFlip()
        }
        game

    let parseCommand (command : string) : Command =
        { isValid = true; cardNumber = 1; cardField = S_A5; cardTargetFields = [N_A1; N_A2] }

    let processGameCommand (game : Game) (player : Player) (command : string) : unit =
        ()