using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    [SerializeField]
    private int _lives = 3;

    private float _nextFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        calculateMovement();
        //Firing laser
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            fireLaser();
        }
    }  

    void fireLaser()
    {
        _nextFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
    }

    void calculateMovement(){

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
         //Move the object one secound at a time
         //*_speed will perform speed steps in one secound
        Vector3 direction = new Vector3(horizontalInput,verticalInput,0);
        transform.Translate(direction * Time.deltaTime * _speed);
          //Boundries - player cannot cross these invisible lines

        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-10f,10f),transform.position.y,0);

        transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y,-3.8f,0),0);
	}

    public void damage()
    {
        _lives--;
        if (_lives == 0)
        {
            Destroy(this.gameObject);
            SpawnManager spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
            if(spawnManager != null)
            {
                spawnManager.onPlayerDeath();
            }
            else
            {
                Debug.Log("The spawn manager is null!");
            }
        }
    }
}
