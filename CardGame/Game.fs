namespace CardGame

open System
open System.Net.Sockets
open Types
open Board

module Game =

    type Player = {
        tcpClient: TcpClient
    }

    type Game = {
        name: string
        player1: Player
        player2: Player
        mutable state: string
    }
