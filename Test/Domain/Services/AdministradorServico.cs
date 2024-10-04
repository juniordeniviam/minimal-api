using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;

namespace Test.Domain.Entidades;

[TestClass]
public class AdministradorServicoTeste
{
    private DbContexto CriarContextoDeTeste()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..","..",".."));

        var builder = new ConfigurationBuilder()
            .SetBasePath(path ?? Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();

        return new DbContexto(configuration);
    }

    [TestMethod]
    public void TestandoSalvarAdministrador()
    {
        // Arrange
        var contexto = CriarContextoDeTeste();
        contexto.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");
        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        contexto.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");
        var veiculo = new Veiculo();
        veiculo.Id = 1;
        veiculo.Nome = "Renault";
        veiculo.Marca = "Clio";
        veiculo.Ano = 2024;

        var administradorServico = new AdministradorServico(contexto);
        var veiculoServico = new VeiculoServico(contexto);  

        // Act
        administradorServico.Incluir(adm);
        veiculoServico.Incluir(veiculo);

        // Assert
        Assert.AreEqual(1, administradorServico.Todos(1).Count());
        Assert.AreEqual(1, veiculoServico.Todos(1).Count());
    }

        [TestMethod]
    public void TestandoBuscaPorId()
    {
        // Arrange
        var contexto = CriarContextoDeTeste();
        contexto.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");
        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";
        
        contexto.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");
        var veiculo = new Veiculo();
        veiculo.Id = 1;
        veiculo.Nome = "Renault";
        veiculo.Marca = "Clio";
        veiculo.Ano = 2024;

        var administradorServico = new AdministradorServico(contexto);
        var veiculoServico = new VeiculoServico(contexto);  

        // Act
        administradorServico.Incluir(adm);
        var admDoBanco = administradorServico.BuscaPorId(adm.Id);

        veiculoServico.Incluir(veiculo);
        var veiculoDoBanco = administradorServico.BuscaPorId(veiculo.Id);

        // Assert
        Assert.AreEqual(1, admDoBanco.Id);
        Assert.AreEqual(1, veiculoDoBanco.Id);
    }
}