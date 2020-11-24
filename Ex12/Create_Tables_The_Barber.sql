USE The_Barber
go

CREATE SCHEMA barber;
go

CREATE TABLE barber.Studio(
	Studio_ID int IDENTITY(1,1) PRIMARY KEY,
	StudioName nvarchar(50) NULL,
	StudioAddress nvarchar(50) NULL,
	PhoneNumber nvarchar(50) NULL,
	NumberOfEmployees int NULL,	
);

CREATE TABLE barber.Employee(
	Employee_ID uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
	FullName nvarchar(50) NULL,
	Studio_ID int NULL,
	Occupation nvarchar(50) NULL,
	CONSTRAINT FK_EmployeeStudio FOREIGN KEY(Studio_ID) REFERENCES barber.Studio (Studio_ID)
);

CREATE TABLE barber.Visit(
	Visit_ID uniqueidentifier DEFAULT NEWID() PRIMARY KEY,
	Studio_ID int NULL,
	Employee_ID uniqueidentifier NULL,
	[Date] date NULL,
	[Time] time NULL,
	DurationHours int NULL,
	CONSTRAINT FK_VisitEmployee FOREIGN KEY(Employee_ID) REFERENCES barber.Employee (Employee_ID),
    CONSTRAINT FK_VisitStudio FOREIGN KEY(Studio_ID) REFERENCES barber.Studio (Studio_ID)
);

CREATE TABLE barber.Treatment(
	Treatment_ID int IDENTITY(1,1) PRIMARY KEY,
	TreatmentName nvarchar(50) NULL,
	Price decimal(4, 2) NULL,
	DurationHours float NULL,
);

CREATE TABLE barber.VisitDetail(
	VisitDetail_ID int IDENTITY(1,1) PRIMARY KEY,
	Visit_ID uniqueidentifier NULL,
	Treatment_ID int NULL,
	TotalCost decimal(4, 2) NULL,
	CONSTRAINT FK_VisitDetailTreatment FOREIGN KEY(Treatment_ID) REFERENCES barber.Treatment (Treatment_ID),
	CONSTRAINT FK_VisitDetailVisit FOREIGN KEY(Visit_ID) REFERENCES barber.Visit (Visit_ID)
);