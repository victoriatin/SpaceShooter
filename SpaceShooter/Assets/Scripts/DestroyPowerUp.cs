using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPowerUp : MonoBehaviour
{
    public GameObject explosion;
    public int scoreValue;
   private GameController gameController;
    void Start ()
    {
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }
        if (gameController == null)
        {
            Debug.Log ("Cannot find 'GameController' script");
        }
    }
    void OnTriggerEnter(Collider other){
    
     if (other.CompareTag ("Boundary") || other.CompareTag ("PowerUp"))
        {
            return;
        }
        if (explosion != null)
        {
        Instantiate(explosion, transform.position, transform.rotation);
        }
      gameController.AddScore (scoreValue);
        Destroy(gameObject);
    }
}