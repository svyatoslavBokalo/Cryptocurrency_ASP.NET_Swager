using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoCurrency.Models
{
    //it's a model for a deleted cryptocurrency
    public class DeletedCryptocurrency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Cryptocurrency Crypto { get; set; }
        public int IdCrypto {  get; set; }
    }
}
