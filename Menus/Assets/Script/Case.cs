using UnityEngine;

namespace Script
{
    public class Case : MonoBehaviour
    {
        public enum Biome
        {
            Air, AirBlok, Terrain, Lava, LavaSlab 
        }
        
        private Biome _biome;

        public Case(Biome b) //Fc d'init de case
        {
            _biome = b;
        }

        public bool BuildBloc(ref int credit, Blok.BlocType type)
        {
            if (type == Bloc.BlocType.Blok && credit >= Blok.BuildCost) //modifier le test de bloc ds la grille
                                                                        //par test de bloc ds unity
            {
                credit -= Blok.BuildCost;
                return true;
            }

            //Placer ici les autre bloc posable une fois ceux là implémenté
            
            return false;
        }

        public void BuildTerrain(Biome bloc)
        {
            
        }

        public bool CanDestroyBloc()
        {
            if (_biome != Biome.Terrain || _biome != Biome.AirBlok)
            {
                return true;
            }

            return false;
        }
    }
}
