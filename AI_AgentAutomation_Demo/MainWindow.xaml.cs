using System.Windows;

namespace AI_AgentAutomation_Demo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ProcessRequest_Click(object sender, RoutedEventArgs e)
        {
            string input = txtCustomerRequest.Text.ToLower();

            string category = ClassifyRequest(input);
            string response = GenerateResponse(category);

            txtResult.Text = $"Kategori: {category}\nÖnerilen Cevap: {response}";
        }

        private string ClassifyRequest(string text)
        {
            if (text.Contains("fatura") || text.Contains("ödeme"))
                return "Fatura / Ödeme";
            else if (text.Contains("ariza") || text.Contains("bozuk"))
                return "Teknik Destek";
            else if (text.Contains("iptal") || text.Contains("abonelik"))
                return "Abonelik İşlemleri";
            else
                return "Genel";
        }

        private string GenerateResponse(string category)
        {
            switch (category)
            {
                case "Fatura / Ödeme":
                    return "Faturanızla ilgili sorularınız için müşteri hizmetlerimizi 444-1234 numaralı telefondan arayabilirsiniz.";
                case "Teknik Destek":
                    return "Teknik destek talebiniz için lütfen cihazınızı yeniden başlatmayı deneyin. Sorun devam ederse teknik ekibimizle iletişime geçin.";
                case "Abonelik İşlemleri":
                    return "Abonelik iptali veya değişikliği için müşteri temsilcimiz en kısa sürede sizinle iletişime geçecektir.";
                default:
                    return "Talebiniz alındı, en kısa sürede size dönüş yapılacaktır.";
            }
        }
    }
}
