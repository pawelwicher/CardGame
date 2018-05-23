namespace CardGame

open System
open System.Net.Sockets
open SimpleTCP
open Types
open Game

module GameServer =

    let game = createGame()
    let mutable client1 : TcpClient = null
    let mutable client2 : TcpClient = null

    let start () =
        let simpleTcpServer = new SimpleTcpServer()
        let server = simpleTcpServer.Start(port = 8080)

        let send (msg : string) (client : TcpClient) : unit =
            let data = server.StringEncoder.GetBytes(msg)
            client.GetStream().Write(data, 0, data.Length)

        Console.Clear()
        "Server started." |> Console.WriteLine

        server.ClientConnected.Add(fun client ->
            if client1 = null || client2 = null then
                if client1 = null then
                    client1 <- client
                elif client2 = null then 
                    client2 <- client

                if client1 <> null && client2 <> null then
                    send (gameToString game Player1) client1
                    send (gameToString game Player2) client2
        )

        server.DataReceived.Add(fun msg ->
            let command = msg.MessageString
            processGameCommand game command
            send (gameToString game Player1) client1
            send (gameToString game Player2) client2
        )

        Console.ReadKey() |> ignore