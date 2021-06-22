using DAL.Abstract;
using DATA.Context;
using System;
using System.Collections.Generic;

using System.Text;

namespace DAL.Concrete
{
   public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ERPContext db;

        public UnitOfWork(ERPContext _ctx)
        {
            db = _ctx;

            Cars = new CarRepository(db);
        }


        public ICarRepository Cars { get; set; }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}
