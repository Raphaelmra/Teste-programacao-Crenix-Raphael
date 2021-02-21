using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public Collider2D collider;
    public Gear[] objects;
    public Gear connectedGear;
    public float distance;
    public GameManager gm;

    void Start()
    {
        collider = GetComponent<Collider2D>();
        objects = FindObjectsOfType<Gear>();
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        ConnectGearToInventory();
        DisconnectGearFromInventory();

       
       



    }
    void ConnectGearToInventory()//realiza atualização dos parâmtros no gameManager e também desativa o colisor, para não haver duas engrenagens no mesmo ponto
    {
        for (int x = 0; x < objects.Length; x++)
        {
            distance = Vector2.Distance(transform.position, objects[x].transform.position);
            if (distance < 1)
            {

                if (objects[x].conectedToInventory)
                {


                    collider.enabled = false;
                    objects[x].conectedToInventory = false;
                    connectedGear = objects[x];

                }


            }



        }
    }

    void DisconnectGearFromInventory()//ativa novamente o colisor para que outra engrenagem possa se conectar
    {
        if (collider.enabled == false && connectedGear.dragging == true)
        {
            collider.enabled = true;
        }

    }

 


}
