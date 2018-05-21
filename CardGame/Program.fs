open System
open CardGame

[<EntryPoint>]
let main _ =
    "1 - Server mode" |> Console.WriteLine
    "2 - Client mode" |> Console.WriteLine
    let c = Console.ReadKey()
    if c.KeyChar = '1' then
        GameServer.start()
    elif c.KeyChar = '2' then
        GameClient.start()
    0