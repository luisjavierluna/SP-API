using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class PagedDepartmentsSpecification : Specification<Department>
    {
        public PagedDepartmentsSpecification(int pageNumber, int pageSize
                //, string name
            )
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            //if (!string.IsNullOrEmpty(name))
            //    Query.Search(x => x.Name, "%" + name + "%");
        }
    }
}
