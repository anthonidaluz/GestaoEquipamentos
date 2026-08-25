using GestaoEquipamentos.Compartilhado.Dominio;
using System.Runtime.CompilerServices;

namespace GestaoEquipamentos.Modulos.Equipamentos.Dominio
{
    public sealed class Equipamento : EntidadeBase
    {
        public string Nome { get; set; } = string.Empty;
        public decimal PrecoAquisicao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public Fabricante Fabricante { get; set; } = null!;

        public override void Atualizar(EntidadeBase entidadeAtualizada)
        {
            Equipamento equipamentoAtualizado = (Equipamento)entidadeAtualizada;

            Nome = equipamentoAtualizado.Nome;
            PrecoAquisicao = equipamentoAtualizado.PrecoAquisicao;
            DataFabricacao = equipamentoAtualizado.DataFabricacao;
            Fabricante = equipamentoAtualizado.Fabricante;
        }
    }
}
