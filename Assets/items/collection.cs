using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class collection : MonoBehaviour
{
    public ParticleSystem collectionEffect;
    public Score score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If player collides with object, fruit is destroyed, particle plays, score is added to and the amount of fruit collected in that level is checked
        if (collision.gameObject.tag == "character")
        {
            Debug.Log("Fruit collected");
            Destroy(this.gameObject);
            playCollection(collectionEffect);
            score.AddScore();
            score.checkScore();

        }
    }
    // Start is called before the first frame update

    static void playCollection(ParticleSystem collision)
    {
        collision.Play();
    }
}
