USE [master]
GO
CREATE DATABASE [Wallet]
GO
USE [Wallet]
GO
/****** Object:  Table [dbo].[Currencies]    Script Date: 22/12/2021 10:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currencies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyCode] [nvarchar](3) NOT NULL,
	[Rate] [decimal](18, 1) NOT NULL,
 CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Identities]    Script Date: 22/12/2021 10:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Identities](
	[Id] [uniqueidentifier] NOT NULL,
	[IdCardNumber] [nvarchar](8) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Username] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Identities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 22/12/2021 10:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WalletId] [int] NOT NULL,
	[TransactionTypeId] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionTypes]    Script Date: 22/12/2021 10:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionType] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_TransactionTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wallets]    Script Date: 22/12/2021 10:34:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wallets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyId] [int] NOT NULL,
	[IdentityId] [uniqueidentifier] NOT NULL,
	[CardNumber] [nvarchar](16) NOT NULL,
	[Balance] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Wallets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Currencies] ON 
GO
INSERT [dbo].[Currencies] ([Id], [CurrencyCode], [Rate]) VALUES (1, N'EUR', CAST(1.0 AS Decimal(18, 1)))
GO
INSERT [dbo].[Currencies] ([Id], [CurrencyCode], [Rate]) VALUES (2, N'GBP', CAST(0.9 AS Decimal(18, 1)))
GO
SET IDENTITY_INSERT [dbo].[Currencies] OFF
GO
INSERT [dbo].[Identities] ([Id], [IdCardNumber], [FirstName], [LastName], [DateOfBirth], [Email], [Username], [Password]) VALUES (N'f3efd723-700e-40d3-854a-08a90dcb9a76', N'0199999A', N'Test', N'Test', CAST(N'1990-01-31' AS Date), N'test@test.com', N'test', N'test')
GO
SET IDENTITY_INSERT [dbo].[TransactionTypes] ON 
GO
INSERT [dbo].[TransactionTypes] ([Id], [TransactionType]) VALUES (1, N'Credit')
GO
INSERT [dbo].[TransactionTypes] ([Id], [TransactionType]) VALUES (2, N'Debit')
GO
SET IDENTITY_INSERT [dbo].[TransactionTypes] OFF
GO
INSERT [dbo].[Wallets] ([CurrencyId], [IdentityId], [CardNumber], [Balance]) VALUES (1, N'f3efd723-700e-40d3-854a-08a90dcb9a76', N'0608578407017604', CAST(0.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Wallets] OFF
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_TransactionTypes] FOREIGN KEY([TransactionTypeId])
REFERENCES [dbo].[TransactionTypes] ([Id])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_TransactionTypes]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Wallets] FOREIGN KEY([WalletId])
REFERENCES [dbo].[Wallets] ([Id])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Wallets]
GO
ALTER TABLE [dbo].[Wallets]  WITH CHECK ADD  CONSTRAINT [FK_Wallets_Currencies] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[Currencies] ([Id])
GO
ALTER TABLE [dbo].[Wallets] CHECK CONSTRAINT [FK_Wallets_Currencies]
GO
ALTER TABLE [dbo].[Wallets]  WITH CHECK ADD  CONSTRAINT [FK_Wallets_Identities] FOREIGN KEY([IdentityId])
REFERENCES [dbo].[Identities] ([Id])
GO
ALTER TABLE [dbo].[Wallets] CHECK CONSTRAINT [FK_Wallets_Identities]
GO
USE [master]
GO
ALTER DATABASE [Wallet] SET  READ_WRITE 
GO