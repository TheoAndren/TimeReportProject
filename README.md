# TimeReportProject
![Violet Blue Modern Coding Bootcamp Facebook Banner](https://user-images.githubusercontent.com/91311313/163331929-251f2e10-9442-4847-b077-101bc259311c.jpg)


Get info about specific employee and their time reports

https://localhost:44375/api/employee/time/3

----------------------------------------------------------------------------------

Get hours worked of an employee a specific week

2 = employee with id 2
https://localhost:44375/api/timereport/2/year=2022/week=14

----------------------------------------------------------------------------------

Get all employees working with a specific project
https://localhost:44375/api/project/1/employees

----------------------------------------------------------------------------------

Add Employee [POST]
https://localhost:44375/api/employee
{ "firstName": "kalle", "lastName": "karlsson", "phoneNumber": "05251251",
 "email": "kalle.gmail.com"}

----------------------------------------------------------------------------------

UPDATE Employee  [PUT]
https://localhost:44375/api/employee/3
{ "employeeId": 1, "firstName": "Jesper", "lastName": "Bratt", "phoneNumber": "051251512",
"email": "jesper.bratt@gmail.com"}

----------------------------------------------------------------------------------
DELETE Employee  [DELETE]
https://localhost:44375/api/employee/3

----------------------------------------------------------------------------------

Add Project [POST]
https://localhost:44375/api/project
{ "projectName": "Södra rosgården nybygge"}

----------------------------------------------------------------------------------

UPDATE Project [PUT]
https://localhost:44375/api/project/3
{ "projectId": 8, "projectName": "Södra rosgården nybygge" }

----------------------------------------------------------------------------------

Delete Project [DELETE]
https://localhost:44375/api/project/3

----------------------------------------------------------------------------------

ADD Timereport [POST]
https://localhost:44375/api/timereport
{ "timeReportId": 5, "employeeId": 1, "projectId": 1, "date": "2022-04-10", "workedHours": 4}

----------------------------------------------------------------------------------

UPDATE Timereport [PUT]
https://localhost:44375/api/timereport/10
{ "timeReportId": 5, "employeeId": 1, "projectId": 1, "date": "2022-04-10", "workedHours": 6}

----------------------------------------------------------------------------------

DELETE Timereport [DELETE]
https://localhost:44375/api/timereport/5

----------------------------------------------------------------------------------

VG UPPGIFT -----------------------------------------------------------------------

TimeReportProject

Models 

 När jag funderade på hur många och vad för sorts modell klasser jag skulle använda för att bygga databasen så bestämde jag mig för att endast använda 3. Jag tyckte att skapa extra tabeller som en kopplingstabell inte var nödvändigt för uppgiften och skulle bara försvåra uppgiften för mig. Därför valde jag att endast använda tre tabeller Employee, Project och TimeReport. TimeReport tablet använde jag som ett join table för mina many to many relationer. Så den tabellen är kopplad till både Employee och project. Detta för att jag då kan koppla en timereport med en employee och ett projekt, de verkade som både den bästa och simplaste lösningen. Och jag ville också tänka på att inte göra det onödigt svårt. Jag ville se till att göra programmet lättförståeligt och enkelt att bygga vidare på utan att någon skulle behöva spendera en vecka eller två för att sätta sig in i det. Utan jag gjorde det som behövdes för kravställningar men inte mycket mer då jag ansåg att det bara skulle vara onödigt i det här fallet. I Timereport gjorde jag också en snygg lösning där jag skapade en property som heter Week som hämtar veckonr på veckan. Det förenklade för mig senare när jag jobbade med metoderna i APIet som jag kommer till snart. 


Interface

 Jag valde att bara använda en interface för alla min klasser i klassbiblioteket. Detta för att göra en för varje klass tyckte jag både var fulare kodvis och bara skulle svårat till det och gjort det mer komplicerat än vad det behöver vara. Eftersom det bara finns 3 klass specifika metoder och resten av metoderna delar alla klasser med varandra. Så var det enklare att bara inte implementera de kursspecifika metoderna i klassen som dom inte var behövliga. Detta istället för att göra 4 olika interfaces. Det tycker jag gjorde så att det blev mindre att förstå och mycket mer enkelt för någon som försöker sätta sig in i koden att förstå. Dock hade det varit ett större projekt med mer metoder så hade jag nog absolut gjort klass specifika interfaces då det annars hade kunnat bli väldigt rörigt. Men nu tycker jag det blev ett bra resultat och väldigt clean. 







Tekniska metoder


EmployeeWorkedTime 

Denna metoden är den klass specifika för EmployeeRepo klassen. Den tar en int och skickar tillbaka info från employees som matchar idet och skickar tillbaka alla länkade time reports som employee med det matchande idet har. Där använder jag include metoden för att få dem matchande time reports istället för att göra en query med joins. 

EmployeeReportWeekly 

Denna metoden är den klass specifika metoden för TimeReportRepo klassen. Den tar tre olika ints som är id, year och week. Först kollar den om det finns en match på idet, Om den hittar match så kommer det att anropa metoden GetFirstDayOfWeek, det kommer att returnera den första dagen i veckan (måndag) för valt år och vecka. Den sparade variabeln kommer att användas för att få TimeReports för den valda veckan där employee id är samma som indata-id. Metoden EmployeeReportWeekly kommer då att returnera ett heltal av totalt antal timmar den anställde har arbetat den veckan. Jag valde att använda Query för att få alla TimeReports för den valda veckan och Employee id. Du kan använda metoden Include här om information om medarbetaren eller tidrapporter ska returneras, men jag tyckte de var enklare såhär att få rätt info eftersom jag bara vill returnera ett heltal har jag valt att köra med Queryn.

EmployeesProject 

Denna metoden är den klassspecifika metoden för ProjectRepo. Den tar ett id och kollar om det finns ett projekt med matchande id. Om det finns en match så skickar den tillbaka info om projektet med idn. Då använder den include ännu en gång och skickar tillbaka alla employees som har timereports registrerade med samma projekt som efterfrågas. Jag använder också ThenInclude istället för att göra en längre query med flera joins för att få info från de olika tabellerna. Denna metoden skulle jag vilja göra om och göra lite bättre och inte skicka med lista på alla timereports. Men jag hittade tyvärr ingen lösning på detta på tiden jag hade. 

