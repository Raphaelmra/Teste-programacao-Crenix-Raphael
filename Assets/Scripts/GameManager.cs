using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int QtdGearsConnected;
    public GearPlacement[] gearPlacements;

    public bool reseted;

    public Button button;
    public Sprite sprite;
    public Sprite clickedSprite;

    public TextMesh text;

    public Gear[] gears;

    public Inventory[] slots;
   

   
    void Start()
    {
        gearPlacements = FindObjectsOfType<GearPlacement>();
        gears = FindObjectsOfType<Gear>();
        slots = FindObjectsOfType<Inventory>();
        gearPlacements[0].isDownside = true;
        gearPlacements[1].isDownside = true;
        gearPlacements[2].isUpside = true;
        gearPlacements[3].isUpside = true;
        gearPlacements[4].isUpside = true;

    }

   
    void Update()
    {
        CheckVictory();
      
       
    }


    public void CheckVictory()//checa se todas as engrenagens estao conectadas, método que muda o texto
    {
        if (QtdGearsConnected >= 5)
        {
            for (int x = 0; x < gearPlacements.Length; x++)
            {
                gearPlacements[x].completed = true;
                text.text = "YAY, PARABENS." + "\r\n" + "TASK CONCLUÍDA!";
            }


        }
        else
        {
            text.text = "ENCAIXE AS ENGRENAGENS " + "\r\n" + "EM QUALQUER ORDEM";
            for (int x = 0; x < gearPlacements.Length; x++)
            {
                gearPlacements[x].completed = false;

            }
        }

    }

    public void Reset()//devolve todas as engrenagens para o inventário e reativa os colisores
    {
        QtdGearsConnected = 0;
        for (int x = 0; x < gearPlacements.Length; x++)
        {
            gears[x].transform.position = new Vector3(slots[x].transform.position.x, slots[x].transform.position.y, -1);

            reseted = true;
            gearPlacements[x].collider.enabled = true;
            slots[x].collider.enabled = true;


        }

        text.text = "ENCAIXE AS ENGRENAGENS "+ "\r\n" +"EM QUALQUER ORDEM";
    }

 


    public void Clicked()//muda o sprite para o sprite de botão clicado
    {
        button.image.sprite = clickedSprite;
    }
    public void Unclicked()//volta para o sprite padrão do botão
    {
        button.image.sprite = sprite;
    }
}
