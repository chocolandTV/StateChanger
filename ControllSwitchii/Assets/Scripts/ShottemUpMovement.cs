using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShottemUpMovement : MonoBehaviour
{
    [SerializeField] private GameObject pallet;
    private Rigidbody2D rb;
    public float PalletCooldown = 0.5f;
  
    private float timer =0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 input = new Vector3 (PlayerController.Instance.nextDirection.x, PlayerController.Instance.nextDirection.y,0);
        rb.MovePosition(transform.position + input *PlayerController.Instance.movementSpeed * Time.deltaTime);
        if(PlayerController.Instance.isShooting && timer >=PalletCooldown)
        {
            Shooting();
            timer = 0.0f;
        }
        timer += Time.deltaTime;
    }
    private void Shooting()
    {
        GameObject _newObstacle =  Instantiate(pallet);
        _newObstacle.transform.position = transform.position;
        Rigidbody2D _rb = _newObstacle.GetComponent<Rigidbody2D>();
        _rb.AddForce(PlayerController.Instance.nextDirection * 33);
        Destroy(_newObstacle, 5);
        Debug.Log("Shooting");
    }
}
