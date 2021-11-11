using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Fisioterapia.Web.Pages.Pacientes
{
    public static class ManageNavPages
    {
        public static string Edit => "Edit";

        public static string Anamnese => "Anamnese";

        public static string Convenios => "Convenios";

        public static string Enderecos => "Enderecos";

        public static string Condutas => "Condutas";

        public static string EditNavClass(ViewContext viewContext) => PageNavClass(viewContext, Edit);

        public static string AnamneseNavClass(ViewContext viewContext) => PageNavClass(viewContext, Anamnese);

        public static string ConveniosNavClass(ViewContext viewContext) => PageNavClass(viewContext, Convenios);

        public static string EnderecosNavClass(ViewContext viewContext) => PageNavClass(viewContext, Enderecos);

        public static string CondutasNavClass(ViewContext viewContext) => PageNavClass(viewContext, Condutas);

        public static string EditNavRoute(ViewContext viewContext) => PageNavRoute(viewContext, Edit);

        public static string AnamneseNavRoute(ViewContext viewContext) => PageNavRoute(viewContext, Anamnese);

        public static string ConveniosNavRoute(ViewContext viewContext) => PageNavRoute(viewContext, Convenios);

        public static string EnderecosNavRoute(ViewContext viewContext) => PageNavRoute(viewContext, Enderecos);

        public static string CondutasNavRoute(ViewContext viewContext) => PageNavRoute(viewContext, Condutas);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);


            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        public static string PageNavRoute(ViewContext viewContext, string page)
        {
            var paramId = viewContext.HttpContext.Request.Query["idPaciente"][0];
            return $"./{page}?idPaciente={paramId}";
        }
    }
}
