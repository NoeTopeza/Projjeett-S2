namespace Script
{
    public class Blok : Bloc
    {
        public Blok()
        {
            Type = BlocType.Blok;
        }

        public Blok(Blok blok)
        {
            Type = blok.Type;
        }
    }
}
