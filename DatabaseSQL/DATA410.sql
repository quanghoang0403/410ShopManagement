-- PRODUCT	(table)		:
-- Id_Product
-- Name_Product
-- Image
-- Import_Price
-- Export_Price
-- Material: Chất liệu
-- Origin: nguồn gốc
-- Product_Category: loại sản phẩm
-- Size
-- Color
-- Description
-- Sex
-- Offset
-- Sold quantity
-- Storage quantity
-- Failure quantity

-- ACCOUNT	(table)
-- Id_Account
-- Username
-- Password
-- Position
-- id_Staff

-- SHIPMENT: Lô hàng (table)
-- Id_Shipment
-- Import_date
-- Id_Staff

-- SHIPMENT_DETAIL	(table)
-- Id_ShipmentDetail
-- Id_Shipment
-- ID_Product
-- Quantity

-- BILL (table)
-- Id_Bill
-- Id_Staff
-- Export_Date
-- Total_Bill

-- BILL_DETAIL	(table)
-- Id_BillDetail
-- Id_Bill
-- Id_Product
-- Price
-- Quantity
-- Total_Price

-- STAFF	(table)
-- Id_Staff
-- Name_Staff
-- Position

CREATE DATABASE POWERFUL_SHOP_MANAGEMENT
GO

USE POWERFUL_SHOP_MANAGEMENT
GO

CREATE TABLE PRODUCT
(
	Id_Product			INT IDENTITY PRIMARY KEY,
	Name_Product		NVARCHAR(100) NOT NULL,
	Images				NVARCHAR(100),
	Import_Price		INT NOT NULL, --doi qua INT
	Export_Price		INT NOT NULL,
	Material			NVARCHAR(20) NOT NULL, --Chất liệu
	Origin				NVARCHAR(20) NOT NULL, --Nguồn gốc
	Product_Category	NVARCHAR(20) NOT NULL, --Loại sản phẩm
	Size				NVARCHAR(10) NOT NULL,
	Color				NVARCHAR(20) NOT NULL,
	Descriptions		NVARCHAR(200) NOT NULL,
	Sex					NVARCHAR(10) NOT NULL,
	Offset				INT	NOT NULL, -- doi qua float
	Sold_Quantity		INT NOT NULL, --Số lượng đã bán
	Storage_Quantity	INT NOT NULL, -- Số lượng tồn kho
	Failure_Quantity	INT NOT NULL, -- Số lượng hủy
)
GO

ALTER TABLE PRODUCT
	ALTER COLUMN Export_Price INT NOT NULL

CREATE TABLE STAFF
(
	Id_Staff			INT IDENTITY PRIMARY KEY,
	Name_Staff			NVARCHAR(50) NOT NULL,
	Position			NVARCHAR(50) IDENTITY PRIMARY KEY,
)
GO


CREATE TABLE ACCOUNT
(
	Id_Account			INT IDENTITY PRIMARY KEY,
	Username			NVARCHAR(20) NOT NULL,
	Passwordd			VARCHAR(40) NOT NULL,
	Permision			NVARCHAR(20) NOT NULL,
	Id_Staff			INT,
	FOREIGN KEY (Id_Staff) REFERENCES STAFF(Id_Staff) ON UPDATE CASCADE,
	
)
GO



CREATE TABLE SHIPMENT
(
	Id_Shipment			INT IDENTITY PRIMARY KEY,
	Import_date			DATE NOT NULL,
	Id_Staff			INT NOT NULL,
	FOREIGN KEY (Id_Staff) REFERENCES STAFF(Id_Staff) ON UPDATE CASCADE
)
GO

CREATE TABLE BILL
(
	Id_Bill				INT IDENTITY PRIMARY KEY,
	Id_Staff			INT NOT NULL,
	Export_Date			DATE NOT NULL,
	Total_Bill			INT NOT NULL,
	FOREIGN KEY (Id_Staff) REFERENCES STAFF(Id_Staff) ON UPDATE CASCADE

)
GO


CREATE TABLE SHIPMENT_DETAIL
(
	Id_ShipmentDetail	INT IDENTITY PRIMARY KEY,
	Id_Shipment			INT NOT NULL,
	Id_Product			INT NOT NULL,
	Quantity_Product	INT NOT NULL,
	FOREIGN KEY (Id_Shipment) REFERENCES SHIPMENT(Id_Shipment) ON UPDATE CASCADE,
	FOREIGN KEY (Id_Product) REFERENCES PRODUCT(Id_Product) ON UPDATE CASCADE

)
GO


CREATE TABLE BILL_DETAIL
(
	Id_BillDetail		INT IDENTITY PRIMARY KEY,
	Id_Bill				INT NOT NULL,
	Id_Product			INT NOT NULL,
	Price				INT NOT NULL,
	Quantity_Product	INT NOT NULL,
	Total_Price			INT NOT NULL,
	FOREIGN KEY (Id_Product) REFERENCES PRODUCT(Id_Product) ON UPDATE CASCADE,
	FOREIGN KEY (Id_Bill) REFERENCES BILL(Id_Bill) ON UPDATE CASCADE
)
GO



