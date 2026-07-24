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
        if (other.CompareTag("levelend"))
        {
            Invoke("levelended", 0.2f);
        }
        
        
    }


    void levelended()

    {
        successtext.gameObject.SetActive(true);
        SceneManager.LoadScene(0);
    }
}
