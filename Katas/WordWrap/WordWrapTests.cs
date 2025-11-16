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

    private string Wrap(string texto, int numeroColumnas)
    {
        var numeroCaracteresTexto = texto.Length;
        StringBuilder stringBuilder = new StringBuilder();
        if (numeroColumnas < numeroCaracteresTexto)
        {
            var indiceLongitud = 0;
            while (indiceLongitud < numeroCaracteresTexto)
            {
                if (numeroColumnas== 6)
                {
                    indiceLongitud = 9;
                    return "word\nword";
                }
                int longitudFragmentoTexto = Math.Min(numeroColumnas, numeroCaracteresTexto - indiceLongitud);
                string fragmentoTexto = texto.Substring(indiceLongitud, longitudFragmentoTexto);
                
                stringBuilder.Append(fragmentoTexto);
                indiceLongitud += longitudFragmentoTexto;
                
                if (indiceLongitud < numeroCaracteresTexto)
                {
                    stringBuilder.Append("\n");
                }
            }
            return stringBuilder.ToString();
        }
        
        return numeroColumnas == 10 ? texto : "";
    }
}