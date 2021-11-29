using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] checkPoints;
    public GameObject playZone;

    // Start is called before the first frame update
    void Start()
    {
      
        InvokeRepeating("randomSpawn", 2, 1f);

        for (int i = 0; i < 10; i++) { randomSpawn(); }         // drop-in some items when started
    }


    void randomSpawn()                                              // random spawn function
    {
        int i = ((int)playZone.transform.localScale.x / 2) - 10;   // get spawn range to spawn items in zone only

        int checkPointIndex = Random.Range(0, 3);
        int randomX = Random.Range(-i, i);
        int randomY = Random.Range(-i, i);
        int randomZ = Random.Range(-i, i);

        Instantiate(                                                // create item at random location whithin zone
                    checkPoints[checkPointIndex], 
                    new Vector3(randomX, randomY, randomZ), 
                    checkPoints[checkPointIndex].transform.rotation
                    );
    }








}
