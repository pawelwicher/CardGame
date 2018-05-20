namespace CardGame

open System
open System.Net.Sockets
open SimpleTCP
open Game

module GameServer =

    let mutable players : Player list = []
    let mutable games : Game list = []

    let start () =
        let simpleTcpServer = new SimpleTcpServer()
        let server = simpleTcpServer.Start(port = 8080)

        let send (msg : string) (client : TcpClient) : unit =
            let data = server.StringEncoder.GetBytes(msg)
            client.GetStream().Write(data, 0, data.Length)

        let gameToString (game : Game) (playerToPlay : PlayerToPlay) : string =
            "[" + playerToPlay.ToString() + "] " + game.name + " " + game.message + " state: " + game.state
        
        let gameSendToPlayers (game : Game) : unit =
            send (gameToString game Player1) game.player1.tcpClient
            send (gameToString game Player2) game.player2.tcpClient

        let findGame (games : Game list) (client : TcpClient) : Game option =
            let games = games |> List.filter (fun (x : Game) -> x.player1.tcpClient.Client.Handle = client.Client.Handle || x.player2.tcpClient.Client.Handle = client.Client.Handle)
            if games.Length = 1 then
                Some games.[0]
            else
                None

        let createMessage (playerToPlay : PlayerToPlay) : string =
            match playerToPlay with
            | Player1 -> "Player's 1 turn."
            | Player2 -> "Player's 2 turn."

        let processGameCommand (cmd : string) (game : Game) (client : TcpClient) : unit =
            if game.playerToPlay = Player1 && game.player1.tcpClient.Client.Handle = client.Client.Handle then
                game.playerToPlay <- Player2
                game.message <- createMessage game.playerToPlay
                game.state <- cmd

            if game.playerToPlay = Player2 && game.player2.tcpClient.Client.Handle = client.Client.Handle then
                game.playerToPlay <- Player1
                game.message <- createMessage game.playerToPlay
                game.state <- cmd
                
            gameSendToPlayers game

            // here todo: processing cmd. bob card1 S_A5 N_A5,N_A6
            ()

        Console.Clear()
        "Server started." |> Console.WriteLine

        server.ClientConnected.Add(fun client ->
            "Client connected." |> Console.WriteLine
            let player = { tcpClient = client }
            players <- players @ [player]

            if players.Length = 2 then
                let game = {
                    playerToPlay = Player1
                    player1 = players.[0]
                    player2 = players.[1]
                    name = ("Game " + games.Length.ToString())
                    message = ""
                    state = ""
                }
                games <- game :: games
                players <- []

                game.message <- createMessage game.playerToPlay
                gameSendToPlayers game
        )

        server.DataReceived.Add(fun msg ->
            let cmd = msg.MessageString
            cmd |> Console.WriteLine

            let game = findGame games msg.TcpClient

            if game.IsSome then
                processGameCommand cmd game.Value msg.TcpClient
        )

        Console.ReadKey() |> ignore