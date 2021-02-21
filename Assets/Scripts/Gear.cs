using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Gear : MonoBehaviour


{
   
    Vector3 initialPosition;
    Vector3 destination;
    Vector3 directionVector;


    Rigidbody2D _rigidbody2D;
    public bool dragging;
    [Range(1, 15)]
    public float speed = 10;
    [Space]
    [Header("Check Connections")]
    public bool touchedGearPlacement;
    public bool touchedInventory;
    public bool conectedToPlacement;
    public bool conectedToInventory;
    
    
    Vector3 GearPlacementPosition;
    Vector3 InventoryPosition;
   

  
    void Start()
    {
       
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
    }
    
    void Update()
    {
      
        
    }

    
   
    void OnMouseDown()//pega a posição do mouse no momento em que é clicado em cima da engrenagem
    {
        dragging = true;
        initialPosition = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _rigidbody2D.gravityScale = 0;
        speed = 10;
      
      
    }

    void OnMouseDrag()//atualiza a posicao do mouse e move a engrenagem para a posição
    {
        
        destination = initialPosition + Camera.main.ScreenToWorldPoint(Input.mousePosition);
        directionVector = destination - transform.position;
        _rigidbody2D.velocity = directionVector * speed;
    }

    void OnMouseUp()//zera a velocidade da engrenagem e checa se ela está conectada a algo
    {
        _rigidbody2D.velocity = Vector2.zero;
        dragging = false;
        
        
        if (touchedGearPlacement)
        {
            transform.position = new Vector3(GearPlacementPosition.x, GearPlacementPosition.y, -1);
            conectedToPlacement = true;
        }

        if (touchedInventory)
        {
            transform.position = new Vector3(InventoryPosition.x, InventoryPosition.y, -1);
            conectedToInventory = true;
        }
        
      
    }


   

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == "Inventory")
        {
            InventoryPosition = collision.transform.position;
            touchedInventory = true;
        }

        if (collision.tag == "GearPlacement")
        {
            GearPlacementPosition = collision.transform.position;
            touchedGearPlacement = true;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "GearPlacement")
        {
            GearPlacementPosition = collision.transform.position;
            touchedGearPlacement = true;
        }

        if (collision.tag == "Inventory")
        {
            InventoryPosition = collision.transform.position;
            touchedInventory = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        touchedGearPlacement = false;
        touchedInventory = false;
    }


    public void Rotate(int force)//realiza a rotação com base na rotateForce enviada pela classe GearPlacement
    {
        transform.Rotate(new Vector3(0, 0, force));
    }










}
