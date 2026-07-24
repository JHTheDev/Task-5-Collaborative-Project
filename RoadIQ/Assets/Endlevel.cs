using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endlevel : MonoBehaviour
{
   

    public TextMeshProUGUI successtext;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            successtext.gameObject.SetActive(true);
            Invoke("levelended", 3f);
        }
        
        
    }


    void levelended()

    {
        
        SceneManager.LoadScene(0);
    }
}
