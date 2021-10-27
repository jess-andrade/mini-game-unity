using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strawberry : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;
    public int Score = 10;

    // Start is called before the first frame update
    void Start()
    {

        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collider) //mesma logica de collision enter, mas é trigger pq passa por cima do objeto
    {
        if(collider.gameObject.tag == "Player") // minha maça colide com player 
        {
            sr.enabled = false; // desativa exibição do objeto
            circle.enabled = false; // desativa colisor
            collected.SetActive(true); // para exibir o efeito q ta desabilitado inicialmente

            Destroy(gameObject, 0.25f); // destruir em 0.25seg (float)
        }
    }
}
