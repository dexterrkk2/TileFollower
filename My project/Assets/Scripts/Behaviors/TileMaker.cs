using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMaker : MonoBehaviour
{
    public List<Node> tilePrefabs;
    public int mapSizeX;
    public int mapSizeY;
    public int tileScale;
    public Node[,] tiles;
    public void MakeMap()
    {
        tiles = new Node[mapSizeX, mapSizeY];
        for (int i = 0; i < mapSizeX; i++) 
        {
            for (int q = 0; q < mapSizeY; q++) 
            {
                int random = Random.Range(0, tilePrefabs.Count);
                GameObject tile = Instantiate(tilePrefabs[random].gameObject, new Vector3(i * tileScale, 1f, q * tileScale), Quaternion.identity);
                tiles[i, q] = tile.GetComponent<Node>();
             }
         }
        MakeConnections();
    }
    public void MakeConnections()
    {
        for (int i = 0; i < mapSizeX; i++)
        {
            for (int q = 0; q < mapSizeY; q++)
            {
                if (i + 1 < mapSizeX)
                {
                    tiles[i,q].ConnectsTo.Add(tiles[i + 1, q]);
                    if (q + 1 < mapSizeY)
                    {
                        //tiles[i,q].ConnectsTo.Add(tiles[i + 1,q + 1]);
                        tiles[i,q].ConnectsTo.Add(tiles[i, q + 1]);
                    }
                }
            }
        }
    }
}
