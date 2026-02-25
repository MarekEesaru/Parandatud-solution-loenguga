using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abc.Data;

public class  Currency
{
    public int Id { get; set; }
    public string Code { get; set; }   //EUR
    public string Name { get; set; }   //Euro
    public string Symbol { get; set; } //€
    [Column(TypeName = "decimal(18, 4)")]
    public decimal ExchangeRate { get; set; }
}
