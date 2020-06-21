# technicalTest1

Concreet, zou ik graag een uitwerking van jou zien in ASP.NET Core, waar je volgende technieken/technologieën gebruikt:

- Dependency Injection 
- Domain Driven Design
- Azure Cosmos DB
- ASP.NET Core 

De opdracht is als volgt; maak een API service (dus geen front-end, api alleen is voldoende), die het mogelijk stelt om:
- Klanten aan te maken
- Een contactgegeven (email/telefoon) toe te wijzen aan een klant
- Een factuur met factuurlijnen te maken
- Een status te updaten van een factuur

Ik zie dit dus als een 4-tal aparte APIs. Het datamodel lever ik je aan, verder reken ik erop dat je zelf de juiste informatie gebruikt;

Klant:
- Voornaam
- Achternaam
- Adresgegevens
- 0 of meerdere contactgegevens
  - Type (Email/GSM)
  - Waarde

Factuur:
- Datum 
- Omschrijving
- Klant
- Totaalbedrag
- 1 of meerdere factuurlijnen
- Aantal
- Prijs per eenheid
- Totaalprijs
 
 Let op, dat je dus met Cosmos DB werkt (Je kan hiervoor een emulator installeren lokaal), en dus geen SQL database gebruikt. Hierdoor ga je met een document-db werken ipv een relationele db. 
