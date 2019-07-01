using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordsService _salesRecordsService;

        public SalesRecordsController(SalesRecordsService salesRecordsService)
        {
            _salesRecordsService = salesRecordsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Mètodo para busca de registro de venda
        /// </summary>
        /// <param name="minDate"></param>
        /// <param name="maxDate"></param>
        /// <returns>Retorna o método que busca as vendas por data</returns>
        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            //Passando os dados para a View com dicionário ViewData
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordsService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        /// <summary>
        /// Método de busca agrupando as vendas por departamento
        /// </summary>
        /// <param name="minDate"></param>
        /// <param name="maxDate"></param>
        /// <returns>Retorna o método que busca as vendas por data, adiconando um GroupBy Department na consulta</returns>
        public async Task<IActionResult> SimpleGroup(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            //Passando os dados para a View com dicionário ViewData
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _salesRecordsService.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }
    }
}