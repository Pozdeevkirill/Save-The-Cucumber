using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKnifeController : MonoBehaviour
{
    public GameObject knifePrefab; // Префаб ножа
    public float SpawnDely; // Задержка межде спавном 

    private Vector3 _spawnPosition; // Позиция спавна
    public float _SpawnDely;
    public bool _spawn = true;

    public float speedKnife;

    // Start is called before the first frame update
    void Start()
    {
        _SpawnDely = SpawnDely;
        SpawnDely = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_spawn)
        {
            Spawn();
        }
    }

    void Spawn() // Метод спавна
    {
        _spawnPosition = new Vector2(transform.position.x, Random.Range(1.87f,-1.87f));

        if(SpawnDely <= 0)
        {
            Instantiate(knifePrefab, _spawnPosition, Quaternion.identity);
            SpawnDely = _SpawnDely;
        }
        else
        {
            SpawnDely -= Time.deltaTime;
        }
    }
}
