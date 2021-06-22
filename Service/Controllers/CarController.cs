using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstract;
using BLL.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Service.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarBll CarBll;
        private readonly ILogger<CarController> _logger;

        public CarController(ICarBll _CarBll , ILogger<CarController> logger)
        {
            CarBll = _CarBll;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var data = CarBll.GetAll();
                return Ok(data);
            }
            catch (Exception e)
            {
              var  Message = $"{e.Message}   {DateTime.UtcNow.ToLongTimeString()}";       
                _logger.LogInformation(Message);

                throw e;

            }

        }

        [HttpPost]
        public IActionResult AddData(CarViewModel PostedObject)
        {
            try
            {
                var res = CarBll.AddCar(PostedObject);
                return Ok(res);

            }
            catch (Exception e)
            {
                var Message = $"{e.Message} {DateTime.UtcNow.ToLongTimeString()}";
                _logger.LogInformation(Message);

                throw e;
            }

        }

        [HttpPut]
        public IActionResult EditData(CarViewModel PostedObject)
        {

            try
            {
                var res = CarBll.EditCar(PostedObject);
                return Ok(res);

            }
            catch (Exception e)
            {
                var Message = $"{e.Message}   {DateTime.UtcNow.ToLongTimeString()}";
                _logger.LogInformation(Message);
                throw e;
            }
        }

        [HttpDelete]
        public IActionResult DeleteData(List<int> ids)
        {
            try
            {
                foreach (var item in ids)
                {
                    CarBll.DeleteCar(item);

                }

            }

            catch (Exception e)
            {
                var Message = $"{e.Message}   {DateTime.UtcNow.ToLongTimeString()}";
                _logger.LogInformation(Message);

                throw e;
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult GetRemainingBalance(int CarId)
        {
            try
            {
                var data = CarBll.GetRemainingBalance(CarId);

                return Ok(data);
            }
            catch (Exception e)
            {
                var Message = $"{e.Message}   {DateTime.UtcNow.ToLongTimeString()}";
                _logger.LogInformation(Message);

                throw e;
            }

        }

        [HttpGet]
        public IActionResult RegisterCarToGate(int CarId)
        {
            try
            {
                CarBll.RegisterCarToGate(CarId);

                return Ok();
            }
            catch (Exception e)
            {
                var Message = $"{e.Message}   {DateTime.UtcNow.ToLongTimeString()}";
                _logger.LogInformation(Message);

                throw e;
            }

        }


        [HttpGet]
        public IActionResult PassesThroughGate(int CarId)
        {
            try
            {
                CarBll.PassesThroughGate(CarId);
                return Ok();
            }
            catch (Exception e)
            {
                var Message = $"{e.Message}   {DateTime.UtcNow.ToLongTimeString()}";
                _logger.LogInformation(Message);

                throw e;
            }

        }
    }
}
