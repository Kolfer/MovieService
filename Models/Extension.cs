using System.Data.Entity;
using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Collections;
using MoviesDomain.Entities;
using MoviesDomain.Abstract;

namespace MovieService.Models
{
    public static class Extension
    {

        //----------------------------------------------------------------//

        public static T FirstOrNull<T>(this DbSet<T> set, Func<T,bool> action) where T : class
        {
            T item = null;
            try
            {
                item = set.First(action);
            }
            catch(Exception)
            {
                item = null;
            }
            return item;
        }

        //----------------------------------------------------------------//

        public static List<Genre> getCurrentGenre(this IEnumerable<Genre> genres)
        {
            List<Genre> list = new List<Genre>();
            foreach (var genre in genres)
            {
                if (!list.Contains(genre))
                {
                    list.Add(genre);
                }
            }
            return list;
        }

        //----------------------------------------------------------------//

        public static IEnumerable<int> getIds<T>(this IRepository repository) where T : class
        {
            int count = repository.Count<T>();
            var items = repository.getItems<T>(count).ToList().Cast<IItemDatabase>();
            return items.Select( item => item.Id);
        }

        //----------------------------------------------------------------//

    }
}