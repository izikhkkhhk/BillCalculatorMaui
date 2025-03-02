using System;
using Microsoft.Maui.Controls;

namespace BillCalculator
{
    public partial class MainPage : ContentPage
    {
        private double billAmount = 0;
        private double tipPercentage = 0;
        private int peopleCount = 1;

        public MainPage()
        {
            InitializeComponent();
            UpdateTotals();
        }

        private void OnBillAmountChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(e.NewTextValue, out double value) && value >= 0)
            {
                billAmount = value;
            }
            else
            {
                billAmount = 0;
                billEntry.Text = "0"; // Предотвращение некорректного ввода
            }
            UpdateTotals();
        }

        private void OnTipPercentageChanged(object sender, EventArgs e)
        {
            if (sender is Button button && double.TryParse(button.Text.Trim('%'), out double value))
            {
                tipPercentage = value / 100;
                tipSlider.Value = value; // Обновляем положение слайдера
                UpdateTotals();
            }
        }

        private void OnSliderChanged(object sender, ValueChangedEventArgs e)
        {
            tipPercentage = e.NewValue / 100;
            tipPercentageLabel.Text = $"{e.NewValue:0}%"; // Отображаем значение рядом со слайдером
            UpdateTotals();
        }

        private void OnPeopleCountChanged(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Text == "+")
                {
                    peopleCount++;
                }
                else if (button.Text == "-" && peopleCount > 1)
                {
                    peopleCount--;
                }

                peopleLabel.Text = peopleCount.ToString();
                UpdateTotals();
            }
        }

        private void UpdateTotals()
        {
            double tipAmount = billAmount * tipPercentage;
            double totalAmount = billAmount + tipAmount;
            double perPerson = peopleCount > 0 ? totalAmount / peopleCount : 0;

            totalLabel.Text = "$" + perPerson.ToString("0.00");
            subtotalLabel.Text = "$" + billAmount.ToString("0.00");
            tipLabel.Text = "$" + tipAmount.ToString("0.00");
        }
    }
}
