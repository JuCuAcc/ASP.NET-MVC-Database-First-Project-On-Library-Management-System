
-- Creating BookCategories table
CREATE TABLE BookCategories
(
  CategoryID	int NOT NULL PRIMARY KEY,
  Category		varchar(30) NOT NULL
); 
GO
-- Creating Books table
CREATE TABLE Books
(
  BookID		int PRIMARY KEY IDENTITY(100,1) ,
  Title			varchar(100) NOT NULL,
  Author		varchar(120) NOT NULL,
  Description	varchar(140) SPARSE NULL,
  CategoryID	int	FOREIGN KEY REFERENCES BookCategories(CategoryID) ON DELETE CASCADE,
  AddedTime		datetime NOT NULL DEFAULT GETDATE()
); 
GO


--Creating Members table
CREATE TABLE Members
(
	MemberID		int NOT NULL PRIMARY KEY IDENTITY(500,1),
	MemberName		varchar(30) NOT NULL,
	MemberStatus	varchar(15) -- Student Or Teacher
);
GO

-- Creating Groups table

CREATE TABLE StudentGroup
(
  GroupID		int	PRIMARY KEY,
  GroupName		varchar(15)  NOT NULL
);
GO
-- Creating Students table

CREATE TABLE Students
(
  StudentID		int PRIMARY KEY IDENTITY,
  GroupID		int FOREIGN KEY REFERENCES StudentGroup(GroupID) ON DELETE SET NULL,
  MemberID		int FOREIGN KEY REFERENCES Members(MemberID) ON DELETE CASCADE,
  StudentName	varchar(30) NOT NULL,
  Gender		nvarchar(1) NOT NULL,--'M' for male and 'F' for female
  Email			varchar(50) NOT NULL CHECK (Email LIKE '%@%')
);
GO





--Inserting data in the tables

INSERT INTO  BookCategories (CategoryID,Category) VALUES(1,'References Book'),(2,'Academic Books'),(3,'Novel'),(4,'Magazine');
GO
INSERT Books
(
	Title,			
	Author,		
	Description,	
	CategoryID,	
	AddedTime		
)
VALUES('Business Statistics', 'Manindra Roy','For Business Graduates.',1,'2012/01/01'),
		('Business Mathmatics', 'S.P Gupta','For Business Graduates.',1,'2013/07/01'),
			('Business Finance', 'Hasan Rahman','For Business Graduates.',1,'2013/09/01'),
			('Financial Management', 'Abdur Rahman','For Business Graduates.',2,'2019/03/01'),
			('Business Law', 'Manindra Roy','For Business Graduates.',1,'2018/05/01'),
			('Research Journal', 'Morshedur Rahman','For Business Graduates.',4,'2013/06/01'),
			('Advanced Statistics', 'Manindra Roy','For Business Graduates.',1,'2017/10/01'),
			('Intermediate Accounting', 'Jashim Uddin','For Business Graduates.',1,'2014/11/15'),
			('Business Programming', 'Foysal Wahid','For Business Graduates.',1,'1996/12/31'),
			('Entrepreneurship Cases', 'Jahid Hasan','For Business Graduates.',3,'2021/01/31');
GO

INSERT INTO StudentGroup VALUES(1,'BBA'),(2,'MBA');
GO

INSERT Members VALUES('Hasan','Student'),	('Bakul','Student'),	('Badol','Student'),	('Farjana','Teacher'),
					 ('Kalam','Student'),	('Hasnahena','Student'), ('Bidhan','Student'),	('Setu','Teacher'),
					 ('Babul','Student'),	('Akash','Student'),	('Bikash','Student'),	('Polash','Teacher'),
					 ('Rafique','Student'), ('Badsha','Student'),	 ('Jashim','Student'),	('Foyjul','Teacher'),
					 ('Bulbul','Student'),	('Tutul','Student'),	('Joynal','Student'),	('Tarek','Teacher'),
					 ('Nishan','Student'),	('Sujan','Student'),	('Khan','Student'),		('Belal','Teacher'),
					 ('Rahim','Student'),	('Foysal','Student'),	('Sadiya','Student'),	('Kashem','Teacher');
GO
INSERT Students
(
	 GroupID,		
	 MemberID,		
	 StudentName,	
	 Gender,		
	 Email	
)
VALUES
(1,500,'Hasan','M','hasan@yahoo.com'),(1,501,'Bakul','M','bakul@yahoo.com'),(1,502,'Badol','M','badol@yahoo.com'),(1,503,'Farjana','F','farjana@yahoo.com'),
(1,504 ,'Kalam','M','kalam@yahoo.com'),(1,505 ,'Hasnahena','F','hasnahena@yahoo.com'),(1,506 ,'Bidhan','M','bidhan@hotmail.com'),(1,508 ,'Babul','M','babul@hotmail.com'),
(1,509 ,'Akash','M','akash@gmail.com'),(1,510 ,'Bikash','M','bikash@mail.ru.com'),(1,512 ,'Rafique','M','rafique@hotmail.com'),(1,513 ,'Badsha','M','badsha@outlook.com'),
(1,514 ,'Jashim','M','jashim@gmail.com'),(1,516 ,'Bulbul','M','bulbul@outlook.com'),(1,517 ,'Tutul','M','tutul@yahoo.com'),(1,518 ,'Joynal','M','joynal@yahoo.com'),
(1,520 ,'Nishan','M','nishan@mail.ru.com'),(1,521 ,'Sujan','M','sujan@yahoo.com'),(1,522 ,'Khan','M','khan@outlook.com'),(1,524 ,'Rahim','M','Rahim@gmail.com'),
(1,525 ,'Foysal','M','foysal@idb-bisew.net'),(1,526 ,'Sadiya','F','sadiya@outlook.com'),

(2,500,'Hasan','M','hasan2@yahoo.com'),
(2,504 ,'Kalam','M','kalam2@yahoo.com'),
(2,509 ,'Akash','M','akash2@gmail.com'),
(2,514 ,'Jashim','M','jashim2@gmail.com'),
(2,520 ,'Nishan','M','nishan2@mail.ru.com'),
(2,525 ,'Foysal','M','foysal2@idb-bisew.net');
GO
