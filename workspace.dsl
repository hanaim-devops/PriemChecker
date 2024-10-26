workspace "PriemChecker" "Context, Container en Component diagrammen voor PriemChecker systeem" {

    !identifiers hierarchical

    model {
        // Gebruikers
        anoniemeGebruiker = person "Anonieme Gebruiker" {
            description "Gebruiker die alleen int waardes kan opvragen."
        }
        
        ingelogdeGebruiker = person "Ingelogde Gebruiker" {
            description "Gebruiker die BigIntegers kan opvragen."
        }
        
        privilegedGebruiker = person "Privileged User (Prime Hacker)" {
            description "Gebruiker die BigIntegers kan opvragen en al een priemgetal heeft geraden."
        }
        
        adminGebruiker = person "Admin Gebruiker" {
            description "Beheerder die statistieken kan opvragen."
        }

        // Extern systeem
        superComputer = softwareSystem "Supercomputer Prime" {
            description "Externe supercomputer voor het berekenen van grote priemgetallen."
        }

        // PriemChecker Systeem
        prChecker = softwareSystem "PriemChecker Systeem" {
            description "Een systeem dat controleert of een getal een priemgetal is."
            
            // Containers binnen het PriemChecker systeem
            frontEnd = container "Front-end (Nginx)" {
                description "De front-end die draait op Nginx en communiceert met de back-end."
                technology "Nginx"
            }

            database = container "Database (SQL Server)" {
                description "Slaat de opgevraagde priemgetallen en metadata op."
                technology "SQL Server"
                tags "Database"
            }

            backEnd = container "Back-end (Java Spring Boot)" {
                description "Bevat de logica voor het controleren van priemgetallen en communiceert met de database."
                technology "Spring Boot"

                // Definieer componenten binnen de backEnd container
                consoleApp = component "Console Applicatie" {
                    description "Biedt toegang tot de priemgetallen logica zonder verdere autorisatie."
                    technology "Java"
                }

                restApi = component "RESTful API" {
                    description "Stelt API endpoints beschikbaar en voert autorisatie uit."
                    technology "Spring MVC"
                }

                authService = component "Authenticatie Service" {
                    description "Beheert gebruikersnamen en rollen."
                    technology "Spring Security"
                }

                priemService = component "PriemService" {
                    description "Business logica voor het controleren of een getal een priemgetal is."
                    technology "Java"
                }

                dataLayer = component "Data Laag" {
                    description "Beheert de verbinding met SQL Server en bevat Entity Framework code first."
                    technology "Spring Data JPA"
                }

                // Relaties tussen componenten
                consoleApp -> priemService "Gebruikt de priemgetallen logica"
                restApi -> priemService "Stuurt priemgetal verzoeken naar de service"
                restApi -> authService "Controleert credentials/tokens via de authenticatieservice"
                priemService -> dataLayer "Verstuurt database verzoeken"
                dataLayer -> prChecker.database "Leest en schrijft resultaten"
            }

        }

        // Externe API (optioneel)
        externalApi = softwareSystem "Externe Wiskunde API" {
            description "Een externe API die complexe wiskundige berekeningen uitvoert."
            tags "Extern"
        }

        // Relaties tussen de elementen
        anoniemeGebruiker -> prChecker.frontEnd "Gebruikt om integer priemgetallen  te checken"
        ingelogdeGebruiker -> prChecker.frontEnd "Gebruikt om BigInteger priemgetallen te checken"
        privilegedGebruiker -> prChecker.frontEnd "Gebruikt om BigInteger priemgetallen te checken (eerder geraden)"
        #prChecker.backEnd -> prChecker.database "Leest en schrijft resultaten"
    }

    views {
        // Voeg System Context diagram toe
        systemContext prChecker "PriemCheckerContextDiagram" {
            include *
            autolayout lr
            description "Legenda:\nPerson: Gebruiker van het systeem\nSoftware System: Het PriemChecker systeem\nExtern: Externe systemen zoals de Wiskunde API"
        }
    
        // Voeg Container diagram toe
        container prChecker "PriemCheckerContainerDiagram" {
            include *
            autolayout lr
        }
        
        component prChecker.backEnd "PriemCheckerComponentDiagram" {
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
            element "Component" {
                background #85bbf0
                color #000000
            }
            element "Database" {
                shape cylinder
                background #438dd5
                color #ffffff
            }
            element "Extern" {
               background #999999
                color #ffffff
            }
        }
    }

    configuration {
        scope softwaresystem
        # theme default
    }
}
