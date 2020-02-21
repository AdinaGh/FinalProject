CREATE TABLE Occasion
	(
	OccasionId int NOT NULL IDENTITY (1, 1),
	Name nvarchar(100) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE Occasion ADD CONSTRAINT
	PK_Occasion PRIMARY KEY CLUSTERED 
	(
	OccasionId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE TABLE Category
	(
	CategoryId int NOT NULL IDENTITY (1, 1),
	Name nvarchar(100) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE Category ADD CONSTRAINT
	PK_Category PRIMARY KEY CLUSTERED 
	(
	CategoryId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE TABLE Cuisine
	(
	CuisineId int NOT NULL IDENTITY (1, 1),
	Name nvarchar(100) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE Cuisine ADD CONSTRAINT
	PK_Cuisine PRIMARY KEY CLUSTERED 
	(
	CuisineId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE TABLE Dificulty
	(
	DificultyId int NOT NULL IDENTITY (1, 1),
	Name nvarchar(50) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE Dificulty ADD CONSTRAINT
	PK_Dificulty PRIMARY KEY CLUSTERED 
	(
	DificultyId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE TABLE Recipe
	(
	RecipeId int NOT NULL IDENTITY (1, 1),
	CreatedUserId int NOT NULL,
	CreatedDate datetime NOT NULL,
	CuisineId int NOT NULL,
	DificultyId int NOT NULL,
	ImageUrl nvarchar(50) NULL,
	Notes ntext NULL,
	PreparationMinutes int NULL,
	TotalMinutes int NULL,
	Serves int NULL,
	Title nvarchar(200) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE Recipe ADD CONSTRAINT
	PK_Recipe PRIMARY KEY CLUSTERED 
	(
	RecipeId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE Recipe ADD CONSTRAINT
	FK_Recipe_Dificulty FOREIGN KEY
	(
	DificultyId
	) REFERENCES Dificulty
	(
	DificultyId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Recipe ADD CONSTRAINT
	FK_Recipe_Cuisine FOREIGN KEY
	(
	CuisineId
	) REFERENCES Cuisine
	(
	CuisineId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Recipe ADD CONSTRAINT
	DF_Recipe_CreatedDate DEFAULT getdate() FOR CreatedDate
GO
CREATE TABLE RecipeStep
	(
	RecipeStepId int NOT NULL IDENTITY (1, 1),
	RecipeId int NOT NULL,
	Description nvarchar(2000) NOT NULL,
	Step int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE RecipeStep ADD CONSTRAINT
	PK_RecipeStep PRIMARY KEY CLUSTERED 
	(
	RecipeStepId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE RecipeStep ADD CONSTRAINT
	FK_RecipeStep_Recipe FOREIGN KEY
	(
	RecipeId
	) REFERENCES Recipe
	(
	RecipeId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
CREATE TABLE Comment
	(
	CommentId int NOT NULL IDENTITY (1, 1),
	Comment text NOT NULL,
	RecipeId int NOT NULL,
	UserId int NOT NULL,
	CreatedDate datetime NOT NULL,

	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE Comment ADD CONSTRAINT
	PK_Comment PRIMARY KEY CLUSTERED 
	(
	CommentId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE Comment ADD CONSTRAINT
	FK_Comment_Recipe FOREIGN KEY
	(
	RecipeId
	) REFERENCES Recipe
	(
	RecipeId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Comment ADD CONSTRAINT
	DF_Commnet_CreatedDate DEFAULT getdate() FOR CreatedDate
GO
CREATE TABLE UserRating
	(
	UserRatingId int NOT NULL IDENTITY (1, 1),
	RecipeId int NOT NULL,
	UserId int NOT NULL,
	Rating tinyint NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE UserRating ADD CONSTRAINT
	PK_UserRating PRIMARY KEY CLUSTERED 
	(
	UserRatingId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE UserRating ADD CONSTRAINT
	FK_UserRating_Recipe FOREIGN KEY
	(
	RecipeId
	) REFERENCES Recipe
	(
	RecipeId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
CREATE TABLE RecipeIngredient
	(
	RecipeIngredientId int NOT NULL IDENTITY (1, 1),
	RecipeId int NOT NULL,
	Ingredient nvarchar(100) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE RecipeIngredient ADD CONSTRAINT
	PK_RecipeIngredient PRIMARY KEY CLUSTERED 
	(
	RecipeIngredientId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE RecipeIngredient ADD CONSTRAINT
	FK_RecipeIngredient_Recipe FOREIGN KEY
	(
	RecipeId
	) REFERENCES Recipe
	(
	RecipeId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
CREATE TABLE RecipeCategory
	(
	RecipeCategoryId int NOT NULL IDENTITY (1, 1),
	RecipeId int NOT NULL,
	CategoryId int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE RecipeCategory ADD CONSTRAINT
	PK_RecipeCategory PRIMARY KEY CLUSTERED 
	(
	RecipeCategoryId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE RecipeCategory ADD CONSTRAINT
	FK_RecipeCategory_Recipe FOREIGN KEY
	(
	RecipeId
	) REFERENCES Recipe
	(
	RecipeId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE RecipeCategory ADD CONSTRAINT
	FK_RecipeCategory_Category FOREIGN KEY
	(
	CategoryId
	) REFERENCES Category
	(
	CategoryId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
CREATE TABLE RecipeOccasion
	(
	RecipeOccasionId int NOT NULL IDENTITY (1, 1),
	RecipeId int NOT NULL,
	OccasionId int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE RecipeOccasion ADD CONSTRAINT
	PK_RecipeOccasion PRIMARY KEY CLUSTERED 
	(
	RecipeOccasionId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE RecipeOccasion ADD CONSTRAINT
	FK_RecipeOccasion_Recipe FOREIGN KEY
	(
	RecipeId
	) REFERENCES Recipe
	(
	RecipeId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE RecipeOccasion ADD CONSTRAINT
	FK_RecipeOccasion_Occasion FOREIGN KEY
	(
	OccasionId
	) REFERENCES Occasion
	(
	OccasionId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO

CREATE TABLE Users
	(
	UserId int NOT NULL IDENTITY (1, 1),
	[Name] nvarchar(200) NOT NULL,
	[AspNetUserId] nvarchar(128) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE Users ADD CONSTRAINT
	PK_Users PRIMARY KEY CLUSTERED 
	(
	UserId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE UserRating ADD CONSTRAINT
	FK_UserRating_Users FOREIGN KEY
	(
	UserId
	) REFERENCES Users
	(
	UserId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Comment ADD CONSTRAINT
	FK_Comment_Users FOREIGN KEY
	(
	UserId
	) REFERENCES Users
	(
	UserId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Recipe ADD CONSTRAINT
	FK_Recipe_Users FOREIGN KEY
	(
	CreatedUserId
	) REFERENCES Users
	(
	UserId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
--user & roles
CREATE TABLE [AspNetRoles](
[Id] [nvarchar](128) NOT NULL,
[Name] [nvarchar](256) NOT NULL,
CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
  [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [AspNetUserClaims](
   [Id] [int] IDENTITY(1,1) NOT NULL,
   [UserId] [nvarchar](128) NOT NULL,
   [ClaimType] [nvarchar](max) NULL,
   [ClaimValue] [nvarchar](max) NULL,
CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
   [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
CREATE TABLE [AspNetUserLogins](
    [LoginProvider] [nvarchar](128) NOT NULL,
    [ProviderKey] [nvarchar](128) NOT NULL,
    [UserId] [nvarchar](128) NOT NULL,
CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
    [LoginProvider] ASC,
    [ProviderKey] ASC,
    [UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [AspNetUserRoles](
   [UserId] [nvarchar](128) NOT NULL,
   [RoleId] [nvarchar](128) NOT NULL,
CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
    [UserId] ASC,
    [RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [AspNetUsers](
    [Id] [nvarchar](128) NOT NULL,
    [Email] [nvarchar](256) NULL,
    [EmailConfirmed] [bit] NOT NULL,
    [PasswordHash] [nvarchar](max) NULL,
    [SecurityStamp] [nvarchar](max) NULL,
    [PhoneNumber] [nvarchar](max) NULL,
    [PhoneNumberConfirmed] [bit] NOT NULL,
    [TwoFactorEnabled] [bit] NOT NULL,
    [LockoutEndDateUtc] [datetime] NULL,
    [LockoutEnabled] [bit] NOT NULL,
    [AccessFailedCount] [int] NOT NULL,
    [UserName] [nvarchar](256) NOT NULL,
CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

 GO
 ALTER TABLE [AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
 REFERENCES [AspNetUsers] ([Id])
 ON DELETE CASCADE
 GO
 ALTER TABLE [AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
 GO
 ALTER TABLE [AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
 REFERENCES [AspNetUsers] ([Id])
 ON DELETE CASCADE
 GO
 ALTER TABLE [AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
 GO
 ALTER TABLE [AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
 REFERENCES [AspNetRoles] ([Id])
 ON DELETE CASCADE
 GO
 ALTER TABLE [AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
 GO
 ALTER TABLE [AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
 REFERENCES [AspNetUsers] ([Id])
 ON DELETE CASCADE
 GO
 ALTER TABLE [AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
 GO
 ALTER TABLE [Users] ADD CONSTRAINT
	FK_Users_AspNetUsers FOREIGN KEY
	(
	AspNetUserId
	) REFERENCES AspNetUsers
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
GO
