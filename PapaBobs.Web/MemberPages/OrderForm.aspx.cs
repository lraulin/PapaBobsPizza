using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PapaBobs.DTO;
using PapaBobs.DTO.Enums;
using PapaBobs.Domain;

namespace PapaBobs.Web
{
    public partial class OrderForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OrderButton_Click(object sender, EventArgs e)
        {
            if (!TextBoxDataIsValid())
            {
                return;
            }

            OrderDTO orderDTO = BuildOrder();

            OrderManager.CreateOrder(orderDTO);
            Response.Redirect("Success.aspx");
        }

        private OrderDTO BuildOrder()
        {
            OrderDTO orderDTO = new OrderDTO();
            orderDTO.Size = DetermineSize();
            orderDTO.Crust = DetermineCrust();
            orderDTO.Pepperoni = pepperoniCheckBox.Checked;
            orderDTO.Onions = onionCheckBox.Checked;
            orderDTO.GreenPeppers = greenCheckBox.Checked;
            orderDTO.PaymentType = DeterminePayment();
            orderDTO.Name = nameTextBox.Text;
            orderDTO.Address = addressTextBox.Text;
            orderDTO.ZipCode = zipCodeTextBox.Text;
            orderDTO.Phone = phoneTextBox.Text;
            return orderDTO;
        }

        private bool TextBoxDataIsValid()
        {
            if (nameTextBox.Text.Trim().Length == 0)
            {
                TextBoxValidationError("name");
                return false;
            }
            else if (addressTextBox.Text.Trim().Length == 0)
            {
                TextBoxValidationError("address");
                return false;
            }
            else if (zipCodeTextBox.Text.Trim().Length == 0)
            {
                TextBoxValidationError("zip code");
                return false;
            }
            else if (phoneTextBox.Text.Trim().Length == 0)
            {
                TextBoxValidationError("phone number");
                return false;
            }
            else
            {
                return true;
            }
        }

        SizeType DetermineSize()
        {
            SizeType size;
            if (!Enum.TryParse(sizeDropDown.SelectedValue, out size))
            {
                throw new Exception("Could not determine Pizza size.");
            }
            return size;
        }

        CrustType DetermineCrust()
        {
            CrustType crust;
            if (!Enum.TryParse(crustDropDown.SelectedValue, out crust))
            {
                throw new Exception("Could not determine Pizza crust.");
            }

            return crust;
        }

        PaymentType DeterminePayment()
        {
            PaymentType paymentMethod;
            if (cashRadio.Checked) paymentMethod = PaymentType.Cash;
            else paymentMethod = PaymentType.Credit;
            return paymentMethod;
        }

        void TextBoxValidationError(string errorType)
        {
            string errorMessage = "";
            errorMessage += string.Format("<strong>Please enter a {0}.</strong>", errorType);
            validationLabel.Text = errorMessage;
            validationLabel.Visible = true;
        }

        protected void RecalculateTotalCost(object sender, EventArgs e)
        {
            if (sizeDropDown.SelectedValue == "" || crustDropDown.SelectedValue == "")
            {
                return;
            }

            var order = BuildOrder();
            decimal cost = PizzaPriceManager.CalculateCost(order);
            resultLabel.Text = string.Format("<h3>{0:C}</h3>", cost);
        }
    }
}