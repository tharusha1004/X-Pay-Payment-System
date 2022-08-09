Create Database XPay_Payment_System
use XPay_Payment_System;

 
create table Online_Banking
(List_no int identity,
 Transfer_no AS ('TRA_NO_' + Right('000' + CAST(List_no AS Varchar(7)), 7)) PERSISTED Primary Key,
 acc varchar (20),
 accno varchar(10),
 toacc varchar (20),
 toaccno varchar(10),
 tnsamt decimal
 );
 
 create table Client
(Cno int identity primary key,
 CName varchar (50),
 Caccno int,
 Balance decimal);
 
 insert into Client values ('Tharusha', 75423491, 100000);
 insert into Client values ('Netumal', 67434919, 500000);
 insert into Client values ('Heshan', 34571234, 170000);

 select*from Online_Banking
 
 Create table Bill_Payment
(Bno int identity primary key,
 accnum varchar(10),
 bcategory varchar(20),
 biller varchar(20),
 bnum varchar(30),
 bamt int );

 select * from Bill_Payment

 Create table Reload_Payment
(Rno int identity primary key,
 accnum varchar (10),
 misp varchar (10),
 Rvalue int,
 mobileno char(10));

 select*from Reload_Payment

 Create table Registration
(AccNo varchar(10) primary key,
 username varchar (10),
 AccBal int); 

 select * from Registration

 insert into Registration values ('12345','Heshan',1000000);
 insert into Registration values ('45678','Janith',5000000);
 insert into Registration values ('09876','Pruthuwi',1000000);
 insert into Registration values ('87654','Tharusha',1000000);

 -------------------------------------------------------------

 create table CustomerRegistration
 (Full_name varchar(30),
 DOB Date,
 Age int,
 NIC varchar(20),
 Mobile int,
 Username varchar(15) Primary Key,
 Cus_password varchar(20),
 Email varchar(30)
 );
 Select * from CustomerRegistration;
 Create table CustomerOnlineBanking
(List_no int identity,
 Transfer_no AS ('TRA_NO_' + Right('000' + CAST(List_no AS Varchar(7)), 7)) PERSISTED Primary Key,
 username varchar(30),
 acc varchar(40),
 toacc varchar(40),
 toaccno varchar(15),
 tnsamt decimal,
 insdatetime datetime);

 select*from CustomerOnlineBanking

 create table CustomerBillPayment
(List_no int identity,
 Bill_no AS ('BPay_NO_' + Right('000' + CAST(List_no AS Varchar(7)), 7)) PERSISTED Primary Key,
 username varchar(30),
 category varchar(50),
 biller varchar(50),
 bnum varchar(40),
 bamt varchar(20),
 insdatetime datetime);

 select*from CustomerBillPayment

 create table CustomerReloadPayment
(List_no int identity,
 Reload_no AS ('REL_NO_' + Right('000' + CAST(List_no AS Varchar(7)), 7)) PERSISTED Primary Key,
 username varchar(30),
 misp varchar(10),
 rvalue decimal,
 mobileno varchar(20),
 insdatetime datetime);

 select * from CustomerReloadPayment

  create table DealerRegistration
 (Full_name varchar(30),
 DOB Date,
 Age int,
 NIC varchar(20),
 Mobile int,
 Username varchar(15) Primary Key,
 Dea_password varchar(20),
 Email varchar(30)
 );

 select * from DealerRegistration

 create table DealerOnlineBanking
(List_no int identity,
 Bill_no AS ('D_TRA_NO_' + Right('000' + CAST(List_no AS Varchar(7)), 7)) PERSISTED Primary Key,
 username varchar(30),
 toacc varchar (30),
 toaccno varchar (15),
 tamt decimal,
 cname varchar (20),
 cmobno varchar(10),
 insdatetime datetime);


 select*from DealerOnlineBanking

 create table DealerBillPayment
(List_no int identity,
Bill_no AS ('D_BPay_NO_' + Right('000' + CAST(List_no AS Varchar(7)), 7)) PERSISTED Primary Key,
 username varchar (30),
 category varchar (30),
 biller varchar (30),
 bnum varchar (20),
 bamt decimal,
 cname varchar(30),
 cmobno varchar(10),
 insdatetime datetime);

 select*from DealerBillPayment

 create table DealerReloadPayment
(List_no int identity,
 Reload_no AS ('D_REL_NO_' + Right('000' + CAST(List_no AS Varchar(7)), 7)) PERSISTED Primary Key,
 username varchar(30),
 misp varchar(10),
 rvalue decimal,
 cname varchar(30),
 cmobno varchar(10),
 insdatetime datetime);

 select*from DealerReloadPayment

 Create table Echaneling
 (Dno int identity primary key ,
 Dname varchar(30),
 Specilization varchar(30),
 Hospital varchar(30));


 select * from Echaneling

 insert into Echaneling values ('Pubudu', 'Skin', 'Navaloka');
 insert into Echaneling values ('Roshan', 'Eye-Ear-Nose', 'Asiri');
 insert into Echaneling values ('Heshani', 'Dental', 'Leasens');
 insert into Echaneling values ('Thusitha', 'Cancers', 'Nevil Fernando');
 insert into Echaneling values ('Milan', 'HIV', 'Central');


 select *from DealerBillPayment

 create table Cus_login_user
(num int identity primary key,
 username varchar(30));

 insert into loginuser values ('janithkavinda');
 insert into loginuser values ('heshanavishka');
 insert into loginuser values ('TharushaPerera');

 select*from loginuser

 select username
 from loginuser
 where  num = (select max(num) from loginuser)
 group by username

 create table loginuser
(num int identity primary key,
 username varchar(30),
 loginDate date);