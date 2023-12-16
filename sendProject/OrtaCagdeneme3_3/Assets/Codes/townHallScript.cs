using UnityEngine;
using UnityEngine.UI;

public class townHallScript : MonoBehaviour
{
    public GameObject panel; // Unity Editor'da bağlantısını yapın
    void Start()
    {
         panel.SetActive(true);
       
    }
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("townHall"))
                {
                    
                }
                
                
            }
        }
    }
}
