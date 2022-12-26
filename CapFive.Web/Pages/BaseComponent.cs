using Microsoft.AspNetCore.Components;

namespace CapFive.Web.Pages
{
    public abstract class BaseComponent : ComponentBase
    {
        [CascadingParameter(Name = "InfoToastEvent")]
        public EventCallback<string> DisplayMessage { get; set; }

        [CascadingParameter(Name = "ErrorToastEvent")]
        public EventCallback<string> DisplayError { get; set; }
    }
}
