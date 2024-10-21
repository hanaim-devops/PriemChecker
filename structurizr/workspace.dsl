workspace {

    !identifiers hierarchical
    
    // Algemene informatie over het model en diagram.
    model {
        
        // De software die we willen beschrijven: PriemChecker
        softwareSystem prChecker "PriemChecker Systeem" {
            description "Een systeem dat controleert of een getal een priemgetal is."

            // De primaire gebruiker van het systeem
            person gebruiker "Gebruiker" {
                description "De persoon die een getal invoert om te controleren of het een priemgetal is."
            }

            // Externe systemen waarmee PriemChecker mogelijk communiceert
            softwareSystem exApi "Externe API voor wiskundige functies" {
                description "Een API die wiskundige berekeningen ondersteunt zoals het vinden van priemgetallen."
            }

            // Relaties tussen het PriemChecker systeem en gebruikers/externe systemen
            gebruiker -> prChecker "Voert een getal in om te controleren of het een priemgetal is"
            prChecker -> exApi "Vraagt wiskundige berekeningen op voor complexe getallen"        
        }
    }

    // Views: definieer het contextdiagram (C4 niveau 1)
    views {
        systemContext prChecker {
            include *
            # autolayout lr
            animation gebruiker -> prChecker
            animation prChecker -> exApi
        }

        // Stijl voor het diagram
        theme default
    }

    // Voor diagramgeneratie
    documentation prChecker "Context" {
        format markdown
        content """
        Dit diagram toont het PriemChecker systeem in context. Het PriemChecker systeem wordt gebruikt door een gebruiker die getallen invoert om te bepalen of ze priem zijn. 
        Het systeem kan indien nodig gebruik maken van een externe API voor geavanceerde wiskundige functies.
        """
    }
}
