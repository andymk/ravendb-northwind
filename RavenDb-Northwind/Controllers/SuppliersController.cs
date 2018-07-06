using Microsoft.AspNetCore.Mvc;
using RavenDb_Northwind.DataAccess;
using RavenDb_Northwind.Domain;
using RavenDbNorthwind.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenDbNorthwind.Controllers
{
    [Route("api/[controller]")]
    public class SuppliersController : Controller
    {
        private readonly IDocumentStoreFactory storeFactory;

        public SuppliersController(IDocumentStoreFactory storeFactory)
        {
            this.storeFactory = storeFactory;
        }

        [HttpGet]
        public JsonResult Get()
        {
            using (var session = storeFactory.Store.OpenSession())
            {
                var result = session.Query<Supplier>().ToList();
                var dto = AutoMapper.Mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDto>>(result);
                return Json(dto);
            }
        }
    }
}
