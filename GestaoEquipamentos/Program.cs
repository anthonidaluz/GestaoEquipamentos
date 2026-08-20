namespace GestaoEquipamentos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurar a infra (banco de dados, logs, arquivos etc..)

            // Configurar o MVC / Apresentacao

            var app = builder.Build();
            
            //Middlewares
            app.UseRouting();
            app.MapDefaultControllerRoute();

            app.UseStaticFiles();

            // Executa o servidor
            app.Run();
        }
    }
}
