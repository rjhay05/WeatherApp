using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace WeatherApp.Helpers
{
    [HtmlTargetElement("script", Attributes = "on-content-loaded")]
    public class ScriptTagHelper : TagHelper
    {
        private bool OnContentLoaded { get; set; } = false;
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
           if(!OnContentLoaded)
            {
                base.Process(context, output);
                return;
            }
            else
            {
                var content = output.GetChildContentAsync().Result;
                var script = content.GetContent();
                var sb = new StringBuilder();
                sb.Append("document.addEventListener.('DOMContentLoaded',");
                sb.Append("function(){");
                sb.Append(script);
                sb.Append("});");
                output.Content.SetHtmlContent(sb.ToString());
            }
        }
    }
}
