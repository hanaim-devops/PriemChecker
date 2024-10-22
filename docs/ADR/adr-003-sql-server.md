# ADR 003: Gebruik van SQL Server als database

*Status*: Besloten  
*Datum*: 2024-10-16  
*Auteur*: Bart van der Wal & ChatGpt

**In de context van** de keuze voor een databaseoplossing,  
**gezien de noodzaak** dat studenten bekend zijn met relationele databases zoals SQL Server vanuit eerdere vakken ('Db' en het I-project),  
**hebben we besloten voor** SQL Server als primaire opslagtechnologie,  
**en tegen** alternatieven zoals MySQL of PostgreSQL,  
**om** consistente kennisopbouw te ondersteunen en aan te sluiten bij de .NET-technologieën en het gebruik in PitStop.  
**Dit accepteren we**, ondanks mogelijke nadelen zoals hoog geheugengebruik en eerdere compatibiliteitsproblemen met containers op macOS met M1/M2, waarvan de nieuwste versie dit probleem heeft opgelost (zie Microfoft blog van [Skwiers-Koballa, 2023](https://devblogs.microsoft.com/azure-sql/development-with-sql-in-containers-on-macos)).

## Bronnen

- Skwiers-Koballa, D. (January 13th, 2023) *Development with SQL in containers on macOS(). Geraadpleegd 16-10-2024 op <https://devblogs.microsoft.com/azure-sql/development-with-sql-in-containers-on-macos>
