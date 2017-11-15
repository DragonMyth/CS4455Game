using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


class Tile
{
	public GameObject tile;
	public float creationTime;

	public Tile(GameObject t, float ct){
	
		tile = t;
		creationTime = ct;
	}

}

public class InfiniteTerrainGenerator : MonoBehaviour {

	public GameObject plane;
	public GameObject player;

	int planeSize = 10;
	int halfTilesX = 5;
	int halfTilesZ = 5;

	Vector3 startPos;

	Hashtable tiles = new Hashtable();


	// Use this for initialization
	void Start () {
		gameObject.transform.position = Vector3.zero;
		startPos = Vector3.zero;

		float updateTime = Time.realtimeSinceStartup;

		for (int x = -halfTilesX; x < halfTilesX; x++) {
			for (int z = -halfTilesZ; z < halfTilesZ; z++) {
				Vector3 pos = new Vector3 ((x * planeSize + startPos.x),
					-5, 
					(z * planeSize + startPos.z));
				GameObject t = (GameObject)Instantiate (plane, pos, Quaternion.identity);
				string tileName = "Tile_" + ((int)(pos.x)).ToString () + "_" + ((int)(pos.z)).ToString ();
				t.name = tileName;

				Tile tile = new Tile (t, updateTime);
				tiles.Add (tileName,tile);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		int xMove = (int)(player.transform.position.x - startPos.x);
		int zMove = (int)(player.transform.position.z - startPos.z);
		if (Mathf.Abs (xMove) >= planeSize || Mathf.Abs (zMove) >= planeSize) {
			float updateTime = Time.realtimeSinceStartup;
			int playerX = (int)(Mathf.Floor (player.transform.position.x / planeSize) * planeSize);
			int playerZ = (int)(Mathf.Floor (player.transform.position.z / planeSize) * planeSize);


			for (int x = -halfTilesX; x < halfTilesX; x++) {
				for (int z = -halfTilesZ; z < halfTilesZ; z++) {
					Vector3 pos = new Vector3 ((x * planeSize + playerX),
						-5, 
						(z * planeSize + playerZ));

					string tileName = "Tile_" + ((int)(pos.x)).ToString () + "_" + ((int)(pos.z)).ToString ();

					if (!tiles.ContainsKey (tileName)) {
						GameObject t = (GameObject)Instantiate (plane, pos, Quaternion.identity);
						t.name = tileName;

						Tile tile = new Tile (t, updateTime);
						tiles.Add (tileName, tile);
					
					} else {
						(tiles [tileName] as Tile).creationTime = updateTime;
					}


				}
			}

			Hashtable newTerrain = new Hashtable ();
			foreach (Tile tls in tiles.Values) {
				if (tls.creationTime != updateTime) {

					Destroy (tls.tile);
				} else {
					newTerrain.Add (tls.tile.name,tls);
				}
			}
			tiles = newTerrain;

			startPos = player.transform.position;
		}
	}
}
