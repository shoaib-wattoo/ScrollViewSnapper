using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridChildCall : MonoBehaviour {
	[HideInInspector]
	public int myIndex;
	[HideInInspector]
	public bool isSnaped;
	GameObject snapedRotation;
	GameObject otherRightRotaion;
	GameObject otherLeftRotation;
	public int maa = 0;
	int counter = 2;
	GameObject Center;
	bool oneTime = true;

	public static float DistanceToAngle(float distance){
		float disPercent = distance / myDisstance;
		return angleLimit * disPercent;
	}

	static float myDisstance = 0;
	static float angleLimit = 80;

	public static void MyDissi(float given){
		myDisstance = given;
	}

	// Use this for initialization
	void Start ()
	{
		Center = GameObject.FindGameObjectWithTag ("Center");
		snapedRotation = GameObject.FindGameObjectWithTag ("snapedRotation");
		otherRightRotaion = GameObject.FindGameObjectWithTag ("otherRightRotation");
		otherLeftRotation = GameObject.FindGameObjectWithTag ("otherLeftRotation");
	}
	
	// Update is called once per frame
	void Update () {
		if (oneTime) {
			oneTime = false;

		}
		else
		{
			//float distance = Vector3.Distance (this.transform.position,Center.transform.position);
			float distance = Mathf.Abs(this.transform.position.x - Center.transform.position.x);
			if (maa == 1) {
				Debug.Log ("dkfhdkf = "+ distance	);
			}
			if (!isSnaped) {
				if (Center.transform.position.x > this.transform.position.x) {
					//(transform.parent.childCount > (myIndex + 1))
					//{
					//transform.rotation = Quaternion.Lerp (transform.rotation, otherLeftRotation.transform.rotation, 0.3f);
					//}
					transform.rotation = Quaternion.Euler (transform.rotation.x, -DistanceToAngle (distance), transform.rotation.z);

				} else {
					transform.rotation = Quaternion.Euler (transform.rotation.x, DistanceToAngle (distance), transform.rotation.z);
					//if(transform.parent.childCount < (myIndex - 1))
					//{
					//transform.rotation = Quaternion.Lerp (transform.rotation, otherRightRotaion.transform.rotation, 0.3f);
					//}
				}
			}
			else
			{
				transform.rotation = Quaternion.Euler (0,0,0);
			}
//			if(distance > 3)
//			{
//				transform.rotation = Quaternion.Lerp (transform.rotation, otherLeftRotation.transform.rotation, 0.3f);
//				if (Center.transform.position.x > this.transform.position.x) {
//					if (transform.parent.childCount < (myIndex + 1)) {
//						transform.parent.GetChild (myIndex + 1).rotation = Quaternion.Lerp (transform.rotation, snapedRotation.transform.rotation, 0.3f);
//					}
//				} else {
//					if (transform.parent.childCount < (myIndex - 1)) {
//						transform.parent.GetChild (myIndex - 1).rotation = Quaternion.Lerp (transform.rotation, snapedRotation.transform.rotation, 0.3f);
//					}
//				}
//			}

			if (distance > 45) {
				

			}
			if(distance < 45)
			{
				
				//float speed = ( Center.transform.position.x - / Time.);
				//Debug.Log ("speed = "+speed);
				//transform.rotation = Quaternion.Lerp (transform.rotation,snapedRotation.transform.rotation,0.3f);
			}
	}
	}

//	void OnTriggerEnter(Collider other)
//	{
//		Debug.Log ("i am entring in collider");
////		if(other.transform.tag == "Center")
////		{
////			Debug.Log ("i am entring in collider");
////		}
//	}
}
