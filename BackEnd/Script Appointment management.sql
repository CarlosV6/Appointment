GO
IF NOT OBJECT_ID('tblDoctors') IS NULL
BEGIN
   DROP TABLE tblDoctors
END
GO
CREATE TABLE tblDoctors(
                        IdDoctor    INT IDENTITY(1,1),
                        NameDoctor  VARCHAR(400),
                        PhoneDoctor VARCHAR(100),
                        IdSpecialty INT
                       )
GO
IF NOT OBJECT_ID('tblPatients') IS NULL
BEGIN
   DROP TABLE tblPatients
END
GO
CREATE TABLE tblPatients(
                         IdPatient      INT IDENTITY(1,1),
                         NamePatient    VARCHAR(400),
                         PhonePatient   VARCHAR(100),
                         AddressPatient VARCHAR(400),
                         Observations   VARCHAR(MAX)
                        )
GO
IF NOT OBJECT_ID('tblSchedule') IS NULL
BEGIN
   DROP TABLE tblSchedule
END
GO
CREATE TABLE tblSchedule(
                         IdSchedule   INT IDENTITY(1,1),
                         Schedule     VARCHAR(50)
                        )
GO
IF NOT OBJECT_ID('tblDaysWeek') IS NULL
BEGIN
   DROP TABLE tblDaysWeek
END
GO
CREATE TABLE tblDaysWeek(
                         IdDaysWeek INT IDENTITY(1,1),
                         DaysWeek   VARCHAR(50)
                        )
GO
IF NOT OBJECT_ID('tblDoctorSchedule') IS NULL
BEGIN
   DROP TABLE tblDoctorSchedule
END
GO
CREATE TABLE tblDoctorSchedule(
                               IdDocSch   INT IDENTITY(1,1),
                               IdDoctor   INT,
                               IdSchedule INT,
                               IdDaysWeek INT,
                               IdOffce    INT
                              )
GO
IF NOT OBJECT_ID('tblOffces') IS NULL
BEGIN
   DROP TABLE tblOffces
END
GO
CREATE TABLE tblOffces(
                       IdOffce      INT IDENTITY(1,1),
                       Offce        VARCHAR(400),
                       OffceAddress VARCHAR(400)
                      )
GO
IF NOT OBJECT_ID('tblAppointment') IS NULL
BEGIN
   DROP TABLE tblAppointment
END
GO
CREATE TABLE tblAppointment(
                            IdAppointment   INT IDENTITY(1,1),
                            IdPatient       INT,
                            IdDocSch        INT,
                            Observations   VARCHAR(MAX),
                            DateAppointment DATETIME,
                            SitAppointment  BIT
                           )
GO
IF NOT OBJECT_ID('tblSystemUsers') IS NULL
BEGIN
   DROP TABLE tblSystemUsers
END
GO
CREATE TABLE tblSystemUsers(
                            IdSystemUsers   INT IDENTITY(1,1),
                            IdSUserProfile  INT,
                            SystemUsers     VARCHAR(50),
                            SystemUsersPass VARCHAR(50),
                            SitSystemUsers  BIT
                           )
GO
IF NOT OBJECT_ID('tblUserProfile') IS NULL
BEGIN
   DROP TABLE tblUserProfile
END
GO
CREATE TABLE tblUserProfile(
                            IdSUserProfile  INT IDENTITY(1,1),
                            UserProfile     VARCHAR(50)
                           )
GO
IF NOT OBJECT_ID('tblSpecialties') IS NULL
BEGIN
   DROP TABLE tblSpecialties
END
GO
CREATE TABLE tblSpecialties(
                         IdSpecialty INT IDENTITY(1,1),
                         Specialty   VARCHAR(500)
                        )
