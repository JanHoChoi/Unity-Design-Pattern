using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace FlyweightPatternExample1
{
    public class FlyweightPatternExample1 : MonoBehaviour
    {
       
        private void Start()
        {
            TerrainFactory factory = new TerrainFactory();

            World world = new World(factory, 10, 10);

            world.GenerateTerrain();
           
            Debug.Log(world.getTile(3, 5).getMoveCost());
            Debug.Log(world.getTile(1, 3).ifWater());
            Debug.Log(world.getTile(4, 9).ifGrass());
        }


    }

    public class World
    {
        private Terrain[,] m_tiles;

        private int m_width;

        private int m_height;

        public World(TerrainFactory factory, int width, int height)
        {
            grassTerrain = factory.GetTerrain("grass");
            groundTerrain = factory.GetTerrain("ground");
            waterTerrain = factory.GetTerrain("water");

            m_width = width;
            m_height = height;
        }

        public void GenerateTerrain()
        {
            m_tiles = new Terrain[m_width, m_height];
            for(int i = 0; i < m_height; i++)
            {
                for(int j = 0; j < m_width; j++)
                {
                    int temp = UnityEngine.Random.Range(0, 3);
                    switch (temp)
                    {
                        case 0:
                            m_tiles[i, j] = grassTerrain;
                            break;
                        case 1:
                            m_tiles[i, j] = groundTerrain;
                            break;
                        case 2:
                            m_tiles[i, j] = waterTerrain;
                            break;
                    }
                }
            }
        }

        public Terrain getTile(int i, int j)
        {
            return m_tiles[i, j];
        }

        private Terrain grassTerrain;
        private Terrain groundTerrain;
        private Terrain waterTerrain;
    }

    public class TerrainFactory
    {

        private Dictionary<string, Terrain> m_terrain = new Dictionary<string, Terrain>();

        public Terrain GetTerrain(string type)
        {
            if (!m_terrain.ContainsKey(type))
            {
                switch (type)
                {
                    case "grass":
                        m_terrain.Add(type, new Terrain(0, true, false));
                        break;
                    case "ground":
                        m_terrain.Add(type, new Terrain(0, false, false));
                        break;
                    case "water":
                        m_terrain.Add(type, new Terrain(1, false, true));
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            return m_terrain[type];
        }
    }

    public class Terrain
    {
        public int moveCost;
        public bool canHide;
        public bool isWater;

        public Terrain(int _moveCost, bool _canHide, bool _isWater)
        {
            moveCost = _moveCost;
            canHide = _canHide;
            isWater = _isWater;
        }

        public bool ifWater()
        {
            return isWater;
        }

        public bool ifGrass()
        {
            return canHide;
        }

        public int getMoveCost()
        {
            return moveCost;
        }
    }
}