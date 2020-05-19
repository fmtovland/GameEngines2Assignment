using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : OffsetPursue
{
	void Update()
	{
		transform.LookAt(target.transform.position);
	}
}
