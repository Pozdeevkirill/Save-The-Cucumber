using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    public float speed;

    private GameObject SpawnController;
    // Start is called before the first frame update
    void Start()
    {
        SpawnController = GameObject.FindWithTag("Spawner");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        gameObject.transform.Translate(new Vector2(SpawnController.GetComponent<SpawnKnifeController>().speedKnife * Time.deltaTime,0));
    }
}
