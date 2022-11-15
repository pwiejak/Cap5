using Microsoft.AspNetCore.Components;

namespace CapFive.Web.Shared
{
    public class MainLayoutBase : LayoutComponentBase
    {
        public EventCallback<string> DisplayMessage => EventCallback.Factory.Create<string>(this, ShowToast);
        public EventCallback<string> DisplayError => EventCallback.Factory.Create<string>(this, ShowError);

        public string? InfoMessage { get; set; }
        public string? ErrorMessage { get; set; }

        public async Task ShowToast(string message)
        {
            ErrorMessage = "";
            InfoMessage = message;
            StateHasChanged();
            await Task.Delay(2000);
            InfoMessage = "";
            StateHasChanged();
        }

        public async Task ShowError(string message)
        {
            InfoMessage = "";
            ErrorMessage = message;
            StateHasChanged();
            await Task.Delay(2000);
            ErrorMessage = "";
            StateHasChanged();
        }
    }
}
