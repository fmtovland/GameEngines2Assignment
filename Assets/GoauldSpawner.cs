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
	}
	
	void spawnShips()
	{
		for(int i=0; i<alkesh_count; i++)
		{
			addShip(ShipClass.alkesh,spawnpoint+getRandomOffset(min_offset,max_offset));
		}
	}
}
