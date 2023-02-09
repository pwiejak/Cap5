using Microsoft.AspNetCore.Components;

namespace CapFive.Web.Pages.Common
{
    public class ModalBase : BaseComponent
    {
        [Parameter]
        public RenderFragment Title { get; set; }

        [Parameter]
        public RenderFragment Body { get; set; }

        [Parameter]
        public RenderFragment Footer { get; set; }



        protected string modalDisplay = "none;";
        protected string modalClass = "";
        protected bool showBackdrop = false;

        public void Open()
        {
            modalDisplay = "block;";
            modalClass = "show";
            showBackdrop = true;
        }

        public void Close()
        {
            modalDisplay = "none";
            modalClass = "";
            showBackdrop = false;
        }
    }
}
