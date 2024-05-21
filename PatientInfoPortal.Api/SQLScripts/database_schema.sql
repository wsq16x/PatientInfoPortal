CREATE TABLE Disease_Information(
	ID INT NOT NULL,
	Name NVARCHAR(250) NOT NULL,

	CONSTRAINT PK_Disease_Information PRIMARY KEY (ID)
)

CREATE TABLE NCD(
	ID INT NOT NULL,
	Name NVARCHAR(100) NOT NULL,

	CONSTRAINT PK_NCD PRIMARY KEY (ID)
)

CREATE TABLE Allergies(
	ID INT NOT NULL,
	Name NVARCHAR(100) NOT NULL,

	CONSTRAINT PK_Allergies PRIMARY KEY (ID)
)

CREATE TABLE Patients_Information(
	ID INT IDENTITY (1, 1) NOT NULL,
	Name NVARCHAR(100) NOT NULL,
	Epilepsy BIT NOT NULL,
	DiseaseID INT NOT NULL,

	CONSTRAINT PK_Patients_Information PRIMARY KEY (ID),
	CONSTRAINT FK_Patients_Disease_Information FOREIGN KEY (DiseaseID) REFERENCES Disease_Information (ID)
)

CREATE TABLE NCD_Details(
	ID INT IDENTITY (1,1) NOT NULL,
	PatientID INT NOT NULL,
	NCDID INT NOT NULL,

	CONSTRAINT PK_NCD_Details PRIMARY KEY (ID),

	CONSTRAINT FK_NCD_Details_Patients_Information FOREIGN KEY (PatientID) REFERENCES Patients_Information (ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE,

	CONSTRAINT FK_NCD_Details_NCD FOREIGN KEY (NCDID) REFERENCES NCD (ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)

CREATE TABLE Allergies_Details(
	ID INT IDENTITY (1,1) NOT NULL,
	PatientID INT NOT NULL,
	AllergiesID INT NOT NULL,

	CONSTRAINT PK_Allergies_Details PRIMARY KEY (ID),

	CONSTRAINT FK_Allergies_Details_Patients_Information FOREIGN KEY (PatientID) REFERENCES Patients_Information (ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE,

	CONSTRAINT FK_Allergies_Details_Allergies FOREIGN KEY (AllergiesID) REFERENCES Allergies (ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)

INSERT INTO Disease_Information (ID, Name)
VALUES 
    (1, 'Influenza'),
    (2, 'Common Cold'),
    (3, 'Chickenpox'),
    (4, 'Measles'),
    (5, 'Mumps'),
    (6, 'Tuberculosis'),
    (7, 'Malaria'),
    (8, 'Hepatitis B'),
    (9, 'Hepatitis C'),
    (10, 'Dengue Fever'),
    (11, 'HIV/AIDS'),
    (12, 'Ebola'),
    (13, 'Cholera'),
    (14, 'Zika Virus'),
    (15, 'COVID-19'),
    (16, 'Hypertension'),
    (17, 'Diabetes Mellitus'),
    (18, 'Asthma'),
    (19, 'Chronic Obstructive Pulmonary Disease (COPD)'),
    (20, 'Osteoarthritis'),
    (21, 'Rheumatoid Arthritis'),
    (22, 'Stroke'),
    (23, 'Coronary Artery Disease'),
    (24, 'Heart Failure'),
    (25, 'Migraine');

INSERT INTO NCD (ID, Name) VALUES 
	(1, 'Asthma'),
	(2, 'Cancer'),
	(3, 'Disorders of ear'),
	(4, 'Disorder of eye'),
	(5, 'Mental illness'),
	(6, 'Oral health problems');

INSERT INTO Allergies (ID, Name) VALUES 
	(1, 'Drugs-Penicillin'),
	(2, 'Drugs-Others'),
	(3, 'Animals'),
	(4, 'Food'),
	(5, 'Oinments'),
	(6, 'Plant'),
	(8, 'Others'),
	(9, 'No Allergies')