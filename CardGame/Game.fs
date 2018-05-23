namespace CardGame

open Types
open Board

module Game =

    let createGame () = {
        board = createBoard()
        player1Hand = { cards = [] }
        player2Hand = { cards = [] }
        playerToPlay = Player1
        message = ""
        state = ""
    }

    let processGameCommand (game : Game) (command : string) : unit =
        ()

    let gameToString (game : Game) (player : Player) : string =
        boardToString game.board player