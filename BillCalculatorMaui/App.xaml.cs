using BillCalculator;

namespace BillCalculatorMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage(); // Указываем, что при запуске открывается MainPage
        }
    }

}