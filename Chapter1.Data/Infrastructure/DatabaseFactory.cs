using Chapter1.models;
using System;
//using Microsoft

namespace Chapter1.Data.Infrastructure
{
    public class DatabaseFactory: IDatabaseFactory
    {
        private ChapterContext dataContext;
        public ChapterContext Get()
        {
            return dataContext ?? (dataContext = new ChapterContext());
        }
        //protected override void DisposeCore()
        //{
        //    if (dataContext != null)
        //        dataContext.Dispose();
        //}

    }
}
