﻿using System;
using System.Collections.Generic;
using System.Text;

namespace myeshop.Application.Dtos
{
    public class PagedResult <T>
    {
        public List<T> Items { get; set; }
        public int TotalRecord { get; set; }
    }
}