﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    /*
     *  Purpose of this script is to make the retrieval of resources like sprites and prefabs easier for other scripts
     *  To call this script, just do ResourceManager.Instance.<function>
     */


    //Resources
    public List<Sprite> mineralSprites;
    public List<Sprite> seedSprites;
    public List<Sprite> genSprites;
    public List<GameObject> seedObjects;
    public List<GameObject> genObjects;
    public Sprite[] wallSprites = new Sprite[13];
    public Sprite treeShadow1, treeShadow2, playersAndEnemiesShadow;
    public Material shadowMaterial;
    public GameObject dropItem, healthBar;


    private static ResourceManager _instance;
    public static ResourceManager Instance { get {
        if (_instance == null) {
            _instance = FindObjectOfType<ResourceManager>();
        }
        if (_instance == null) {
            Debug.Log("resource manager script not found!, Add resource manager prefab to your scene!");
        }
        return _instance;
    } }

    #region Setup
    //Singleton
    private void Awake()
    {
        SetupMineralMap();
        SetupSeedMap();
        SetupGenMap();
        SetupSeedObjectMap();
        SetupGenObjectMap();
    }
    private static Dictionary<string, Sprite> mineralMap;
    private static Dictionary<string, Sprite> seedMap;
    private static Dictionary<string, Sprite> genMap;
    private static Dictionary<string, GameObject> seedObjectMap;
    private static Dictionary<string, GameObject> genObjectMap;

    private void SetupMineralMap()
    {
        mineralMap = new Dictionary<string, Sprite>();

        string[] PieceTypeNames = System.Enum.GetNames(typeof(Mineral_type));
        for (int i = 0; i < PieceTypeNames.Length; i++)
        {
            if (i < mineralSprites.Count)
            {
                mineralMap.Add(PieceTypeNames[i], mineralSprites[i]);
            }
            else
            {
                throw new System.Exception("Not all sprites are set for each mineral type!! Check ItemInfo in Inventory controller!");
            }
        }
    }

    private void SetupSeedObjectMap()
    {
        seedObjectMap = new Dictionary<string, GameObject>();

        string[] PieceTypeNames = System.Enum.GetNames(typeof(Seed_type));
        for (int i = 0; i < PieceTypeNames.Length; i++)
        {
            if (i < seedObjects.Count)
            {
                seedObjectMap.Add(PieceTypeNames[i], seedObjects[i]);
            }
            else
            {
                throw new System.Exception("Not all sprites are set for each mineral type!! Check ItemInfo in Inventory controller!");
            }
        }
    }

    private void SetupGenObjectMap()
    {
        genObjectMap = new Dictionary<string, GameObject>();

        string[] PieceTypeNames = System.Enum.GetNames(typeof(Gen_type));
        for (int i = 0; i < PieceTypeNames.Length; i++)
        {
            if (i < genObjects.Count)
            {
                genObjectMap.Add(PieceTypeNames[i], genObjects[i]);
            }
            else
            {
                throw new System.Exception("Not all sprites are set for each mineral type!! Check ItemInfo in Inventory controller!");
            }
        }
    }


    private void SetupSeedMap()
    {
        seedMap = new Dictionary<string, Sprite>();

        string[] PieceTypeNames = System.Enum.GetNames(typeof(Seed_type));
        for (int i = 0; i < PieceTypeNames.Length; i++)
        {
            if (i < seedSprites.Count)
            {
                seedMap.Add(PieceTypeNames[i], seedSprites[i]);
            }
            else
            {
                throw new System.Exception("Not all sprites are set for each seed type!! Check ItemInfo in Inventory controller!");
            }
        }
    }
    private void SetupGenMap()
    {
        genMap = new Dictionary<string, Sprite>();

        string[] PieceTypeNames = System.Enum.GetNames(typeof(Gen_type));
        for (int i = 0; i < PieceTypeNames.Length; i++)
        {
            if (i < genSprites.Count)
            {
                genMap.Add(PieceTypeNames[i], genSprites[i]);
            }
            else
            {
                throw new System.Exception("Not all sprites are set for each seed type!! Check ItemInfo in Inventory controller!");
            }
        }
    }
    #endregion

    public Sprite GetMineralSprite(Mineral_type type)
    {
        Sprite sprite = mineralMap[type.ToString()];
        if (sprite == null)
        {
            throw new System.Exception("No sprite corresponding to type: " + type.ToString());
        }
        return sprite;
    }

    public Sprite GetSeedSprite(Seed_type type)
    {
        Sprite sprite = seedMap[type.ToString()];
        if (sprite == null)
        {
            throw new System.Exception("No sprite corresponding to type: " + type.ToString());
        }
        return sprite;
    }

    public Sprite GetGenSprite(Gen_type type)
    {
        Sprite sprite = genMap[type.ToString()];
        if (sprite == null)
        {
            throw new System.Exception("No sprite corresponding to type: " + type.ToString());
        }
        return sprite;
    }

    public GameObject GetSeedObject(Seed_type type)
    {
        GameObject obj = seedObjectMap[type.ToString()];
        if (obj == null)
        {
            throw new System.Exception("No object corresponding to type: " + type.ToString());
        }
        return obj;
    }

    public GameObject GetGenObject(Gen_type type)
    {
        GameObject obj = genObjectMap[type.ToString()];
        if (obj == null)
        {
            throw new System.Exception("No object corresponding to type: " + type.ToString());
        }
        return obj;
    }

}
