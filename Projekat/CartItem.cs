﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat
{
    public class CartItem
    {
        public int ProizvodId { get; set; }
        public string Naziv { get; set; }
        public decimal Cena { get; set; }
        public int Kolicina { get; set; }
        public decimal Ukupno => Cena * Kolicina;
    }
}
