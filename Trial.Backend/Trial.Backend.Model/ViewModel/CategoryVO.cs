using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.Backend.Model.ViewModel
{
    public class CategoryVO
    {
        public string Result { get; set; }

        public string ErrorMsg { get; set; }

        public List<Category> Data { get; set; }
    }

    public class Category
    {
        public string SubjectId { get; set; }

        public string SubjectName { get; set; }
    }
}
