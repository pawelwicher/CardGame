namespace CardGame

open System
open System.Net.Sockets
open Types
open Board

module Game =

    type Player = {
        tcpClient: TcpClient
    }

    type PlayerToPlay =
        | Player1
        | Player2

    type Game = {
        name: string
        mutable playerToPlay: PlayerToPlay
        player1: Player
        player2: Player
        mutable message: string
        mutable state: string
    }