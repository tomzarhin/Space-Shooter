using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 4.0f;

    private float randomX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        randomX = Random.Range(-10.0f, 10.0f);
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        //Respone
        if(transform.position.y < -5f)
        {
            transform.position = new Vector3(randomX, 7f,0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            other.transform.GetComponent<Player>().damage();
        }
        if (other.gameObject.CompareTag("Laser"))
        {
            //randomX = Random.Range(-10.0f, 10.0f);
            //transform.position = new Vector3(randomX, 7f, 0f);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
