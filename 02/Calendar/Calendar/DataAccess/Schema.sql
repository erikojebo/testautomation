USE [CalendarTest]

CREATE TABLE [Persons](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[FirstName] [nvarchar](128) NOT NULL,
	[LastName] [nvarchar](128) NOT NULL)

CREATE TABLE [CalendarEntries](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[PersonId] [int] NOT NULL)

ALTER TABLE [CalendarEntries]  ADD  CONSTRAINT [FK_CalendarEntries_Persons] FOREIGN KEY([PersonId])
REFERENCES [Persons] ([Id])
