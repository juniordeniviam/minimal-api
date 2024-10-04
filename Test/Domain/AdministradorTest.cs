using MinimalApi.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public class AdministradorTeste
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        // Arrange
        var adm = new Administrador();
        var veiculo = new Veiculo();

        // Act
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        veiculo.Id = 1;
        veiculo.Nome = "Renault";
        veiculo.Marca = "Clio";
        veiculo.Ano = 2024;

        // Assert
        Assert.AreEqual(1, adm.Id);
        Assert.AreEqual("teste@teste.com", adm.Email);
        Assert.AreEqual("teste", adm.Senha);
        Assert.AreEqual("Adm", adm.Perfil);

        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("Renault", veiculo.Nome);
        Assert.AreEqual("Clio", veiculo.Marca);
        Assert.AreEqual(2024, veiculo.Ano);
    }
}