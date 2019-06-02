using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // include so we can manipulate SceneManager

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player1;
    private GameObject player2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player1 = GameObject.FindWithTag("Player1");
        player2 = GameObject.FindWithTag("Player2");
        if( player1 == null ){
            //Time.timeScale = 0;
            Debug.Log("Player 2 wins");
            StartCoroutine(p2wins());
        } else if (player2 == null){
            //Time.timeScale = 0;
            Debug.Log("Player 1 wins");
            StartCoroutine(p1wins());
        }
    }

    IEnumerator p1wins() {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("p1wins");
    }
    IEnumerator p2wins() {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("p2wins");
    }
}
