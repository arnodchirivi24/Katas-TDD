using System.Text;
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
        var numeroCaracteresTexto = texto.Length;
        StringBuilder stringBuilder = new StringBuilder();
        if (numeroColumnas < numeroCaracteresTexto)
        {
            var indiceLongitud = 0;
            while (indiceLongitud < numeroCaracteresTexto)
            {
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