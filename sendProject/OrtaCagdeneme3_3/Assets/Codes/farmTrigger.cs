using System.Collections;
using UnityEngine;

public class farmTrigger : MonoBehaviour
{
    public int numberOfFoods= 0;
    public float interval = 5f; // Her kaç saniyede bir artırılacak
    private float timer = 0f;

    public GUIStyle style;

    void OnGUI()
    {
        // Ekranın sol üst köşesine sayıyı yazdır
        GUI.Label(new Rect(10, 50, 200, 20), "Food: " + numberOfFoods.ToString(), style);
    }

    void OnTriggerStay(Collider other)
    {
        // Timer'ı güncelle
        timer += Time.deltaTime;

        // Belirli bir süre geçtikten sonra
        if (timer >= interval)
        {
            // Sayıyı artır
            numberOfFoods += 1;
            

            // Timer'ı sıfırla
            timer = 0f;
        }
    }
}
