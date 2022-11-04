using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Logic;


public class FieldController : MonoBehaviour
{
    public GameObject lightBedrockVoxel;
    public GameObject darkBedrockVoxel;
    public GameObject destroyableBedrockVoxel;
    public GameObject platform;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject mainCamera;

    private Cell[,] cells;

    private string[] map = new[]
    {
        "...............",
        "..........P....",
        "..###########..",
        "..E.........#..",
        "..#########.#..",
        "..#...... #.#..",
        "..#.##***.#.#..",
        "..#.#.*0*.#.#..",
        "..#.#.***.#.#..",
        "..#.#.....#.#..",
        "..#.#######.#..",
        "..#.........#..",
        "..###########..",
        "...............",
        "...............",

    };

    // Start is called before the first frame update
    void Start()
    {
        var height = map.Length;
        var width = map[0].Length;

        cells = new Cell[width + 2, height + 2];

        for (int i = 0; i < height; i++)
        {
            if (map[i].Length != width)
            {
                throw new System.Exception("Invalid map");
            }
            for (int j = 0; j < width; j++)
            {
                if (map[i][j] == '#')
                {
                    cells[j + 1, i + 1] = new Cell(CellSpace.LightBedrock);
                }
                else
                if (map[i][j] == '*')
                {
                    cells[j + 1, i + 1] = new Cell(CellSpace.DestroyableBedrock);
                }

                else
                if (map[i][j] == '0')
                {
                    cells[j + 1, i + 1] = new Cell(CellSpace.Platform);
                }

                else
                {
                    cells[j + 1, i + 1] = new Cell(CellSpace.Empty);
                }
                
                if (map[i][j] == 'P')
                {
                    cells[j + 1, i + 1].Occupy(Occupant.Player);
                }

                if (map[i][j] == 'E')
                {
                    cells[j + 1, i + 1].Occupy(Occupant.Enemy);
                }
            }
        }

        for (int i = 0; i < width + 2; i++)
        {
            cells[i, 0] = new Cell(CellSpace.DarkBedrock);
            cells[i, height + 1] = new Cell(CellSpace.DarkBedrock);
        }

        for (int i = 0; i < height + 2; i++)
        {
            cells[0, i] = new Cell(CellSpace.DarkBedrock);
            cells[width + 1, i] = new Cell(CellSpace.DarkBedrock);
        }
        
        for (var x = 0; x < width + 2; x++)
        {
            for (var y = 0; y < height + 2; y++)
            {
                Instantiate(darkBedrockVoxel, new Vector3(x, 0, y), Quaternion.identity, transform);

                if (cells[x, y].Space == CellSpace.LightBedrock)
                {
                    Instantiate(lightBedrockVoxel, new Vector3(x, 1, y), Quaternion.identity, transform);
                }

                if (cells[x, y].Space == CellSpace.DarkBedrock)
                {
                    Instantiate(darkBedrockVoxel, new Vector3(x, 1, y), Quaternion.identity, transform);
                }

                if (cells[x, y].Space == CellSpace.DestroyableBedrock)
                {
                    Instantiate(destroyableBedrockVoxel, new Vector3(x, 1, y), Quaternion.identity, transform);
                }

                if (cells[x, y].Space == CellSpace.Platform)
                {
                    Instantiate(platform, new Vector3(x, 0, y), Quaternion.identity, transform);
                }

                if (cells[x, y].Occupant == Occupant.Player)
                {
                    Instantiate(playerPrefab, new Vector3(x, 1, y), Quaternion.identity, transform);
                }

                if (cells[x, y].Occupant == Occupant.Enemy)
                {
                    Instantiate(enemyPrefab, new Vector3(x, 1, y), Quaternion.Euler(0, 90, 0), transform);
                }
            }
        }

        mainCamera.transform.position = new Vector3(8f, 11.74f, 1.77f);
        mainCamera.transform.eulerAngles = new Vector3(69.457f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
