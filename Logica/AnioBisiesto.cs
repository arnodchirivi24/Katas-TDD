namespace Logica
{
    public class AnioBisiesto
    {
        public bool EsAnioBisiesto(int anio)
        {
            return (anio % 4 == 0 && anio % 100 !=0) || anio % 400 ==0;
        }
    }
}