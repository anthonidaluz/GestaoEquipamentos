using GestaoDeEquipamentos.WebApp.Modulos.Chamados.Dominio;
using GestaoEquipamentos.Modulos.Chamados.Infraestrutura;
using GestaoEquipamentos.Modulos.Equipamentos.Dominio;
using GestaoEquipamentos.Modulos.Equipamentos.Infraestrutura;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Modulos.Chamados.Apresentacao;

public sealed class ChamadoController : Controller
{
    private readonly RepositorioChamadoEmArquivo repositorioChamado;
    private readonly RepositorioEquipamentoEmArquivo repositorioEquipamento;

    public ChamadoController(
        RepositorioChamadoEmArquivo repositorioChamado,
        RepositorioEquipamentoEmArquivo repositorioEquipamento
    )
    {
        this.repositorioChamado = repositorioChamado;
        this.repositorioEquipamento = repositorioEquipamento;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarChamadoViewModel> viewModels = new List<ListarChamadoViewModel>();

        foreach (Chamado c in repositorioChamado.SelecionarTodos())
        {
            ListarChamadoViewModel viewModel = new ListarChamadoViewModel(
                c.Id,
                c.Titulo,
                c.Equipamento?.Nome ?? "Equipamento não encontrado",
                c.DataAbertura,
                c.DiasEmAberto
            );

            viewModels.Add(viewModel);
        }

        return View(viewModels);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarChamadoViewModel viewModel = new(
            null,
            null,
            null,
            0,
            ObterEquipamentosDisponiveis()
        );

        return View(viewModel);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarChamadoViewModel viewModel)
    {
        Equipamento? equipamentoSelecionado =
            repositorioEquipamento.SelecionarPorId(viewModel.EquipamentoId);

        if (equipamentoSelecionado == null)
            ModelState.AddModelError(nameof(viewModel.EquipamentoId), "Selecione um equipamento válido");

        if (!ModelState.IsValid)
        {
            viewModel = viewModel with
            {
                EquipamentosDisponiveis = ObterEquipamentosDisponiveis()
            };

            return View(viewModel);
        }

        Chamado chamado = new(
            viewModel.Titulo ?? string.Empty,
            viewModel.Descricao ?? string.Empty,
            viewModel.DataAbertura.GetValueOrDefault(),
            viewModel.EquipamentoId
        );

        chamado.Equipamento = equipamentoSelecionado!;

        repositorioChamado.Cadastrar(chamado);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(int id)
    {
        Chamado? chamadoSelecionado = repositorioChamado.SelecionarPorId(id);

        if (chamadoSelecionado == null)
            return NotFound();

        EditarChamadoViewModel viewModel = new(
            chamadoSelecionado.Id,
            chamadoSelecionado.Titulo,
            chamadoSelecionado.Descricao,
            chamadoSelecionado.DataAbertura,
            chamadoSelecionado.EquipamentoId,
            ObterEquipamentosDisponiveis()
        );

        return View(viewModel);
    }

    [HttpPost]
    public ActionResult Editar(int id, EditarChamadoViewModel viewModel)
    {
        Equipamento? equipamentoSelecionado =
            repositorioEquipamento.SelecionarPorId(viewModel.EquipamentoId);

        if (equipamentoSelecionado == null)
            ModelState.AddModelError(nameof(viewModel.EquipamentoId), "Selecione um equipamento válido.");

        if (!ModelState.IsValid)
        {
            viewModel = viewModel with
            {
                EquipamentosDisponiveis = ObterEquipamentosDisponiveis()
            };

            return View(viewModel);
        }

        Chamado chamadoAtualizado = new(
           viewModel.Titulo ?? string.Empty,
           viewModel.Descricao ?? string.Empty,
           viewModel.DataAbertura.GetValueOrDefault(),
           viewModel.EquipamentoId
        );
        chamadoAtualizado.Equipamento = equipamentoSelecionado!;

        bool conseguiuEditar = repositorioChamado.Editar(id, chamadoAtualizado);

        if (!conseguiuEditar)
            return NotFound();

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(int id)
    {
        Chamado? chamadoSelecionado = repositorioChamado.SelecionarPorId(id);

        if (chamadoSelecionado == null)
            return NotFound();

        ExcluirChamadoViewModel viewModel = new(
            chamadoSelecionado.Id,
            chamadoSelecionado.Titulo,
            chamadoSelecionado.Equipamento?.Nome ?? "Equipamento não encontrado"
        );

        return View(viewModel);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirChamadoViewModel viewModel)
    {
        bool conseguiuExcluir = repositorioChamado.Excluir(viewModel.Id);

        if (!conseguiuExcluir)
            return NotFound();

        return RedirectToAction(nameof(Listar));
    }

    private List<SelecionarEquipamentoViewModel> ObterEquipamentosDisponiveis()
    {
        List<SelecionarEquipamentoViewModel> viewModels = new();

        foreach (Equipamento e in repositorioEquipamento.SelecionarTodos())
        {
            SelecionarEquipamentoViewModel viewModel = new(e.Id, e.Nome);

            viewModels.Add(viewModel);
        }

        return viewModels;
    }
}