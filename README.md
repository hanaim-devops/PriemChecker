# Priemgetal Checker

Dit project moet er komen in zowel een Java Spring boot variant als een C# variant. De Java variant zit al in de blog post op minordevops.nl ([van der Wal, 2024](https://minordevops.nl/blogs/spring-boot-priemtester/index.html)), dus dit project werkt de C# variant uit.

We hanteren Domain Driven Design (DDD) voor deze simpele opgave als oefening. We houden het nog wel bij een monoliet in plaats van Microservices (Architecture; MSA). Maar als oefening, en met idee dit later te kunnen 'stranglen' naar microservicves, maken we wel een *modulaire* monoliet. En we hangen een beetje richting 'over engineering' met gebruiken principes van Layered architecture, TDD en Dependency Injection (DI).

Om *branch by abstraction** te laten zien zijn er 3 gebruikes van de priem 'service':

1. Een main (C# of .NET console project)
2. Een set unit tests (apart Test project die xUnit gebruikt (analoog JUnit in Java))
3. Een RESTful endpoint in de vorm van API Controllers, voor een minimal API*

*Deze 'minimal API' is een vrij recent variant al bedoeld voor/gericht op microservices. Meer heb ik hier nu ook niet over gelezen, maar ChatGPT (ChatGPT 2024) gaf me wel wat verwijzingen die ik onderaan toevoeg in een 'Bibliografie', naast een Literatuurlijst. De werken in de biobliografie kun je zelf verder lezen, en dat zal ik ook doen als ik klaar met deze opdracht ;). In de 'Literatuurlijst' plaats ik netjes overal verwijzingen (bij quotes of parafrases) naar hier in de tekst, zoals het hoort bij APA. Dit even ter illustratie van het verschil tussen deze twee (vooruitlopend op week 6 onderzoeksweek in de minor).

Later breiden we dit uit met een database voor persistentie met een 'code first' ORM met migrations (Entity Framework Core in C# of voor Java/Spring boot variant JPA/Hibernate met Flyway voor ook migrations)

In afwezigheid van een echte opdrachtgever zie ik Wikipedia als Business expert.
Dit is minder willekeurig dan zelf de termen verzinnen.

De Engels-Amerikaans talige Wikipedia noemt testen voor priemgetallen testen het 'primality checking'.

Aangezien de opdracht in het Nederlands is gebruik ik ook Nederlands, maar gebruik ik wel de uit het Engels afkomstige term 'checken'. Prettige bijkomstigheid is dat nu de `xUnit` naamgeving postfix `-test` in bestandsnamen anders is, en dat het geen PriemgetalTesterTest wordt, maar `PriemgetalCheckerTest` - https://nl.wikipedia.org/wiki/Priemgetal

> "The property of being prime is called primality. A simple but slow method of checking the primality of a given number n, called trial division, ..." - https://en.wikipedia.org/wiki/Prime_number


## EF core, code first ORM with migrations

Bron: 
https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli

## How to run?

De WEB api met Swagger test pagina's kun je makkelijkst runnen uit IDE. Ik gebruikte Rider 2024.2.4.

Maar het kan ook met
```console
cd WebPriemgetal 
dotnet run
```

En dan ga je naar aangegeven URL. Je moet wel `/swagger` achtervoegen.

Standaard `http://localhost:5062`

Of gebruik
```console
curl -X 'POST' \
  'http://localhost:5062/isPriem?getal=12' \
  -H 'accept: application/json' \
  -H 'Content-Type: application/json' \
  -d '{}'
```

De command line kan je runnen met `dotnet` cli, mits je die hebt geinstalleerd natuurlijk (en [`brew`](https://brew.sh/) geïnstalleerd hebt).

### Install op macOS:

```console
brew install dotnet@8
brew install --cask dotnet-sdk
```

En dan run je de applicatie met bijvoorbeeld input `12` om te prime checken met `dotnet run 12`:

Als je in de folder zit (`PrimeChecker`):

```console
cd ConsolePriemChecker
dotnet run 12
>Is getal 12 een priemgetal? JA
```

## Bronnen

- Wal, B.W. (augustus 2024) *Unit testen in Java met Maven Surefire en JUnit.* Geraadpleegd september 2024 op <https://minordevops.nl/blogs/spring-boot-priemtester/index.html>
- Pickett, W. et al. (28 juli 2024)  *Tutorial: Create a minimal API with ASP.NET Core.* Geraadpleegd september 2024 op <https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-8.0&tabs=visual-studio>

## Bibliografie

-  Lander, R. (2021, November 8). *Announcing .NET 6 - The Fastest .NET Yet.* Microsoft DevBlogs. Zie <https://devblogs.microsoft.com/dotnet/announcing-net-6/>
- Warren, G., Pine, D. aka "IEvangelist" (2024, August 2). *What's new in .NET 8 - Minimal APIs and More.* Microsoft DevBlogs. Zie <https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8/overview>
