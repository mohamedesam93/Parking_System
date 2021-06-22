using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Abstract
{
   public interface ICarRepository
    {

        string RegisterCarToGate(int CarId);
        int GetRemainingBalance(int CarId);
        void PassesThroughGate(int CarId);
        IEnumerable<Car> GetAll();   
        bool Add_Obj(Car item);
        bool Edit_Obj(Car item);
        bool Delete_Obj(int id);
        bool Commit();

    }
}
