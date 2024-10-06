using MinimalApi.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public class VeiculoTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        // Arrange
        var veiculo = new Veiculo();

        // Act
        veiculo.Id = 1;
        veiculo.Nome = "Renault";
        veiculo.Marca = "Clio";
        veiculo.Ano = 2024;

        // Assert
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("Renault", veiculo.Nome);
        Assert.AreEqual("Clio", veiculo.Marca);
        Assert.AreEqual(2024, veiculo.Ano);
    }
}