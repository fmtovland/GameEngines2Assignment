using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipClass{prometheus,jet,hatak_sg1,alkesh};

public struct Ship
{
	public GameObject body;
	public ShipClass type;
	public Boid boid;
}

public abstract class Spawner : MonoBehaviour
{
	public List<Ship> ships=new List<Ship>();
	protected Dictionary<ShipClass,GameObject> shipPrefabs;
	protected string alligence_tag;
	protected string enemy_tag;
	protected int enemy_layer;
	
	protected int addShip(ShipClass sc,Vector3 pos,Quaternion rot)
	{
		Ship ship=new Ship();
		ship.type=sc;

		ship.body=Instantiate(shipPrefabs[sc]);
		ship.boid=ship.body.GetComponent<Boid>();
		ship.body.transform.position=pos;
		ship.body.transform.rotation=rot;
		ship.body.tag=alligence_tag;

		Fighter fighter=ship.body.GetComponentInChildren<Fighter>();
		if(fighter!=null)
		{
			fighter.enemy=enemy_tag;
			fighter.enemy_layer=enemy_layer;
		}

		ships.Add(ship);
		return ships.Count-1;
	}

	protected Vector3 getRandomOffset(float minOffset, float maxOffset)
	{
		Vector3 t = new Vector3(
			Random.Range(-maxOffset,maxOffset),
			Random.Range(-maxOffset,maxOffset),
			Random.Range(-maxOffset,maxOffset)
		);

		if(t.x<0) t.x-=minOffset; else t.x+=minOffset;
		if(t.y<0) t.y-=minOffset; else t.y+=minOffset;
		if(t.z<0) t.z-=minOffset; else t.z+=minOffset;

		return t;
	}
	
	public abstract void spawnArmy();
}
