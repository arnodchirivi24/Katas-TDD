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

    private string Wrap(string texto, int numeroColumnas)
    {
        return "";
    }
}



