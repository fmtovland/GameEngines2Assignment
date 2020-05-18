using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipClass{prometheus,jet,hatak_sg1};

public struct Ship
{
	public GameObject body;
	public ShipClass type;
	public Boid boid;
}

public class TauriSpawner : MonoBehaviour
{
	public int jetCount=0;
	public float minJetOffset=150;
	public float maxJetOffset=200;
	
	public float prometheus_maxspeed;
	public float jet_maxspeed;
	public float hatak_sg1_maxspeed;
	
	public Vector3 SG1_spawnpoint;
	public Vector3 Prometheus_spawnpoint;

	public GameObject camera;
	int cameraTarget=-1;
	OffsetPursue camOffsetPursue;

	public List<Ship> ships=new List<Ship>();

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
	}

	int addShip(ShipClass sc,Vector3 pos)
	{
		Ship ship=new Ship();
		ship.type=sc;

		switch(sc)
		{
			case ShipClass.prometheus:
				ship.body=Instantiate(Prometheus);
				ship.boid=ship.body.GetComponent<Boid>();
				ship.boid.maxSpeed=prometheus_maxspeed;
				break;

			case ShipClass.jet:
				ship.body=Instantiate(Jet);
				ship.boid=ship.body.GetComponent<Boid>();
				ship.boid.maxSpeed=jet_maxspeed;
				break;

			case ShipClass.hatak_sg1:
				ship.body=Instantiate(Hatak_SG1);
				ship.boid=ship.body.GetComponent<Boid>();
				ship.boid.maxSpeed=hatak_sg1_maxspeed;
				break;

			default:
				Debug.Log("Tried to instanciate unimplemeted ship");
				return -1;
		}

		ship.body.transform.position=pos;
		ships.Add(ship);
		return ships.Count-1;
	}

	public void spawnShips()
	{
		Vector3 offset;
		int ship_id;
		int prometheus_id=addShip(ShipClass.prometheus,Prometheus_spawnpoint);
		for(int i=0; i<jetCount; i++)
		{
			offset=getRandomOffset();
			ship_id=addShip(ShipClass.jet,Prometheus_spawnpoint+offset);
			OffsetPursue o=ships[ship_id].body.GetComponent<OffsetPursue>();
			o.target=ships[prometheus_id].body;
			o.offset=offset;
		}
	}

	Vector3 getRandomOffset()
	{
		Vector3 t = new Vector3(
			Random.Range(-maxJetOffset,maxJetOffset),
			Random.Range(-maxJetOffset,maxJetOffset),
			Random.Range(-maxJetOffset,maxJetOffset)
		);

		if(t.x<0) t.x-=minJetOffset; else t.x+=minJetOffset;
		if(t.y<0) t.y-=minJetOffset; else t.y+=minJetOffset;
		if(t.z<0) t.z-=minJetOffset; else t.z+=minJetOffset;

		return t;
	}
}
