workspace "PriemChecker" "Context diagram voor PriemChecker systeem" {

    !identifiers hierarchical

    model {

        // Gebruiker van het PriemChecker systeem
        gebruiker = person "Gebruiker" {
            description "De persoon die een getal invoert om te controleren of het een priemgetal is."
        }

        // PriemChecker software systeem
        prChecker = softwareSystem "PriemChecker Systeem" {
            description "Een systeem dat controleert of een getal een priemgetal is."

            // Containers binnen het PriemChecker systeem
            webApp = container "Web Applicatie" {
                description "De front-end applicatie die door de gebruiker wordt gebruikt om getallen in te voeren."
                technology "React"
            }

            db = container "Database" {
                description "Slaat resultaten op van priemgetal-controles."
                technology "PostgreSQL"
                tags "Database"
            }
        }

        // Externe API (optioneel)
        externalApi = softwareSystem "Externe Wiskunde API" {
            description "Een externe API die complexe wiskundige berekeningen uitvoert."
        }

        // Relaties tussen de elementen
        gebruiker -> prChecker.webApp "Gebruikt om getallen in te voeren"
        prChecker.webApp -> prChecker.db "Leest en schrijft resultaten"
        prChecker.webApp -> externalApi "Vraagt complexe berekeningen aan"
    }

    views {
        // Context diagram voor het PriemChecker systeem
        systemContext prChecker "PriemCheckerContextDiagram" {
            include *
            autolayout lr
        }

        // Container diagram voor het PriemChecker systeem
        container prChecker "PriemCheckerContainerDiagram" {
            include *
            autolayout lr
        }

        // Stijlen voor de weergave van elementen
        styles {
            element "Person" {
                background #08427b
                color #ffffff
                shape person
            }
            element "Software System" {
                background #1168bd
                color #ffffff
            }
            element "Container" {
                background #438dd5
                color #ffffff
            }
            element "Database" {
                shape cylinder
                background #438dd5
                color #ffffff
            }
        }
    }

    configuration {
        scope softwareSystem
    }

}
