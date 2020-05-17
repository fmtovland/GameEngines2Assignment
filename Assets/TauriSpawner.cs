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

	public GameObject camera;
	int cameraTarget=-1;

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
		spawnShips();
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
		camera.transform.parent=ship.body.transform;
		camera.transform.position=cameraParams[ship.type]+ship.body.transform.position;
	}

	void addShip(ShipClass sc,Vector3 pos)
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
				//return;
				break;
		}

		ship.body.transform.position=pos;
		ship.body.transform.LookAt(new Vector3(0,0,0));
		ships.Add(ship);
	}

	void spawnShips()
	{
		addShip(ShipClass.prometheus,transform.position);
		for(int i=0; i<jetCount; i++)
		{
			addShip(ShipClass.jet,getRandomOffset());
		}
	}

	Vector3 getRandomOffset()
	{
		Vector3 t = transform.position;

		t += new Vector3(
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
