using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightLeftButtonsManager : MonoBehaviour {

	public GameObject RightButton;
	public GameObject LeftButton;
	public int viewAbleChildCount;
	public GameObject GridPanel;
	// Use this for initialization
	void Start()
	{

	}
	void OnEnable()
	{
		StartCoroutine (checkStatus());
	}
	IEnumerator checkStatus()
	{
		yield return new WaitForSeconds (0.01f);
		if (GridPanel.transform.childCount <= viewAbleChildCount)
		{
			RightButton.SetActive (false);
			LeftButton.SetActive (false);
		}
		else 
		{
			CheckScrollViewValue();
		}
	}
	public void CheckScrollViewValue()
	{
		if (GridPanel.transform.childCount > viewAbleChildCount)
		{
			float value = this.GetComponent<ScrollRect> ().horizontalNormalizedPosition;
			if (value >= 1) {
				RightButton.SetActive (false);
				LeftButton.SetActive (true);
			} else if (value <= 0) {
				RightButton.SetActive (true);
				LeftButton.SetActive (false);
			} else {
				RightButton.SetActive (true);
				LeftButton.SetActive (true);
			}
		}
		else
		{

		}

	}
}
