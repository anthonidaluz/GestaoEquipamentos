namespace GestaoEquipamentos.Compartilhado.Apresentacao
{
    public static class InjecaoDeDependencia
    {

        public static void AdicionarCamadaDeApresentacao(this IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorOptions(options =>
            {
                options.ViewLocationFormats.Clear();

                options.ViewLocationFormats.Add("/Compartilhado/Apresentacao/Views/{0}.cshtml");

                options.ViewLocationFormats.Add("/Modulos/{1}s/Apresentacao/Views/{0}.cshtml");

            });
        }

    }
}
