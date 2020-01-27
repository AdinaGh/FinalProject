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
ALTER TABLE Occasion SET (LOCK_ESCALATION = TABLE)
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
ALTER TABLE Category SET (LOCK_ESCALATION = TABLE)
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
ALTER TABLE Cuisine SET (LOCK_ESCALATION = TABLE)
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
ALTER TABLE Dificulty SET (LOCK_ESCALATION = TABLE)
GO
CREATE TABLE Recipe
	(
	RecipeId int NOT NULL IDENTITY (1, 1),
	CreatedUserId int NOT NULL,
	CreatedDate datetime NOT NULL,
	CategoryId int NOT NULL,
	OccasionId int NOT NULL,
	CuisineId int NOT NULL,
	DificultyId int NOT NULL
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
	FK_Recipe_Category FOREIGN KEY
	(
	CategoryId
	) REFERENCES Category
	(
	CategoryId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Recipe ADD CONSTRAINT
	FK_Recipe_Occasion FOREIGN KEY
	(
	OccasionId
	) REFERENCES Occasion
	(
	OccasionId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Recipe SET (LOCK_ESCALATION = TABLE)
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
ALTER TABLE RecipeStep SET (LOCK_ESCALATION = TABLE)
GO
CREATE TABLE Comment
	(
	CommentId int NOT NULL IDENTITY (1, 1),
	Comment text NOT NULL,
	RecipeId int NOT NULL,
	UserId int NOT NULL
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
ALTER TABLE Comment SET (LOCK_ESCALATION = TABLE)
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
ALTER TABLE UserRating SET (LOCK_ESCALATION = TABLE)
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
ALTER TABLE RecipeIngredient SET (LOCK_ESCALATION = TABLE)
GO
