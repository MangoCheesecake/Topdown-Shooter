using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject zombie;
    public GameObject zombieBoss;
    public List<Transform> spawnPositions;
    public float timeLeft;

    void Start()
    {
        StartCoroutine(Spawn());
    }
	
    void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
    }

    IEnumerator Spawn()
    {
        int spawnNum;
        Vector3 spawnPosition;

        while (timeLeft > 0)
        {
            spawnNum = Random.Range(0, 7);

            spawnPosition = new Vector3(spawnPositions[spawnNum].position.x,
                                                spawnPositions[spawnNum].position.y,
                                                spawnPositions[spawnNum].position.z);
            Instantiate(zombie, spawnPosition , Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }
        yield return new WaitForSeconds(5);
        spawnNum = Random.Range(0, 7);
        spawnPosition = new Vector3(spawnPositions[spawnNum].position.x,
                                    spawnPositions[spawnNum].position.y,
                                    spawnPositions[spawnNum].position.z);
        Instantiate(zombieBoss, spawnPosition, Quaternion.identity);
    }
}
