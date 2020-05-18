using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TauriSpawner : Spawner
{
	public int jetCount=0;
	public float minJetOffset=150;
	public float maxJetOffset=200;
	
	public Vector3 SG1_spawnpoint;
	public Vector3 Prometheus_spawnpoint;

	public GameObject camera;
	int cameraTarget=-1;
	OffsetPursue camOffsetPursue;

	public GameObject Prometheus;
	public GameObject Jet;
	public GameObject Hatak_SG1;

	public Dictionary<ShipClass,Vector3> cameraParams=
		new Dictionary<ShipClass,Vector3>
	{
		{ShipClass.prometheus,new Vector3(0,200,-750)},
		{ShipClass.jet,new Vector3(0,15,-40)},
		{ShipClass.hatak_sg1,new Vector3(0,25,-50)}
	};

	// Start is called before the first frame update
	void Start()
	{
		shipPrefabs=new Dictionary<ShipClass,GameObject>
		{
			{ShipClass.prometheus,Prometheus},
			{ShipClass.jet,Jet},
			{ShipClass.hatak_sg1,Hatak_SG1}
		};

		addShip(ShipClass.hatak_sg1,SG1_spawnpoint);
		//spawnShips();
		camOffsetPursue=camera.GetComponent<OffsetPursue>();
		//camera.transform.position=ships[0].body.transform.position + cameraParams[ShipClass.hatak_sg1];
		camera.transform.SetParent(ships[0].body.transform);
		ships[0].body.GetComponentInChildren<OnEnterOutpostTriggerzone>().ts=this;
		changeSpectateTarget(true);
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown("left")) changeSpectateTarget(false);
		if(Input.GetKeyDown("right")) changeSpectateTarget(true);
	}

	void changeSpectateTarget(bool up)
	{
		if(up) cameraTarget++;
		else cameraTarget--;

		int s = ships.Count;
		if(cameraTarget<0) cameraTarget+=s;
		else cameraTarget %= s;

		Ship ship = ships[(int)cameraTarget];
		camOffsetPursue.target=ship.body;
		camOffsetPursue.offset=cameraParams[ship.type];
		camera.GetComponent<CamScript>().target=ship.body;
	}

	public void spawnShips()
	{
		Vector3 offset;
		int ship_id;
		int prometheus_id=addShip(ShipClass.prometheus,Prometheus_spawnpoint);
		ships[prometheus_id].body.GetComponentInChildren<OnEnterOutpostPrometheus>().ts=this;
		for(int i=0; i<jetCount; i++)
		{
			offset=getRandomOffset(minJetOffset,maxJetOffset);
			ship_id=addShip(ShipClass.jet,Prometheus_spawnpoint+offset);
			OffsetPursue o=ships[ship_id].body.GetComponent<OffsetPursue>();
			o.target=ships[prometheus_id].body;
			o.offset=offset;
		}
	}
	
	public void setAttackMode()
	{
		foreach(Ship s in ships)
		{
			if(s.type==ShipClass.jet)
			{
				s.body.GetComponent<OffsetPursue>().active=false;
			}
		}
	}
}
