 create database dbMyOnlineShopping
 go
 use dbMyOnlineShopping


 create table Tbl_Category(

 CategoryId int identity primary key,
 CategoryName varchar(500) unique,
 IsActive bit null,
 IsDelete bit null
 )

 create table Tbl_product
 (
 ProductId int identity primary key,
 ProductName varchar(500) unique,
 CategoryId int,
 IsActive bit null,
 IsDelete bit null,
 CreateDate datetime  null,
 Description datetime null,
 ProductImage varchar(max),
 IsFeatured bit null,
 Quantity int,
 foreign key(CategoryId) references Tbl_Category
 )

 create table Tbl_CartStatus
 (
 CartStatusId int identity primary key,
 CartStatus varchar(500)
 )

 create table Tbl_Members
 (
 MemberID   int identity primary key,
 FirstName  varchar(200) ,
 LastName   varchar(200) unique,
 EmailId    varchar(200) unique,
 Password   varchar(500) ,
 IsActive   bit null,
 IsDelete   bit null,
 CreatedOn  datetime,
 ModifiedOn datetime
 )


 Create table Tbl_ShippingDetails
 (
 ShippingDetailId int identity primary key,
 MemberId int,
 Address varchar(500),
 City    varchar(500),
 State   varchar(500),
 Country varchar(50),
 ZipCode varchar(50),
 OrderId int,
 AmountId decimal, 
 PaymentType varchar(50),
 foreign key(MemberId) references Tbl_Members(MemberId)
 )

  create table Tbl_MemberRole
  ( 
  MemberRoleID int identity primary key,
  MemberId int,
  RoleId int
  )



 create table Tbl_Roles
 (
  RoleId int identity primary key,
  RoleName varchar(200) unique
  )



  Create table Tbl_Cart
  (
  CartId int identity primary key,
  ProductId int,
  MemberId int,
  CartStatusId int,
  foreign key (ProductId) references Tbl_product(ProductId)
  )

 

  create table Tbl_SlideImage
  (
   slideId int identity primary key,
   SlideTitle varchar(500),
   SlideImage varchar(max)

  )