﻿using System.ComponentModel.DataAnnotations.Schema;

namespace PFA_Project.Models
{
    public class FamilleProduit
    {
        public int IdProduit { get; set; }
        public string? LibelleProduit { get; set; }
        public double? Prix { get; set; }
        public string ?Image { get; set; }
        public string LibelleFamille { get; set; }
    
    }
}