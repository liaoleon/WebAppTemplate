﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTemplate.Repo.Interface
{
    public interface IOrderRepo
    {
        List<Orders> GetAll();
        void Add(Orders model);
        void Edit(Orders model);
        void Delete(int id);
    }
}