# ADR 001: Gebruik Value Converter voor BigInteger in EF Core

*Status*: Besloten
*Datum*: 2024-09-22
*Auteur*: Bart van der Wal & ChatGpt

## Context

We moeten in ons project grote getallen, zoals priemkandidaten, opslaan in een relationele database (SQL database). Deze getallen zijn groter dan de standaard int of long typen die door de database worden ondersteund. De BigInteger-struct in .NET biedt een oplossing voor het werken met zeer grote getallen, maar Entity Framework Core (EF Core) biedt geen directe ondersteuning voor `BigInteger` bij het mappen naar SQL Server.

## Beslissing

We hebben besloten om een Value Converter te gebruiken binnen Entity Framework Core om de BigInteger-waarden te converteren naar een string-weergave voor opslag in de database. Bij het ophalen van de gegevens zal de Value Converter de string weer omzetten naar een BigInteger.

Dit voorkomt dat we de structuur van de database drastisch hoeven te veranderen en maakt het mogelijk om nauwkeurige priemgetalberekeningen op te slaan zonder dat we afhankelijk zijn van ondersteunde datatypes van de database.

Het 'String' format biedt beste mogelijkheid voor het opslaan van arbitrair grote getallen, hoewel we extra logica moeten toevoegen voor de conversie.

## Consequenties

Deze architectuur keuze heeft voor- en nadelen.

### Voordelen

- We kunnen zeer grote getallen zoals BigInteger opslaan in een database zonder dat we de database-schema's hoeven aan te passen.
- De applicatie blijft schaalbaar en flexibel wat betreft het omgaan met grote priemkandidaten.

### Nadelen

- We moeten rekening houden met de prestatie-impact van het converteren van grote getallen naar en van een string formaat.
- We introduceren extra complexiteit met de Value Converter, wat kan leiden tot moeilijkheden bij het debuggen of uitbreiden van de logica.

## Alternatieven

1. Decimal opslaan in SQL Server
   We hebben overwogen om BigInteger-waarden op te slaan als `decimal`-waarden in de database, maar de maximale schaal van een decimal is beperkt tot 38 cijfers, wat onvoldoende kan zijn voor sommige zeer grote priemkandidaten.

> "In SQL Server, the default maximum precision of numeric and decimal data types is 38." - Mike Ray, Microsoft Learn

2. Opslag als bigint
   SQL Server ondersteunt bigint, waarmee je getallen kunt opslaan die groter zijn dan een standaard `int`. Echter, `bigint` is beperkt tot 64-bit integers, wat nog steeds onvoldoende is voor het opslaan van extreem grote getallen zoals vereist voor onze toepassing. (TODO bigint bron Microsoft Learn)

## Links (TODO Apa-ify)

Alle bronnen geraadpleegd september 2024

- [EF Core documentatie over Value Converters](https://learn.microsoft.com/en-us/ef/core/modeling/value-conversions?tabs=data-annotations)
- Ray, M. (05/23/2023) *Precision, scale, and length (Transact-SQL)* Op](https://learn.microsoft.com/en-us/sql/t-sql/data-types/precision-scale-and-length-transact-sql?view=sql-server-ver16)
- https://learn.microsoft.com/en-us/sql/t-sql/data-types/int-bigint-smallint-and-tinyint-transact-sql?view=sql-server-ver16