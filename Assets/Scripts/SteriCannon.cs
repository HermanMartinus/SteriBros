using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteriCannon : MonoBehaviour
{

    public List<GameObject> _items = new List<GameObject>();
    public float _force;
    public GameObject boom;
    int index = 0;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Shoot", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Shoot()
    {
        boom.SetActive(false);
        boom.SetActive(true);
        GameObject spawnedItem = Instantiate(_items[index]);
        spawnedItem.transform.position = transform.position;
        spawnedItem.GetComponent<Rigidbody2D>().AddRelativeForce(transform.up * _force, ForceMode2D.Impulse);
        if (index < _items.Count - 1)
            index++;
        else
            index = 0;
    }

}
