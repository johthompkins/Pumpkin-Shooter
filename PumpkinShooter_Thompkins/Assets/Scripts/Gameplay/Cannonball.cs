using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }
    IEnumerator OnCollisionEnter(Collision collision)
    {
        //checking layer 10 which is Enemy
        if(collision.gameObject.layer == 10)
        {
            // show hitting particle
            foreach (ContactPoint contact in collision.contacts)
            {
                Instantiate(hitEffect, contact.point, Quaternion.identity);
        
            }
            //grab current score and add 1 to it
            string tempScoreTxt = GameObject.Find("HUDCanvas").GetComponent<HUD>()._scoreValue.text;
            int tempScoreInt = Convert.ToInt32(tempScoreTxt);
            tempScoreInt++;
            GameObject.Find("HUDCanvas").GetComponent<HUD>()._scoreValue.text = Convert.ToString(tempScoreInt);

            Destroy(collision.gameObject);

            //check for which pumpkin it hit
            if (collision.gameObject.tag.Contains("green"))
            {
                yield return new WaitForSeconds(1f);
                GameObject.Find("Spawners/CircularSpawner0").GetComponent<EnemySpawner>().SpawnEnemy();
            }
            if (collision.gameObject.tag.Contains("orange"))
            {
                yield return new WaitForSeconds(1f);
                GameObject.Find("Spawners/CircularSpawner1").GetComponent<EnemySpawner>().SpawnEnemy();
            }
            if (collision.gameObject.tag.Contains("purple"))
            {
                yield return new WaitForSeconds(1f);
                GameObject.Find("Spawners/CircularSpawner2").GetComponent<EnemySpawner>().SpawnEnemy();
            }

            yield return null;

        }
    }
}
