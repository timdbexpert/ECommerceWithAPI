﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_MVC.Helper
{
    public class PagedData<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
