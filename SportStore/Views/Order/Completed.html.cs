using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SportStore.Pages
{
    public class CompletedModel : PageModel
    {
        public int OrderId { get; set; }

        public void OnGet(int orderId)
        {
            OrderId = orderId;
        }
    }
}