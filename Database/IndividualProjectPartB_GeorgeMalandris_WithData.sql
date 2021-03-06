USE [IndividualProjectPARTB_GeorgeMalandris]
GO
/****** Object:  Table [dbo].[Assignments]    Script Date: 18/9/2020 12:58:32 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignments](
	[AssignmentID] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[description] [nvarchar](50) NOT NULL,
	[subDateTime] [datetime] NOT NULL,
	[oralMark] [int] NOT NULL,
	[totalMark] [int] NOT NULL,
 CONSTRAINT [PK_Assignments] PRIMARY KEY CLUSTERED 
(
	[AssignmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseAssignmentsRelation]    Script Date: 18/9/2020 12:58:32 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseAssignmentsRelation](
	[CourseID] [int] NOT NULL,
	[AssignmentID] [int] NOT NULL,
 CONSTRAINT [PK_CourseAssignmentsRelation] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC,
	[AssignmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 18/9/2020 12:58:32 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](10) NOT NULL,
	[stream] [nvarchar](10) NOT NULL,
	[type] [nvarchar](30) NOT NULL,
	[start_date] [datetime] NOT NULL,
	[end_date] [datetime] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseStudentRelation]    Script Date: 18/9/2020 12:58:32 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseStudentRelation](
	[CourseID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
 CONSTRAINT [PK_CourseStudentRelation] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC,
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseTrainerRelation]    Script Date: 18/9/2020 12:58:32 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseTrainerRelation](
	[CourseID] [int] NOT NULL,
	[TrainerID] [int] NOT NULL,
 CONSTRAINT [PK_CourseTrainerRelation] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC,
	[TrainerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 18/9/2020 12:58:32 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](25) NOT NULL,
	[lastName] [nvarchar](25) NOT NULL,
	[dateOfBirth] [datetime] NOT NULL,
	[tuitionFees] [decimal](6, 2) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trainers]    Script Date: 18/9/2020 12:58:32 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainers](
	[TrainerID] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](25) NOT NULL,
	[lastName] [nvarchar](25) NOT NULL,
	[subject] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Trainers] PRIMARY KEY CLUSTERED 
(
	[TrainerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Assignments] ON 

INSERT [dbo].[Assignments] ([AssignmentID], [title], [description], [subDateTime], [oralMark], [totalMark]) VALUES (1, N'IndividualProject', N'Project', CAST(N'2020-09-22T00:00:00.000' AS DateTime), 50, 100)
INSERT [dbo].[Assignments] ([AssignmentID], [title], [description], [subDateTime], [oralMark], [totalMark]) VALUES (2, N'TeamProject', N'Project', CAST(N'2020-12-11T00:00:00.000' AS DateTime), 50, 100)
INSERT [dbo].[Assignments] ([AssignmentID], [title], [description], [subDateTime], [oralMark], [totalMark]) VALUES (3, N'Exercise 1', N'Assignment', CAST(N'2020-12-16T00:00:00.000' AS DateTime), 50, 100)
INSERT [dbo].[Assignments] ([AssignmentID], [title], [description], [subDateTime], [oralMark], [totalMark]) VALUES (4, N'Exercise 2', N'Assignment', CAST(N'2021-01-01T00:00:00.000' AS DateTime), 50, 100)
INSERT [dbo].[Assignments] ([AssignmentID], [title], [description], [subDateTime], [oralMark], [totalMark]) VALUES (5, N'IndividualProject', N'Project', CAST(N'2021-02-16T00:00:00.000' AS DateTime), 50, 100)
INSERT [dbo].[Assignments] ([AssignmentID], [title], [description], [subDateTime], [oralMark], [totalMark]) VALUES (6, N'TeamProject', N'Project', CAST(N'2021-02-16T00:00:00.000' AS DateTime), 50, 100)
INSERT [dbo].[Assignments] ([AssignmentID], [title], [description], [subDateTime], [oralMark], [totalMark]) VALUES (7, N'Exercise 3', N'Assignment', CAST(N'2020-11-18T00:00:00.000' AS DateTime), 50, 100)
INSERT [dbo].[Assignments] ([AssignmentID], [title], [description], [subDateTime], [oralMark], [totalMark]) VALUES (8, N'Exercise 4', N'Assignment', CAST(N'2021-02-18T00:00:00.000' AS DateTime), 50, 100)
INSERT [dbo].[Assignments] ([AssignmentID], [title], [description], [subDateTime], [oralMark], [totalMark]) VALUES (9, N'Exercise 5', N'Assignment', CAST(N'2021-05-18T00:00:00.000' AS DateTime), 50, 100)
SET IDENTITY_INSERT [dbo].[Assignments] OFF
GO
INSERT [dbo].[CourseAssignmentsRelation] ([CourseID], [AssignmentID]) VALUES (1, 1)
INSERT [dbo].[CourseAssignmentsRelation] ([CourseID], [AssignmentID]) VALUES (1, 3)
INSERT [dbo].[CourseAssignmentsRelation] ([CourseID], [AssignmentID]) VALUES (2, 2)
INSERT [dbo].[CourseAssignmentsRelation] ([CourseID], [AssignmentID]) VALUES (4, 3)
INSERT [dbo].[CourseAssignmentsRelation] ([CourseID], [AssignmentID]) VALUES (5, 7)
INSERT [dbo].[CourseAssignmentsRelation] ([CourseID], [AssignmentID]) VALUES (5, 9)
INSERT [dbo].[CourseAssignmentsRelation] ([CourseID], [AssignmentID]) VALUES (6, 4)
INSERT [dbo].[CourseAssignmentsRelation] ([CourseID], [AssignmentID]) VALUES (6, 5)
INSERT [dbo].[CourseAssignmentsRelation] ([CourseID], [AssignmentID]) VALUES (6, 7)
INSERT [dbo].[CourseAssignmentsRelation] ([CourseID], [AssignmentID]) VALUES (6, 8)
INSERT [dbo].[CourseAssignmentsRelation] ([CourseID], [AssignmentID]) VALUES (8, 1)
INSERT [dbo].[CourseAssignmentsRelation] ([CourseID], [AssignmentID]) VALUES (8, 2)
INSERT [dbo].[CourseAssignmentsRelation] ([CourseID], [AssignmentID]) VALUES (8, 3)
INSERT [dbo].[CourseAssignmentsRelation] ([CourseID], [AssignmentID]) VALUES (8, 4)
INSERT [dbo].[CourseAssignmentsRelation] ([CourseID], [AssignmentID]) VALUES (8, 5)
INSERT [dbo].[CourseAssignmentsRelation] ([CourseID], [AssignmentID]) VALUES (8, 6)
INSERT [dbo].[CourseAssignmentsRelation] ([CourseID], [AssignmentID]) VALUES (8, 7)
INSERT [dbo].[CourseAssignmentsRelation] ([CourseID], [AssignmentID]) VALUES (8, 8)
INSERT [dbo].[CourseAssignmentsRelation] ([CourseID], [AssignmentID]) VALUES (8, 9)
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([CourseID], [title], [stream], [type], [start_date], [end_date]) VALUES (1, N'CB11', N'C#', N'online', CAST(N'2020-09-16T00:00:00.000' AS DateTime), CAST(N'2021-03-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Courses] ([CourseID], [title], [stream], [type], [start_date], [end_date]) VALUES (2, N'CB11', N'C#', N'parttime', CAST(N'2020-09-16T00:00:00.000' AS DateTime), CAST(N'2021-03-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Courses] ([CourseID], [title], [stream], [type], [start_date], [end_date]) VALUES (3, N'CB10', N'Python', N'online', CAST(N'2020-03-05T00:00:00.000' AS DateTime), CAST(N'2020-10-05T00:00:00.000' AS DateTime))
INSERT [dbo].[Courses] ([CourseID], [title], [stream], [type], [start_date], [end_date]) VALUES (4, N'CB10', N'Python', N'parttime', CAST(N'2020-03-05T00:00:00.000' AS DateTime), CAST(N'2020-10-05T00:00:00.000' AS DateTime))
INSERT [dbo].[Courses] ([CourseID], [title], [stream], [type], [start_date], [end_date]) VALUES (5, N'CB12', N'C#', N'online', CAST(N'2021-03-16T00:00:00.000' AS DateTime), CAST(N'2021-09-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Courses] ([CourseID], [title], [stream], [type], [start_date], [end_date]) VALUES (6, N'CB10', N'JavaScript', N'online', CAST(N'2020-03-05T00:00:00.000' AS DateTime), CAST(N'2020-09-05T00:00:00.000' AS DateTime))
INSERT [dbo].[Courses] ([CourseID], [title], [stream], [type], [start_date], [end_date]) VALUES (7, N'CB12', N'Python', N'online', CAST(N'2021-03-16T00:00:00.000' AS DateTime), CAST(N'2021-09-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Courses] ([CourseID], [title], [stream], [type], [start_date], [end_date]) VALUES (8, N'CB12', N'JavaScript', N'parttime', CAST(N'2021-03-16T00:00:00.000' AS DateTime), CAST(N'2021-09-16T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Courses] OFF
GO
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (1, 1)
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (1, 2)
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (1, 3)
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (1, 4)
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (1, 5)
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (1, 6)
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (1, 7)
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (1, 8)
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (1, 9)
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (1, 10)
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (2, 2)
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (3, 1)
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (3, 2)
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (4, 7)
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (5, 1)
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (5, 10)
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (6, 1)
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (6, 2)
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (6, 7)
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (8, 1)
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (8, 4)
INSERT [dbo].[CourseStudentRelation] ([CourseID], [StudentID]) VALUES (8, 8)
GO
INSERT [dbo].[CourseTrainerRelation] ([CourseID], [TrainerID]) VALUES (1, 1)
INSERT [dbo].[CourseTrainerRelation] ([CourseID], [TrainerID]) VALUES (2, 1)
INSERT [dbo].[CourseTrainerRelation] ([CourseID], [TrainerID]) VALUES (2, 2)
INSERT [dbo].[CourseTrainerRelation] ([CourseID], [TrainerID]) VALUES (3, 1)
INSERT [dbo].[CourseTrainerRelation] ([CourseID], [TrainerID]) VALUES (3, 2)
INSERT [dbo].[CourseTrainerRelation] ([CourseID], [TrainerID]) VALUES (3, 3)
INSERT [dbo].[CourseTrainerRelation] ([CourseID], [TrainerID]) VALUES (3, 4)
INSERT [dbo].[CourseTrainerRelation] ([CourseID], [TrainerID]) VALUES (3, 5)
INSERT [dbo].[CourseTrainerRelation] ([CourseID], [TrainerID]) VALUES (3, 6)
INSERT [dbo].[CourseTrainerRelation] ([CourseID], [TrainerID]) VALUES (5, 1)
INSERT [dbo].[CourseTrainerRelation] ([CourseID], [TrainerID]) VALUES (5, 5)
INSERT [dbo].[CourseTrainerRelation] ([CourseID], [TrainerID]) VALUES (5, 6)
INSERT [dbo].[CourseTrainerRelation] ([CourseID], [TrainerID]) VALUES (6, 3)
INSERT [dbo].[CourseTrainerRelation] ([CourseID], [TrainerID]) VALUES (6, 4)
INSERT [dbo].[CourseTrainerRelation] ([CourseID], [TrainerID]) VALUES (8, 3)
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentID], [firstName], [lastName], [dateOfBirth], [tuitionFees]) VALUES (1, N'George', N'Malandris', CAST(N'1988-06-06T00:00:00.000' AS DateTime), CAST(1800.00 AS Decimal(6, 2)))
INSERT [dbo].[Students] ([StudentID], [firstName], [lastName], [dateOfBirth], [tuitionFees]) VALUES (2, N'Tatiana', N'Tsitsani', CAST(N'1991-08-14T00:00:00.000' AS DateTime), CAST(2000.00 AS Decimal(6, 2)))
INSERT [dbo].[Students] ([StudentID], [firstName], [lastName], [dateOfBirth], [tuitionFees]) VALUES (3, N'John', N'Rizos', CAST(N'1998-02-23T00:00:00.000' AS DateTime), CAST(1500.50 AS Decimal(6, 2)))
INSERT [dbo].[Students] ([StudentID], [firstName], [lastName], [dateOfBirth], [tuitionFees]) VALUES (4, N'George', N'Tilkens', CAST(N'1973-02-18T00:00:00.000' AS DateTime), CAST(1800.50 AS Decimal(6, 2)))
INSERT [dbo].[Students] ([StudentID], [firstName], [lastName], [dateOfBirth], [tuitionFees]) VALUES (5, N'Michael', N'Nickolson', CAST(N'1995-08-23T00:00:00.000' AS DateTime), CAST(1300.00 AS Decimal(6, 2)))
INSERT [dbo].[Students] ([StudentID], [firstName], [lastName], [dateOfBirth], [tuitionFees]) VALUES (6, N'Melany', N'Sharlow', CAST(N'1991-04-23T00:00:00.000' AS DateTime), CAST(1900.80 AS Decimal(6, 2)))
INSERT [dbo].[Students] ([StudentID], [firstName], [lastName], [dateOfBirth], [tuitionFees]) VALUES (7, N'Bill', N'Adriano', CAST(N'1989-08-15T00:00:00.000' AS DateTime), CAST(1500.00 AS Decimal(6, 2)))
INSERT [dbo].[Students] ([StudentID], [firstName], [lastName], [dateOfBirth], [tuitionFees]) VALUES (8, N'Helen', N'Ferreira', CAST(N'2000-12-01T00:00:00.000' AS DateTime), CAST(1610.50 AS Decimal(6, 2)))
INSERT [dbo].[Students] ([StudentID], [firstName], [lastName], [dateOfBirth], [tuitionFees]) VALUES (9, N'Christine', N'Pattison', CAST(N'1982-04-20T00:00:00.000' AS DateTime), CAST(1500.50 AS Decimal(6, 2)))
INSERT [dbo].[Students] ([StudentID], [firstName], [lastName], [dateOfBirth], [tuitionFees]) VALUES (10, N'Bill', N'Osborn', CAST(N'1990-02-05T00:00:00.000' AS DateTime), CAST(2000.50 AS Decimal(6, 2)))
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[Trainers] ON 

INSERT [dbo].[Trainers] ([TrainerID], [firstName], [lastName], [subject]) VALUES (3, N'Aliki', N'Tsirozidi', N'Academic Assistant')
INSERT [dbo].[Trainers] ([TrainerID], [firstName], [lastName], [subject]) VALUES (6, N'Bill', N'Adriano', N'Instructor')
INSERT [dbo].[Trainers] ([TrainerID], [firstName], [lastName], [subject]) VALUES (4, N'Ektoras', N'Gkatsos', N'Trainer')
INSERT [dbo].[Trainers] ([TrainerID], [firstName], [lastName], [subject]) VALUES (2, N'George', N'Pasparakis', N'Academic Lead')
INSERT [dbo].[Trainers] ([TrainerID], [firstName], [lastName], [subject]) VALUES (1, N'Michalis', N'Chamilos', N'Academic Associate')
INSERT [dbo].[Trainers] ([TrainerID], [firstName], [lastName], [subject]) VALUES (5, N'Nick', N'Osborn', N'Lead Instructor')
SET IDENTITY_INSERT [dbo].[Trainers] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Assignments]    Script Date: 18/9/2020 12:58:32 μμ ******/
ALTER TABLE [dbo].[Assignments] ADD  CONSTRAINT [IX_Assignments] UNIQUE NONCLUSTERED 
(
	[title] ASC,
	[description] ASC,
	[subDateTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Courses]    Script Date: 18/9/2020 12:58:32 μμ ******/
ALTER TABLE [dbo].[Courses] ADD  CONSTRAINT [IX_Courses] UNIQUE NONCLUSTERED 
(
	[title] ASC,
	[type] ASC,
	[stream] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Students]    Script Date: 18/9/2020 12:58:32 μμ ******/
ALTER TABLE [dbo].[Students] ADD  CONSTRAINT [IX_Students] UNIQUE NONCLUSTERED 
(
	[firstName] ASC,
	[lastName] ASC,
	[dateOfBirth] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Trainers]    Script Date: 18/9/2020 12:58:32 μμ ******/
ALTER TABLE [dbo].[Trainers] ADD  CONSTRAINT [IX_Trainers] UNIQUE NONCLUSTERED 
(
	[firstName] ASC,
	[lastName] ASC,
	[subject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CourseAssignmentsRelation]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssignmentsRelation_Assignments] FOREIGN KEY([AssignmentID])
REFERENCES [dbo].[Assignments] ([AssignmentID])
GO
ALTER TABLE [dbo].[CourseAssignmentsRelation] CHECK CONSTRAINT [FK_CourseAssignmentsRelation_Assignments]
GO
ALTER TABLE [dbo].[CourseAssignmentsRelation]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssignmentsRelation_Courses] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[CourseAssignmentsRelation] CHECK CONSTRAINT [FK_CourseAssignmentsRelation_Courses]
GO
ALTER TABLE [dbo].[CourseStudentRelation]  WITH CHECK ADD  CONSTRAINT [FK_CourseStudentRelation_Courses] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[CourseStudentRelation] CHECK CONSTRAINT [FK_CourseStudentRelation_Courses]
GO
ALTER TABLE [dbo].[CourseStudentRelation]  WITH CHECK ADD  CONSTRAINT [FK_CourseStudentRelation_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[CourseStudentRelation] CHECK CONSTRAINT [FK_CourseStudentRelation_Students]
GO
ALTER TABLE [dbo].[CourseTrainerRelation]  WITH CHECK ADD  CONSTRAINT [FK_CourseTrainerRelation_Courses] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[CourseTrainerRelation] CHECK CONSTRAINT [FK_CourseTrainerRelation_Courses]
GO
ALTER TABLE [dbo].[CourseTrainerRelation]  WITH CHECK ADD  CONSTRAINT [FK_CourseTrainerRelation_Trainers] FOREIGN KEY([TrainerID])
REFERENCES [dbo].[Trainers] ([TrainerID])
GO
ALTER TABLE [dbo].[CourseTrainerRelation] CHECK CONSTRAINT [FK_CourseTrainerRelation_Trainers]
GO
