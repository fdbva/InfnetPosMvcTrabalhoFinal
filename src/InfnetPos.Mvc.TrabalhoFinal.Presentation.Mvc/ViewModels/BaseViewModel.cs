using System;
using System.ComponentModel.DataAnnotations;

namespace InfnetPos.Mvc.TrabalhoFinal.Presentation.Mvc.ViewModels
{
    public class BaseViewModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}