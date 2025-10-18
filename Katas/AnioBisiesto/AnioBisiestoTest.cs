using FluentAssertions;
using Logica;


namespace Katas.AnioBisiestoTests
{
    public class AnioBisiestoTest
    {
        [Fact]
        public void Debe_EsBisiesto_DevolverTrueCuandoElAnioEsDivisiblePorCuatro()
        {
            var anioBisiesto = new AnioBisiesto();

            var esAnioBisiesto = anioBisiesto.EsAnioBisiesto(2028);

            esAnioBisiesto.Should().BeTrue();
        }

        [Fact]
        public void Debe_EsBisiesto_DevolverFalseCuandoElAnioNoEsDivisiblePorCuatro()
        {
            var anioBisiesto = new AnioBisiesto();

            var esAnioBisiesto = anioBisiesto.EsAnioBisiesto(2025);

            esAnioBisiesto.Should().BeFalse();
        }
    }
}
