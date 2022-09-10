create table users(username varchar(50) primary key, passcode varchar(50) not null, usertype varchar(20) not null)

insert into users values('anand', 'data123', 'admin')
insert into users values('arun', 'data123', 'admin')
select * from users

select passcode from users where username='anand'

update users set passcode='data' where username='anand'

delete from users where username='arun'

create table FuelPrice(petrol int, diesel int, oil int)

insert into fuelprice values(100, 90, 2)

update FuelPrice set petrol=101

select * from FuelPrice

select petrol from FuelPrice

create table Bills(billno int identity(1,1) primary key, regno varchar(10) not null, fueltype varchar(10), vehicletype varchar(20), wheels int, litres int, oil int, total int, billdate datetime) 

insert into bills values('tn45t9810', 'petrol', 'Two Wheeler', 2, 5, 20, 551)

select * from bills where billdate='2022-09-10 11:37:02.000'

create table samples(empid int, attddate datetime)

insert into samples values(1, '20220910')

select * from samples

delete from bills

select fueltype, sum(litres) from bills where billdate='20221009' group by fueltype
