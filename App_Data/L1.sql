
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



