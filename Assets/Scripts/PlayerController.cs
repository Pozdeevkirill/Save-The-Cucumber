using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedRotation; // Скорость поворота
    public GameObject Weel; // Объект, во круг которого будет вращаться игрок
    public GameObject GameControllerObj; // Контроллер игры

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.RotateAround(Weel.transform.localPosition, Vector3.back, speedRotation *Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            speedRotation *= -1;
        }
    }
    void Rotation()
    {
        gameObject.transform.RotateAround(Weel.transform.localPosition, Vector3.back, Time.deltaTime * speedRotation);

        //Телефоны
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        speedRotation *= -1;
        //    }
        //}

        //Тест на пк
        
          
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Knife")
        {
            GameControllerObj.GetComponent<GameController>().EndGame();
        }
    }
}
