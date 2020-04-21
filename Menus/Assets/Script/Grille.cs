using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;

namespace Script
{
    public class Grille : MonoBehaviour
    {
        public GameObject terrain;
        [FormerlySerializedAs("Air")] public GameObject air;
        public GameObject zNnCtr;
        private Case[,,] _grille;
        private static int l = 32;
        private static int h = 8;
        private static float a = 0.3125f;
        private static float b = 0.15625f;
        private static float by = 1.875f;
        public Grille(string name) //nom du niveau
        {
            _grille = GameManager.Lecteur(name);
        }

        private Grille()
        {
            _grille = new Case[l,l,h];
        }

        private void Awake()
        {
            InitGrid();
            //GameManager.Scribe(_grille, "niveau_zéro");
            //HandButton.OnPress += ;
        }

        public void InitGrid()
        {
            _grille = new Case[l,l,h];
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    for (int k = 0; k < h; k++)
                    {
                        
                        if (i > 7 && i < 24 && j > 7 && j < 24)
                        {
                            _grille[i, j, k] = null;
                            continue;
                        }
                        _grille[i,j,k] = new Case(Case.Biome.Air);
                        Vector3 coord = GetCoordinatesOut(i, k, j);
                        Instantiate(air, coord, Quaternion.identity);
                    }
                }
            }
        }

        public void BlockSwitch(Case.BlocType bloc)
        {
            
        }

        private static Vector3 GetCoordinatesOut(int i, int k, int j)
        {
            float x = a * i + b;
            float y = a * k + by; // base b différente de x et z
            float z = a * j + b;

            return new Vector3(x, y, z);
        }
        private static Tuple<int, int, int> GetCoordinatesIn(float x, float y, float z)
        {
            int i = Convert.ToInt32(x / a - b);
            int j = Convert.ToInt32(y / a - by);
            int k = Convert.ToInt32(z / a - b);
            
            return new Tuple<int, int, int>(i, j, k);
        }
        public void BuildTerrain(float x, float y, float z, Case.Biome bloc) //pas besoin de détruire quand on
                                                                            //peut contruire l'air par dessus les blocs
        {
            (int i, int j, int k) = GetCoordinatesIn(x, y, z);
            _grille[i,j,k].BuildTerrain(bloc);
        }
        
        /*
        public bool Destroy(int i, int j, int k)
        {
            if (i < 0 || (i > 7 && i < 24) || i >= l || j < 0 || (j > 7 && j < 24) || j >= l || k < 0 || k >= h)
                return false;
            if (grille[i][j][k].CanDestroyBloc())
            {
                return true;
            }

            return false;
        } */
    }
}
