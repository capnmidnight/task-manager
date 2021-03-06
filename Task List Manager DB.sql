USE [TaskDB]
GO
/****** Object:  Table [dbo].[Attachments]    Script Date: 10/10/2008 00:21:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Attachments](
	[AttachmentID] [int] IDENTITY(1,1) NOT NULL,
	[TaskID] [int] NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
	[FileData] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Attachment] PRIMARY KEY CLUSTERED 
(
	[AttachmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 10/10/2008 00:21:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[TaskID] [int] NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime] NOT NULL CONSTRAINT [DF_Comments_DateCreated]  DEFAULT (getdate()),
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tags]    Script Date: 10/10/2008 00:21:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[TagID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[IsDefault] [bit] NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[TagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TagsOnTasks]    Script Date: 10/10/2008 00:21:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagsOnTasks](
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
/****** Object:  Table [dbo].[Tasks]    Script Date: 10/10/2008 00:21:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[TaskID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[DateCreated] [datetime] NOT NULL CONSTRAINT [DF_Tasks_DateCreated]  DEFAULT (getdate()),
	[DueDate] [datetime] NOT NULL,
	[UserCreator] [int] NOT NULL,
	[UserAssigned] [int] NOT NULL,
	[Priority] [int] NOT NULL,
	[Progress] [int] NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/10/2008 00:21:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Attachments]  WITH CHECK ADD  CONSTRAINT [FK_Attachment_Tasks] FOREIGN KEY([TaskID])
REFERENCES [dbo].[Tasks] ([TaskID])
GO
ALTER TABLE [dbo].[Attachments] CHECK CONSTRAINT [FK_Attachment_Tasks]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Tasks] FOREIGN KEY([TaskID])
REFERENCES [dbo].[Tasks] ([TaskID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Tasks]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users]
GO
ALTER TABLE [dbo].[TagsOnTasks]  WITH CHECK ADD  CONSTRAINT [FK_TagsOnTasks_Tags] FOREIGN KEY([TagID])
REFERENCES [dbo].[Tags] ([TagID])
GO
ALTER TABLE [dbo].[TagsOnTasks] CHECK CONSTRAINT [FK_TagsOnTasks_Tags]
GO
ALTER TABLE [dbo].[TagsOnTasks]  WITH CHECK ADD  CONSTRAINT [FK_TagsOnTasks_Tasks] FOREIGN KEY([TaskID])
REFERENCES [dbo].[Tasks] ([TaskID])
GO
ALTER TABLE [dbo].[TagsOnTasks] CHECK CONSTRAINT [FK_TagsOnTasks_Tasks]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Users_Assigned] FOREIGN KEY([UserAssigned])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Users_Assigned]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Users_Creator] FOREIGN KEY([UserCreator])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Users_Creator]
GO
CREATE PROCEDURE [dbo].[sp_Attachment_Insert]
	@TaskID int,
	@FileName nvarchar(MAX),
	@FileData varbinary(MAX)
as
begin
	set nocount on;
	INSERT INTO Attachments(
		TaskID,
		FileName,
		FileData)
	VALUES(
		@TaskID,
		@FileName,
		@FileData)
	RETURN @@IDENTITY
end
GO
CREATE PROCEDURE [dbo].[sp_Attachment_Delete]
	@AttachmentID int
as
begin
	set nocount on;
	DELETE FROM Attachments WHERE AttachmentID = @AttachmentID
end
GO
CREATE PROCEDURE [dbo].[sp_Attachment_Get]
	@AttachmentID int
as
begin
	set nocount on;
	SELECT * FROM Attachments WHERE AttachmentID = @AttachmentID
end
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [dbo].[sp_Comment_Insert] 
	@UserID int, 
	@TaskID int,
	@Text text
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Comments(UserID, TaskID, [Text])
	VALUES(@UserID, @TaskID, @Text)
END

GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [dbo].[sp_Tag_Insert] 
	@Name nvarchar(50), 
	@Description nvarchar(250),
	@IsDefault bit
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Tags([Name], [Description], IsDefault)
	VALUES(@Name, @Description, @IsDefault)
	RETURN @@Identity;
END

GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [dbo].[sp_Tag_Delete] 
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
CREATE PROCEDURE [dbo].[sp_Tag_Update] 
	@TagID int,
	@Name nvarchar(50),
	@Description nvarchar(250),
	@IsDefault bit
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Tags SET
	[Name] = @Name,
	[Description] = @Description,
	IsDefault = @IsDefault
	WHERE TagID = @TagID
END

GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [dbo].[sp_Tag_Select] 
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
CREATE PROCEDURE [dbo].[sp_TagOnTask_Insert] 
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
CREATE PROCEDURE [dbo].[sp_TagOnTask_Delete] 
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
CREATE PROCEDURE [dbo].[sp_Task_Insert] 
	@Title nvarchar(50),
	@Description text,
	@UserCreator int,
	@DueDate datetime,
	@UserAssigned int = 1,
	@Priority int,
	@Progress int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Tasks(
		Title,
		[Description],
		UserCreator,
		DueDate,
		UserAssigned,
		Priority,
		Progress)
	VALUES(
		@Title,
		@Description,
		@UserCreator,
		@DueDate,
		@UserAssigned,
		@Priority,
		@Progress)
	RETURN @@IDENTITY
END

GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [dbo].[sp_Task_Delete] 
	@TaskID int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM Comments WHERE TaskID = @TaskID
	DELETE FROM TagsOnTasks WHERE TaskID = @TaskID
	DELETE FROM Tasks WHERE TaskID = @TaskID
END

GO
CREATE PROCEDURE [dbo].[sp_Task_Update] 
	@TaskID int,
	@Title nvarchar(50),
	@Description text,
	@UserAssigned int,
	@DueDate datetime,
	@Priority int,
	@Progress int
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Tasks SET
		Title = @Title,
		[Description] = @Description,
		UserAssigned = @UserAssigned,
		DueDate = @DueDate,
		Priority = @Priority,
		Progress = @Progress
	WHERE TaskID = @TaskID
END
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [dbo].[sp_Task_Find] 
	@TagID int,
	@AfterDueDate datetime = null,
	@BeforeDueDate datetime = null
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * 
	FROM Tasks a
	JOIN TagsOnTasks b
	ON a.TaskID = b.TaskID
	WHERE b.TagID = @TagID
		AND (@AfterDueDate is null or a.DueDate = @AfterDueDate)
		AND (@BeforeDueDate is null or a.DueDate <= @BeforeDueDate)
	ORDER BY a.DateCreated DESC
END

GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [dbo].[sp_Task_Get] 
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
CREATE PROCEDURE [dbo].[sp_Task_Select] 
	@UserID int = 0
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * 
	FROM Tasks
	WHERE (@UserID is null or UserAssigned = @UserID)
	ORDER BY DateCreated DESC
END

GO
CREATE PROCEDURE [dbo].[sp_Task_GetAttachments]
	@TaskID int
as
begin
	set nocount on;
	SELECT AttachmentID, TaskID, FileName FROM Attachments WHERE TaskID = @TaskID
end
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [dbo].[sp_Task_GetComments] 
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
CREATE PROCEDURE [dbo].[sp_Task_GetTags] 
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
CREATE PROCEDURE [dbo].[sp_User_Check] 
	@UserName nvarchar(50),
	@Password nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT UserID
	FROM Users
	WHERE LOWER(UserName) = LOWER(@UserName)
	AND [Password] = @Password)
END

GO
CREATE PROCEDURE [dbo].[sp_User_Insert]
	@UserName nvarchar(50),
	@Password nvarchar(50),
    @Email nvarchar(50)
as
begin
	set nocount on;
	INSERT INTO Users(
		UserName,
		Password,
		Email)
	VALUES(
		@UserName,
		@Password,
		@Email)
end
GO
-- =============================================
-- Author:		Sean T. McBeth
-- Create date: 04/09/2008
-- =============================================
CREATE PROCEDURE [dbo].[sp_User_Update] 
	@UserID nvarchar(50), 
	@Password nvarchar(50),
	@Email nvarchar(50)
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
CREATE PROCEDURE [dbo].[sp_User_Get] 
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
CREATE PROCEDURE [dbo].[sp_User_Select] AS
BEGIN
	SET NOCOUNT ON;
	SELECT * 
	FROM Users
END
go
create procedure sp_Comment_Delete 
	@CommentID int
as
begin
	set nocount on;
	delete from Comments where CommentID = @CommentID
end