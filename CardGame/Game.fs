namespace CardGame

open Types
open Board

module Game =

    let createGame () = {
        board = createBoard()
        playerToPlay = Player1
        message = ""
        state = ""
    }

    let processGameCommand (game : Game) (command : string) : unit =
        ()

    let gameToString (game : Game) (player : Player) : string =
        player.ToString()