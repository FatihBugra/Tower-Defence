using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefabA;
    [SerializeField] Tower towerPrefabB;
    [SerializeField] Tower towerPrefabC;

    [SerializeField] bool isPlaceable;
    [SerializeField] bool isBuildingATower; 
    [SerializeField] bool isBuildingBTower;
    [SerializeField] bool isBuildingCTower;

    Vector2Int coordinates = new Vector2Int();
    public bool IsPlaceable { get { return isPlaceable; } }

    GridManager gridManager;
    Pathfinder pathfinder;

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    void Start()
    {
        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if (!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isBuildingATower = true;
            isBuildingBTower = false;
            isBuildingCTower = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isBuildingBTower = true;
            isBuildingATower = false;
            isBuildingCTower = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            isBuildingCTower = true;
            isBuildingATower = false;
            isBuildingBTower = false;
        }
    }

    void OnMouseDown()
    {
        if (isBuildingATower)
        {
            TryBuildTower(towerPrefabA);
        }
        else if (isBuildingBTower)
        {
            TryBuildTower(towerPrefabB);
        }
        else if (isBuildingCTower)
        {
            TryBuildTower(towerPrefabC);
        }

        isBuildingATower = false;
        isBuildingCTower = false;
        isBuildingBTower = false;
    }

    void TryBuildTower(Tower towerPrefab)
    {
        if (gridManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
        {
            bool isSuccessful = towerPrefab.CreateTower(towerPrefab, transform.position);

            if (isSuccessful)
            {
                gridManager.BlockNode(coordinates);
                pathfinder.NotifyReceivers();
            }
        }
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
