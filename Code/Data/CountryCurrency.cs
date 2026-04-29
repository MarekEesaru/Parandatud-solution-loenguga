using Abc.Data.Common;
using Abc.Aids;

namespace Abc.Data
{
    public class CountryCurrency : DetailedEntity
    {
        [Select(typeof(Country), nameof(Country.Code))]public Guid? CountryId { get; set; }
        [Select(typeof(Currency))]public Guid? CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public Country Country { get; set; }
    }
}