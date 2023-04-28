using ASM_APPLICATION_DEV.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace ASM_APPLICATION_DEV.DTOs.Responses
{
    public class BookView
    {
        public int Id { get; set; }
        public string NameBook { get; set; } = string.Empty;
        public int QuantityBook { get; set; }
        public int PriceBook { get; set; }
        public string DescriptionBook { get; set; } = string.Empty;
        public string ImageBook { get; set; } = string.Empty;
    }
}
