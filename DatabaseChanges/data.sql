begin tran t1
INSERT INTO [Category]([Name])
     VALUES('Dinner')
INSERT INTO [Category]([Name])
     VALUES('Pizza')


INSERT INTO [Cuisine]([Name])
     VALUES('Asian')
INSERT INTO [Cuisine]([Name])
     VALUES('Italian')

INSERT INTO [Dificulty]([Name])
     VALUES('Easy')
INSERT INTO [Dificulty]([Name])
     VALUES('Medium')

INSERT INTO [Occasion]([Name])
     VALUES('Party')
INSERT INTO [Occasion]([Name])
     VALUES('Picnic')
INSERT INTO [Occasion]([Name])
     VALUES('Christmas')


commit tran t1  
--rollback tran t1