using FluentAssertions;

namespace Katas.AnioBisiesto.Test
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
    }
}
