using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Shield_Destroy : MonoBehaviour
{
    //If the shield's parent fly is grabbed, the shield will dissipate.
    void Update()
    {
        if (this.gameObject.transform.parent.GetComponent<Scr_Edible_Base>().grabbed)
        {Destroy(this.gameObject);}
    }
}