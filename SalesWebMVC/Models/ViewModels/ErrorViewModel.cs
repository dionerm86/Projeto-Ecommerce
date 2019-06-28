using System;

namespace SalesWebMVC.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string Message { get; set; }

        //M�todo para verificar se o id do request existe
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}