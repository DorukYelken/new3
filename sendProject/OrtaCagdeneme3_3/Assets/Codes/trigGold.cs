using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigGold : MonoBehaviour
{


    public int numberToDisplay = 0;
    public GUIStyle style;

    void OnGUI()
    {
        // Ekranın sol üst köşesine sayıyı yazdır
        GUI.Label(new Rect(10, 10, 200, 20), "Sayı: " + numberToDisplay.ToString(), style);

      
    }

    void OnTriggerStay(Collider other)
    {
         
        Debug.Log("Sayı: " + numberToDisplay);

        // Her girişte sayıya 5 ekle
        numberToDisplay += 5;
    }
}

