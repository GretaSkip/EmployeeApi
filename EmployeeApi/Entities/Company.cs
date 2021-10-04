﻿using System.Collections.Generic;

namespace EmployeeApi.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
