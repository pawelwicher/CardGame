﻿namespace CardGame

open Types
open Board

module Cards =

    let createCard (id : CardId) : Card =
        let knight () = { 
            id = Knight
            name = "Knight"
            description = "Knight. 15 Power. Deal 7 damage. Soldier. Loyal."
            basePower = 15
            currentPower = 15
            tags = [Unit; Loyal; Soldier]
            deploy =
                fun (card : Card) (fieldId : BoardFieldId) (fieldIds : BoardFieldId list) (board : Board) ->
                    changeField fieldId board (fun _ -> Field card)
                    let f (field : BoardField) : BoardField =
                        match field with
                        | Field card -> if card.currentPower <= 7 then
                                            EmptyField 
                                        else
                                            Field { card with currentPower = card.currentPower - 7 }
                        | _ -> field
                    fieldIds |> List.take 1 |> List.iter (fun fieldId -> changeField fieldId board f)
        }

        let archer () = { 
            id = Archer
            name = "Archer"
            description = "Archer. 8 Power. Deal 2 damage 3 times. Soldier. Loyal."
            basePower = 8
            currentPower = 8
            tags = [Unit; Loyal; Soldier]
            deploy =
                fun (card : Card) (fieldId : BoardFieldId) (fieldIds : BoardFieldId list) (board : Board) ->
                    changeField fieldId board (fun _ -> Field card)
                    let f (field : BoardField) : BoardField =
                        match field with
                        | Field card -> if card.currentPower <= 2 then
                                            EmptyField 
                                        else
                                            Field { card with currentPower = card.currentPower - 2 }
                        | _ -> field
                    fieldIds |> List.take 3 |> List.iter (fun fieldId -> changeField fieldId board f)
        }

        let druid () = {
            id = Druid
            name = "Druid"
            description = "Druid. 5 Power. Heal damaged unit. Support. Loyal."
            basePower = 5
            currentPower = 5
            tags = [Unit; Loyal; Support]
            deploy =
                fun (card : Card) (fieldId : BoardFieldId) (fieldIds : BoardFieldId list) (board : Board) ->
                    changeField fieldId board (fun _ -> Field card)
                    let f (field : BoardField) : BoardField =
                        match field with
                        | Field card -> Field { card with currentPower = card.basePower }
                        | _ -> field
                    fieldIds |> List.take 1 |> List.iter (fun fieldId -> changeField fieldId board f)
        }

        let thunderbolt () = {
            id = Thunderbolt
            name = "Thunderbolt"
            description = "Thunderbolt. Deal 10 damage. Spell."
            basePower = 0
            currentPower = 0
            tags = [Special; Spell]
            deploy =
                fun (card : Card) (fieldId : BoardFieldId) (fieldIds : BoardFieldId list) (board : Board) ->
                    let f (field : BoardField) : BoardField =
                        match field with
                        | Field card -> if card.currentPower <= 10 then
                                            EmptyField 
                                        else
                                            Field { card with currentPower = card.currentPower - 10 }
                        | _ -> field
                    fieldIds |> List.take 1 |> List.iter (fun fieldId -> changeField fieldId board f)
        }

        match id with
        | Knight -> knight()
        | Archer -> archer()
        | Druid  -> druid()
        | Thunderbolt -> thunderbolt()

    let playCard (card : Card) (fieldId : BoardFieldId) (fieldIds : BoardFieldId list) (board : Board) : unit =
        card.deploy card fieldId fieldIds board