using System.ComponentModel.DataAnnotations;

namespace GestaoDeEquipamentos.WebApp.Modulos.Chamados.Apresentacao;

public record ListarChamadoViewModel(
    int Id,
    string Titulo,
    string NomeEquipamento,
    DateTime DataAbertura,
    int DiasEmAberto
);

public record SelecionarEquipamentoViewModel(int Id, string Nome);

public record CadastrarChamadoViewModel(

    [Required(ErrorMessage = "O campo \"Título\" é obrigatório.")]
    [StringLength(100, MinimumLength = 3,
        ErrorMessage = "O campo \"Título\" deve conter entre 3 e 100 caracteres.")]
    string? Titulo,

    [Required(ErrorMessage = "O campo \"Descrição\" é obrigatório.")]
    [StringLength(500, MinimumLength = 5,
        ErrorMessage = "A \"Descrição\" deve conter entre 5 e 500 caracteres.")]
    string? Descricao,

    [Required(ErrorMessage = "O campo \"Data de abertura\" é obrigatório.")]
    [DataType(DataType.Date)]
    DateTime? DataAbertura,

    [Range(1, int.MaxValue, ErrorMessage = "O campo \"Equipamento\" é obrigatório.")]
    int EquipamentoId,

    List<SelecionarEquipamentoViewModel>? EquipamentosDisponiveis
);

public record EditarChamadoViewModel(
    int Id,

    [Required(ErrorMessage = "O campo \"Título\" é obrigatório.")]
    [StringLength(100, MinimumLength = 3,
        ErrorMessage = "O campo \"Título\" deve conter entre 3 e 100 caracteres.")]
    string? Titulo,

    [Required(ErrorMessage = "O campo \"Descrição\" é obrigatório.")]
    [StringLength(500, MinimumLength = 5,
        ErrorMessage = "A \"Descrição\" deve conter entre 5 e 500 caracteres.")]
    string? Descricao,

    [Required(ErrorMessage = "O campo \"Data de abertura\" é obrigatório.")]
    [DataType(DataType.Date)]
    DateTime? DataAbertura,

    [Range(1, int.MaxValue, ErrorMessage = "O campo \"Equipamento\" é obrigatório.")]
    int EquipamentoId,

    List<SelecionarEquipamentoViewModel>? EquipamentosDisponiveis
);

public record ExcluirChamadoViewModel(
    int Id,
    string Titulo,
    string NomeEquipamento
);