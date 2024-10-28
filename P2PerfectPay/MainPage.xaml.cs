namespace P2PerfectPay
{
    public partial class MainPage : ContentPage
    {
        decimal bill;
        int tip;
        int numPersons = 1;

        public MainPage()
        {
            InitializeComponent();
        }

        private void txtBill_Completed(object sender, EventArgs e)
        {
            bill = decimal.Parse(txtBill.Text);
            CalculateTotal();
        }
        private void CalculateTotal()
        {
            //Total propina
            var totalTip = (bill * tip) / 100;

            //Propina por persona
            var tipByperson = (totalTip / numPersons);
            lblTipByPerson.Text = $"{tipByperson:C}";

            //Subtotal
            var subtotal = (bill / numPersons);
            lblSubtotal.Text = $"{subtotal:C}";

            //Total
            var totalByPerson = (bill + totalTip) / numPersons;
            lblTotal.Text = $"{totalByPerson:C}";
        }

        private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            tip = (int)sldTip.Value;
            lblTip.Text = $"Tip: {tip}%";
            CalculateTotal();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                var btn = (Button)sender;
                var percentage = int.Parse(btn.Text.Replace("%", ""));
                sldTip.Value = percentage;
            }
        }

        private void btnMinus_Clicked(object sender, EventArgs e)
        {
            if(numPersons > 1)
            {
                numPersons--;
            }
            lblNumPersons.Text = numPersons.ToString();
            CalculateTotal();
        }

        private void btnPlus_Clicked(object sender, EventArgs e)
        {
            numPersons++;
            lblNumPersons.Text = numPersons.ToString();
            CalculateTotal();
        }
    }

}
