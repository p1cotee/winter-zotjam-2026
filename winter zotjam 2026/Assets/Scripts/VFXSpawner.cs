using UnityEngine;

public class VFXSpawner : MonoBehaviour
{
    public float countTime = 2f;
    public float currentTime = 0f;
    //public float spawnInterval = .5f;
    public GameObject vfxPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = countTime;
        Player.Instance.OnBlink += DestroyAll;
   
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

        }
        else
        {
            RandomSpawn();
            ResetTimer();
        }

    }

    public void ResetTimer()
    {
        currentTime = countTime;
    }

    public void RandomSpawn()
    {
        float randomX = Random.Range(-8f, 8f);
        float randomY = Random.Range(-6f, 6f);
        Vector3 randomPosition = new Vector3(randomX, randomY, 10);
        Instantiate(vfxPrefab, randomPosition, Quaternion.identity);
    }

    public void DestroyAll()
    {
        GameObject[] vfxObjects = GameObject.FindGameObjectsWithTag("VFX");
        foreach (GameObject vfx in vfxObjects)
        {
            Destroy(vfx);
        }
    }


}
