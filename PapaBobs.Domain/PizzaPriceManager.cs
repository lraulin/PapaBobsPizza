using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobs.DTO;
using PapaBobs.DTO.Enums;
using PapaBobs.Persistence;

namespace PapaBobs.Domain
{
    public class PizzaPriceManager
    {
        public static decimal CalculateCost(OrderDTO order)
        {
            decimal cost = 0M;
            var prices = PizzaPriceRepository.GetPizzaPrices();

            cost += CalculateSizeCost(order, prices);
            cost += CalculateCrustCost(order, prices);
            cost += CalculateToppingsCost(order, prices);

            return cost;
        }

        private static decimal CalculateToppingsCost(OrderDTO order, PizzaPriceDTO prices)
        {
            decimal cost = 0M;
            cost += (order.Sausage) ? prices.SausageCost : 0M;
            cost += (order.Pepperoni) ? prices.PepperoniCost : 0M;
            cost += (order.Onions) ? prices.OnionsCost : 0M;
            cost += (order.GreenPeppers) ? prices.GreenPeppersCost : 0M;

            return cost;
        }

        private static decimal CalculateCrustCost(OrderDTO order, PizzaPriceDTO prices)
        {
            decimal cost = 0M;

            switch (order.Crust)
            {
                case CrustType.Regular:
                    cost = prices.RegularCrustCost;
                    break;
                case CrustType.Thick:
                    cost = prices.ThickCrustCost;
                    break;
                case CrustType.Thin:
                    cost = prices.ThinCrustCost;
                    break;
                default:
                    throw new InvalidOperationException("No valid crust thickness information.");
            }

            return cost;
        }

        private static decimal CalculateSizeCost(OrderDTO order, PizzaPriceDTO prices)
        {
            decimal cost;

            switch (order.Size)
            {
                case SizeType.Small:
                    cost = prices.SmallSizeCost;
                    break;
                case SizeType.Medium:
                    cost = prices.MediumSizeCost;
                    break;
                case SizeType.Large:
                    cost = prices.LargeSizeCost;
                    break;
                default:
                    throw new InvalidOperationException("No valid pizza size information.");
            }

            return cost;
        }
    }
}
