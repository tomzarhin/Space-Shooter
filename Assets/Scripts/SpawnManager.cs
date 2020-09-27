using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //create a coroutine of type IEnumerator -- Yield Events
    IEnumerator spawnRoutine()
    {
        float z_position, y_position, x_position;

        while (!_stopSpawning)
        {  
            x_position = Random.Range(-10.0f, 10.0f);
            y_position = 7;
            z_position = 0;

            Vector3 position = new Vector3(x_position, y_position, z_position);

            GameObject newEnemy = Instantiate(_enemyPrefab, position, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);//wait 5 secounds
            //yield return null; //wait 1 frame
        }
    }

    public void onPlayerDeath()
    {
        _stopSpawning = true;
    }
}
