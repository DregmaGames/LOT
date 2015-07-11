using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {
	
	public static ObjectPool instance;
	
	///  Arrays prefabs que van a utilizarse para Pools.
	public GameObject[] objPrefabs;
	

	[SerializeField]
	public List<GameObject>[] pooledObjects;
	public int[] amountToBuffer;
	
	
	public int defaultBufferAmount = 3;
	
	protected GameObject containerObj;
	
	void Awake (){
		instance = this;
	}

	void Start (){
		containerObj = new GameObject("ObjectPool");
		
		pooledObjects = new List<GameObject>[objPrefabs.Length];
		
		int i = 0;
		foreach ( GameObject objPrefab in objPrefabs )
		{
			pooledObjects[i] = new List<GameObject>(); 
			
			int bufferAmount;
			
			if(i < amountToBuffer.Length) bufferAmount = amountToBuffer[i];
			else
				bufferAmount = defaultBufferAmount;
			
			for ( int n=0; n<bufferAmount; n++)
			{
				GameObject newObj = Instantiate(objPrefab) as GameObject;
				newObj.name = objPrefab.name;
				PoolObject(newObj);
			}
			
			i++;
		}
	}

	public GameObject GetObjectForType ( string objectType , bool onlyPooled = false){
		for(int i=0; i<objPrefabs.Length; i++)
		{
			GameObject prefab = objPrefabs[i];
			if(prefab.name == objectType)
			{
				
				if(pooledObjects[i].Count > 0)
				{
					GameObject pooledObject = pooledObjects[i][0];
					pooledObjects[i].RemoveAt(0);
					pooledObject.transform.parent = null;
					pooledObject.SetActive(true);
					
					return pooledObject;
					
				} else if(!onlyPooled) {
					GameObject go = Instantiate(objPrefabs[i]) as GameObject;
					go.name = prefab.name;
					return go; 
				}
				
				break;
				
			}
		}
		

		return null;
	}
	
	public void PoolObject ( GameObject Object ){
		for ( int i=0; i<objPrefabs.Length; i++)
		{
			if(objPrefabs[i].name == Object.name)
			{
				Object.SetActive(false);
				Object.transform.parent = containerObj.transform;
				pooledObjects[i].Add(Object);
				return;
			}
		}
	}
	
}