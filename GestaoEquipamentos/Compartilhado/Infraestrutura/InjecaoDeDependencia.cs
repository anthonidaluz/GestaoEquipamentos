using GestaoEquipamentos.Compartilhado.Infraestrutura.Arquivos;
using System.Runtime.CompilerServices;

namespace GestaoEquipamentos.Compartilhado.Infraestrutura
{
    public static class InjecaoDeDependencia
    {

        public static void AdicionarCamadaDeInfraestrutura(this IServiceCollection services)
        {
            // Razor = CSHTML
            services.AddControllersWithViews().AddRazorOptions(options =>
            {
                // Rseta o mecanismo de buca de views
                options.ViewLocationFormats.Clear();


            });


        }

    }
}
