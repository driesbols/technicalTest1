﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTest.Domain
{
    public class Address
    {
        public string Countryname { get; set; }
        public int CountryNisCode { get; set; }
        public string CityName { get; set; }
        public string CityZipCode { get; set; }
        public string StreetName { get; set; }
        public string houseNr { get; set; }
        public string boxNr { get; set; }
    }
}
