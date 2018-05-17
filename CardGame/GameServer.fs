namespace CardGame

open System
open System.Net.Sockets
open SimpleTCP
open Game

module GameServer =

    let mutable players : Player list = []
    let mutable games : Game list = []

    let start() =
        let simpleTcpServer = new SimpleTcpServer()
        let server = simpleTcpServer.Start(port = 8080)

        let send (msg : string) (client : TcpClient) : unit =
            let data = server.StringEncoder.GetBytes(msg)
            client.GetStream().Write(data, 0, data.Length)

        let gameToString (game : Game) : string =
            game.name + " state: " + game.state
        
        let gameSendToPlayers (game : Game) : unit =
            send (gameToString game) game.player1.tcpClient
            send (gameToString game) game.player2.tcpClient

        let findGame (games : Game list) (client : TcpClient) : Game option =
            let games = games |> List.filter (fun (x : Game) -> x.player1.tcpClient.Client.Handle = client.Client.Handle || x.player2.tcpClient.Client.Handle = client.Client.Handle)
            if games.Length = 1 then
                Some games.[0]
            else
                None

        Console.Clear()
        "Server started." |> Console.WriteLine

        server.ClientConnected.Add(fun client ->
            "Client connected." |> Console.WriteLine
            let player = { tcpClient = client }
            players <- player :: players

            if players.Length = 2 then
                let game = { player1 = players.[0]; player2 = players.[1]; name = ("Game " + games.Length.ToString()); state = "" }
                games <- game :: games
                players <- []
                gameSendToPlayers game
        )

        server.DataReceived.Add(fun msg ->
            let cmd = msg.MessageString
            cmd |> Console.WriteLine

            let game = findGame games msg.TcpClient

            if game.IsSome then
                game.Value.state <- cmd
                gameSendToPlayers game.Value

            // here todo: processing cmd. bob card1 S_A5 N_A5,N_A6
        )

        Console.ReadKey() |> ignore
