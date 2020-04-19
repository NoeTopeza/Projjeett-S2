using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grille : MonoBehaviour
{
    private static readonly char[] Hgrid = {'o','o','o','o','o','o','o','o'};
    private static readonly char[][] Lgrid = {Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid,Hgrid};
    public char[][][] grid = {Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid,Lgrid};
    private int[] _mesure = {Lgrid.GetLength(0),Hgrid.Length};
    void Awake()
    {
        
    }

    
    void Update()
    {
        
    }
}
