/***************************************************************
	NOTES:
		The default database name is "TaskDB". 
		The default login account is "TaskUserLogin".
		The default DB user is "TaskUser"
		The default schema for task-specific tables is "bugs"

	Do a global text replace to set these values to your
		desired database name.

		User login information is under the "dbo" schema
***************************************************************/
USE [master]
GO
/****** Object:  Database [TaskDB]    Script Date: 04/11/2008 15:55:00 ******/
CREATE DATABASE [TaskDB] ON  PRIMARY 
( NAME = N'TaskDB', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\TaskDB.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TaskDB_log', FILENAME = N'c:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\TaskDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
EXEC dbo.sp_dbcmptlevel @dbname=N'TaskDB', @new_cmptlevel=90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TaskDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TaskDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TaskDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TaskDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TaskDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TaskDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TaskDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TaskDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TaskDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TaskDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TaskDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TaskDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TaskDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TaskDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TaskDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TaskDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TaskDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TaskDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TaskDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TaskDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TaskDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TaskDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TaskDB] SET  READ_WRITE 
GO
ALTER DATABASE [TaskDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TaskDB] SET  MULTI_USER 
GO
ALTER DATABASE [TaskDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TaskDB] SET DB_CHAINING OFF 
GO
CREATE LOGIN [TaskUserLogin] WITH PASSWORD=N'TaskUser_Pass', DEFAULT_DATABASE=[TaskDB], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
USE [TaskDB]
GO
CREATE USER [TaskUser] FOR LOGIN [TaskUserLogin] WITH DEFAULT_SCHEMA=[dbo]
GO
CREATE SCHEMA [bugs] AUTHORIZATION [TaskUser]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [bugs].[Tasks](
	[TaskID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[DateCreated] [datetime] NOT NULL CONSTRAINT [DF_Tasks_DateCreated]  DEFAULT (getdate()),
	[DueDate] [datetime] NOT NULL,
	[UserCreator] [int] NOT NULL,
	[UserAssigned] [int] NOT NULL,
	[Priority] [int] NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [bugs].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Users_Assigned] FOREIGN KEY([UserAssigned])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [bugs].[Tasks] CHECK CONSTRAINT [FK_Tasks_Users_Assigned]
GO
ALTER TABLE [bugs].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Users_Creator] FOREIGN KEY([UserCreator])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [bugs].[Tasks] CHECK CONSTRAINT [FK_Tasks_Users_Creator]
GO
CREATE TABLE [bugs].[Tags](
	[TagID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[TagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [bugs].[TagsOnTasks](
	[TaskID] [int] NOT NULL,
	[TagID] [int] NOT NULL,
	[DateTagged] [datetime] NOT NULL CONSTRAINT [DF_TagsOnTasks_DateTagged]  DEFAULT (getdate()),
 CONSTRAINT [PK_TagsOnTasks] PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC,
	[TagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [bugs].[TagsOnTasks]  WITH CHECK ADD  CONSTRAINT [FK_TagsOnTasks_Tags] FOREIGN KEY([TagID])
REFERENCES [bugs].[Tags] ([TagID])
GO
ALTER TABLE [bugs].[TagsOnTasks] CHECK CONSTRAINT [FK_TagsOnTasks_Tags]
GO
ALTER TABLE [bugs].[TagsOnTasks]  WITH CHECK ADD  CONSTRAINT [FK_TagsOnTasks_Tasks] FOREIGN KEY([TaskID])
REFERENCES [bugs].[Tasks] ([TaskID])
GO
ALTER TABLE [bugs].[TagsOnTasks] CHECK CONSTRAINT [FK_TagsOnTasks_Tasks]
GO
CREATE TABLE [bugs].[Comments](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[TaskID] [int] NOT NULL,
	[Text] [varchar](max) NOT NULL,
	[DateCreated] [datetime] NOT NULL CONSTRAINT [DF_Comments_DateCreated]  DEFAULT (getdate()),
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [bugs].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Tasks] FOREIGN KEY([TaskID])
REFERENCES [bugs].[Tasks] ([TaskID])
GO
ALTER TABLE [bugs].[Comments] CHECK CONSTRAINT [FK_Comments_Tasks]
GO
ALTER TABLE [bugs].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [bugs].[Comments] CHECK CONSTRAINT [FK_Comments_Users]
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [bugs].[Comment_Add] 
	@UserID int, 
	@TaskID int,
	@Text text
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO bugs.Comments(UserID, TaskID, [Text])
	VALUES(@UserID, @TaskID, @Text)
END
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [bugs].[Tag_Create] 
	@Name varchar(50), 
	@Description varchar(250)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO bugs.Tags([Name], [Description])
	VALUES(@Name, @Description)
	RETURN @@Identity;
END
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [bugs].[Tag_Delete] 
	@TagID int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM TagsOnTasks WHERE TagID = @TagID
	DELETE FROM Tags WHERE TagID = @TagID
END
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [bugs].[Tag_Edit] 
	@TagID int,
	@Name varchar(50),
	@Description varchar(250)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Tags SET
	[Name] = @Name,
	[Description] = @Description
	WHERE TagID = @TagID
END
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [bugs].[Tag_GetAll] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * 
	FROM Tags
	ORDER BY [Name] ASC
END
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [bugs].[TagOnTask_Add] 
	@TaskID int,
	@TagID int
AS
BEGIN
	SET NOCOUNT ON;

	IF (SELECT COUNT(*) 
		FROM TagsOnTasks 
		WHERE TagID=@TagID 
			AND TaskID=@TaskID) = 0
	BEGIN
		INSERT INTO TagsOnTasks(TagID, TaskID)
		VALUES(@TagID, @TaskID)
	END
END
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [bugs].[TagOnTask_Delete] 
	@TaskID int,
	@TagID int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM TagsOnTasks
	WHERE TagID = @TagID
		 AND TaskID = @TaskID
END
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [bugs].[Task_Create] 
	@Title varchar(50),
	@Description text,
	@UserCreator int,
	@DueDate datetime,
	@UserAssigned int = 1,
	@Priority int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Tasks(
		Title,
		[Description],
		UserCreator,
		DueDate,
		UserAssigned,
		Priority)
	VALUES(
		@Title,
		@Description,
		@UserCreator,
		@DueDate,
		@UserAssigned,
		@Priority)
	RETURN @@IDENTITY
END
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [bugs].[Task_Delete] 
	@TaskID int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM Comments WHERE TaskID = @TaskID
	DELETE FROM TagsOnTasks WHERE TaskID = @TaskID
	DELETE FROM Tasks WHERE TaskID = @TaskID
END
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [bugs].[Task_Edit] 
	@TaskID int,
	@Title varchar(50),
	@Description text,
	@UserAssigned int,
	@DueDate datetime,
	@Priority int
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Tasks SET
		Title = @Title,
		[Description] = @Description,
		UserAssigned = @UserAssigned,
		DueDate = @DueDate,
		Priority = @Priority
	WHERE TaskID = @TaskID
END
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [bugs].[Task_Find] 
	@TagID int,
	@AfterDueDate datetime = null,
	@BeforeDueDate datetime = null
AS
BEGIN
	SET NOCOUNT ON;
	IF @AfterDueDate IS NULL
	BEGIN
		IF @BeforeDueDate IS NULL
		BEGIN
			SELECT * 
			FROM Tasks a
			JOIN TagsOnTasks b
			ON a.TaskID = b.TaskID
			WHERE b.TagID = @TagID
			ORDER BY a.DateCreated DESC
		END
		ELSE
		BEGIN
			SELECT * 
			FROM Tasks a
			JOIN TagsOnTasks b
			ON a.TaskID = b.TaskID
			WHERE b.TagID = @TagID
			AND a.DueDate <= @BeforeDueDate
			ORDER BY a.DateCreated DESC
		END
	END
	ELSE
	BEGIN
		IF @BeforeDueDate IS NULL
		BEGIN
			SELECT * 
			FROM Tasks a
			JOIN TagsOnTasks b
			ON a.TaskID = b.TaskID
			WHERE b.TagID = @TagID
			AND a.DueDate >= @AfterDueDate
			ORDER BY a.DateCreated DESC
		END
		ELSE
		BEGIN
			SELECT * 
			FROM Tasks a
			JOIN TagsOnTasks b
			ON a.TaskID = b.TaskID
			WHERE b.TagID = @TagID
			AND a.DueDate >= @AfterDueDate
			AND a.DueDate <= @BeforeDueDate
			ORDER BY a.DateCreated DESC
		END
	END
END
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [bugs].[Task_Get] 
	@TaskID int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * 
	FROM Tasks
	WHERE TaskID = @TaskID
END
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [bugs].[Task_GetAll] 
	@UserID int = 0
AS
BEGIN
	SET NOCOUNT ON;
	IF @UserID > 0
	BEGIN
		SELECT * 
		FROM Tasks
		WHERE UserAssigned = @UserID
		ORDER BY DateCreated DESC
	END
	ELSE
	BEGIN
		SELECT *
		FROM Tasks
		ORDER BY DateCreated DESC
	END
END
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [bugs].[Task_GetComments] 
	@TaskID int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Comments 
	WHERE TaskID = @TaskID
	ORDER BY DateCreated ASC
END
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [bugs].[Task_GetTags] 
	@TaskID int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM Tags a
	JOIN TagsOnTasks b
	ON a.TagID = b.TagID
	WHERE b.TaskID = @TaskID
END
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [dbo].[User_Check] 
	@UserName varchar(50),
	@Password varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	RETURN (SELECT UserID
		FROM Users
		WHERE LOWER(UserName) = LOWER(@UserName)
		AND [Password] = @Password)
END
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [dbo].[User_Edit] 
	@UserID varchar(50), 
	@Password varchar(50),
	@Email varchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Users SET
    [Password] = @Password,
    Email = @Email
	WHERE UserID = @UserID
END
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [dbo].[User_Get] 
	@UserID int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * 
	FROM Users
	WHERE UserID = @UserID
END
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [dbo].[User_GetAll] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * 
	FROM Users
END
GO
INSERT INTO bugs.Tags([Name], [Description])  VALUES('Type: Bug','Task is a bug')
INSERT INTO bugs.Tags([Name], [Description])  VALUES('Type: Requirement','Task is a defined requirement')
INSERT INTO bugs.Tags([Name], [Description])  VALUES('Type: Testing','Testing of the application')
INSERT INTO bugs.Tags([Name], [Description])  VALUES('Type: Documentation','Required documentation must be provided to complete this task')
INSERT INTO bugs.Tags([Name], [Description])  VALUES('Type: Data','Anything related to data')
INSERT INTO bugs.Tags([Name], [Description])  VALUES('Type: CM','Configuration Management tasks (code and data organization, deployment processes, etc.)')
INSERT INTO bugs.Tags([Name], [Description])  VALUES('Type: Admin','Administrative Tasks (information discovery, organizational tasks, etc.)')
INSERT INTO bugs.Tags([Name], [Description])  VALUES('Project: <project name>','<project description>')
INSERT INTO bugs.Tags([Name], [Description])  VALUES('Status: Open','Task is open')
INSERT INTO bugs.Tags([Name], [Description])  VALUES('Status: Closed','Task is closed')
INSERT INTO bugs.Tags([Name], [Description])  VALUES('Discussion Topics','General Header for Discussion Topics')
GO
GRANT EXECUTE ON [bugs].[Task_GetAll] TO [TaskUser]
GO
GRANT EXECUTE ON [bugs].[Tag_Create] TO [TaskUser]
GO
GRANT DELETE ON [dbo].[Users] TO [TaskUser]
GO
GRANT INSERT ON [dbo].[Users] TO [TaskUser]
GO
GRANT SELECT ON [dbo].[Users] TO [TaskUser]
GO
GRANT UPDATE ON [dbo].[Users] TO [TaskUser]
GO
GRANT EXECUTE ON [bugs].[Task_Edit] TO [TaskUser]
GO
GRANT DELETE ON [bugs].[TagsOnTasks] TO [TaskUser]
GO
GRANT INSERT ON [bugs].[TagsOnTasks] TO [TaskUser]
GO
GRANT SELECT ON [bugs].[TagsOnTasks] TO [TaskUser]
GO
GRANT UPDATE ON [bugs].[TagsOnTasks] TO [TaskUser]
GO
GRANT EXECUTE ON [bugs].[Task_Delete] TO [TaskUser]
GO
GRANT EXECUTE ON [bugs].[Tag_Edit] TO [TaskUser]
GO
GRANT EXECUTE ON [bugs].[Task_Create] TO [TaskUser]
GO
GRANT EXECUTE ON [bugs].[Comment_Add] TO [TaskUser]
GO
GRANT EXECUTE ON [bugs].[Tag_Delete] TO [TaskUser]
GO
GRANT EXECUTE ON [bugs].[TagOnTask_Delete] TO [TaskUser]
GO
GRANT EXECUTE ON [bugs].[Tag_GetAll] TO [TaskUser]
GO
GRANT EXECUTE ON [bugs].[TagOnTask_Add] TO [TaskUser]
GO
GRANT DELETE ON [bugs].[Tags] TO [TaskUser]
GO
GRANT INSERT ON [bugs].[Tags] TO [TaskUser]
GO
GRANT SELECT ON [bugs].[Tags] TO [TaskUser]
GO
GRANT UPDATE ON [bugs].[Tags] TO [TaskUser]
GO
GRANT EXECUTE ON [bugs].[Task_Get] TO [TaskUser]
GO
GRANT DELETE ON [bugs].[Comments] TO [TaskUser]
GO
GRANT INSERT ON [bugs].[Comments] TO [TaskUser]
GO
GRANT SELECT ON [bugs].[Comments] TO [TaskUser]
GO
GRANT UPDATE ON [bugs].[Comments] TO [TaskUser]
GO
GRANT EXECUTE ON [bugs].[Task_GetTags] TO [TaskUser]
GO
GRANT EXECUTE ON [bugs].[Task_GetComments] TO [TaskUser]
GO
GRANT DELETE ON [bugs].[Tasks] TO [TaskUser]
GO
GRANT INSERT ON [bugs].[Tasks] TO [TaskUser]
GO
GRANT SELECT ON [bugs].[Tasks] TO [TaskUser]
GO
GRANT UPDATE ON [bugs].[Tasks] TO [TaskUser]
GO
GRANT EXECUTE ON [bugs].[Task_Find] TO [TaskUser]
GO
USE [master]
GO