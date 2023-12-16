using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class Mover : MonoBehaviourPunCallbacks
{
    private NavMeshAgent navMeshAgent;
    public bool isPlayerSelected = false;

    private Vector3 destination;

    void Start()
    {
        // NavMeshAgent bileşenini al
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(photonView.IsMine){
        if (Input.GetKeyDown(KeyCode.K))
        {
            isPlayerSelected = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            // Ray oluştur
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Tıklanan obje bir oyuncu mu diye kontrol et
                if (hit.collider.CompareTag("Player1"))
                {
                    // Birinci tıklamada oyuncuyu seç
                    isPlayerSelected = true;
                }
                else if (hit.collider.CompareTag("Player2"))
                {
                    // Birinci tıklamada oyuncuyu seçme
                    isPlayerSelected = false;
                }
                else if (hit.collider.CompareTag("Player3"))
                {
                    // Birinci tıklamada oyuncuyu seçme
                    isPlayerSelected = false;
                }
                else if (hit.collider.CompareTag("InvisibleCube") && !IsInsideCube())
                {
                    // Eğer tıklanan obje görünmez küp ve oyuncu küpün içinde değilse, küpe git
                    destination = hit.collider.transform.position;
                    navMeshAgent.SetDestination(destination);
                    isPlayerSelected = true;
                }
                else if (isPlayerSelected)
                {
                    // İkinci tıklamada tıklanan yere git
                    destination = hit.point;
                    navMeshAgent.SetDestination(destination);
                    isPlayerSelected = true;
                }
            }
        }
}
        // Her frame'de hareket animasyonunu güncelle
     //   UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        if (isPlayerSelected)
        {
            // Eğer oyuncu seçiliyse, animasyonu güncelle
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
        else
        {
            // Eğer oyuncu seçili değilse, animasyonu sıfırla
            GetComponent<Animator>().SetFloat("forwardSpeed", 0f);
        }
    }

    private bool IsInsideCube()
    {
        // Küpün içinde mi kontrolü yap
        Collider collider = GetComponent<Collider>();
        return collider.bounds.Intersects(navMeshAgent.gameObject.GetComponent<Collider>().bounds);
    }
}

