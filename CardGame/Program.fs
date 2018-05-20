open System
open CardGame.Types
open CardGame.Board
open CardGame.Cards
open CardGame.DebugHelper
open CardGame

[<EntryPoint>]
let main _ =
    (*let board = createBoard()

    let northKnight1 = createCard Knight
    playCard northKnight1 N_C1 [S_C0] board

    let northKnight2 = createCard Knight
    playCard northKnight2 N_C2 [S_C0] board

    let northKnight3 = createCard Knight
    playCard northKnight3 N_C3 [S_C0] board

    let northKnight4 = createCard Knight
    playCard northKnight4 N_C4 [S_C0] board

    let northKnight5 = createCard Knight
    playCard northKnight5 N_C5 [S_C0] board

    let southArcher = createCard Archer
    playCard southArcher S_E5 [N_C1;N_C2;N_C3;N_C4;N_C5] board

    let thunderbolt = createCard Thunderbolt
    playCard thunderbolt S_E5 [N_C5] board

    (printBoard board) |> Console.WriteLine*)

    "1 - Server mode" |> Console.WriteLine
    "2 - Client mode" |> Console.WriteLine
    let c = Console.ReadKey()

    if c.KeyChar = '1' then
        GameServer.start()
    elif c.KeyChar = '2' then
        GameClient.start()

    0