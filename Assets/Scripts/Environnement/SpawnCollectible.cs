using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectible : MonoBehaviour
{
    public Collectible collectibleSpawned = null;

    private void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

        if (collectibleSpawned == null)
        {
            Debug.Log(collectibleSpawned);
            Destroy(this.gameObject);
        }
        else if (collectibleSpawned.collectibleName != GameManager.instance.collectibles[0].collectibleName)
            Spawn();
    }
        
    void Spawn()
    {
        if (collectibleSpawned != null)
        {
            Debug.Log("Destroying old spawned collectible");
            Destroy(collectibleSpawned.gameObject);
        }
        
        Debug.Log(this.gameObject.name + " is spawning "+ GameManager.instance.collectibles[0].collectibleName);
        collectibleSpawned = Instantiate(GameManager.instance.collectibles[0], this.transform.position, Quaternion.identity, this.transform);
    }
}
