using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [Header("Elements")]


    [SerializeField] private Chunk[] chunksPrefabs;

    private GameObject finishLine;
    [SerializeField] private LevelSO[] levels;

    public static ChunkManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
        finishLine = GameObject.FindWithTag("Finish");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GenerateLevel()
    {
        int currentLevel = GetLevel();
        currentLevel = currentLevel % levels.Length;
        LevelSO level = levels[currentLevel];
        CreateLevel(level.chunks);
    }


    private void CreateLevel(Chunk[] levelChunks) //unused now, only for testing
    {
        Vector3 chunkPosition = Vector3.zero;

        for (int i = 0; i < levelChunks.Length; i++)
        {
            Chunk chunkToCreate = levelChunks[i];
            if (i > 0)
            {
                chunkPosition.z += chunkToCreate.GetLength() / 2;
            }
            Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);
            chunkPosition.z += chunkInstance.GetLength() / 2;
        }
    }
    private void CreateRandomLevel()//unused now, only for testing
    {
        Vector3 chunkPosition = Vector3.zero;

        for (int i = 0; i < chunksPrefabs.Length; i++)
        {
            Chunk chunkToCreate = chunksPrefabs[Random.Range(0, chunksPrefabs.Length)];
            if (i > 0)
            {
                chunkPosition.z += chunkToCreate.GetLength() / 2;
            }
            Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);
            chunkPosition.z += chunkInstance.GetLength() / 2;
        }
    }
    public float GetFinishLineZ()
    { // we get finish line's z position
        
        return finishLine.transform.position.z;
    }
    public int GetLevel()
    {
        //Debug.Log(PlayerPrefs.GetInt("level", 0));
        return PlayerPrefs.GetInt("level",0);
    }
}
