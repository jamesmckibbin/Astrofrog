using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDestroy : MonoBehaviour
{
    //If the shield's parent fly is grabbed, the shield will dissipate.
    void Update()
    {
        if (this.gameObject.transform.parent.GetComponent<EdibleBase>().Grabbed)
        {
            Destroy(this.gameObject);
        }
    }
}