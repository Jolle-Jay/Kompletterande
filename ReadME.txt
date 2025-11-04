Varför jag har gjort som jag har? Har tagit det mest simpla vägarna (för mig) för att kunna snickra ihop detta programmet. Försökt följa instruktioner till
punkt och pricka, så som jag har tytt dem.
Det vet inte lätt att få ihopa det med enums och txt fil, tillslut så gick det, började med att göra en boiler plate, vet att det hade varit
 bättre att skriva kod först, dock så blir jag lite bättre varje dag att kunna se vad jag ska skriva utan att ha någon struktur framför mig.

Använder mig av en User class och en txt för att kunna logga in.
En rooms class för att kunna ha enums och en txt fil där alla Rooms sparas.

I början hårdkodade jag 10 rum där 4 är upptagna. Fick hålla på och göra List<string> i slutet på 4-6 för att kunna spara det i txt filen igen.
Lista med rummen i början därav hårdkodningen, ändrade detta i slutet för att det inte gick att göra och sedan få det sparat i ändringarna med enums.
 Gjorde tillslut en string array för att kunna läsa av listan (txt) och sedan parse med enums om string status till Enum status, sedam gå
  in i Rooms göra en konstruktor för att kunna läsa ifrån.

Lösen är 123,123 i loginNames.txt.
 Har försökt hålla det så precist och tight som möjligt, utan massa extra kodning, tycker det är riktigt cleant för att vara på min nivå.
 Det mesta fungerar, försöker få fram så att på piunkt 6 ska jag kunna ta bort Maintenance från rummen, men har inte kommit på hur jag ska göra 
 för att det ska kunna visa äännu.
 Vet att det ligger i att i "2" så ber jag om en sträng att den ska visa alla "Occupied" vill få visa dem som är i maintenance med. Det löste jag precis
 med att göra samma kod bara att ändra Occupied strängen till Maintenance.

 
 Det var mer mot slutet som jag började få enums att fungera eller förstå det bättre sagt. Det tog lång tid att få ihop kod och logik som fungerade, dock när det
 fungerade och gick ihopa så skillde det sig inte mycket för att det skulle vara samma i nästa steg. Börjar förstå mer för varje dag att det är Arrays
 och loopar nästan alltihopa, förstår hur jag vill att systemet ska arbeta och kan skriva upp i pseudo kod hur jag tänker, nötar bara in det här med
 syntax och hur det ska kunna falla på plats mer istället för att det ska ta timmar för att skriva några rader.
 Väldigt stolt och glad över arbetet, jag kommer att ägna mig minst en timme åt dagen att skriva kod för att syntaxen ska kunna sätta sig.

Programmet i hehet;
Det finns hårdkodat Lista med Rooms och User som följs av en bit kod som läser in från Rooms och sparar i listan Rooms. Sedan en rad som läser in från LoginNames.txt.
Körde loginen som jag har sett i alla fall hittils.

"2"
Läser in Rooms.txt till variabel, loopar igenom och om det står occupied i txt fil så skriv ut följande.

"3"
Samma logik här.

"4"
Samma logik i början som i 2, 3 sedan så ber jag om input från användaren och TryParse, som jag matchar ihop med ett rums nummer. Gör en Room variabel lägger osm null för att kunna ha något
i den senare. Om då selectedRoom matchar ett nummer lägg in ett Room i min gjorda Room variabel.
Nu när det inte är null och om det är tillgängligt gör det till otilgängligt och skriv in namn på gästen.

"5"
Samma logik helt som 4 bara att i slutet så har jag gjort det tvärtom och lagt en tom sträng som namn, i slutet på bvåde 4 , 5 och 6 så har jag gjort en  lista med strängar, loopar igenom
och updaterar listan.

"6"
Nästan i princip samma logik med. Har faktiskt skrivit om allting utan att titta på föregående text för att nöta in det.


 