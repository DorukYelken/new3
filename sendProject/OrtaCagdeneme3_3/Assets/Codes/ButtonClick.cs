using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonClick : MonoBehaviour
{
    private Rigidbody prefabRigidbody;
    public GameObject Player1;
    public GameObject Player1A;
    public GameObject Player2;
    public Button buton;
    public Button buton2;
    public Button buton3;
    public Button buton4;
    public bool explorerBool = false;
    private IEnumerator coroutine;
 private int buttonClickCount = 0;
    private int maxButtonClicks = 5; // Maksimum tıklama sayısı
    private float waitTimeBetweenClicks = 5f; // Tıklamalar arasındaki bekleme süresi

    void Start()
    {
        float var1 = Random.Range(0,2);
        int intVar = Mathf.RoundToInt(var1);
        Debug.Log(intVar.ToString());
       if( intVar == 0){
        
            buton.onClick.AddListener(() => ButonaTiklandi(Player1A , buton));
            Debug.Log("if");
            
        }else{
            
            buton.onClick.AddListener(() => ButonaTiklandi(Player1 , buton));
            Debug.Log("else");
            
        }
        
        
        buton2.onClick.AddListener(() => ButonaTiklandi2(Player2 , buton2));

        
    }

    

    // Buton tıklandığında çağrılacak metod
    void ButonaTiklandi(GameObject player, Button button)
    {
        if (buttonClickCount < maxButtonClicks)
        {
            coroutine = WaitforInstantiate(waitTimeBetweenClicks * buttonClickCount, player, button);
            StartCoroutine(coroutine);

            buttonClickCount++;
        }
    }

    void ButonaTiklandi2(GameObject player , Button button)
    {
        if(explorerBool){
            Debug.Log("Kaşif Mevcut");
        }else{
            coroutine = WaitforInstantiate(5f , player , button);
            StartCoroutine(coroutine);
            explorerBool = true;
        }
        
        
        
    }

    void ButonaTiklandi3(GameObject player , Button button)
    {
        
        coroutine = WaitforInstantiate(5f , player , button);
        StartCoroutine(coroutine);
        
        
    }

    


    private IEnumerator WaitforInstantiate(float waitTime , GameObject player , Button button)
    {
        if(button != buton){
            button.interactable = false;
            yield return new WaitForSeconds(waitTime);
        }else{
            button.interactable = true;
            yield return new WaitForSeconds(waitTime);
        }
       
        
        
        // Instantiate the player object after waiting for waitTime
        GameObject playerInstance = Instantiate(player, new Vector3(315f, 0.1f, 250f), Quaternion.identity);
        yield return new WaitForSeconds(waitTime);
        prefabRigidbody = playerInstance.GetComponent<Rigidbody>();
        button.interactable = true;
        // Disable the button interaction after instantiation
        
    }

    private IEnumerator Wait(float time){
         yield return new WaitForSeconds(time);
    }
}
