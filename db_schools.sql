USE [db_schools]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 4/25/2023 10:02:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ClassId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 4/25/2023 10:02:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NULL,
	[SubjectId] [int] NULL,
	[Mark] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ranking]    Script Date: 4/25/2023 10:02:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ranking](
	[RankId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Ranking] PRIMARY KEY CLUSTERED 
(
	[RankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Result]    Script Date: 4/25/2023 10:02:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[ResultId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[GPA] [decimal](18, 2) NULL,
	[RankId] [int] NULL,
 CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED 
(
	[ResultId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 4/25/2023 10:02:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[ClassId] [int] NULL,
 CONSTRAINT [PK_StudentId] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 4/25/2023 10:02:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[SubjectId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Class] ON 

INSERT [dbo].[Class] ([ClassId], [Name]) VALUES (1, N'Lớp 10SSS ')
INSERT [dbo].[Class] ([ClassId], [Name]) VALUES (2, N'Lớp 10A')
INSERT [dbo].[Class] ([ClassId], [Name]) VALUES (3, N'Lớp 10B')
INSERT [dbo].[Class] ([ClassId], [Name]) VALUES (4, N'Lớp 11C')
INSERT [dbo].[Class] ([ClassId], [Name]) VALUES (5, N'Lớp 11D')
INSERT [dbo].[Class] ([ClassId], [Name]) VALUES (6, N'Lớp 12A')
INSERT [dbo].[Class] ([ClassId], [Name]) VALUES (7, N'Lớp 12B')
SET IDENTITY_INSERT [dbo].[Class] OFF
GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([CourseId], [StudentId], [SubjectId], [Mark]) VALUES (2, 3, 2, CAST(6.00 AS Decimal(18, 2)))
INSERT [dbo].[Course] ([CourseId], [StudentId], [SubjectId], [Mark]) VALUES (3, 1, 2, CAST(6.00 AS Decimal(18, 2)))
INSERT [dbo].[Course] ([CourseId], [StudentId], [SubjectId], [Mark]) VALUES (4, 1, 5, CAST(3.00 AS Decimal(18, 2)))
INSERT [dbo].[Course] ([CourseId], [StudentId], [SubjectId], [Mark]) VALUES (5, 1, 6, CAST(5.00 AS Decimal(18, 2)))
INSERT [dbo].[Course] ([CourseId], [StudentId], [SubjectId], [Mark]) VALUES (7, 4, 2, CAST(3.30 AS Decimal(18, 2)))
INSERT [dbo].[Course] ([CourseId], [StudentId], [SubjectId], [Mark]) VALUES (8, 5, 2, CAST(7.70 AS Decimal(18, 2)))
INSERT [dbo].[Course] ([CourseId], [StudentId], [SubjectId], [Mark]) VALUES (10, 3, 5, CAST(8.20 AS Decimal(18, 2)))
INSERT [dbo].[Course] ([CourseId], [StudentId], [SubjectId], [Mark]) VALUES (11, 4, 2, CAST(9.60 AS Decimal(18, 2)))
INSERT [dbo].[Course] ([CourseId], [StudentId], [SubjectId], [Mark]) VALUES (12, 5, 5, CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[Course] ([CourseId], [StudentId], [SubjectId], [Mark]) VALUES (13, 6, 6, CAST(9.50 AS Decimal(18, 2)))
INSERT [dbo].[Course] ([CourseId], [StudentId], [SubjectId], [Mark]) VALUES (15, 8, 2, CAST(6.20 AS Decimal(18, 2)))
INSERT [dbo].[Course] ([CourseId], [StudentId], [SubjectId], [Mark]) VALUES (16, 9, 2, CAST(8.40 AS Decimal(18, 2)))
INSERT [dbo].[Course] ([CourseId], [StudentId], [SubjectId], [Mark]) VALUES (19, 3, 6, CAST(6.50 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Ranking] ON 

INSERT [dbo].[Ranking] ([RankId], [Name]) VALUES (1, N'Giỏi')
INSERT [dbo].[Ranking] ([RankId], [Name]) VALUES (2, N'Khá')
INSERT [dbo].[Ranking] ([RankId], [Name]) VALUES (3, N'Trung Bình')
INSERT [dbo].[Ranking] ([RankId], [Name]) VALUES (4, N'Yếu')
SET IDENTITY_INSERT [dbo].[Ranking] OFF
GO
SET IDENTITY_INSERT [dbo].[Result] ON 

INSERT [dbo].[Result] ([ResultId], [StudentId], [GPA], [RankId]) VALUES (48, 1, CAST(4.67 AS Decimal(18, 2)), 4)
INSERT [dbo].[Result] ([ResultId], [StudentId], [GPA], [RankId]) VALUES (49, 3, CAST(7.10 AS Decimal(18, 2)), 2)
INSERT [dbo].[Result] ([ResultId], [StudentId], [GPA], [RankId]) VALUES (50, 4, CAST(6.45 AS Decimal(18, 2)), 3)
INSERT [dbo].[Result] ([ResultId], [StudentId], [GPA], [RankId]) VALUES (51, 5, CAST(8.85 AS Decimal(18, 2)), 1)
INSERT [dbo].[Result] ([ResultId], [StudentId], [GPA], [RankId]) VALUES (52, 6, CAST(2.50 AS Decimal(18, 2)), 4)
INSERT [dbo].[Result] ([ResultId], [StudentId], [GPA], [RankId]) VALUES (53, 8, CAST(6.20 AS Decimal(18, 2)), 3)
INSERT [dbo].[Result] ([ResultId], [StudentId], [GPA], [RankId]) VALUES (54, 9, CAST(8.40 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Result] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (1, N'Le Quang Huy', 1)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (2, N'Le Van Huyy', 1)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (3, N'Nguyen Van Tuan', 2)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (4, N'Nguyen Van Tam', 3)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (5, N'Le Van Hoang', 4)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (6, N'Le Van Tam', 5)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (7, N'Trinh Thi Nhung', 6)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (8, N'Trinh Thi Tim', 1)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (9, N'Trinh Thi Huong', 1)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (10, N'Do Thi Hanh', 2)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (11, N'Do Thi My', 3)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (12, N'Cao Thi Thu', 4)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (13, N'Cao Thi Nhi', 5)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (14, N'Huynh Thi Ngoc', 6)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (15, N'Nguyen Van Huy', 2)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (18, N'huy', 2)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (19, N'huy', 3)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (20, N'test 1', 1)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (21, N'asd', 2)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (24, N'asdasd', 3)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (27, N'asdas', 2)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (28, N'Tran Van On', 2)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (32, N'string', 1)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (33, N'huy', 1)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (34, N'huyhuy', 1)
INSERT [dbo].[Student] ([StudentId], [Name], [ClassId]) VALUES (35, N'string', 3)
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([SubjectId], [Name]) VALUES (2, N'Vật Lý 10')
INSERT [dbo].[Subject] ([SubjectId], [Name]) VALUES (3, N'Hoá Học')
INSERT [dbo].[Subject] ([SubjectId], [Name]) VALUES (4, N'Sinh Học')
INSERT [dbo].[Subject] ([SubjectId], [Name]) VALUES (5, N'Toán')
INSERT [dbo].[Subject] ([SubjectId], [Name]) VALUES (6, N'Ngữ Văn')
SET IDENTITY_INSERT [dbo].[Subject] OFF
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Student]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Subject] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([SubjectId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Subject]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Ranking] FOREIGN KEY([RankId])
REFERENCES [dbo].[Ranking] ([RankId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Ranking]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Student]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([ClassId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Class]
GO
