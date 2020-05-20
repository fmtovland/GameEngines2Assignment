using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSpaceScene : MonoBehaviour
{
	public void OnTriggerEnter(Collider collider)
	{
		SceneManager.LoadScene("DeathOfAnubis");
	}
}
