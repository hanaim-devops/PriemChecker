# Documentatie

In de folder `ADR` staan alle Architecture Decision Records.

De belangrijkste toelichting staat in de README.md. Maar hier komt eventuele verdere uitwerking zoals C4 diagrammen e.d.

## System architectuur

We gebruiken C4 diagrammen om een software architectuur van de PriemChecker weer te geven op verschillende niveaus. Figuur 1 toont het gehele systeem in een C4 System Context diagram.

```plantuml
!define RECTANGLE <<rectangle>>

title PriemChecker - Context Diagram

actor AnoniemeGebruiker as AnonymousUser
actor IngelogdeGebruiker as LoggedInUser
actor PrimeHacker as PrivilegedUser
actor AdminUser as Admin

AnonymousUser --> PriemCheckerApp : "Getal insturen (int)"
LoggedInUser --> PriemCheckerApp : "Getal insturen (BigInteger)"
PrivilegedUser --> PriemCheckerApp : "Eerder opgevraagde getallen, max 1/dag"
Admin --> PriemCheckerApp : "Statistieken opvragen"

boundary PriemCheckerApp {
RECTANGLE FrontEnd as FE
RECTANGLE BackEnd as BE
RECTANGLE SQLServer as DB
RECTANGLE ExternalSuperComputer as PrimeSuperComputer
}

FE --> BE : "API requests (JSON)"
BE --> DB : "Opslaan en ophalen priemgetallen"
BE --> PrimeSuperComputer : "Uitbesteden zware berekeningen"
```

*Figuur 1*: Het systeem en zijn gebruikers en externe systemen