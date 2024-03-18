using CryptoCurrency.Models;
using CryptoCurrency.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System;
using CryptoCurrency.Services.Interfaces;
using CryptoCurrency.ApiActions;
using Microsoft.EntityFrameworkCore;

namespace CryptoCurrency.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CryptoController : Controller
    {
        private readonly IRepository repository;
        private readonly ICryptoCurrencyService cryptoService;
        public CryptoController(IRepository _repository, ICryptoCurrencyService currencyService)
        {
            this.repository = _repository;
            this.cryptoService = currencyService;
        }

        //this method get all data
        [HttpGet("GetAllCrypto")]
        public IActionResult GetCrypto()
        {
            string response = "";
            IList<Cryptocurrency> cryptocurrencies = repository.Read();
            if(cryptocurrencies.Count > 0)
            {
                response = SerealizationCrypto(cryptocurrencies);
                return Ok(response);
            }
            else
            {
                cryptoService.GetFromAPI(GeneralConst.СryptocurrencyURL).Wait();
                cryptocurrencies = repository.Read();
                response = SerealizationCrypto(cryptocurrencies);
                return Ok(response);
            }
        }
        //this method serealize data to json
        private string SerealizationCrypto(IList<Cryptocurrency> cryptocurrencies)
        {
            return JsonSerializer.Serialize(cryptocurrencies);
        }

        [HttpGet("sortingBy/{property}")]
        public IActionResult SortingData([FromQuery] string prop)
        {
            return Ok();
        }

        //this method change items in db
        [HttpPut("EditCryptocurrency/{id}")]
        public IActionResult EditCrypto(int id, [FromBody] Cryptocurrency updatedItem)
        {
            if (repository.Edit(id,updatedItem))
            {
                return Ok();
            }
            return new StatusCodeResult(501);
        }

        // this method should delete all data in db
        // it's for me just clean data base
        [HttpDelete("DeleteAll")]
        public IActionResult DeleteAll()
        {
            repository.DeleteAll();
            return Ok();
        }


        //delete just one cryptocurrency 
        [HttpDelete("DeleteID/{id}")]
        public IActionResult DeleteCryptoId(int id)
        {
            if (repository.DeleteId(id))
            {
                return Ok();
            }
            return new StatusCodeResult(501);
        }

    }
}
