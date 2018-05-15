namespace CardGame

open System
open SimpleTCP

module GameClient =

    let start() =
        let client = new SimpleTcpClient()
        let c = client.Connect("127.0.0.1", 8080)
        let clear = Console.Clear
        let prompt (name : string) = String.Format("[{0}] -> ", name) |> Console.Write
        let mutable loop = true

        clear()
        "Enter your name: " |> Console.Write
        let name = Console.ReadLine()

        clear()
        prompt(name)

        c.DataReceived.Add(fun e ->
            clear()
            e.MessageString |> Console.WriteLine
            prompt(name)
        )
    
        while loop do
            let line = Console.ReadLine()
            if line = "quit" then
                loop <- false
            else
                c.Write(String.Format("[{0}] -> {1}", name, line))
    
        c.Disconnect() |> ignore