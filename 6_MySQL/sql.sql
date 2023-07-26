CREATE TABLE usertable (
  `userId` INT NOT NULL AUTO_INCREMENT,
  `email` VARCHAR(45) NOT NULL,
  `firstName` VARCHAR(45) NOT NULL,
  `lastName` VARCHAR(45) NULL,
  `password` VARCHAR(45) NOT NULL,
  `countryId` INT NOT NULL,
  `stateId` INT NOT NULL,
  `addressLine1` VARCHAR(45) NOT NULL,
  `addressLine2` VARCHAR(45) NULL,
  `City` VARCHAR(45) NOT NULL,
  `zipcode` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`userId`),
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) );
  
CREATE TABLE userroletable (
  `userRoleId` INT NOT NULL AUTO_INCREMENT,
  `userRole` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`userRoleId`),
  UNIQUE INDEX `userRole_UNIQUE` (`userRole` ASC) );
	
create table userroleforuser(
	userRoleId int,
    userId int,
    constraint foreign key (userRoleId) references userroletable(userRoleId),
    constraint foreign key (userId) references usertable(userId)); 
	
create table country_table(
	countryId int PRIMARY KEY,
    country_name varchar(50),
    country_abbr varchar(3)
    );
create table state_table(
	stateId int PRIMARY KEY,
    state_name varchar(50),
    countryId int,
    constraint foreign key (countryId) references country_table(countryId)
    );
	
alter table usertable
add constraint foreign key (countryId) references country_table(countryId),
add constraint foreign key (stateId) references state_table(stateId);

alter table userroleforuser
add constraint primary key(userRoleId,userId);

select * from country_table;

call printcountry("IN");

select countState("India");
