using QLHV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLHV.Controllers
{
    [RoutePrefix("api/HOCVIENs")]
    public class HOCVIENsController : ApiController
    {
        private HocVienDbContext db = new HocVienDbContext();



        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var query = (from x in db.HOCVIENs select x
                         ).ToList();
            return Ok(query);


        }

        [HttpGet]
        [Route("danhsach")]
        public IHttpActionResult GetHOCVIEN(string keyword, int page, int pageSize)
        {
            int TotalCount = (from x in db.HOCVIENs
                         where x.HOV_FullName.ToLower().Contains(keyword.ToLower())
                         || x.HOV_FirstName.ToLower().Contains(keyword.ToLower())
                         || x.HOV_LastName.ToLower().Contains(keyword.ToLower())
                         || x.HOV_Phone.ToLower().Contains(keyword.ToLower())
                         || x.HOV_BirthDay.ToLower().Contains(keyword.ToLower())
                         || x.HOV_Code.ToLower().Contains(keyword.ToLower())
                         || keyword == null
                         select x).Count();
            int totalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);
            var result = (from x in db.HOCVIENs
                         where x.HOV_FullName.ToLower().Contains(keyword.ToLower())
                         || x.HOV_FirstName.ToLower().Contains(keyword.ToLower())
                         || x.HOV_LastName.ToLower().Contains(keyword.ToLower())
                         || x.HOV_Phone.ToLower().Contains(keyword.ToLower())
                         || x.HOV_BirthDay.ToLower().Contains(keyword.ToLower())
                         || x.HOV_Code.ToLower().Contains(keyword.ToLower())
                         || keyword == null
                         select new { 
                             HOV_ID = x.HOV_ID,
                             HOV_FullName = x.HOV_FullName,
                             HOV_BirthDay = x.HOV_BirthDay,
                             HOV_NoiSinh = x.HOV_NoiSinh,
                             HOV_Phone=x.HOV_Phone,
                             HOV_QueQuan = (from b in db.TINHs where b.TIN_ID == x.HOV_NoiSinh select b.TIN_Name).FirstOrDefault(),
                             HOV_QuocTich = x.HOV_QuocTich,
                             IMG_Image = (from a in db.HOCVIEN_IMGs where (a.IMG_HOVID == x.HOV_ID) select a.IMG_Image).FirstOrDefault()
                         }).OrderByDescending(x=>x.HOV_ID).Skip((page) * pageSize).Take(pageSize).ToList();
            return Ok(new
            {
                Page = page,
                TotalCount,
                totalPages,
                result                
            });


        }
        [HttpGet]
        [Route("chitiet")]
        public IHttpActionResult GetHOCVIEN(int id)
        {
            var query = (from x in db.HOCVIENs
                         where x.HOV_ID == id
                         select new
                         {
                             HOV_ID = x.HOV_ID,
                             HOV_FullName = x.HOV_FullName,
                             HOV_BirthDay = x.HOV_BirthDay,
                             HOV_NoiSinh = x.HOV_NoiSinh,
                             HOV_QueQuan = (from b in db.TINHs where b.TIN_ID == x.HOV_NoiSinh select b.TIN_Name).FirstOrDefault(),
                             HOV_QuocTich = x.HOV_QuocTich,
                             IMG_Image = (from a in db.HOCVIEN_IMGs where (a.IMG_HOVID == x.HOV_ID) select a.IMG_Image).FirstOrDefault(),
                             LISTCHUNGCHI = (from x2 in db.CHUNG_CHIs
                                             join x3 in db.CAP_CHUNGCHIs on x2.CHC_ID equals x3.CCC_CHCID
                                             where x3.CCC_HOVID == id
                                             select new
                                             {
                                                 CCC_SoCC = x3.CCC_SoCC,
                                                 CCC_NgayCap = x3.CCC_NgayCap,
                                                 CCC_NgayHetHan = x3.CCC_NgayHetHan,
                                                 CCC_Status = x3.CCC_Status,//CCC_Status =1 => "Cấp mới"| CCC_Status = 2 => "Cấp đổi" | CCC_Status = 3 =>"Cấp lại"
                                                 CHC_Name = x2.CHC_Name
                                             }
                                ).ToList()
                         }).FirstOrDefault();
            return Ok(query);
        }          
    }
}
