/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [ID]
      ,[DanhBo]
      ,[NgayThay]
      ,[LyDoThay]
      ,[GhiChu],
      REPLACE(REPLACE(REPLACE(REPLACE(GhiChu, CHAR(9), ''), CHAR(10), ''), CHAR(13), '') ,' ',''),
     REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(GhiChu, CHAR(9), ''), CHAR(10), ''), CHAR(13), '') ,' ',''),N'Ghichú:Dathay(LoaiDongHo:',''),N',CoDongHo:15)','')
  FROM [CAPNUOCTHUDUC].[dbo].[ThayDHN]
 
UPDATE ThayDHN SET HIEUDHN = REPLACE(HIEUDHN,N',CoDongHo:100)','')
     
SELECT HIEUDHN,COUNT(*) FROM ThayDHN
GROUP BY HIEUDHN

---------------

SELECT  *  FROM [CAPNUOCTHUDUC].[dbo].[GMBD] WHERE NGAYGAN IS NOT NULL
SELECT * FROM GMBD WHERE NGAYTHICONG IS NULL

DELETE FROM GMBD WHERE NGAYTHICONG IS NULL
  
UPDATE GMBD SET DANHBO=REPLACE(DANHBO,' ',''),HIEU=UPPER(HIEU)

SELECT * FROM GMBD WHERE  LEN(NGAYTHICONG)=9 

UPDATE GMBD SET NGAYGAN=CONVERT(datetime,NGAYTHICONG) WHERE LEN(NGAYTHICONG)=9 AND   NGAYGAN IS NULL


UPDATE GMBD SET NGAYGAN=CONVERT(datetime,NGAYTHICONG) WHERE LEN(NGAYTHICONG)=8 AND  SUBSTRING(NGAYTHICONG,5,4)  IN ('2013','2014','2012') AND   NGAYGAN IS NULL

SELECT * FROM GMBD WHERE LEN(NGAYTHICONG)=8 AND  SUBSTRING(NGAYTHICONG,5,4)  IN ('2013','2014','2012')

SELECT *, SUBSTRING(NGAYTHICONG,4,2)+'/'+SUBSTRING(NGAYTHICONG,1,2)+'/20'+
CASE WHEN SUBSTRING(NGAYTHICONG,7,2)='03' OR  SUBSTRING(NGAYTHICONG,7,2)='04' THEN  CONVERT(VARCHAR(10),(CONVERT(INT,SUBSTRING(NGAYTHICONG,7,2))+10))  ELSE  SUBSTRING(NGAYTHICONG,7,2) END 
FROM GMBD 
WHERE LEN(NGAYTHICONG)=8  AND  SUBSTRING(NGAYTHICONG,5,4)  NOT IN ('2013','2014','2012')
ORDER BY CASE WHEN SUBSTRING(NGAYTHICONG,7,2)='03' OR  SUBSTRING(NGAYTHICONG,7,2)='04' THEN  CONVERT(VARCHAR(10),(CONVERT(INT,SUBSTRING(NGAYTHICONG,7,2))+10))  ELSE  SUBSTRING(NGAYTHICONG,7,2) END 
 ASC


SELECT  SUBSTRING(NGAYTHICONG,4,2)+'/'+SUBSTRING(NGAYTHICONG,1,2)+'/20'+
CASE WHEN SUBSTRING(NGAYTHICONG,7,2)='03' OR  SUBSTRING(NGAYTHICONG,7,2)='04' THEN  CONVERT(VARCHAR(10),(CONVERT(INT,SUBSTRING(NGAYTHICONG,7,2))+10))  ELSE  SUBSTRING(NGAYTHICONG,7,2) END ,COUNT(*)
FROM GMBD 
WHERE LEN(NGAYTHICONG)=8  AND  SUBSTRING(NGAYTHICONG,5,4)  NOT IN ('2013','2014','2012')
GROUP BY 
SUBSTRING(NGAYTHICONG,4,2)+'/'+SUBSTRING(NGAYTHICONG,1,2)+'/20'+
CASE WHEN SUBSTRING(NGAYTHICONG,7,2)='03' OR  SUBSTRING(NGAYTHICONG,7,2)='04' THEN  CONVERT(VARCHAR(10),(CONVERT(INT,SUBSTRING(NGAYTHICONG,7,2))+10))  ELSE  SUBSTRING(NGAYTHICONG,7,2) END 

SELECT SUBSTRING(NGAYTHICONG,4,2)+'/'+SUBSTRING(NGAYTHICONG,1,2)+'/20'+CASE WHEN SUBSTRING(NGAYTHICONG,7,2)='03' OR  SUBSTRING(NGAYTHICONG,7,2)='04' THEN  CONVERT(VARCHAR(10),(CONVERT(INT,SUBSTRING(NGAYTHICONG,7,2))+10))  ELSE  SUBSTRING(NGAYTHICONG,7,2) END,COUNT(*) FROM GMBD 
WHERE LEN(NGAYTHICONG)=8  AND  SUBSTRING(NGAYTHICONG,5,4)  NOT IN ('2013','2014','2012') AND NGAYGAN IS NULL
GROUP BY SUBSTRING(NGAYTHICONG,4,2)+'/'+SUBSTRING(NGAYTHICONG,1,2)+'/20'+CASE WHEN SUBSTRING(NGAYTHICONG,7,2)='03' OR  SUBSTRING(NGAYTHICONG,7,2)='04' THEN  CONVERT(VARCHAR(10),(CONVERT(INT,SUBSTRING(NGAYTHICONG,7,2))+10))  ELSE  SUBSTRING(NGAYTHICONG,7,2) END
ORDER BY SUBSTRING(NGAYTHICONG,4,2)+'/'+SUBSTRING(NGAYTHICONG,1,2)+'/20'+CASE WHEN SUBSTRING(NGAYTHICONG,7,2)='03' OR  SUBSTRING(NGAYTHICONG,7,2)='04' THEN  CONVERT(VARCHAR(10),(CONVERT(INT,SUBSTRING(NGAYTHICONG,7,2))+10))  ELSE  SUBSTRING(NGAYTHICONG,7,2) END




