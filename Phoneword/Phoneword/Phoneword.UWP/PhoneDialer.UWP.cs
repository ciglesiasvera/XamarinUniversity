using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Phoneword.UWP;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneDialer))]

namespace Phoneword.UWP
{
    public class PhoneDialer : IDialer
    {
        public Task<bool> DialAsync(string number)
        {
            if (ApiInformation.IsApiContractPresent("Windows.ApplicationModel.Calls.CallsPhoneContract", 1,0))
            {
                // Se realiza la llamada
                // Se tiene que corregir la referencia. 
                // Para mayor informacion se puede consultar la siguietne referencia. 
                // http://stackoverflow.com/questions/32396926/how-to-dial-a-number-in-c-sharp-windows-universal-10
                //Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI(number, "Phoneword");

                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}