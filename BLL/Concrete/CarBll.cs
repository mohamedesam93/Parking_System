using AutoMapper;
using BLL.Abstract;
using BLL.Validator;
using BLL.ViewModels;
using DAL.Abstract;
using DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace  BLL.Concrete
{
    public class CarBll : ICarBll
    {


        private readonly IUnitOfWork db;
        private readonly IMapper _mapper;
        private readonly CarViewModelValidator CarValidator;


        public CarBll(IUnitOfWork unitofwork, IMapper mapper, CarViewModelValidator validator)
        {
            db = unitofwork;
            _mapper = mapper;
            CarValidator = validator;
        }

        public bool AddCar(CarViewModel PostedObject)
        {

            try
            {
                if (CarValidator.Validate(PostedObject).IsValid)
                {
                    var data = _mapper.Map<Car>(PostedObject);

                    var res = db.Cars.Add_Obj(data);

                    return res;

                }

                return false;
            }
            catch (Exception e)
            {

                throw e;
            }
           

        }

        public bool DeleteCar(int id)
        {
            try
            {
                var res = db.Cars.Delete_Obj(id);
                return res;
            }
            catch (Exception e)
            {

                throw e;
            }
          
        }

        public bool EditCar(CarViewModel PostedObject)
        {
            try
            {
                if (CarValidator.Validate(PostedObject).IsValid)
                {
                    var data = _mapper.Map<Car>(PostedObject);

                    var res = db.Cars.Edit_Obj(data);

                    return res;

                }

                return false;
            }
            catch (Exception e)
            {

                throw e;
            }        
        
        }

        public IEnumerable<CarViewModel> GetAll()
        {
            var Cars = db.Cars.GetAll();

            var data = _mapper.Map<IEnumerable<CarViewModel>>(Cars);

            return data;
        }

        public int GetRemainingBalance(int CarId)
        {
            try
            {
                var res = db.Cars.GetRemainingBalance(CarId);
                return res;
            }
            catch (Exception e)
            {
                throw e;
            }
           
        }

        public void PassesThroughGate(int CarId)
        {
            try
            {
               db.Cars.PassesThroughGate(CarId);

            }
            catch (Exception e)
            {
                throw e;
            }
                
          }

        public string RegisterCarToGate(int CarId)
        {
            try
            {
            var res =  db.Cars.RegisterCarToGate(CarId);
             
                return res;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
