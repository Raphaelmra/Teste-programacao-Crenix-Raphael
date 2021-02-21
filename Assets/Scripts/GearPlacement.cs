using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearPlacement : MonoBehaviour
{
    
   
    public Collider2D collider;
    public Gear[] objects;
    public Gear connectedGear;
    public float distance;
    public GameManager gm;

    [Space]
    [Header("General Components")]
    public bool isUpside;
    public bool isDownside;
    public int forceRotate;
    public bool completed;

    void Start()
    {
        collider = GetComponent<Collider2D>();


        objects = FindObjectsOfType<Gear>();
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {

        SetForceRotation();    
        ConnectGearToPlacement();
        DisconnectGearToPlacement();






    }


    void SetForceRotation()//diz para a engrenagem para qual direção ela deverá rodar
    {
        if (isUpside)
        {
            forceRotate = -2;
        }
        if (isDownside)
        {
            forceRotate = 2;
        }
        if (connectedGear != null && completed)
        {
            connectedGear.Rotate(forceRotate);

        }

    }


    void ConnectGearToPlacement()//realiza atualização dos parâmtros no gameManager e também desativa o colisor, para não haver duas engrenagens no mesmo ponto
    {
        for (int x = 0; x < objects.Length; x++)
        {
            distance = Vector2.Distance(transform.position, objects[x].transform.position);
            if (distance < 1)
            {

                if (objects[x].conectedToPlacement)
                {
                    gm.QtdGearsConnected++;
                    collider.enabled = false;
                    objects[x].conectedToPlacement = false;
                    connectedGear = objects[x];
                    connectedGear.Rotate(2);

                }


            }



        }
    }


    void DisconnectGearToPlacement()//ativa novamente o colisor para que outra engrenagem possa se conectar
    {
        if (collider.enabled == false && connectedGear.dragging == true)
        {
            collider.enabled = true;
            gm.QtdGearsConnected--;



        }

    }

   
   
   
}
