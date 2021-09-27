using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class explode : MonoBehaviour

  
{
    bool canexplode = false;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)& !canexplode)
        {
            canexplode = true;
            foreach(Transform child in this.transform)
            {
                child.gameObject.TryGetComponent<Rigidbody>(out Rigidbody childrigid);
                childrigid.AddExplosionForce(Random.Range(600,1400), transform.position, 20) ;
                StartCoroutine(loadscene());
            }
        }
    }
    IEnumerator loadscene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("SampleScene");
        canexplode = false;
    }


}
