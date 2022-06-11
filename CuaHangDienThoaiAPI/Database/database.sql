use
master
go
create
database CuaHangDienThoai
go
use CuaHangDienThoai
go
create table Account
(
    UserName nvarchar(50) primary key,
    Password nvarchar(50) not null,
    IsActive bit default 1,
)
    go
create table Product
(
    ID          int primary key identity,
    Name        nvarchar(50)  not null,
    CategoryID  int           not null,
    Image       nvarchar(max) not null,
    Details     nvarchar(max) not null,
    Description nvarchar(max) not null,
    Cost        int           not null,
    IsHot       bit default 1,
    IsSale      bit default 1,
    IsActive    bit default 1,
)
    go
create table ImageProduct
(
    ID        int primary key identity,
    ProductID int           not null,
    Image     nvarchar(max) not null,
    IsActive  bit default 1,
)
    go
create table Category
(
    ID       int primary key identity,
    Name     nvarchar(50)  not null,
    Image    nvarchar(max) not null,
    IsActive bit default 1,
)
    go
create table [Order]
(
    ID
    int
    primary
    key
    identity,
    NameCustomer
    nvarchar(50)  not null,
    PhoneNumber char(10)      not null,
    Address     nvarchar(max) not null,
    Status      int           not null default 0
    )
    go
create table OrderDetails
(
    ID        int primary key identity,
    OrderID   int not null,
    ProductID int not null,
    Quantity  int not null,
)
    go
-- tai khoan
create
proc register @username nvarchar(50),
                  @password nvarchar(50) AS
BEGIN
insert into Account(username, password)
VALUES (@username, @password)
END
go
create
proc login @username nvarchar(50),
               @password nvarchar(50) AS
BEGIN
select *
from account
where username = @username
  and password = @password
END
GO
--san pham
create
proc addProduct @Name nvarchar(50),
                    @CategoryID int,
                    @Image nvarchar(max),
                    @Details nvarchar(max),
                    @Description nvarchar(max),
                    @Cost int,
                    @IsHot bit,
                    @IsSale bit AS
begin
insert into Product (name,
                     categoryId,
                     image,
                     details,
                     Description,
                     cost,
                     ishot,
                     issale)
VALUES (@Name,
        @CategoryID,
        @Image,
        @Details,
        @Description,
        @Cost,
        @IsHot,
        @IsSale)
end
go
create
proc updateProduct @id int,
                       @Name nvarchar(50),
                       @CategoryID int,
                       @Image nvarchar(max),
                       @Details nvarchar(max),
                       @Description nvarchar(max),
                       @Cost int,
                       @IsHot bit,
                       @IsSale bit AS
begin
update Product
set Name        = @Name,
    Description = @Description,
    Cost        = @Cost,
    Details     = @Details,
    IsHot       = @IsHot,
    IsSale      = @IsSale,
    Image       = @Image,
    CategoryID  = @CategoryID
where id = @ID
END
go
-- delete product
create
proc deleteProduct @id int AS
begin
update Product
set isActive = 0
where id = @ID
end

-- lay ve toan bo danh sach san pham
go
create
proc getAllProduct AS
begin
select Product.ID,
       Product.Name,
       Category.Name [CategoryName],
       Product.Image,
       Product.Details,
       Product.Description,
       Product.Cost,
       Product.IsHot,
       Product.IsSale
from Product,
     Category
where CategoryID = Category.ID
  and Product.IsActive = 1
END
go
--  lay ve danh sach theo danh muc
create
proc getProductByCategory @idCategory int AS
begin
select Product.ID,
       Product.Name,
       Category.Name [CategoryName],
       Product.Image,
       Product.Details,
       Product.Description,
       Product.Cost,
       Product.IsHot,
       Product.IsSale
from Product,
     Category
where CategoryID = Category.ID
  and Product.IsActive = 1
  and CategoryID = @idCategory
END
go
-- lay ve danh sach san pham hot
create
proc getProductHot as
begin
select Product.ID,
       Product.Name,
       Category.Name [CategoryName],
       Product.Image,
       Product.Details,
       Product.Description,
       Product.Cost,
       Product.IsHot,
       Product.IsSale
from Product,
     Category
where CategoryID = Category.ID
  and Product.IsActive = 1
  and IsHot = 1
end
go
--lay ve danh sach san pham sale
create
proc getProductSale as
begin
select Product.ID,
       Product.Name,
       Category.Name [CategoryName],
       Product.Image,
       Product.Details,
       Product.Description,
       Product.Cost,
       Product.IsHot,
       Product.IsSale
from Product,
     Category
where CategoryID = Category.ID
  and Product.IsActive = 1
  and IsSale = 1
end
-- hinh anh san pham
go
create
proc addImageProduct @ProductID int, @Image nvarchar(max)
as
begin
insert into ImageProduct(ProductID, Image)
values (@ProductID, @Image)
end
go
create
proc updateImageProduct @ID int, @ProductID int, @Image nvarchar(max)
as
begin
update ImageProduct
set ProductID = @ProductID,
    Image     = @Image
where ID = @ID
end
go
create
proc deleteImageProduct @ID int
as
begin
update ImageProduct
set IsActive = 0
where ID = @ID
end
go
create
proc getImageProduct @ProductID int
as
begin
select *
from ImageProduct
where ProductID = @ProductID
end
-- danh muc san pham
go
create
proc addCategory @Name nvarchar(50), @Image nvarchar(max)
as
begin
insert into Category (Name, Image)
values (@Name, @Image);
end
go
create
proc updateCategory @ID int, @Name nvarchar(50), @Image nvarchar(max)
as
begin
update Category
set Name  = @Name,
    Image = @Image
where ID = @ID
end
go
create
proc deleteCategory @ID int
as
begin
update Category
set IsActive = 0
where ID = @ID
end
go
create
proc getAllCategory
as
begin
select *
from Category
where IsActive = 1
end
go
-- don hang
create
proc addOrder @Name nvarchar(50), @Phone char(10), @Address nvarchar(max)
as
begin
insert into [Order](NameCustomer, PhoneNumber, Address)
values (@Name, @Phone, @Address)
end
go
create
proc updateOrder @ID int, @Status int
as
begin
update [Order]
set Status = @Status
where ID = @ID
end
--
go
create
proc addOrderDetails @OrderID int, @ProductID int, @Quantity int
as
begin
insert into OrderDetails (OrderID, ProductID, Quantity)
values (@OrderID, @ProductID, @Quantity)
end
go
create proc getImageProductByID @ID int as
begin
select * from ImageProduct where ID = @ID
end
go
create proc getCategoryByID @ID int as
begin
select * from Category where ID = @ID
end
go
create proc getOrder
as
begin
select * from [Order]
end
go
create proc getOrderDetails @OrderID int
as
begin
select Product.Name, Product.Cost, OrderDetails.Quantity, Product.Cost * OrderDetails.Quantity [Money]
from [Order],
    OrderDetails,
    Product
where Order.ID = OrderDetails.OrderID
    and OrderDetails.ProductID = Product.ID
    and OrderID = @OrderID
end 
go
create
proc getProductById @ID int AS
begin
select Product.ID,
       Product.Name,
       Category.Name [CategoryName],
       Product.Image,
       Product.Details,
       Product.Description,
       Product.Cost,
       Product.IsHot,
       Product.IsSale
from Product,
     Category
where CategoryID = Category.ID
  and Product.IsActive = 1 and Product.ID = @ID
END