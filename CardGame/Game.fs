namespace CardGame

open Types
open Board
open Cards

module Game =

    let createGame () = {
        board = createBoard()
        player1Hand = { cards = [createCard Knight; createCard Archer] }
        player2Hand = { cards = [createCard Archer; createCard Druid] }
        playerToPlay = Player1
        message = ""
        state = ""
    }

    let processGameCommand (game : Game) (player : Player) (command : string) : unit =
        ()