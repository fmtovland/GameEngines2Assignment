using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Boid
{
	public GameObject missile;
	public int hitpoints;
	public int ammunition=0;
	public int time_between_shots;
	public int max_distance_to_target=750;
	public string enemy;
	public int enemy_layer;
	public bool seek_and_destroy=true;
	public Vector3 battlezone=new Vector3(0,400,0);

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

		if(Vector3.Distance(transform.position,battlezone)>1200)
		{
			transform.LookAt(battlezone);
		}
	}
	
	public void shoot(GameObject target)
	{
		if(reloading) return;

		if(ammunition!=0)
		{
			GameObject missile1=Instantiate(missile,transform);
			Chase missileChaser=missile1.GetComponent<Chase>();
			if(missileChaser!=null) missileChaser.target=target;
			missile1.GetComponent<Projectile>().friend_tag=this.tag;
			ammunition--;
			StartCoroutine(cooldown());
		}
	}

	public void Damage(int hitpoints)
	{
		this.hitpoints-=hitpoints;
		if(this.hitpoints<=0)
		{
			GameObject explosion=transform.Find("Explosion").gameObject;
			explosion.SetActive(true);
			explosion.transform.parent=null;

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
