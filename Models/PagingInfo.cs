using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieService.Models
{
    public class PagingInfo
    {
        public int CurrentPage;

        public int ItemsPerPage;

        public int TotalPages;

        public PagingInfo(int currentPage, int itemPerPage, int totalItems)
        {
            CurrentPage = currentPage;
            ItemsPerPage = itemPerPage;
            TotalPages = (int)((double)totalItems/(double)ItemsPerPage);
        }

    }
}