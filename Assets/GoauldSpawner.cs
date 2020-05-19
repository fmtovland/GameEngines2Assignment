using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoauldSpawner : Spawner
{
	public int alkesh_count;
	public GameObject alkesh;
	public Vector3 spawnpoint;
	public float min_offset,max_offset;

	void Start()
	{
		shipPrefabs=new Dictionary<ShipClass,GameObject>
		{
			{ShipClass.alkesh, alkesh}
		};
		alligence_tag="goauld";
		enemy_tag="tauri";
		enemy_layer=1<<9;
	}
	
	public override void spawnArmy()
	{
		int s;
		Vector3 offset;

		for(int i=0; i<alkesh_count; i++)
		{
			offset=getRandomOffset(min_offset,max_offset);
			s=addShip(ShipClass.alkesh,spawnpoint+offset);
			ships[s].body.GetComponentInChildren<Arrive>().target=new Vector3(0,350,0) + offset;
		}
	}
}
