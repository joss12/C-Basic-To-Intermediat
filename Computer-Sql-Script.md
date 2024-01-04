    CREATE DATABASE DotNetCourseDatabase
    GO
     
    USE DotNetCourseDatabase
    GO
     
    CREATE SCHEMA TutorialAppSchema
    GO
     
    CREATE TABLE TutorialAppSchema.Computer(
        ComputerId INT IDENTITY(1,1) PRIMARY KEY,
        Motherboard NVARCHAR(50),
        CPUCores INT,
        HasWifi BIT,
        HasLTE BIT,
        ReleaseDate DATE,
        Price DECIMAL(18,4),
        VideoCard NVARCHAR(50)
    );






UserName: sa
Password: SQLConnect1

For connection strings you will also need to set Trusted_Connection to false and supply a UserName and Password:
    Server=localhost;Database=DotNetCourseDatabase;Trusted_Connection=false;TrustServerCertificate=True;User Id=sa;Password=SQLConnect1;


