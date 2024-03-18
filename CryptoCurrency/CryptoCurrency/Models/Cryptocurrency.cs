using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CryptoCurrency.Models
{
    //it's a model in db
    public class Cryptocurrency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? id_text {  get; set; }

        public string? Rank { get; set; }

        public string? Symbol { get; set; }

        public string? Name { get; set; }

        public double? Supply { get; set; }

        public double? MaxSupply { get; set; }

        public double? MarketCapUsd { get; set; }

        public double? VolumeUsd24Hr { get; set; }

        public double? PriceUsd { get; set; }

        public double? ChangePercent24Hr { get; set; }

        public double? Vwap24Hr { get; set; }

        public int? action {  get; set; }
    }
}