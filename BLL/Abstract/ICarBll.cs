using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
   public interface ICarBll
    {
        string RegisterCarToGate(int CarId);
        int GetRemainingBalance(int CarId);
        void PassesThroughGate(int CarId);
        bool AddCar(CarViewModel PostedObject);
        bool EditCar(CarViewModel PostedObject);
        IEnumerable<CarViewModel> GetAll();
        bool DeleteCar(int id);


    }
}
