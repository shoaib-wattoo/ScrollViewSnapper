using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewUI : MonoBehaviour {

	public GameObject childPrefab;
	public Vector2 childPrefabSize;
	public int childCount;

	private Transform gridPanel;

	void OnEnable()
	{
	}
	// Use this for initialization
	void Start ()
	{
		SetGrid ();
	}
	/// <summary>
	/// Sets the grid.
	/// this fuction is spawnnig number of child , given in inspector.Also sets the size of the grid according to number of children
	/// </summary>
	void SetGrid()
	{
		gridPanel = this.transform.Find ("Viewport").Find ("Grid");
		//gridPanel.GetComponent<GridLayoutGroup> ().cellSize = new Vector2 ((childPrefabSize.x - ((childPrefabSize.x/100)*10)) , (childPrefabSize.y - ((childPrefabSize.y/100)*10)));
		gridPanel.GetComponent<GridLayoutGroup> ().cellSize = new Vector2 (childPrefabSize.x, childPrefabSize.y);
		//gridPanel.GetComponent<GridLayoutGroup> ().padding.left = Mathf.Abs((int)(gridPanel.GetComponent<GridLayoutGroup> ().spacing.x));
		for(int i = 0 ; i < childCount ; i++)
		{
			GameObject child = Instantiate (childPrefab) as GameObject;
			child.transform.SetParent (gridPanel);
			child.transform.localScale = Vector3.one;
			child.transform.localPosition = new Vector3 (child.transform.localPosition.x,child.transform.localPosition.y,200);
			if(i == 0)
			{
				child.transform.localRotation = Quaternion.Euler(0.0f,0.0f,0.0f);
			}else
			{
				child.transform.localRotation = Quaternion.Euler(0.0f,80.0f,0.0f);
			}

			child.GetComponent<GridChildCall> ().myIndex = i;

		}


		gridPanel.GetComponent<RectTransform> ().sizeDelta = new Vector2 (gridOffset (), gridPanel.GetComponent<RectTransform> ().sizeDelta.y);
		float offset = this.GetComponent<RectTransform> ().sizeDelta.x / 2;
		gridPanel.transform.localPosition = new Vector3 (((gridPanel.transform.localPosition.x + gridPanel.GetComponent<RectTransform> ().sizeDelta.x / 2) - offset) , gridPanel.transform.localPosition.y, gridPanel.transform.localPosition.z);
		StartCoroutine (NowScrollViewCanBeSnapped ());
	}
	/// <summary>
	/// Grids the offset.
	/// </summary>
	/// <returns>The offset.</returns>
	float gridOffset()
	{
		float offset = ((((gridPanel.GetComponent<GridLayoutGroup>().cellSize.x + gridPanel.GetComponent<GridLayoutGroup>().spacing.x) * (childCount))) +  (Mathf.Abs(gridPanel.GetComponent<GridLayoutGroup> ().spacing.x)));
	//	float offset = ((gridPanel.GetComponent<GridLayoutGroup>().cellSize.x) * (childCount));
		return offset;
	}
	IEnumerator NowScrollViewCanBeSnapped()
	{
		yield return new WaitForSeconds (0.3f);
		gridPanel.GetComponent <ScrollViewSnap> ().enabled = true;
		float first = gridPanel.GetChild (0).position.x;
		float second = gridPanel.GetChild (1).position.x;
		float diffs = Mathf.Abs(second - first);
		Debug.Log ("Distance = "+ diffs);
		GridChildCall.MyDissi (diffs);
	}
}
