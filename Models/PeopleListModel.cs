using MoviesDomain.Entities;
using System.Collections.Generic;

namespace MovieService.Models
{
    public class PeopleListModel
    {
        public IEnumerable<People> people;

        public PagingInfo pagingInfo;
    }
}