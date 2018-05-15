namespace CardGame

open System
open System.Net.Sockets
open SimpleTCP

module GameServer =

    let start() =
        let simpleTcpServer = new SimpleTcpServer()
        let server = simpleTcpServer.Start(port = 8080)
        let clients = Map.empty
        let clear = Console.Clear
        let send (msg : string) (client : TcpClient) =
            let data = server.StringEncoder.GetBytes(msg)
            client.GetStream().Write(data, 0, data.Length)
        
        clear()
        "Server started." |> Console.WriteLine

        server.ClientConnected.Add(fun _ -> "Client connected." |> Console.WriteLine)

        server.ClientDisconnected.Add(fun _ -> "Client disconnected." |> Console.WriteLine)

        server.DataReceived.Add(fun msg ->
            msg.MessageString |> Console.WriteLine
            msg.Reply("<- hello")
            //let data = server.StringEncoder.GetBytes(e.MessageString)
            //list.ForEach(fun c -> c.GetStream().Write(data, 0, data.Length))
        )

        Console.ReadKey() |> ignore