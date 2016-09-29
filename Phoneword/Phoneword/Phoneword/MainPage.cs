using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Phoneword
{
    public class MainPage : ContentPage
    {
        Entry txtPhoneNumber;
        Button btnTranslate;
        Button btnCallButton;
        string translatedNumber;

        public MainPage()
        {
            this.Padding = new Thickness(20,Device.OnPlatform<double>(40, 20, 20), 20, 20);

            StackLayout panel = new StackLayout {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Vertical,
                Spacing = 15
            };

            panel.Children.Add(new Label{
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Enter the Phoneword"
            });

            panel.Children.Add(txtPhoneNumber = new Entry
            {
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "1-855-XAMARIN",
            });

            panel.Children.Add(btnTranslate = new Button {
                Text = "Translate"
            });

            panel.Children.Add(btnCallButton = new Button {
                Text = "Call",
                IsEnabled = false
            });

            btnTranslate.Clicked += BtnTranslate_Clicked;

            btnCallButton.Clicked += BtnCallButton_Clicked;

            this.Content = panel;   
        }

        async private void BtnCallButton_Clicked(object sender, EventArgs e)
        {
            if (await this.DisplayAlert(
                "Llamar al telefono",
                "Quieres marcar al numero " + txtPhoneNumber.Text + " ?",
                "Yes",
                "No"))
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)                
                    await dialer.DialAsync(translatedNumber);
                
            }
        }

        private void BtnTranslate_Clicked(object sender, EventArgs e)
        {
            string enteredNumber = txtPhoneNumber.Text;
            translatedNumber = PhonewordTranslator.ToNumber(enteredNumber);

            if (!string.IsNullOrWhiteSpace(translatedNumber))
            {
                btnCallButton.IsEnabled = true;
                btnCallButton.Text = "Call "+ translatedNumber;
            }
            else
            {
                btnCallButton.IsEnabled = false;
                btnCallButton.Text = "Incorrect numbers";
            }
        }
    }
}
