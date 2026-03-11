📚 LibrarySystem - Inlämning
Detta är mitt bibliotekssystem byggt med C#, Blazor och Entity Framework Core. Jag har fokuserat på att skapa en stabil backend med en snygg och fungerande frontend.

🛠 Tekniker jag har använt
Frontend: Blazor Web App (Interactive Server Mode)

Backend: Entity Framework Core med SQLite

Arkitektur: Repository Pattern (för att hålla koden ren och testbar)

Testning: xUnit med InMemory Database

✨ Funktioner i systemet
Dashboard: En startsida som automatiskt räknar antal böcker och medlemmar i databasen.

Hantering av Böcker: En lista där man kan söka, lägga till och redigera information (som t.ex. utgivningsår) direkt i tabellen.

Medlemsregister: Full koll på alla medlemmar med möjlighet att uppdatera namn och e-post.

Status: Tydliga badges som visar om en bok är 🟢 Tillgänglig eller 🔴 Utlånad.

🧪 Tester 
Jag har skrivit totalt 10 enhetstester för att säkerställa att systemet fungerar som det ska.

4 tester för BookRepository (Add, GetAll, Search, Delete).

4 tester för MemberRepository (Add, GetAll, Search, Delete).

2 tester för mina modeller (Book och Member).

Hur man kör testerna: Öppna Test Explorer i Visual Studio och klicka på "Run All Tests". Alla 10 tester ska lysa grönt.

🚀 Kom igång
Öppna .sln-filen i Visual Studio 2022.

Kontrollera att library.db skapas automatiskt vid start, annars kör update-database i konsolen.

Tryck på F5 

Navigera i menyn för att hantera biblioteket.