using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bloc : MonoBehaviour
{
    public enum BlocType
    {
        //mettre ici les différents type de bloc à placer
        Blok, Bumper, Lava
    }

    protected BlocType Type;

    public BlocType GType => Type;
}