UPDATE GMBD SET NGAYGAN=CONVERT(DATETIME,REPLACE((SUBSTRING(NGAYTHICONG,4,2)+'/'+SUBSTRING(NGAYTHICONG,1,2)+'/20'+CASE WHEN SUBSTRING(NGAYTHICONG,7,2)='03' OR  SUBSTRING(NGAYTHICONG,7,2)='04' THEN  CONVERT(VARCHAR(10),(CONVERT(INT,SUBSTRING(NGAYTHICONG,7,2))+10))  ELSE  SUBSTRING(NGAYTHICONG,7,2) END),'18/19/2012','09/18/2012'))
WHERE  LEN(NGAYTHICONG)=8  AND  SUBSTRING(NGAYTHICONG,5,4)  NOT IN ('2013','2014','2012') AND NGAYGAN IS NULL

SELECT * FROM GMBD WHERE  LEN(NGAYTHICONG)=8  AND  SUBSTRING(NGAYTHICONG,5,4)  NOT IN ('2013','2014','2012')

DELETE FROM GMBD WHERE NGAYTHICONG=' '



UPDATE GMBD SET NGAYGAN=CONVERT(datetime,NGAYTHICONG) WHERE LEN(NGAYTHICONG)=8 AND   NGAYGAN IS NULL

UPDATE GMBD SET NGAYTHICONG=REPLACE(NGAYTHICONG,'//','')


UPDATE GMBD SET HIEU=NGAYTHICONG WHERE NGAYGAN IS  NULL AND HIEU='TD'

UPDATE GMBD SET SOTHAN=TLK,NGAYTHICONG=DIACHI WHERE NGAYGAN IS NULL  AND HOTEN='15'

UPDATE GMBD SET DANHBO=REPLACE(DOT,' ','') WHERE LEN(DOT)>10 AND LEN(DANHBO)<7

SELECT NGAYTHICONG, SOTHAN, HIEU, DANHBO, HIEULUC, NGAYGAN
FROM GMBD
WHERE LEN(DANHBO)=11


UPDATE GMBD SET KY= CONVERT(INT,SUBSTRING(HIEULUC,1,2))
WHERE ISNUMERIC(SUBSTRING(HIEULUC,1,2))=1 AND CONVERT(INT,SUBSTRING(HIEULUC,1,2))<=12

SELECT * FROM GMBD

UPDATE GMBD SET HIEU=NGAYTHICONG,SOTHAN=TLK,NGAYTHICONG=DIACHI WHERE  NGAYGAN IS NULL AND DANHBO=''

UPDATE GMBD SET DANHBO=REPLACE(SOTHAN,' ' ,''),SOTHAN=NGAYTHICONG WHERE STT IN ('ARIS','MUL','SUS','aric','Kent')

UPDATE GMBD SET DANHBO = REPLACE(SOTHAN,' ','') WHERE NGAYGAN IS NULL AND DANHBO IS NULL

UPDATE GMBD SET HIEU='ALEMA',NGAYGAN='01/01/2014'
 WHERE NGAYGAN IS NULL AND  SOTHAN='2102 201 0355'

SELECT * FROM GMBD WHERE NGAYGAN IS NULL

---------------------------------------------------------------------------------------------------------------
SELECT * FROM TB_DULIEUKHACHHANG WHERE HIEUDH IS NOT NULL


----- DU LIEU GAN MOI 
UPDATE TB_DULIEUKHACHHANG SET NGAYTHAY=T1.NGAYGAN
	,HIEUDH=T1.HIEU
	,SOTHANDH=T1.SOTHAN
	,KY=T1.KY
	,NAM=T1.NAM
FROM GMBD T1
WHERE TB_DULIEUKHACHHANG.DANHBO=T1.DANHBO AND LEN(T1.DANHBO)=11


UPDATE TB_DULIEUKHACHHANG SET NGAYTHAY=T1.NGAYGAN
	,HIEUDH=T1.HIEU
	,SOTHANDH=T1.SOTHAN
	,KY=T1.KY
	,NAM=T1.NAM
FROM GMBD T1
WHERE TB_DULIEUKHACHHANG.GIAOUOC=T1.DANHBO AND LEN(T1.DANHBO)=9

------------------------
----- DU LIEU THAY
SELECT DANHBO,CONVERT(NVARCHAR(50),DANHBO),Str(DANHBO,25,0) FROM ThayDHN WHERE HIEUDHN IS NOT NULL
UPDATE ThayDHN SET SODANHBO=Str(DANHBO,25,0)

UPDATE TB_DULIEUKHACHHANG SET NGAYTHAY=T1.NgayThay
	,HIEUDH=T1.HIEUDHN
	,SOTHANDH=T1.SOTHAN
FROM ThayDHN T1
WHERE TB_DULIEUKHACHHANG.DANHBO=T1.DanhBo 

------- THAY HANDHELD
SELECT HIEUDH,COUNT(*) FROM TB_DULIEUKHACHHANG 
GROUP BY HIEUDH

select HIEUDHN,COUNT(*) from ThayDHN WHERE HIEUDHN='0'
group by HIEUDHN