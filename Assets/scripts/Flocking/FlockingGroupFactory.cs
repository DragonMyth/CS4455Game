using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingGroupFactory {

	public static FlockingGroup createGroup(int fishKind, int numInstance, GameObject spawnCenterObj, int spawnRadius){
		if (fishKind == 0) {
			return new SimpleFishGroup (numInstance, spawnCenterObj, spawnRadius);
		
		} else if (fishKind == 1) {
			return new ArticFishGroup (numInstance, spawnCenterObj, spawnRadius);
			
		} else if (fishKind == 2) {
			return new EelGroup (numInstance, spawnCenterObj, spawnRadius);
		}
		else {

			return new FlockingGroup (numInstance,spawnCenterObj,spawnRadius);
		}
	}
}
