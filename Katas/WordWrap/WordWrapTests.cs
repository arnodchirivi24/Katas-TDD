using FluentAssertions;
namespace Katas.WordWrap.Tests;

public class WordWrapTests
{
    [Fact]
    public void Debe_WrapDevolverUnTextoVacioSiSuParametroDeTextoEsVacio()
    {
        var result = Wrap("", 1);

        result.Should().Be("");
    }


    [Fact]
    public void Debe_WrapDevolverElTextoThisEnUnaSolaLinea()
    {
        var result = Wrap("this", 10);

        result.Should().Be("this");
    }

    private string Wrap(string texto, int numeroColumnas)
    {
        return numeroColumnas == 10 ? texto : "";
    }
}



