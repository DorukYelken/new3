using UnityEngine;

public class ClickToInstantiate : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    private bool isKey1 = false;
    private bool isKey2 = false;
    private bool isKey3 = false;
    void Update()
    {
        
         if (Input.GetKeyDown(KeyCode.U))
        {
            isKey1 = true;
            isKey2 = false; 
            isKey3 = false;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            isKey1 = false;
            isKey2 = true;
            isKey3 = false;
        }

         if (Input.GetKeyDown(KeyCode.O))
        {
            isKey1 = false;
            isKey2 = false;
            isKey3 = true;
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isKey1 = false; 
            isKey2 = false;        
            isKey3 = false;
        }
        if (isKey1 &&  Input.GetMouseButtonDown(0))
        {
            if(FindObjectOfType<newTrig>().numberOfGolds >= 5){
            instantiateBuilding(prefab1); 
            FindObjectOfType<newTrig>().numberOfGolds -= 5;
            }
        }
        if (isKey2 &&  Input.GetMouseButtonDown(0))
        {
            instantiateBuilding(prefab2); 
        }

        if (isKey3 &&  Input.GetMouseButtonDown(0))
        {
            if(FindObjectOfType<newTrig>().numberOfGolds >= 5){
            instantiateBuilding(prefab3); 
            FindObjectOfType<newTrig>().numberOfGolds -= 5;
            }
        }
        
        
    }

public void instantiateBuilding(GameObject prefabName){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Ray'in bir şeyi vurup vurmadığını kontrol et
            if (Physics.Raycast(ray, out hit))
            {
                // Tıklanan noktada prefabı instantiate et
                Instantiate(prefabName, hit.point, Quaternion.identity);
            }
            }
}
