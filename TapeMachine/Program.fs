// Learn more about F# at http://fsharp.org

module TapeMachine
open System

type TapeState =
    | Playing
    | Paused
    | Stopped

type Events =
    | PressPlay
    | PressStop
    | PressPause

let act = function
    | Stopped, PressPlay -> Playing
    | (Playing | Paused), PressStop -> Stopped
    | Playing, PressPause -> Paused
    | Stopped, PressPause -> Stopped
    | Paused, PressPause -> Playing

[<EntryPoint>]
let main argv =
    act (Stopped, PressPlay) |> printfn "Stopped, Press Play: %A"
    act (Playing, PressStop) |> printfn "Playing, PressStop: %A"
    act (Playing, PressPause) |> printfn "Playing, PressPause: %A"
    act (Paused, PressPause) |> printfn "Paused, PressPause: %A"
    act (Stopped, PressPause) |> printfn "Stopped, PressPause: %A"
    0 // return an integer exit code
