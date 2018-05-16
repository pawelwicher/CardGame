namespace CardGame

open System
open System.Net.Sockets
open SimpleTCP

module GameServer =

    let playersNames = ["aaa"; "bbb"; "ccc"; "ddd"; "eee"]
    let mutable i = 0

    let start() =
        let simpleTcpServer = new SimpleTcpServer()
        let server = simpleTcpServer.Start(port = 8080)
        let send (msg : string) (client : TcpClient) =
            let data = server.StringEncoder.GetBytes(msg)
            client.GetStream().Write(data, 0, data.Length)

        Console.Clear()
        "Server started." |> Console.WriteLine

        server.ClientConnected.Add(fun c ->
            "Client connected." |> Console.WriteLine
            let name = playersNames.[i]
            send ("Hello: " + name) c
            i <- i + 1
        )

        server.ClientDisconnected.Add(fun _ -> "Client disconnected." |> Console.WriteLine)

        server.DataReceived.Add(fun msg ->
            let cmd = msg.MessageString
            cmd |> Console.WriteLine
            
            // here todo: processing cmd. bob card1 S_A5 N_A5,N_A6

            //let data = server.StringEncoder.GetBytes(e.MessageString)
            //list.ForEach(fun c -> c.GetStream().Write(data, 0, data.Length))
        )

        Console.ReadKey() |> ignore
