using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFX : MonoBehaviour
{
    public VisualEffect bloodVFX;

    private void Start()
    {
        StartCoroutine(DestroySelf());
    }

    public IEnumerator DestroySelf()
    {
        gameObject.transform.rotation = Quaternion.identity;
        bloodVFX.Play();
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    
}
