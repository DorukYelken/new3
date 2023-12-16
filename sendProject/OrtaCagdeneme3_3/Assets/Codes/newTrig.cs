using System.Collections;
using UnityEngine;

public class newTrig : MonoBehaviour
{
    public int numberOfGolds = 0;
    public float interval = 5f; // Her kaç saniyede bir artırılacak
    private float timer = 0f;

    public GUIStyle style;

    void OnGUI()
    {
        // Ekranın sol üst köşesine sayıyı yazdır
        GUI.Label(new Rect(10, 10, 200, 20), "Gold: " + numberOfGolds.ToString(), style);
    }

    void OnTriggerStay(Collider other)
{
    // Check if the other collider has a Rigidbody component
    Rigidbody rb = other.GetComponent<Rigidbody>();

    // If a Rigidbody is found, reset its velocity to zero
    if (rb != null)
    {
        rb.velocity = Vector3.zero;

        // Increment numberOfGolds after a certain interval
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            // Increment the count
            numberOfGolds += 1;

            // Reset the timer
            timer = 0f;
        }
    }
}
}