-- USP cho Product

CREATE PROC USP_Insert_Update_Product_AllDetail(
							@Name_Product		NVARCHAR(100),
							@Images				NVARCHAR(100),
							@Import_Price		MONEY,
							@Export_Price		MONEY,
							@Material			NVARCHAR(20), --Chất liệu
							@Origin				NVARCHAR(20), --Nguồn gốc
							@Product_Category	NVARCHAR(20), --Loại sản phẩm
							@Size				NVARCHAR(10),
							@Color				NVARCHAR(20),
							@Descriptions		NVARCHAR(200),
							@Sex				NVARCHAR(10),
							@Offset				INT	,
							@Sold_Quantity		INT, --Số lượng đã bán
							@Storage_Quantity	INT, -- Số lượng tồn kho
							@Failure_Quantity	INT, -- Số lượng hủy
							@StatementType NVARCHAR(20) = '',
							@Id_Product			INT
							)
AS
	BEGIN
		IF @StatementType = 'Insert' --Biến Id nhập số bất kì
			BEGIN
				INSERT INTO PRODUCT(Name_Product,Images,Import_Price,Export_Price,Material,Origin,Product_Category,Size,Color,Descriptions,Sex,Offset,Sold_Quantity,Storage_Quantity,Failure_Quantity)
				VALUES (@Name_Product,@Images,@Import_Price,@Export_Price,@Material,@Origin,@Product_Category,@Size,@Color,@Descriptions,@Sex,@Offset,@Sold_Quantity,@Storage_Quantity,@Failure_Quantity)
			END
		IF @StatementType = 'Update'
			BEGIN
				UPDATE PRODUCT
				SET		Name_Product	 =  @Name_Product,		
						Images			 =	@Images,				
						Import_Price	 =	@Import_Price,
						Export_Price	 =	@Export_Price,
						Material		 =	@Material,
						Origin			 =	@Origin,	
						Product_Category =	@Product_Category,
						Size			 =	@Size,
						Color			 =	@Color,
						Descriptions	 =	@Descriptions,	
						Sex				 =	@Sex,
						Offset			 =	@Offset,
						Sold_Quantity	 =	@Sold_Quantity,		
						Storage_Quantity =	@Storage_Quantity,
						Failure_Quantity =	@Failure_Quantity
				WHERE	Id_Product = @Id_Product
			END
	END

GO

CREATE PROC USP_Select_Product_AllDetail
AS
		select * from PRODUCT

GO




-- USP cho Staff

-- STAFF	(table)
-- Id_Staff
-- Name_Staff
-- Position

Create PROC USP_Insert_Update_Staff_AllDetail(@Name_Staff NVARCHAR(50),	@Position NVARCHAR(50),@StatementType NVARCHAR(20) = '', @Id_Staff INT)
AS
	BEGIN
		IF @StatementType = 'Insert' --Biến Id nhập số bất kì
			BEGIN
				INSERT INTO STAFF(Name_Staff, Position)
				VALUES (@Name_Staff, @Position)
			END
		IF @StatementType = 'Update' 
			BEGIN
				UPDATE STAFF
				SET 
					Name_Staff = @Name_Staff,
					Position   = @Position
				WHERE
					Id_Staff = @Id_Staff
			END
	END
GO

CREATE PROC USP_Select_Staff_AllDetail
AS
	Select	* from STAFF
	
GO





-- USP cho ACCOUNT
-- ACCOUNT	(table)
-- Id_Account
-- Username
-- Password
-- Position
-- id_Staff

ALTER PROC USP_Insert_Update_Account_AllDetail(@Username NVARCHAR(20),@Passwordd VARCHAR(40),@Permision NVARCHAR(20),@Id_Staff INT, @StatementType NVARCHAR(20) = '', @Id_Account INT )
AS
	BEGIN
			IF @StatementType = 'Insert' --Biến Id nhập số bất kì
				BEGIN
					INSERT INTO ACCOUNT(Username,Passwordd,Permision,Id_Staff)
					VALUES (@Username,@Passwordd,@Permision,@Id_Staff)
				END
			IF @StatementType = 'Update' 
				BEGIN
					UPDATE ACCOUNT
					SET	Username	= @Username,
						Passwordd	= @Passwordd,
						Permision	= @Permision
						
					WHERE
						Id_Account	= @Id_Account
				END
		END
GO

CREATE PROC USP_Select_Account_AllDetail
AS
	SELECT * FROM ACCOUNT
GO



-- BILL (table)
-- Id_Bill
-- Id_Staff
-- Export_Date
-- Total_Bill

