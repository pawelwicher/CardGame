namespace CardGame

open Types

module Cards =

    let createCard (id : CardId) : Card =
        let knight() = { 
            id = Knight
            name = "Knight"
            description = "Knight. 15 Power. Deal 7 damage. Soldier. Loyal."
            basePower = 15
            currentPower = 15
            tags = [Unit; Loyal; Soldier]
        }

        let druid() = {
            id = Druid
            name = "Druid"
            description = "Druid. 5 Power. Heal damaged unit. Support. Loyal."
            basePower = 5
            currentPower = 5
            tags = [Unit; Loyal; Support]
        }

        match id with
        | Knight -> knight()
        | Druid -> druid()
    
    let targetBoard (card : Card) (target : BoardField list) : BoardField list =
        let knight (target : BoardField list) : BoardField list =
            let f (card : Card) : BoardField =
                if card.currentPower <= 7 then
                    EmptyField
                else
                    Field { card with currentPower = card.currentPower - 7 }        
            match target with
            | [Field card] -> [f card]
            | _ -> target

        let druid (target : BoardField list) : BoardField list =
            let f (card : Card) : BoardField =
                Field { card with currentPower = card.basePower }        
            match target with
            | [Field card] -> [f card]
            | _ -> target

        match card.id with
        | Knight -> knight target
        | Druid -> druid target