create database Student
go
use Student 
go
create table StuInfo       --学生信息表
(
StuNo int primary key identity(1,1),  --学号
Name	Varchar(20) not null,       --姓名
Sex	int	default(1) check(Sex=1 or Sex=2) not null,                --	性别(男=1，女=2)
Adress	Varchar(50) not null,       --家庭住址
Birthday	DateTime not null,      --出生日期
Subjuect	Varchar(20) not null,   --专业
Status	Bit not null,               --状态(离校状态=False,在校状态=true)
Remark	Varchar(50)                 --备注
) 
 go
--使用SQL语句向表中添加至少五条测试数据；
 insert into StuInfo(Name,Sex,Adress,Birthday,Subjuect,Status,Remark)
 values
('admin',1,'湖南长沙','2020-12-11','软件技术','true',''),
('111',1,'湖南永州','2020-01-25','asd','false','1'),
('222',2,'湖南长沙','2020-11-25','qwe','false',''),
('333',1,'湖南株洲','2020-02-12','qwe','true','333333333'),
('444',2,'湖南永州','2020-05-30','asd','true','44444')
select * from StuInfo
--使用SQL语句将表中的在校状态的学生按照学号递增进行排序；
select * from StuInfo where Status=1 order by StuNo asc
--使用SQL语句模糊查询地址包含“湖南”的男同学信息；
select * from StuInfo where Adress like '%湖南%' and Sex=1
--使用SQL语句查询专业为“软件技术”的学生人数；
select COUNT(*) as '人数' from StuInfo where Subjuect='软件技术'
--使用SQL语句将离校状态的学生信息进行删除；
delete from StuInfo where Status=0


