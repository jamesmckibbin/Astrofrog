using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ShieldDestroy : MonoBehaviour
{
    //If the shield's parent fly is grabbed, the shield will dissipate.
    void Update()
    {
        if (this.gameObject.transform.parent.GetComponent<S_EdibleBase>().Grabbed)
        {
            Destroy(this.gameObject);
        }
    }
}