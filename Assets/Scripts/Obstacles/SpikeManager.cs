using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    public static SpikeManager Instance = null;

    [SerializeField]
    GameObject spikePrefab;
    public Player player;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spikePrefab, new Vector2(55f, -52.98f), spikePrefab.transform.rotation);
        Instantiate(spikePrefab, new Vector2(55.9f, -52.98f), spikePrefab.transform.rotation);
        Instantiate(spikePrefab, new Vector2(56.8f, -52.98f), spikePrefab.transform.rotation);
        Instantiate(spikePrefab, new Vector2(57.7f, -52.98f), spikePrefab.transform.rotation);
        Instantiate(spikePrefab, new Vector2(58.6f, -52.98f), spikePrefab.transform.rotation);
        Instantiate(spikePrefab, new Vector2(59.4f, -52.98f), spikePrefab.transform.rotation);
        Instantiate(spikePrefab, new Vector2(60.3f, -52.98f), spikePrefab.transform.rotation);
        Instantiate(spikePrefab, new Vector2(61.2f, -52.98f), spikePrefab.transform.rotation);

    }

    IEnumerator SpawnSpike(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(2f);
        Instantiate(spikePrefab, spawnPosition, spikePrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
