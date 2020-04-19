using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;

namespace Script
{
    public class Grille : MonoBehaviour
    {
        public GameObject blok;
        [FormerlySerializedAs("Air")] public GameObject air;
        public GameObject zNnCtr;
        private Case[][][] grille;
        private static int l = 32;
        private static int h = 8;
        private static float a = 0.3125f;
        private static float b = 0.15625f;
        private static float by = 3.28125f;
        public Grille(string name) //nom du niveau
        {
            
            grille = GameManager.Lecteur(name);
        }

        private void Awake()
        {
            InitGrid();
            //HandButton.OnPress += ; 
        }

        public void InitGrid()
        {
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    for (int k = 0; k < h; k++)
                    {
                        if (i > 7 && i < 24 && j > 7 && j < 24)
                        {
                            continue;
                        }

                        Vector3 coord = GetCoordinatesOut(i, k, j);

                        Instantiate(air, coord, Quaternion.identity);
                    }
                }
            }
        }

        private static Vector3 GetCoordinatesOut(int i, int j, int k)
        {
            float x = a * i + b;
            float y = a * j + by; // base b différente de x et z
            float z = a * k + b;

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
            grille[i][j][k].BuildTerrain(bloc);
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
