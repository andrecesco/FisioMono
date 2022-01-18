using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Fisioterapia.Web.Extensions
{
    public class RadioButtonTagHelper : TagHelper
    {
        public string RadioId { get; set; }
        public string RadioFor { get; set; }
        public string RadioName { get; set; }
        public string RadioValueChecked { get; set; }
        public string RadioOptions { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (output == null)
                throw new ArgumentNullException(nameof(output));
            if (string.IsNullOrWhiteSpace(RadioId))
                throw new ArgumentException(nameof(RadioId));
            if (string.IsNullOrWhiteSpace(RadioFor))
                throw new ArgumentException(nameof(RadioFor));
            if (string.IsNullOrWhiteSpace(RadioName))
                throw new ArgumentException(nameof(RadioName));
            if (string.IsNullOrWhiteSpace(RadioOptions))
                throw new ArgumentException(nameof(RadioOptions));

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "form-group");

            var radioOptions = RadioOptions.Split(";");

            var radiosInputs = new StringBuilder();
            for (int i = 0; i < radioOptions.Length; i++)
            {
                var opcao = Regex.Replace(radioOptions[i], "[^0-9a-zA-Z]+", "");
                var id = $"{RadioId}{opcao}";
                var name = $"{RadioName}";
                var radioFor = $"{RadioFor}{opcao}";
                var check = string.Empty;
                if (!string.IsNullOrWhiteSpace(RadioValueChecked) && RadioValueChecked.Equals(radioOptions[i]))
                {
                    check = "checked";
                }

                if (string.IsNullOrWhiteSpace(RadioValueChecked) && i == radioOptions.Length - 1)
                {
                    check = "checked";
                }

                radiosInputs.AppendLine("<div class=\"form-check\">");
                radiosInputs.AppendFormat("<input class=\"form-check-input\" type=\"radio\" name=\"{0}\" id=\"{1}\" value=\"{2}\" {3} />", name, id, radioOptions[i], check);
                radiosInputs.AppendFormat("<label class=\"form-check-label\" for=\"{0}\">", radioFor);
                radiosInputs.AppendLine(radioOptions[i]);
                radiosInputs.AppendLine("</label>");
                radiosInputs.AppendLine("</div>");
            }

            output.PreContent.SetHtmlContent(radiosInputs.ToString());
        }
        /*
         
                        <div class="form-check">
                            <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" checked>
                            <label class="form-check-label" for="flexRadioDefault2">
                                Default checked radio
                            </label>
                        </div>
         */
    }
}
