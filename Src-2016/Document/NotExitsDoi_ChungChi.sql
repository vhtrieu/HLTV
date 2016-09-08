--1. 200 - HOV_ID = 193 is not exits -> delete 
    -- delete  cap_chungchi.ccc_id = 247 
select * from doi_chungchi where doi_chcid =2 and doi_id=200
select * from cap_chungchi where ccc_chcid =2 and ccc_doiid=200
select * from hocvien where  hov_id = 193
--2. 2216 - why tow certificate on CHC_ID???
select * from doi_chungchi where doi_chcid =2 and doi_id=2216
select * from cap_chungchi where ccc_chcid =2 and ccc_doiid=2216
select * from hocvien where  hov_id = 1595
--3. 1444 HOV_ID = 1135 is not exits -> delete 
    -- delete  cap_chungchi.ccc_id = 1943 
select * from doi_chungchi where doi_chcid =2 and doi_id=1444
select * from cap_chungchi where ccc_chcid =2 and ccc_doiid=1444
select * from hocvien where  hov_id = 1135
--4. 1695 HOV_ID = 1240 is not exits -> delete 
    -- delete  cap_chungchi.ccc_id = 2132
select * from doi_chungchi where doi_chcid =2 and doi_id=1695
select * from cap_chungchi where ccc_chcid =2 and ccc_doiid=1695
select * from hocvien where  hov_id = 1240
--5. 1881 HOV_ID = 1502 is not exits -> delete 
    -- delete  cap_chungchi.ccc_id = 2553
select * from doi_chungchi where doi_chcid =2 and doi_id=1881
select * from cap_chungchi where ccc_chcid =2 and ccc_doiid=1881
select * from hocvien where  hov_id = 1502
--6. 2017 HOV_ID = 1547 is not exits -> delete 
    -- delete  cap_chungchi.ccc_id = 2670
select * from doi_chungchi where doi_chcid =2 and doi_id=2017
select * from cap_chungchi where ccc_chcid =2 and ccc_doiid=2017
select * from hocvien where  hov_id = 1547
--7. 14479 Tại sao HOV_ID = 2569 cấp lại chứng chỉ ngày 2013-01-16 đến ngày 2014-09-15 lại cấp thêm
     -- lần nữa và cùng một số chứng chỉ.
select * from doi_chungchi where doi_chcid =2 and doi_id=14479
select * from cap_chungchi where ccc_chcid =2 and ccc_doiid=14479
select * from hocvien where  hov_id = 2569
--8. 14478 Tại sao HOV_ID = 2589 cấp lại chứng chỉ ngày 2013-01-16 đến ngày 2014-09-15 lại cấp thêm
     -- lần nữa và cùng một số chứng chỉ.
select * from doi_chungchi where doi_chcid =2 and doi_id=14478
select * from cap_chungchi where ccc_chcid =2 and ccc_doiid=14478
select * from hocvien where  hov_id = 2589
--9. 14477 Tại sao HOV_ID = 2630 cấp lại chứng chỉ ngày 2013-01-16 đến ngày 2014-09-15 lại cấp thêm
     -- lần nữa và cùng một số chứng chỉ.
select * from doi_chungchi where doi_chcid =2 and doi_id=14477
select * from cap_chungchi where ccc_chcid =2 and ccc_doiid=14477
select * from hocvien where  hov_id = 2630
-- 10. 4109
select * from doi_chungchi where doi_chcid =2 and doi_id=4109
select * from cap_chungchi where ccc_chcid =2 and ccc_doiid=4109
select * from hocvien where  hov_id = 2804
--11. 4109 Hov_ID = 2774 không tồn tại trong dữ liệu đổi DOI_CHCID=2
	-- delete Cap_ChungChi.CHC_ID = 5214
select * from doi_chungchi where doi_chcid =2 and doi_id=4109
select * from cap_chungchi where ccc_chcid =2 and ccc_doiid=4109
select * from hocvien where  hov_id = 2774
--12. 4110 
select * from doi_chungchi where doi_chcid =2 and doi_id=4110
select * from cap_chungchi where ccc_chcid =2 and ccc_doiid=4110
select * from hocvien where  hov_id = 2798