GO
INSERT INTO tblSpecialties VALUES('Anestesiología')
INSERT INTO tblSpecialties VALUES('Cardiología')
INSERT INTO tblSpecialties VALUES('Cirugía')
INSERT INTO tblSpecialties VALUES('Dermatología')
INSERT INTO tblSpecialties VALUES('Gastroenterología')
INSERT INTO tblSpecialties VALUES('Ginegología')
INSERT INTO tblSpecialties VALUES('Hematología')
INSERT INTO tblSpecialties VALUES('Infectología')
INSERT INTO tblSpecialties VALUES('Nefrología')
INSERT INTO tblSpecialties VALUES('Neurología')
INSERT INTO tblSpecialties VALUES('Oftalmología')
INSERT INTO tblSpecialties VALUES('Ortopedia')
INSERT INTO tblSpecialties VALUES('Otorrinolaringología')
INSERT INTO tblSpecialties VALUES('Pediatría')
INSERT INTO tblSpecialties VALUES('Psiquiatría')
INSERT INTO tblSpecialties VALUES('Urología')
GO
INSERT INTO tblSchedule VALUES('08:00 a.m. - 08:30 a.m.')
INSERT INTO tblSchedule VALUES('08:30 a.m. - 09:00 a.m.')
INSERT INTO tblSchedule VALUES('09:00 a.m. - 09:30 a.m.')
INSERT INTO tblSchedule VALUES('09:30 a.m. - 10:00 a.m.')
INSERT INTO tblSchedule VALUES('10:00 a.m. - 10:30 a.m.')
INSERT INTO tblSchedule VALUES('10:30 a.m. - 11:00 a.m.')
INSERT INTO tblSchedule VALUES('11:00 a.m. - 11:30 a.m.')
INSERT INTO tblSchedule VALUES('11:30 a.m. - 12:00 p.m.')
INSERT INTO tblSchedule VALUES('12:00 p.m. - 12:30 p.m.')
INSERT INTO tblSchedule VALUES('12:30 p.m. - 01:00 p.m.')
INSERT INTO tblSchedule VALUES('01:00 p.m. - 01:30 p.m.')
INSERT INTO tblSchedule VALUES('01:30 p.m. - 02:00 p.m.')
INSERT INTO tblSchedule VALUES('02:00 p.m. - 02:30 p.m.')
INSERT INTO tblSchedule VALUES('02:30 p.m. - 03:00 p.m.')
INSERT INTO tblSchedule VALUES('03:00 p.m. - 03:30 p.m.')
INSERT INTO tblSchedule VALUES('03:30 p.m. - 04:00 p.m.')
INSERT INTO tblSchedule VALUES('04:00 p.m. - 04:30 p.m.')
INSERT INTO tblSchedule VALUES('04:30 p.m. - 05:00 p.m.')
INSERT INTO tblSchedule VALUES('05:00 p.m. - 05:30 p.m.')
INSERT INTO tblSchedule VALUES('05:30 p.m. - 06:00 p.m.')
INSERT INTO tblSchedule VALUES('06:00 p.m. - 06:30 p.m.')
INSERT INTO tblSchedule VALUES('06:30 p.m. - 07:00 p.m.')
INSERT INTO tblSchedule VALUES('07:00 p.m. - 07:30 p.m.')
INSERT INTO tblSchedule VALUES('07:30 p.m. - 08:00 p.m.')
GO
INSERT INTO tblDaysWeek VALUES('Domingo')
INSERT INTO tblDaysWeek VALUES('Lunes')
INSERT INTO tblDaysWeek VALUES('Martes')
INSERT INTO tblDaysWeek VALUES('Miercoles')
INSERT INTO tblDaysWeek VALUES('Jueves')
INSERT INTO tblDaysWeek VALUES('Viernes')
INSERT INTO tblDaysWeek VALUES('Sabado')
GO
INSERT INTO tblOffces VALUES ('Zona Norte - Cuernavaca','Colonia los Saluces, Calle Los Manantiales #1, Cuernavaca, Morelos ')
INSERT INTO tblOffces VALUES ('Zona Centro - Emiliano Zapata','Colonia Miraval, Calle Pueblo Viejo #15, Emiliano Zapata, Morelos')
INSERT INTO tblOffces VALUES ('Zona Sur - Zacatepec',' Colonia Zacatepec Centro, Avenida Tecnologico de Zacatepec #60, Zacatepec, Morelos')
INSERT INTO tblOffces VALUES ('Zona Oriente - Cuautla',' Colonia San Marcos, Avenida Tezontle #30, Cuautla, Morelos')
INSERT INTO tblOffces VALUES ('Zona Poniente - Temixco',' Colonia La Rivera, Avenida del Trabajo #46, Temixco, Morelos')
GO
INSERT INTO tblUserProfile VALUES('Administrator')
INSERT INTO tblUserProfile VALUES('Doctor')
INSERT INTO tblUserProfile VALUES('Patient')
GO
INSERT INTO tblSystemUsers VALUES(1,'TestAmin','Admin123*',1)
INSERT INTO tblSystemUsers VALUES(2,'TestDoctor','Admin123*',1)
INSERT INTO tblSystemUsers VALUES(3,'TestPatient','Admin123*',1)
GO