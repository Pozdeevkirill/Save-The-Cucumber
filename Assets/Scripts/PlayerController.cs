using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedRotation; // �������� ��������
    [HideInInspector]
    public float _speedRotation;
    public GameObject Weel; // ������, �� ���� �������� ����� ��������� �����
    public GameObject GameControllerObj; // ���������� ����


    private void Start()
    {
        _speedRotation = speedRotation;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.RotateAround(Weel.transform.localPosition, Vector3.back, speedRotation *Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            speedRotation *= -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Knife")
        {
            GameControllerObj.GetComponent<GameController>().EndGame();
        }
    }
}
