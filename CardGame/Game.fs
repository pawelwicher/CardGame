namespace CardGame

open System
open System.Text.RegularExpressions
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

    let createPlayerToPlayMessage (player: Player) : string =
        match player with
        | Player1 -> "Player1 turn."
        | Player2 -> "Player2 turn."

    let createGame () =
        let deck1 = createDeck Player1
        let hand1 = createHand deck1
        let graveyard1 = createGraveyard()
        let deck2 = createDeck Player1
        let hand2 = createHand deck1
        let graveyard2 = createGraveyard()
        let playerToPlay = coinFlip()
        let game = {
            board = createBoard()
            player1Deck = deck1
            player1Hand = hand1
            player1Graveyard = graveyard1
            player2Deck = deck2
            player2Hand = hand2
            player2Graveyard = graveyard2
            playerToPlay = playerToPlay
            messages = [createPlayerToPlayMessage playerToPlay]
        }
        game

    let parseCommand (command : string) : Command =
        let m = Regex.Match(command, "(?<cardNumber>\d{1,2}) (?<cardField>(S|N)_[A-E]\d) (?<cardTargetFields>((S|N)_[A-E]\d)(,((S|N)_[A-E]\d))*)")
        if m.Success then
            let cardNumber = Int32.Parse m.Groups.["cardNumber"].Value
            let cardField = stringToBoardFieldId m.Groups.["cardField"].Value
            let cardTargetFields = m.Groups.["cardTargetFields"].Value.Split(',') |> Array.map(fun x -> stringToBoardFieldId x) |> Array.toList
            { isValid = true; cardNumber = cardNumber; cardField = cardField; cardTargetFields = cardTargetFields }
        else
            { isValid = false; cardNumber = 0; cardField = UNKNOWN; cardTargetFields = [] }

    let processGameCommand (game : Game) (player : Player) (command : string) : unit =
        ()