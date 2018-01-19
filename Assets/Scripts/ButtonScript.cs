using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//////////////////////////////////////////////////////////////////////// 
//                    COMP3064 CRN13899 Final                         //
//                       Friday, January 19, 2018                     //
//                    Instructor: Przemyslaw Pawluk                   //
//                     Vishvajit Kher  - 101015270                    //
//                    vishvajit.kher@georgebrown.ca                   //
////////////////////////////////////////////////////////////////////////
public class ButtonScript : MonoBehaviour {

	public void RestartButtonClick()
	{
		SceneManager.LoadScene("main");
	}

}
