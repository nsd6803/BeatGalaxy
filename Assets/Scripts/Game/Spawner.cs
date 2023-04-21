using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    //list of towers (prefabs) that will instantiate
    public List<GameObject> towersPrefabs;
    //Transform of the spawning towers (Root Object)
    public Transform spawnTowerRoot;
    //list of towers (UI)
    public List<Image> towersUI;

    ShipCost shipCost;
    //id of tower to spawn
    int spawnID = -1;
    //SpawnPoints Tilemap
    public Tilemap spawnTilemap;

    public GameObject gameobject;
    public CoinManager coinManager;

    void Start()
    {
        gameobject = GameObject.Find("CoinBar");
        coinManager = gameobject.GetComponentInChildren<CoinManager>();
    }

    void Update()
    {
        if (CanSpawn())
            DetectSpawnPoint();
    }

    bool CanSpawn()
    {
        if (spawnID == -1)
            return false;
        else
            return true;
    }

    void DetectSpawnPoint()
    {
        //Detect when mouse is clicked (first touch clicked)
        if (Input.GetMouseButtonDown(0))
        {
            //get the world space postion of the mouse
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //get the position of the cell in the tilemap
            var cellPosDefault = spawnTilemap.WorldToCell(mousePos);
            //get the center position of the cell
            var cellPosCentered = spawnTilemap.GetCellCenterWorld(cellPosDefault);
            //check if we can spawn in that cell (collider)
            if (spawnTilemap.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite)
            {
                if (coinManager.coinCount >= 5 && spawnID == 0) // если у игрока достаточно монет для покупки растения
                {
                    SpawnTower(cellPosDefault);
                    spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.None);
                }
                else if (coinManager.coinCount >= 10 && spawnID == 1) // если у игрока достаточно монет для покупки растения
                {
                    SpawnTower(cellPosDefault);
                    spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.None);
                }
                else if (coinManager.coinCount >= 15 && spawnID == 2) // если у игрока достаточно монет для покупки растения
                {
                    SpawnTower(cellPosDefault);
                    spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.None);
                }
                else
                {
                    Debug.Log("Not enough coins!"); // выводим сообщение о нехватке монет
                }
              
            }
        }
    }

    void SpawnTower(Vector3 position)
    {
        if(spawnID == 0)
        {
            coinManager.coinCount -= 5;
        }
        else if (spawnID == 1)
        {
            coinManager.coinCount -= 10;
        }
        else if (spawnID == 2)
        {
            coinManager.coinCount -= 15;
        }
        coinManager.CoinStatus();
        GameObject tower = Instantiate(towersPrefabs[spawnID], spawnTowerRoot);
        tower.transform.position = position;
        tower.transform.localScale -= new Vector3(0.6f, 0.6f, 0.0f);


    }

    public void RevertCellState(Vector3Int pos)
    {
        spawnTilemap.SetColliderType(pos, Tile.ColliderType.Sprite);
    }

    public void SelectTower(int id)
    {
   
        //Set the spawnID
        spawnID = id;

    }





}