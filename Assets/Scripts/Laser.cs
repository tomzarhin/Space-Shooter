using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _speed);
        //Destroy the laser if moving to much above
        if(transform.position.y > 8f)
        {
            Destroy(this.gameObject);
        }
    }
}
