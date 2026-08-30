using GestaoEquipamentos.Modulos.Equipamentos.Dominio;

namespace GestaoDeEquipamentos.WebApp.Modulos.Chamados.Dominio;

public class Chamado
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public DateTime DataAbertura { get; set; }
    public int EquipamentoId { get; set; }
    public Equipamento? Equipamento { get; set; }
    public int DiasEmAberto
    {
        get
        {
            TimeSpan tempoAberto = DateTime.Now.Date - DataAbertura.Date;
            return tempoAberto.Days;
        }
    }
    public Chamado()
    {
    }
    public Chamado(string titulo, string descricao, DateTime dataAbertura, int equipamentoId)
    {
        Titulo = titulo;
        Descricao = descricao;
        DataAbertura = dataAbertura;
        EquipamentoId = equipamentoId;
    }
}