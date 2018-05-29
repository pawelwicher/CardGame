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

    let coinFlip () : Player =
        Player1

    let createGame () =
        let deck1 = createDeck Player1
        let deck2 = createDeck Player2
        let hand1 = createHand deck1
        let hand2 = createHand deck2
        let game = {
            board = createBoard()
            player1Deck = deck1
            player2Deck = deck2
            player1Hand = hand1
            player2Hand = hand2
            playerToPlay = coinFlip()
        }
        game

    let processGameCommand (game : Game) (player : Player) (command : string) : unit =
        ()