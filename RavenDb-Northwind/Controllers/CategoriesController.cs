using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RavenDb_Northwind.DataAccess;
using RavenDb_Northwind.Domain;
using RavenDb_Northwind.Dtos;

namespace RavenDb_Northwind.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly IDocumentStoreFactory storeFactory;

        public CategoriesController(IDocumentStoreFactory storeFactory)
        {
            this.storeFactory = storeFactory;
        }

        [HttpGet]
        public JsonResult Get()
        {
            using (var session = storeFactory.Store.OpenSession())
            {
                var result = session.Query<Category>().ToList();
                var dto = AutoMapper.Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(result);
                return Json(dto);
            }
        }

    }
}