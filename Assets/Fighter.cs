using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Boid
{
	public GameObject missile;
	public int hitpoints;
	public int ammunition=0;
	public int time_between_shots;
	public int max_distance_to_target=150;
	public string enemy;
	public int enemy_layer;
	public bool seek_and_destroy=true;

	bool reloading=false;

	void Start()
	{
		base.Start();
		
		if(seek_and_destroy)
		{
			SeekAndDestroy seekndestroy=gameObject.AddComponent<SeekAndDestroy>();
			seekndestroy.enemy_layer=enemy_layer;
			seekndestroy.active=true;
			influencers.Add(seekndestroy);
		}
	}
	
	void Update()
	{
		base.Update();

		RaycastHit hit;
		if (Physics.SphereCast(transform.position, max_distance_to_target, transform.forward, out hit, max_distance_to_target, enemy_layer))
		{
			if (hit.collider != null)
			{
				shoot(hit.collider.gameObject);
			}
		}
	}
	
	public void shoot(GameObject target)
	{
		if(reloading) return;

		if(ammunition!=0)
		{
			GameObject missile1=Instantiate(missile);
			Chase missileChaser=missile1.GetComponent<Chase>();
			if(missileChaser!=null) missileChaser.target=target;
			ammunition--;
			StartCoroutine(cooldown());
		}
	}

	public void Damage(int hitpoints)
	{
		this.hitpoints-=hitpoints;
		if(this.hitpoints<=0)
		{
			Destroy(gameObject);
		}
	}

	IEnumerator cooldown()
	{
		reloading=true;
		yield return new WaitForSeconds(time_between_shots);
		reloading=false;
	}
}
