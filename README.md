# RoniTest

### Environment
.NET Core Version: .NET Core 3.1
IDE: Microsoft Visual Studio Community 2019 Version 16.6.5

### How To Run This Test App
1. Create SQL database named by "RoniTestDb" and import sql dumb file "DemoDBScriptQuery.sql" in the root folder.
2. Open RoniTest.sln in VS2019 and build
3. Navigate to https://localhost:44357/Jobs in browser to see jobs table.
   Jobs rows are colored by status.
   You can 'Mark As Complete' to mark jobs (of which status is 'In Progress' or 'Delayed') as 'Complete'.
4. Navigate to https://localhost:44357/api/RoomTypeSummary to get summary of the jobs status per room type.

* Error handling and Logging is done here https://prnt.sc/tptz3j
* Didn't include tests as I didn't see fit
