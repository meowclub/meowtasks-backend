create database meowtasksdb
go

create table meowUser(
  meowUserId int primary key identity(1, 1),
  nickname varchar(32) unique not null,
  password varchar(255) not null,
  passwordHint varchar(32) not null,
  meowPoints int default 0,
  avatar varchar(50) default 'default',
  color varchar(50) default 'default',
  createdAt datetime default getdate(),
  updatedAt datetime default getdate(),
)
go

create table meowUserRole(
  roleId int primary key identity(1, 1),
  userId int not null references meowUser(meowUserId),
  name varchar(12) not null,
  createdAt datetime default getdate()
)
go

create table meowProduct(
  meowProductId int primary key identity(1, 1),
  name varchar(50) not null,
  description varchar(100) default 'not description',
  type int default 1,
  value varchar(50),
  uses int not null,
  meowPoints int not null,
  createdAt datetime default getdate()
)
go

create table meowTask(
  meowTaskId int primary key identity(1, 1),
  name varchar(50) unique not null,
  description varchar(200) default 'not description.',
  status int default 0,
  type int default 0,
  createdAt datetime default getdate()
)
go

create table meowUserBag(
  meowUserId int references meowUser(meowUserId) not null,
  productId int references meowProduct(meowProductId) not null,
  purchasedAt datetime default getdate(),
  uses int default 0
)
go
