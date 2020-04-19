using UnityEngine;

namespace Script
{
    public abstract class Bloc : MonoBehaviour
    {
        public enum BlocType
        {
            //mettre ici les différents type de bloc à placer, Air est à retirer
            Air, Blok, Bumper, Lava
        }

        protected BlocType Type;

        public BlocType GType => Type;
    }
}
