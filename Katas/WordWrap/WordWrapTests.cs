using System.Text;
using FluentAssertions;

namespace Katas.WordWrap;

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

    [Fact]
    public void Debe_Wrap_CuandoColumnasEs6_DebeRomperLaFraseEnBloquesDe2ConSaltosDeLineaCuandoTienenUnEspacio()
    {
        var result = Wrap("word word", 6);

        result.Should().Be("word\nword");
    }

    [Fact]
    public void Debe_Wrap_CuandoColumnasEs5_DebeRomperLaFraseEnBloquesDe2ConSaltosDeLineaCuandoTienenUnEspacio()
    {
        var result = Wrap("word word", 5);

        result.Should().Be("word\nword");
    }

    [Fact]
    public void
        Debe_Wrap_CuandoColumnasEs6_DebeRomperLaFraseEnBloquesDe3ConSaltosDeLineaCuandoTienenUnEspacioYLaCantidadDeCaracteresSeaMenorALaCantidadColumas()
    {
        var result = Wrap("word word word", 6);

        result.Should().Be("word\nword\nword");
    }

    [Fact]
    public void Debe_Wrap_MantenerVariasPalabrasEnUnaLinea_SiCabenEnElLimiteDeColumnas()
    {
        var result = Wrap("word word word", 11);

        result.Should().Be("word word\nword");
    }

    private string Wrap(string texto, int numeroColumnas)
    {
        if (string.IsNullOrEmpty(texto) || texto.Length <= numeroColumnas)
        {
            return texto;
        }

        var numeroCaracteresTexto = texto.Replace(" ", "").Length;
        StringBuilder stringBuilder = new StringBuilder();
        var indiceInicio = 0;

        while (indiceInicio < numeroCaracteresTexto)
        {
            int indiceFin = indiceInicio + numeroColumnas;
            if (indiceFin >= texto.Length)
            {
                stringBuilder.Append(texto.Substring(indiceInicio));
                break;
            }
            
            int longitudPorcion = Math.Min(numeroColumnas + 1, texto.Length - indiceInicio);
            string porcion = texto.Substring(indiceInicio, longitudPorcion);
            int indiceEspacioRelativo = porcion.LastIndexOf(' ');
            
            if (indiceEspacioRelativo <= 0)
            {
                stringBuilder.Append(texto.Substring(indiceInicio, numeroColumnas));
                stringBuilder.Append("\n");
                indiceInicio += numeroColumnas;
            }
            else
            {
                stringBuilder.Append(texto.Substring(indiceInicio, indiceEspacioRelativo));
                stringBuilder.Append("\n");
                indiceInicio += indiceEspacioRelativo + 1; 
            }
        }

        return stringBuilder.ToString();
    }
}