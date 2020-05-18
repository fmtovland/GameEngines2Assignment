using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Boid
{
	public GameObject missile;
	public int hitpoints;
	public int ammunition;
	public int time_between_shots;
	public int max_distance_to_target=150;
	public string enemy;

	bool reloading=false;

	void Start()
	{
		base.Start();
	}
	
	void Update()
	{
		base.Update();

		RaycastHit hit;
		Ray ray = new Ray(transform.position, transform.forward);
		if (Physics.Raycast(ray, out hit, max_distance_to_target))
		{
			if (hit.collider != null && hit.collider.tag==enemy)
			{
				shoot(hit.collider.gameObject);
			}
		}
	}
	
	public void shoot(GameObject target)
	{
		if(reloading) return;

		GameObject missile1=Instantiate(missile);
		missile.GetComponent<Chase>().target=target;
		ammunition--;
		StartCoroutine(cooldown());
	}

	IEnumerator cooldown()
	{
		reloading=true;
		yield return new WaitForSeconds(time_between_shots);
		reloading=false;
	}
}
