using PapaBobs.DTO;
using System.Linq;

namespace PapaBobs.Persistence
{
    public class PizzaPriceRepository
    {
        public int Id { get; set; }
        public decimal SmallSizeCost { get; set; }
        public decimal MediumSizeCost { get; set; }
        public decimal LargeSizeCost { get; set; }
        public decimal ThickCrustCost { get; set; }
        public decimal ThinCrustCost { get; set; }
        public decimal RegularCrustCost { get; set; }
        public decimal SausageCost { get; set; }
        public decimal PepperoniCost { get; set; }
        public decimal OnionsCost { get; set; }
        public decimal GreenPeppersCost { get; set; }

        public static PizzaPriceDTO GetPizzaPrices()
        {
            var db = new PapaBobsDbEntities1();
            var prices = db.PizzaPrices.First();

            var dto = ConvertToDTO(prices);
            return dto;
        }

        static PizzaPriceDTO ConvertToDTO(PizzaPrice pizzaPrice)
        {
            var dto = new PizzaPriceDTO();

            dto.LargeSizeCost = pizzaPrice.LargeSizeCost;
            dto.MediumSizeCost = pizzaPrice.MediumSizeCost;
            dto.SmallSizeCost = pizzaPrice.SmallSizeCost;
            dto.ThinCrustCost = pizzaPrice.ThinCrustCost;
            dto.RegularCrustCost = pizzaPrice.RegularCrustCost;
            dto.ThickCrustCost = pizzaPrice.ThickCrustCost;
            dto.SausageCost = pizzaPrice.SausageCost;
            dto.PepperoniCost = pizzaPrice.PepperoniCost;
            dto.OnionsCost = pizzaPrice.OnionsCost;
            dto.GreenPeppersCost = pizzaPrice.GreenPeppersCost;

            return dto;
        }
    }
}
