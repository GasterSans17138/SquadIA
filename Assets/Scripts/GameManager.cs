using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; //Use a prefab to instantiate the enemy because once they die they became allies
    [SerializeField] private List<int> enemyPerWave;
    [SerializeField] private GameObject allyPrefab; //Use a prefab to instantiate the enemy because once they die they became allies
    [SerializeField] private int allyToSpawnAtStart;

    [SerializeField] private GameObject minpoint;
    [SerializeField] private GameObject maxpoint;
    
    [SerializeField] private int wave;

    public List<GameObject> enemies = new();
    public List<GameObject> goodGuys = new();
    private int defaultEnemyPerWave = 3;


    //-WAVE-RELATED-FUNCTION-------------------------------------------
    private bool IsWaveFinished()
    {
        foreach (GameObject entity in enemies)
        {
            if (!entity.GetComponent<Entity>().isDead) return false;
        }
        return true;
    }

    private void Clean()
    {
        for(int i = 1; i < goodGuys.Count; i++)
        {
            goodGuys[i].GetComponent<Entity>().Reset();
        }
        foreach (GameObject entity in enemies) Destroy(entity);
        enemies.Clear();
    }

    private void StartWave(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 newPos = new Vector3(UnityEngine.Random.Range(minpoint.transform.position.x, maxpoint.transform.position.x), 1.66f, UnityEngine.Random.Range(minpoint.transform.position.z, maxpoint.transform.position.z));
            enemies.Add(Instantiate(enemyPrefab, newPos, Quaternion.identity));
        }
        wave++;
    }
    //-----------------------------------------------------------------

    private void SpawnAllies()
    {
        for (int i = 0; i < allyToSpawnAtStart; i++)
        {
            goodGuys.Add(Instantiate(allyPrefab, new Vector3(i * 2.0f, 1.66f, 0), Quaternion.identity));
        }
    }

    void Start()
    {
        if(enemyPerWave.Count == 0)
            enemyPerWave.Add(defaultEnemyPerWave);

        goodGuys.Add(GameObject.Find("Player"));
        SpawnAllies();
    }

    public void FixedUpdate()
    {
        if (goodGuys[0].GetComponent<Entity>().isDead)
        {
            SceneManager.UnloadSceneAsync(1);
            SceneManager.LoadScene(2);
        }   
        if (IsWaveFinished())
        {
            Clean();
            if(wave >= enemyPerWave.Count)
                StartWave(enemyPerWave.Last());
            else
                StartWave(enemyPerWave[wave]);
            Debug.Log("Test");
        }
    }
}
