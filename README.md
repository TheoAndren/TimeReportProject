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
https://localhost:44375/api/project/1/employee

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


