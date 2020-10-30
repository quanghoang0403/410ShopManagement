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
	Import_Price		MONEY NOT NULL,
	Export_Price		MONEY NOT NULL,
	Material			NVARCHAR(20) NOT NULL, --Chất liệu
	Origin				NVARCHAR(20) NOT NULL, --Nguồn gốc
	Product_Category	NVARCHAR(20) NOT NULL, --Loại sản phẩm
	Size				NVARCHAR(10) NOT NULL,
	Color				NVARCHAR(20) NOT NULL,
	Descriptions		NVARCHAR(200) NOT NULL,
	Sex					NVARCHAR(10) NOT NULL,
	Offset				INT	NOT NULL,
	Sold_Quantity		INT NOT NULL, --Số lượng đã bán
	Storage_Quantity	INT NOT NULL, -- Số lượng tồn kho
	Failure_Quantity	INT NOT NULL, -- Số lượng hủy


)
GO

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

drop table SHIPMENT_DETAIL

CREATE TABLE BILL_DETAIL
(
	Id_BillDetail		INT IDENTITY PRIMARY KEY,
	Id_Bill				INT NOT NULL,
	Id_Product			INT NOT NULL,
	Price				MONEY NOT NULL,
	Quantity_Product	INT NOT NULL,
	Total_Price			MONEY NOT NULL,
	FOREIGN KEY (Id_Product) REFERENCES PRODUCT(Id_Product) ON UPDATE CASCADE,
	FOREIGN KEY (Id_Bill) REFERENCES BILL(Id_Bill) ON UPDATE CASCADE
)
GO


CREATE PROC USP_Insert_Product(
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
							@Failure_Quantity	INT -- Số lượng hủy
							)
AS
		INSERT INTO PRODUCT(Name_Product,Images,Import_Price,Export_Price,Material,Origin,Product_Category,Size,Color,Descriptions,Sex,Offset,Sold_Quantity,Storage_Quantity,Failure_Quantity)
		VALUES (@Name_Product,@Images,@Import_Price,@Export_Price,@Material,@Origin,@Product_Category,@Size,@Color,@Descriptions,@Sex,@Offset,@Sold_Quantity,@Storage_Quantity,@Failure_Quantity)
GO



CREATE PROC USP_Insert_Staff(@Name_Staff NVARCHAR(50),	@Position NVARCHAR(50))
AS
		INSERT INTO STAFF(Name_Staff, Position)
		VALUES (@Name_Staff, @Position)

GO

CREATE PROC USP_Insert_Account(@Username NVARCHAR(20),@Passwordd VARCHAR(40),@Permision NVARCHAR(20),@Id_Staff INT)
AS
		INSERT INTO ACCOUNT(Username,Passwordd,Permision,Id_Staff)
		VALUES (@Username,@Passwordd,@Permision,@Id_Staff)

GO

CREATE PROC USP_Insert_Bill(@Id_Staff INT,@Export_Date DATE,@Total_Bill INT)
AS
		INSERT INTO	BILL(Id_Staff,Export_Date,Total_Bill)
		VALUES (@Id_Staff,@Export_Date,@Total_Bill)
GO

CREATE PROC	USP_Insert_Shipment(@Import_date DATE,@Id_Staff INT)
AS
		INSERT INTO SHIPMENT(Import_date,Id_Staff)
		VALUES (@Import_date,@Id_Staff)

GO

CREATE PROC USP_Insert_Bill_Detail(@Id_Bill INT,@Id_Product INT,@Quantity_Bill_Detail INT,@Total_Price MONEY)
AS

begin
		DECLARE @price MONEY
		SET @price = (SELECT Export_Price FROM PRODUCT
						WHERE Id_Product=@Id_Product)
				
		INSERT INTO BILL_DETAIL(Id_Bill,Id_Product,Price,Quantity_Bill_Detail,Total_Price)
		VALUES (@Id_Bill,@Id_Product,@Price,@Quantity_Bill_Detail,@Total_Price)
end

GO

CREATE PROC	USP_Insert_Shipment_Detail(@Id_Shipment INT,@Id_Product INT,@Quantity_Product INT)
AS
BEGIN
		INSERT INTO SHIPMENT_DETAIL(Id_Shipment,Id_Product,Quantity_Product)
		VALUES (@Id_Shipment,@Id_Product,@Quantity_Product)

END

GO




USP_Insert_Shipment  '2020-10-20', 1
go

USP_Insert_Product N'Áo thun Phượng bánh bèo', N'aaaa',30000, 50000, N'Thun lạnh', N'Bình Chánh', N'Áo thun', N'M', N'Vàng', N'Đồ ngủ của Phượng', N'Bisexual', 1, 1, 30, 2  
go

USP_Insert_Staff N'DuyDeptrai', 'Manager'
go

USP_Insert_Account N'DuyDeo', N'1', N'admin', 1
go

USP_Insert_Bill 1, '2020-10-20', 30000
go

USP_Insert_Bill_Detail 1, 1, 3, 50000
go

USP_Insert_Shipment_Detail 2,1,5
go



select * from STAFF
select * from ACCOUNT

select * from BILL
select * from BILL_DETAIL
select * from PRODUCT
select * from SHIPMENT
select * from SHIPMENT_DETAIL


