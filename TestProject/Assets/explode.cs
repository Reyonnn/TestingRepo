using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class explode : MonoBehaviour

  
{
    bool canexplode = false;
    public Camera cameraa;
   
    // Start is called before the first frame update
    void Start()
    {
        cameraa = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)& !canexplode)
        {
            canexplode = true;
            foreach(Transform child in this.transform)
            {
                Vector3 direction = (cameraa.gameObject.transform.position - this.transform.position).normalized;
                
                child.gameObject.TryGetComponent <Rigidbody>(out Rigidbody childrigid);
                childrigid.AddExplosionForce(Random.Range(600,1400), direction, 20) ;
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
