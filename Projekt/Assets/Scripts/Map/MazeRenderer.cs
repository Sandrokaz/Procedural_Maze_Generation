using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MazeRenderer : MonoBehaviour
{

    private List<GameObject> walls = new List<GameObject>();

    [SerializeField]
    [Range(1,50)]
    private int width = 10;

    [SerializeField]
    [Range(1,50)]
    private int height = 10;

    [SerializeField]
    private float size = 1f;

    [SerializeField]
    private GameObject wallPrefab = null;

    [SerializeField]
    private GameObject groundPrefab = null;

    [SerializeField]
    private GameObject playerPrefab = null;

    [SerializeField]
    private GameObject dronePrefab = null;

    [SerializeField]
    private bool playerSpawned = false;

    Vector3 spawnPoint;
    float spawnTimer = 0f;
    int dronesInMaze = 0;



    public float GetSize()
    {
        return size;
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }
  

    public void Awake()
    {
        var maze = MazeGenerator.Generate(width, height);
        Draw(maze);
    }

    private void Start()
    {
        WalkingPoint.Instance.ConfigurePoints();
        spawnPoint = new Vector3(-(width / 2) + 0.5f, 0.8f, -( height / 2) + 0.5f);
             
    }
    private void Update()
    {
        Spawner();
    }
   
    private void Spawner()
    {
        int maxDroneCount = 12;
        dronesInMaze = 0;

        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer = 5;
            if (dronesInMaze < maxDroneCount)
            {
                Instantiate(dronePrefab, spawnPoint,Quaternion.identity);
                dronesInMaze++;
            }
        }
          
    }

    private void Draw(WallState[,] maze)
    {
        GameObject ground = Instantiate(groundPrefab, transform);
        ground.transform.localScale = new Vector3(1.5f,1,1.5f);
        ground.transform.localPosition = new Vector3(0, 0, 0); 
       


        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var cell = maze[i, j];
                var position = new Vector3(-width / 2 + i, 0.5f, -height / 2 + j);

                if (cell.HasFlag(WallState.TOP))
                {
                    GameObject topWall = Instantiate(wallPrefab, transform);
                    walls.Add(topWall);
                    topWall.transform.position = position + new Vector3(0, 0, size/2);
                    topWall.transform.localScale = new Vector3(size, topWall.transform.localScale.y, topWall.transform.localScale.z);
                }

                if (cell.HasFlag(WallState.LEFT))
                {
                    GameObject leftWall = Instantiate(wallPrefab, transform);
                    walls.Add(leftWall);
                    leftWall.transform.position = position + new Vector3(-size / 2, 0, 0);
                    leftWall.transform.localScale = new Vector3(size, leftWall.transform.localScale.y, leftWall.transform.localScale.z);
                    leftWall.transform.eulerAngles = new Vector3(0, 90, 0);
                }

                if (i == width - 1)
                {
                    if (cell.HasFlag(WallState.RIGHT))
                    {
                        GameObject rightWall = Instantiate(wallPrefab, transform);
                        walls.Add(rightWall);
                        rightWall.transform.position = position + new Vector3(+size / 2, 0, 0);
                        rightWall.transform.localScale = new Vector3(size, rightWall.transform.localScale.y, rightWall.transform.localScale.z);
                        rightWall.transform.eulerAngles = new Vector3(0, 90, 0);
                    }
                }

                if (j==0)
                {
                    if (cell.HasFlag(WallState.BOTTOM))
                    {
                        GameObject bottomWall = Instantiate(wallPrefab, transform);
                        walls.Add(bottomWall);
                        bottomWall.transform.position = position + new Vector3(0, 0, -size / 2);
                        bottomWall.transform.localScale = new Vector3(size, bottomWall.transform.localScale.y, bottomWall.transform.localScale.z);
                    }
                }

                if (!playerSpawned)
                {
                    GameObject player = Instantiate(playerPrefab, transform);
                    Vector3 pos = new Vector3(0,2,0);                                
                    playerSpawned = true;
                }
            }
        }
    }
}
