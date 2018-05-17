namespace CardGame

open System
open SimpleTCP

module GameClient =

    let start() =
        let simpleTcpClient = new SimpleTcpClient()
        let client = simpleTcpClient.Connect("127.0.0.1", 8080)

        client.DataReceived.Add(fun e ->
            Console.Clear()
            e.MessageString |> Console.WriteLine
        )

        Console.Clear()
    
        while true do
            Console.ReadLine() |> client.Write
            Console.Clear()
