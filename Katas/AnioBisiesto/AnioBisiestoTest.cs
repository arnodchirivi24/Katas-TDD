using FluentAssertions;
using Logica;


namespace Katas.AnioBisiestoTests
{
    public class AnioBisiestoTest
    {
        [Fact]
        public void Debe_EsBisiesto_DevolverVerdaderoCuandoElAnioEsDivisiblePorCuatro()
        {
            var anioBisiesto = new AnioBisiesto();

            var esAnioBisiesto = anioBisiesto.EsAnioBisiesto(2028);

            esAnioBisiesto.Should().BeTrue();
        }

        [Fact]
        public void Debe_EsBisiesto_DevolverFalsoCuandoElAnioNoEsDivisiblePorCuatro()
        {
            var anioBisiesto = new AnioBisiesto();

            var esAnioBisiesto = anioBisiesto.EsAnioBisiesto(2025);

            esAnioBisiesto.Should().BeFalse();
        }

        [Fact]
        public void Debe_EsBisiesto_DevolverFalsoCuandoElAnioEsDivisiblePorCienYNoSeaDivisiblePorCuatrociento()
        {
            var anioBisiesto = new AnioBisiesto();

            var esAnioBisiesto = anioBisiesto.EsAnioBisiesto(1900);

            esAnioBisiesto.Should().BeFalse();
        }

        [Fact]
        public void Debe_EsBisiesto_DevolverVerdaderocuandoElAnioEsDivisiblePorCuatroPeroNoEsDivisiblePorCien()
        {
            var anioBisiesto = new AnioBisiesto();

            var esAnioBisiesto = anioBisiesto.EsAnioBisiesto(2000);

            esAnioBisiesto.Should().BeTrue();
        }
    }
}
