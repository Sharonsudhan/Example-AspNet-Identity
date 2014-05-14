﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter1.models;

namespace Chapter1.Data.Infrastructure
{
    public interface IDatabaseFactory
    {
        ChapterContext Get();
    }
}
