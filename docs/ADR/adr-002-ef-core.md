# ADR 002: Gebruik van Entity Framework Core als ORM

*Status*: Besloten  
*Datum*: 2024-10-16  
*Auteur*: Bart van der Wal & ChatGpt

**In de context van** het opslaan en beheren van data binnen de C# applicatie,  
**gezien de noodzaak** om een [evolutionair databaseontwerp](https://minordevops.nl/week-2-containerization/les-2-orm-en-adr.html?highlight=evolution#web-applicatie-server)  te ondersteunen,
**hebben we besloten voor** Entity Framework (EF) Core 8.0 als ORM,  
**en tegen** handgeschreven SQL of andere ORM-frameworks,  
**om** ontwikkelaars in staat te stellen eenvoudiger met data te werken en aanpassingen te kunnen doen zonder ingrijpende wijzigingen in de applicatie.  
**Dit accepteren we**, hoewel een handgeschreven SQL meer controle kan bieden, maar EF Core bevordert productiviteit en aanpasbaarheid.
