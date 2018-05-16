namespace CardGame

open System
open SimpleTCP

module GameClient =

    let start() =
        let simpleTcpClient = new SimpleTcpClient()
        let client = simpleTcpClient.Connect("127.0.0.1", 8080)
        let mutable loop = true

        client.DataReceived.Add(fun e ->
            Console.Clear()
            e.MessageString |> Console.WriteLine
        )

        Console.Clear()
    
        while loop do
            let line = Console.ReadLine()
            if line = "quit" then
                loop <- false
            else
                line |> client.Write
                Console.Clear()
    
        client.Disconnect() |> ignore
