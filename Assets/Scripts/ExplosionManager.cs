using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//////////////////////////////////////////////////////////////////////// 
//                    COMP3064 CRN13899 Final                         //
//                       Friday, January 19, 2018                     //
//                    Instructor: Przemyslaw Pawluk                   //
//                     Vishvajit Kher  - 101015270                    //
//                    vishvajit.kher@georgebrown.ca                   //
////////////////////////////////////////////////////////////////////////
public class ExplosionManager : MonoBehaviour {

    void Start()
    {
        StartCoroutine(ExplosionEnumerator());
    }

    IEnumerator ExplosionEnumerator()
    {
        yield return new WaitForSeconds(0.2f);
        DestroyMe();
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
