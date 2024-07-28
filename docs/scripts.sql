USE [hf]
GO
/****** Object:  Table [dbo].[InvoiceHeaders]    Script Date: 2024/07/28 23:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceHeaders](
	[Id] [uniqueidentifier] NOT NULL,
	[ClientId] [uniqueidentifier] NOT NULL,
	[Date] [nvarchar](max) NOT NULL,
	[Subtotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_InvoiceHeaders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceLines]    Script Date: 2024/07/28 23:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceLines](
	[Id] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[InvoiceHeaderId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_InvoiceLines] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2024/07/28 23:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [uniqueidentifier] NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[ProductDescription] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
	[ImageUrl] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2024/07/28 23:46:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[DateRegistered] [nvarchar](max) NOT NULL,
	[AccountLocked] [bit] NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[InvoiceHeaders] ([Id], [ClientId], [Date], [Subtotal]) VALUES (N'1d571739-3f8e-49ca-bb2a-010dcaad210b', N'9b09900c-0e23-46e6-b4c5-fc6505b55882', N'2024/07/26', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceHeaders] ([Id], [ClientId], [Date], [Subtotal]) VALUES (N'2e94f23d-f5a6-4ec8-a1a8-0f5663f3f07f', N'9b09900c-0e23-46e6-b4c5-fc6505b55882', N'2024/07/25', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceHeaders] ([Id], [ClientId], [Date], [Subtotal]) VALUES (N'bd762321-5e4b-4576-9f91-106e1681e459', N'9b09900c-0e23-46e6-b4c5-fc6505b55882', N'2024/07/26', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceHeaders] ([Id], [ClientId], [Date], [Subtotal]) VALUES (N'6de1c72c-1725-4edb-a97a-167aab5c0e2e', N'9b09900c-0e23-46e6-b4c5-fc6505b55882', N'2024/07/26', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceHeaders] ([Id], [ClientId], [Date], [Subtotal]) VALUES (N'3771030c-3bee-4f04-9943-2c9869f386e1', N'9b09900c-0e23-46e6-b4c5-fc6505b55882', N'2024/07/26', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceHeaders] ([Id], [ClientId], [Date], [Subtotal]) VALUES (N'35c0b3c4-d41e-4f6e-9e18-369397f307ec', N'9b09900c-0e23-46e6-b4c5-fc6505b55882', N'2024/07/26', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceHeaders] ([Id], [ClientId], [Date], [Subtotal]) VALUES (N'48f312ed-9069-4ad7-a910-61bf894a9b25', N'bb6a63de-dfb3-4778-ac82-6315c176a2d2', N'2024-07-25', CAST(120.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceHeaders] ([Id], [ClientId], [Date], [Subtotal]) VALUES (N'76db83b1-15f4-4fde-aeee-66d771e04900', N'9b09900c-0e23-46e6-b4c5-fc6505b55882', N'2024/07/26', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceHeaders] ([Id], [ClientId], [Date], [Subtotal]) VALUES (N'16dcbce6-d58e-4724-9eb9-9bac7e6fcdd4', N'9b09900c-0e23-46e6-b4c5-fc6505b55882', N'2024/07/26', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceHeaders] ([Id], [ClientId], [Date], [Subtotal]) VALUES (N'51c6bc4e-bf3c-4a56-af9b-a9691b04554f', N'9b09900c-0e23-46e6-b4c5-fc6505b55882', N'2024/07/26', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceHeaders] ([Id], [ClientId], [Date], [Subtotal]) VALUES (N'fb15cb3b-79d3-4efa-acbd-b18528351bad', N'9b09900c-0e23-46e6-b4c5-fc6505b55882', N'2024/07/26', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceHeaders] ([Id], [ClientId], [Date], [Subtotal]) VALUES (N'96910610-2f03-4692-9dbb-c3fea6efaa2f', N'9b09900c-0e23-46e6-b4c5-fc6505b55882', N'2024/07/26', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceHeaders] ([Id], [ClientId], [Date], [Subtotal]) VALUES (N'31823e2d-ffa4-4da0-9ba4-ca99536f94dd', N'9b09900c-0e23-46e6-b4c5-fc6505b55882', N'2024/07/26', CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceHeaders] ([Id], [ClientId], [Date], [Subtotal]) VALUES (N'52ed9c25-6997-41bf-b9da-d490d52c8848', N'9b09900c-0e23-46e6-b4c5-fc6505b55882', N'2024/07/26', CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[InvoiceLines] ([Id], [ProductId], [Quantity], [Price], [InvoiceHeaderId]) VALUES (N'b2c96b0d-850c-4a50-af7d-23f4f9e9b625', N'04fd6ff0-3f90-481d-9cfa-b5092f93555a', 9, CAST(130.00 AS Decimal(18, 2)), N'bd762321-5e4b-4576-9f91-106e1681e459')
INSERT [dbo].[InvoiceLines] ([Id], [ProductId], [Quantity], [Price], [InvoiceHeaderId]) VALUES (N'3344731f-c19e-4468-9e41-2625450e6d6b', N'04fd6ff0-3f90-481d-9cfa-b5092f93555a', 9, CAST(130.00 AS Decimal(18, 2)), N'2e94f23d-f5a6-4ec8-a1a8-0f5663f3f07f')
INSERT [dbo].[InvoiceLines] ([Id], [ProductId], [Quantity], [Price], [InvoiceHeaderId]) VALUES (N'6e56e53a-a45f-4c60-b17d-4d835db0b273', N'04fd6ff0-3f90-481d-9cfa-b5092f93555a', 10, CAST(120.00 AS Decimal(18, 2)), N'48f312ed-9069-4ad7-a910-61bf894a9b25')
INSERT [dbo].[InvoiceLines] ([Id], [ProductId], [Quantity], [Price], [InvoiceHeaderId]) VALUES (N'52502e6b-a269-4993-87a2-6e3fdb33111e', N'd1a3334e-8ebf-4e01-9801-d96c793dbae4', 1, CAST(14000.00 AS Decimal(18, 2)), N'3771030c-3bee-4f04-9943-2c9869f386e1')
INSERT [dbo].[InvoiceLines] ([Id], [ProductId], [Quantity], [Price], [InvoiceHeaderId]) VALUES (N'8959032b-f2bc-4fb2-bb11-b00575db6b6f', N'04fd6ff0-3f90-481d-9cfa-b5092f93555a', 9, CAST(130.00 AS Decimal(18, 2)), N'31823e2d-ffa4-4da0-9ba4-ca99536f94dd')
GO
INSERT [dbo].[Products] ([Id], [ProductName], [ProductDescription], [Price], [Quantity], [ImageUrl]) VALUES (N'04fd6ff0-3f90-481d-9cfa-b5092f93555a', N'Keyboard', N'Microsoft Keyboard', CAST(130.00 AS Decimal(18, 2)), 9, N'keyboard.jpg')
INSERT [dbo].[Products] ([Id], [ProductName], [ProductDescription], [Price], [Quantity], [ImageUrl]) VALUES (N'd201338c-4cb7-4e11-8c41-b6da76ff6e76', N'Mouse', N'Logic Mouse', CAST(20.00 AS Decimal(18, 2)), 1, N'mouse.jpg')
INSERT [dbo].[Products] ([Id], [ProductName], [ProductDescription], [Price], [Quantity], [ImageUrl]) VALUES (N'd1a3334e-8ebf-4e01-9801-d96c793dbae4', N'Asus Laptop', N'Asus Laptop A15', CAST(14000.00 AS Decimal(18, 2)), 1, N'laptop.jpg')
GO
INSERT [dbo].[Users] ([Id], [Name], [Surname], [DateRegistered], [AccountLocked], [Email], [IsAdmin], [Password], [Username]) VALUES (N'bb6a63de-dfb3-4778-ac82-6315c176a2d2', N'admin', N'admin', N'2024-01-01', 0, N'admin@haefele.co.za', 1, N'password', N'admin')
INSERT [dbo].[Users] ([Id], [Name], [Surname], [DateRegistered], [AccountLocked], [Email], [IsAdmin], [Password], [Username]) VALUES (N'9b09900c-0e23-46e6-b4c5-fc6505b55882', N'user', N'user', N'2024-07-25', 0, N'user@haefele.com', 0, N'user', N'user')
GO
ALTER TABLE [dbo].[InvoiceHeaders] ADD  DEFAULT ((0.0)) FOR [Subtotal]
GO
ALTER TABLE [dbo].[InvoiceLines] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [InvoiceHeaderId]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (CONVERT([bit],(0))) FOR [AccountLocked]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (N'') FOR [Email]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsAdmin]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (N'') FOR [Password]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (N'') FOR [Username]
GO
ALTER TABLE [dbo].[InvoiceLines]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceLines_InvoiceHeaders_InvoiceHeaderId] FOREIGN KEY([InvoiceHeaderId])
REFERENCES [dbo].[InvoiceHeaders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceLines] CHECK CONSTRAINT [FK_InvoiceLines_InvoiceHeaders_InvoiceHeaderId]
GO
