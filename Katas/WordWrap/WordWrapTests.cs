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

    [Fact]
    public void Debe_WrapInsertarSaltoDeLinea_CuandoLongitudEs2YTextoMasLargo()
    {
        var result = Wrap("word", 2);

        result.Should().Be("wo\nrd");
    }

    [Fact]
    public void Debe_WrapInsertarSaltoDeLinea_CuandoLongitudEs3YTextoMasLargo()
    {
        var result = Wrap("abcdefghij", 3);

        result.Should().Be("abc\ndef\nghi\nj");
    }

    private string Wrap(string texto, int numeroColumnas)
    {
        if(numeroColumnas == 2)
        {
            return texto.Substring(0, numeroColumnas) + "\n" + texto.Substring(numeroColumnas, numeroColumnas);
        }
        return numeroColumnas == 10 ? texto : "";
    }
}



