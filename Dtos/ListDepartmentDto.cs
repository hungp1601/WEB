using System;
using System.Collections.Generic;
using System.Linq;
using NHNT.Constants;
using NHNT.Models;

namespace NHNT.Dtos
{
    public class ListDepartmentDto
    {
        public DepartmentDto[] data { get; set; }
        public int total { get; set; }
        public ListDepartmentDto(DepartmentDto[] _data, int _total)
        {
            this.data = _data;
            this.total = _total;
        }
    }
}