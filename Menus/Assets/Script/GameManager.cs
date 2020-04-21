using System;
using System.IO;
using UnityEngine;

namespace Script
{
    public class GameManager //inspiré de TycoonIO
    {
        private const int xz = 32;
        private const int y = 8;
        public static Case[,,] Lecteur(string name)
        {
            Case[,,] grille = new Case[xz,xz,y];
            string path = $"C:/Users/lucal/source/repos/ConsoleApp1/{name}.txt";
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(path))
                {
                    // Read the stream to a string, and write the string to the console: première ligne= nom de la map
                    String line = sr.ReadLine();

                    Console.WriteLine("Nom de la map : " + line);

                    line = sr.ReadLine();   //ligne qui ne servira pour d'autre paramètre
                    
                    line = sr.ReadLine();
                    
                    int compteur = 0;

                    for (int i = 0; i < xz; i++)
                    {
                        for (int j = 0; j < xz; j++)
                        {
                            for (int k = 0; k < y; k++)
                            {
                                //attribution de classe case

                                switch (line[compteur])
                                {
                                    case '0':
                                        grille[i,j,k] = new Case(Case.Biome.Air); ;
                                        break;
                                    case '1':
                                        grille[i,j,k] = new Case(Case.Biome.Terrain); ;
                                        break;
                                    case '2':
                                        grille[i,j,k] = new Case(Case.Biome.AirBlok);
                                        break;
                                    case '3':
                                        grille[i,j,k] = new Case(Case.Biome.Lava);
                                        break;
                                    case '4':
                                        grille[i,j,k] = new Case(Case.Biome.LavaSlab);
                                        break;
                                    case 'X':
                                        grille[i,j,k] = null;
                                        break;
                                    
                                    default:
                                        throw new ArgumentException("Argument inconnu rencontré");
                                }
                                compteur++;
                            }
                            line = sr.ReadLine();
                            compteur = 0;
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:"); //à remplacer par une erreur en jeu pour ne pas planter
                Console.WriteLine(e.Message);
            }
            return grille;
        }

        public static void Scribe(Case[,,] grille, string name) //A OPTIMISER AU NIVEAUX DES CREATION DE STRING
        {
            string path = Application.persistentDataPath + $"/{name}.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < xz; i++)
                {
                    string line = "";
                    for (int j = 0; j < y; j++)
                    {
                        for (int k = 0; k < xz; k++)
                        {
                            switch (grille[i,j,k].GBiome)
                            {
                                case Case.Biome.Air:
                                    line += "0";
                                    break;
                                case Case.Biome.Terrain:
                                    line += "1";
                                    break;
                                case Case.Biome.AirBlok:
                                    line += "2";
                                    break;
                                case Case.Biome.Lava:
                                    line += "3";
                                    break;
                                case Case.Biome.LavaSlab:
                                    line += "4";
                                    break;
                                default:
                                    line += "X";
                                    break;

                            }   
                            
                        }
                    }
                    writer.WriteLine(line);
                }
            }
        }
    }
}
