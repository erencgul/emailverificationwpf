CREATE PROC UserAdd
@email varchar(50),
@pass varchar(50),
@name varchar(50)
AS
 INSERT INTO userpass(
 email, pass, name)
 VALUES (
 @email, @pass, @name)