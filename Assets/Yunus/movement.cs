using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movement : MonoBehaviour
{
    public NavMeshAgent agent;
    private bool secili = false;
    private Vector3 hedefPozisyon;
    
    
  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray movePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(movePosition, out var hitInfo)){
                 if (!secili)
                {
                    // Eğer tıklanan nesne bu scriptin bağlı olduğu nesne ise karakteri seç
                    if (hitInfo.collider.gameObject == gameObject )
                    {
                        secili = true;
                    }
                }
                else
                {
                    // Seçili karaktere tıklanan yere gitmesini söyle
                    if (hitInfo.collider.gameObject == gameObject)
                    {
                        // Seçili karakterin hedef pozisyonunu sıfırlayarak hareketini durdurma
                        agent.SetDestination(transform.position);
                    }
                    else
                    {
                        // Diğer karakterlere tıklandığında, seçili karakteri tıklanan yere hareket ettirme
                        hedefPozisyon = hitInfo.point;
                        agent.SetDestination(hedefPozisyon);
                    }
                }
                
            }
           
        }

    }
}
