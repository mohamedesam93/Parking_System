using DAL.Abstract;
using DATA.Context;
using DATA.Entities;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading;

namespace DAL.Concrete
{
   public class CarRepository : ICarRepository
    {
        private ERPContext db;


        public CarRepository(ERPContext _ctx)
        {
            db = _ctx;
        }

        public string RegisterCarToGate(int CarId)
        {
            var car = db.Cars.Find(CarId);
            if (car != null)
            {
                db.AccessCards.Add(new AccessCard { CarId = CarId, OpeningBalance = 10 });
                Commit();
                return "Success";
            }

            return "Failed";
        }

        public int GetRemainingBalance(int CarId)
        {
            var Card = db.AccessCards.FirstOrDefault(a => a.CarId == CarId);

            if (Card!= null)
            {
                return Card.Balance;
            }

            return 0;
        }

        public void PassesThroughGate(int CarId)
        {
            var Card = db.AccessCards.FirstOrDefault(a => a.CarId == CarId);
            var LastTransitForThisCar = db.HistoryTransits.OrderByDescending(a=>a.TimeOfPassing).LastOrDefault(a => a.CarId == CarId && a.TimeOfPassing ==DateTime.Now.Date);

            if (Card != null)
            {
                if (Card.OpeningBalance >= 4)
                {
                    if (LastTransitForThisCar != null)
                    {
                        if (DateTime.Now.TimeOfDay.Subtract(LastTransitForThisCar.TimeOfPassing.TimeOfDay).Minutes > 1)
                        {
                         Card.Balance = Card.OpeningBalance - 4;
                         db.HistoryTransits.Add(new HistoryTransit { CarId = CarId, TimeOfPassing = DateTime.Now });
                         Commit();
                 
                        }
                    }
                    else
                    {
                        Card.Balance = Card.OpeningBalance - 4;
                        db.HistoryTransits.Add(new HistoryTransit { CarId = CarId, TimeOfPassing = DateTime.Now });
                        Commit();
                    }
                                   
                }              
            }

        }

        public bool Add_Obj(Car item)
        {
            db.Cars.Add(item);
            
            return Commit();
        }

        public bool Delete_Obj(int id)
        {
         var car =  db.Cars.Find(id);
                    db.Cars.Remove(car);

            return Commit();
        }

        public bool Edit_Obj(Car item)
        {
            db.Cars.Update(item);

            return Commit();
        }

        public IEnumerable<Car> GetAll()
        {
            return db.Cars.ToList();
        }

        public bool Commit()
        {
            return db.SaveChanges() > 0 ? true : false;
        }

       
    }
}
