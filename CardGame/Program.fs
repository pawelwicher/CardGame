open System
open CardGame

[<EntryPoint>]
let main _ =
    "1 - Server mode" |> Console.WriteLine
    "2 - Client mode" |> Console.WriteLine

    match Console.ReadKey().KeyChar with
    | '1' -> GameServer.start()
    | '2' -> GameClient.start()
    |  _  -> ()
    0