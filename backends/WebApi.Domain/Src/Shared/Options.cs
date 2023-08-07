using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Domain.Src.Shared
{
    public class Options
    {
        public string  searching { get; set; } = String.Empty;
        public string OrderBy { get; set;} = "UpdatedAt";
        public bool OrderByDescending { get; set;} = false;
        public int PagNumber { get; set; } = 1;
        public int PerPage { get; set; } = 25;
    }
}