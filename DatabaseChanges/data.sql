insert into [AspNetRoles] values(1,'Admin')
insert into [AspNetRoles] values(2,'RegisteredUser')
GO

INSERT INTO [Category]([Name])
     VALUES('Dinner')
INSERT INTO [Category]([Name])
     VALUES('Pizza')
INSERT INTO [Category]([Name])
     VALUES('Lunch')
INSERT INTO [Category]([Name])
     VALUES('Pork')
INSERT INTO [Category]([Name])
     VALUES('Meat')
	 	 
INSERT INTO [Cuisine]([Name])
     VALUES('Asian')
INSERT INTO [Cuisine]([Name])
     VALUES('Italian')
INSERT INTO [Cuisine]([Name])
     VALUES('Mexican')

INSERT INTO [Dificulty]([Name])
     VALUES('Easy')
INSERT INTO [Dificulty]([Name])
     VALUES('Moderate')


INSERT INTO [Occasion]([Name])
     VALUES('Party')
INSERT INTO [Occasion]([Name])
     VALUES('Picnic')
INSERT INTO [Occasion]([Name])
     VALUES('Christmas')

INSERT INTO [Occasion]([Name])
     VALUES('Weekends')
INSERT INTO [Occasion]([Name])
     VALUES('Easter')
INSERT INTO [Occasion]([Name])
     VALUES('New Year''s Eve/Day')
INSERT INTO [Occasion]([Name])
     VALUES('Summer')
INSERT INTO [Occasion]([Name])
     VALUES('BBQ')
INSERT INTO [Occasion]([Name])
     VALUES('Wedding')
GO
--------
---after creating admin
--insert into users(name, aspnetuserid) values('John Doe','bd48fe70-44bc-4429-8e5f-a6cd23e074a2')
--update [AspNetUserRoles] set roleId=1 where userid='bd48fe70-44bc-4429-8e5f-a6cd23e074a2'
GO
