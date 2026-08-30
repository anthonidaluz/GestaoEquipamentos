using GestaoEquipamentos.Compartilhado.Dominio;
using GestaoEquipamentos.Modulos.Equipamentos.Dominio;

namespace GestaoDeEquipamentos.WebApp.Modulos.Chamados.Dominio;

public sealed class Chamado : EntidadeBase
{
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

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Chamado chamadoAtualizado = (Chamado)entidadeAtualizada;

        Titulo = chamadoAtualizado.Titulo;
        Descricao = chamadoAtualizado.Descricao;
        DataAbertura = chamadoAtualizado.DataAbertura;
        EquipamentoId = chamadoAtualizado.EquipamentoId;
        Equipamento = chamadoAtualizado.Equipamento;
    }
}