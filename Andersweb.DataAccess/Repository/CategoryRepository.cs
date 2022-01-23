using Andersweb.DataAccess.Data;
using Andersweb.DataAccess.Repository.IRepository;
using Andersweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andersweb.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            var objFromDb =_db.Category.FirstOrDefault(u=> u.Id == category.Id);
            objFromDb.Name = category.Name;
            objFromDb.DisplayOrder = category.DisplayOrder;
            

        }
    }
}
