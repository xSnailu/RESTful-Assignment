# WebNotepad-Assignment
## General info
RESTful API webservice that is responsible for managing and storing in database simple notes, with the thin/web scalable UI part responsible for displaying list of notes with ability to read each note within the app i.e., as popup

## Database
### Requirements
- Ms SQL server management studio 18
### How to run?
- Open Ms Sql Management aplication and connect to server (server type: Database engine, Server name: (localdb)\MSSQLLocalDB, Windows authentication)
- Run Database/databaseInit.sql

## Backend
### Used components:

- .NET Core 5
- Linq
- EntityFramework Core
- AutoMapper 
### Requirements
- Visual Studio 2019 with .NET Core 5 Installed
- MsSql Server
### How to run?
- Just open WebNotepad.sln and build project

## Frontend
### Used components:
- React
### Requirements
- nodejs with yarn installed and added to command line
### How to run?
- open webnotepad - frontend -> yarn install -> yarn start

# Swagger operations examples

## ArchivedNote GET = /archivednote/noteHistoryById
- pass ID of the note -> you'll get history of changes

## NOTE POST = /note
- requested body ex. :
{
  "title": "ExTitle",
  "content": "ExContent",
}

## NOTE DELETE = /note
- pass ID of the note 

## NOTE PATCH = /note
- requested body ex. :
{
  "id": 3,
  "title": "UpdatedTitle",
  "content": "UpdatedContent",
}

## NOTE GET = /note/all
-> list of all notes