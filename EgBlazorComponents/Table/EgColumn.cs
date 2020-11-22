using Microsoft.AspNetCore.Components;

namespace EgBlazorComponents.Table
{
    public class EgColumn : EgColumnBase
    {
        [Parameter]
        public string Field { get; set; }

        [Parameter]
        public RenderFragment<object> Template { get; set; }
    }
}