ALTER PROC USP_Insert_Update_Bill_AllDetail(@Id_Staff INT,@Export_Date DATE,@Total_Bill INT, @StatementType NVARCHAR(20) = '', @Id_Bill INT)
AS
	BEGIN
		IF @StatementType = 'Insert' --Biến Id nhập số bất kì
				BEGIN
					INSERT INTO	BILL(Id_Staff,Export_Date,Total_Bill)
					VALUES (@Id_Staff,@Export_Date,@Total_Bill)

				END
		IF @StatementType = 'Update' 
				BEGIN
					UPDATE BILL
					SET	Export_Date	= @Export_Date,
						Total_Bill	= @Total_Bill
						
					WHERE
						Id_Bill	= @Id_Bill
				END

	END
GO

CREATE PROC USP_Select_Bill_AllDetail
AS
	SELECT * FROM BILL
GO

-- SHIPMENT: Lô hàng (table)
-- Id_Shipment
-- Import_date
-- Id_Staff


CREATE PROC USP_Insert_Update_Shipment_AllDetail(@Import_date DATE,@Id_Staff INT, @StatementType NVARCHAR(20) = '', @Id_Shipment INT)
AS
	BEGIN
		IF @StatementType = 'Insert' --Biến Id nhập số bất kì
			BEGIN
				INSERT INTO SHIPMENT(Import_date,Id_Staff)
				VALUES (@Import_date,@Id_Staff)
			END
		IF @StatementType = 'Update' 
			BEGIN
				UPDATE SHIPMENT
				SET	Import_date	= @Import_date,
					Id_Staff	= @Id_Staff
											
				WHERE
					Id_Shipment	= @Id_Shipment
			END
	END
GO

Alter PROC USP_Select_Shipment_AllDetail
AS
	SELECT * FROM SHIPMENT
GO

-- BILL_DETAIL	(table)
-- Id_BillDetail
-- Id_Bill
-- Id_Product
-- Price
-- Quantity
-- Total_Price


ALTER PROC USP_Insert_Update_Bill_Detail_AllDetail(@Id_Bill INT,@Id_Product INT,@Quantity_Product INT, @StatementType NVARCHAR(20) = '', @Id_BillDetail INT) 
AS

begin
		IF @StatementType = 'Insert' --Khi insert thì ghi số @Id_BillDetail tùy ý
			BEGIN
				DECLARE @price INT
				DECLARE @Total_Price INT
				SET @price = (SELECT Export_Price FROM PRODUCT
						WHERE Id_Product=@Id_Product)
				SET @Total_Price = @Price * @Quantity_Product
				INSERT INTO BILL_DETAIL(Id_Bill,Id_Product,Price,Quantity_Product,Total_Price)
				VALUES (@Id_Bill,@Id_Product,@Price,@Quantity_Product,@Total_Price)
			END
		IF @StatementType = 'Update' --Khi update thì ghi @Id_Bill tùy ý
			BEGIN
				DECLARE @prices INT
				DECLARE @Total_Pricee INT
				SET @prices = (SELECT Export_Price FROM PRODUCT
					WHERE Id_Product=@Id_Product)
				SET @Total_Pricee = @Prices * @Quantity_Product
				UPDATE BILL_DETAIL
				SET	Id_Product	= @Id_Product,
					Quantity_Product = @Quantity_Product,
					Total_Price = @Total_Pricee,
					Price = @prices
							
				WHERE
					Id_BillDetail	= @Id_BillDetail
			END

end

GO


CREATE PROC USP_Select_Bill_Detail_AllDetail
AS
	SELECT * FROM BILL_DETAIL
GO

-- SHIPMENT_DETAIL	(table)
-- Id_ShipmentDetail
-- Id_Shipment
-- ID_Product
-- Quantity


CREATE PROC	USP_Insert_Update_Shipment_Detail_AllDetail(@Id_Shipment INT,@Id_Product INT,@Quantity_Product INT, @StatementType NVARCHAR(20) = '', @Id_ShipmentDetail INT)
AS
	BEGIN
		IF @StatementType = 'Insert' --Khi insert thì ghi số @Id_BillDetail tùy ý
			BEGIN
				INSERT INTO SHIPMENT_DETAIL(Id_Shipment,Id_Product,Quantity_Product)
				VALUES (@Id_Shipment,@Id_Product,@Quantity_Product)
			END
		IF @StatementType = 'Update' -- Khi update thì ghi @Id_Shipment và @Id_Product tùy ý
			BEGIN
				UPDATE SHIPMENT_DETAIL
					SET	ID_Product	= @Id_Product,
						Quantity_Product	= @Quantity_Product
						
					WHERE
						Id_ShipmentDetail	= @Id_ShipmentDetail
			END

	END

GO

CREATE PROC USP_Select_Shipment_Detail_AllDetail
AS
	SELECT * FROM SHIPMENT_DETAIL
GO







