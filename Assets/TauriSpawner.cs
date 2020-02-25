using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipClass{prometheus,drone};

public struct Ship
{
	public GameObject body;
	public ShipClass type;
}

public class TauriSpawner : MonoBehaviour
{
	public GameObject camera;
	uint cameraTarget=0;

	public List<Ship> ships=new List<Ship>();

	public GameObject Prometheus;
	public GameObject Drone;

	public Dictionary<ShipClass,Vector3> cameraParams=
		new Dictionary<ShipClass,Vector3>
	{
		{ShipClass.prometheus,new Vector3(0,0,-800)},
		{ShipClass.drone,new Vector3(0,0,-20)}
	};

	// Start is called before the first frame update
	void Start()
	{
		addShip(ShipClass.prometheus);
		//addShip(ShipClass.drone);
		changeSpectateTarget(true);
	}

	// Update is called once per frame
	void Update()
	{

	}

	void changeSpectateTarget(bool up)
	{
		if(up) cameraTarget++;
		else cameraTarget--;

		uint s = (uint)ships.Count;
		Debug.Log(ships.Count);
		cameraTarget %= s;

		Ship ship = ships[(int)cameraTarget];
		camera.transform.parent=ship.body.transform;
		camera.transform.position=cameraParams[ship.type];
	}

	void addShip(ShipClass sc)
	{
		Ship ship=new Ship();
		ship.type=sc;

		switch(sc)
		{
			case ShipClass.prometheus:
				ship.body=Instantiate(Prometheus);
				break;

			case ShipClass.drone:
				ship.body=Instantiate(Drone);
				break;

			default:
				Debug.Log("Tried to instanciate unimplemeted ship");
				break;
		}

		ships.Add(ship);
	}
}
