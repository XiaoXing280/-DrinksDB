create database Student
go
use Student 
go
create table StuInfo       --ѧ����Ϣ��
(
StuNo int primary key identity(1,1),  --ѧ��
Name	Varchar(20) not null,       --����
Sex	int	default(1) check(Sex=1 or Sex=2) not null,                --	�Ա�(��=1��Ů=2)
Adress	Varchar(50) not null,       --��ͥסַ
Birthday	DateTime not null,      --��������
Subjuect	Varchar(20) not null,   --רҵ
Status	Bit not null,               --״̬(��У״̬=False,��У״̬=true)
Remark	Varchar(50)                 --��ע
) 
 go
--ʹ��SQL��������������������������ݣ�
 insert into StuInfo(Name,Sex,Adress,Birthday,Subjuect,Status,Remark)
 values
('admin',1,'���ϳ�ɳ','2020-12-11','�������','true',''),
('111',1,'��������','2020-01-25','asd','false','1'),
('222',2,'���ϳ�ɳ','2020-11-25','qwe','false',''),
('333',1,'��������','2020-02-12','qwe','true','333333333'),
('444',2,'��������','2020-05-30','asd','true','44444')
select * from StuInfo
--ʹ��SQL��佫���е���У״̬��ѧ������ѧ�ŵ�����������
select * from StuInfo where Status=1 order by StuNo asc
--ʹ��SQL���ģ����ѯ��ַ���������ϡ�����ͬѧ��Ϣ��
select * from StuInfo where Adress like '%����%' and Sex=1
--ʹ��SQL����ѯרҵΪ�������������ѧ��������
select COUNT(*) as '����' from StuInfo where Subjuect='�������'
--ʹ��SQL��佫��У״̬��ѧ����Ϣ����ɾ����
delete from StuInfo where Status=0


