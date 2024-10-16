# ADR 005: Gebruik van apart project met interface `IPriemChecker`

*Status*: Besloten  
*Datum*: 2024-10-16  
*Auteur*: Bart van der Wal & ChatGpt

**In de context van** het ontwerp van een flexibele architectuur voor een project met zowel een Console applicatie als een Web API,  
**gezien de noodzaak** om cyclische afhankelijkheden te vermijden en de SOLID-principes (met name Dependency Inversion) te respecteren,  
**hebben we besloten voor** het plaatsen van de interface `IPriemChecker` in een apart project (https://github.com/hanaim-devops/PriemChecker/blob/main/PriemChecker.Abstractions/IPriemChecker.cs),  
**en tegen** het rechtstreeks implementeren van interfaces binnen de Console- of Web-applicatie projecten,  
**om** het "Separated Interface" patroon van Fowler (2023) toe te passen, waardoor de afhankelijkheden beter beheersbaar zijn en hergebruik van de interface over verschillende componenten mogelijk is.  
**Dit accepteren we**, hoewel het toevoegen van een apart project voor interfaces wat extra complexiteit toevoegt aan de projectstructuur, maar dit voorkomt cyclische afhankelijkheden en zorgt voor een meer schaalbare architectuur.

## Bronnen

- Fowler, M. (2023). *Separated Interface*. Geraadpleegd op 16 oktober 2024, van <https://www.martinfowler.com/eaaCatalog/separatedInterface.html>
