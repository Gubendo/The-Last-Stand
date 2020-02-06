using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrackGestion : Building
{

    public int epeiste_lvl;
    public int piquier_lvl;
    public int chevalier_lvl;
    //public GameObject[] units;
    public Sprite[] units_icons_sprites;
    public Text[] units_lvl;
    public Image[] units_icon_ui;

    override protected void OnClick()
    {
        canvas.SetActive(true);
        canvas.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Image>().sprite = building_icon;
        for (int i=0; i<3; i++)
        {
            units_icon_ui[i].sprite = units_icons_sprites[i];
        }

    }

    //Débloque le personnage de l'épéiste
    public void SwordConstruct()
    {
        if(epeiste_lvl <1)
        {
            epeiste_lvl = 1;
            units_lvl[0].text = "1";
        }
        else
        {
            Debug.Log("Cette branche a déjà été construite.");
        }
    }

    //Améliore le personnage de l'épéiste
    public void SwordImprove()
    {
        if (epeiste_lvl>=1 && epeiste_lvl<5)
        {
            epeiste_lvl += 1;
            units_lvl[0].text = epeiste_lvl.ToString();

        }
        else if (epeiste_lvl>=5)
        {
            Debug.Log("Le niveau des épéistes ne peut pas être amélioré davantage.");
        }
        else if (epeiste_lvl < 1)
        {
            Debug.Log("Construisez d'abord cette branche de la caserne");
        }
    }

    //Débloque le personnage du piquier
    public void PikemanConstruct()
    {
        if (piquier_lvl < 1)
        {
            piquier_lvl = 1;
            units_lvl[1].text = "1";
        }
        else
        {
            Debug.Log("Cette branche a déjà été construite.");
        }
    }

    //Améliore le personnage du piquier
    public void PikemanImprove()
    {
        if (piquier_lvl >= 1 && piquier_lvl < 5)
        {
            piquier_lvl += 1;
            units_lvl[1].text = piquier_lvl.ToString();
        }
        else if (piquier_lvl >= 5)
        {
            Debug.Log("Le niveau des piquiers ne peut pas être amélioré davantage.");
        }
        else if (piquier_lvl < 1)
        {
            Debug.Log("Construisez d'abord cette branche de la caserne");
        }
    }

    //Débloque le personnage du chevalier
    public void KnightConstruct()
    {
        if (chevalier_lvl < 1)
        {
            chevalier_lvl = 1;
            units_lvl[2].text = "1";
        }
        else
        {
            Debug.Log("Cette branche a déjà été construite.");
        }
    }

    //Améliore le personnage du chevalier
    public void KnightImprove()
    {
        if (chevalier_lvl >= 1 && chevalier_lvl < 5)
        {
            chevalier_lvl += 1;
            units_lvl[2].text = chevalier_lvl.ToString();
        }
        else if (chevalier_lvl >= 5)
        {
            Debug.Log("Le niveau des chevaliers ne peut pas être amélioré davantage.");
        }
        else if (chevalier_lvl < 1)
        {
            Debug.Log("Construisez d'abord cette branche de la caserne");
        }
    }


}
