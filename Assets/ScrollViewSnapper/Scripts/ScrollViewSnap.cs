using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollViewSnap : MonoBehaviour {

	public RectTransform gridPanel;
	public GameObject[] panelsToMove;
	public RectTransform center;
	public GameObject scrollViewObj;
	public float[] distances;

	bool isdragging;

	int panelDistence;
	int minDistanceChildCount;

	float minDistance;

	Vector3 targetPos;
	Vector3 startPos;
	Vector2 curPos;
	Vector2 lastPos;

	// Use this for initialization
	void Start () 
	{
		int gridChild = gridPanel.transform.childCount;
		startPos = gridPanel.gameObject.transform.localPosition;
		panelsToMove = new GameObject[gridChild];
		for(int i = 0; i < gridChild ; i++)
		{
			panelsToMove [i] = gridPanel.transform.GetChild (i).gameObject;
		}
    	int panelsCount = panelsToMove.Length;
		distances = new float[panelsCount];
		if(gridChild > 1)
		{
			panelDistence =(int)Mathf.Abs(panelsToMove[1].GetComponent<RectTransform>().anchoredPosition.x - panelsToMove[0].GetComponent<RectTransform>().anchoredPosition.x);
		}
		isdragging = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		for(int i = 0; i < panelsToMove.Length; i++)
		{
			distances [i] = Mathf.Abs (center.transform.position.x - panelsToMove [i].transform.position.x); 
		}
		minDistance = Mathf.Min (distances); 
		for(int  j = 0; j < panelsToMove.Length; j++)
		{
			if(minDistance == distances [j])
			{
				minDistanceChildCount = j;
			}
		}
		curPos = this.transform.position;
		if (curPos == lastPos) {
		} else 
		{
			Dragging ();
		}
		lastPos = curPos;
	}

	void FixedUpdate()
	{
		if (isdragging){
			float velocityOn_x=scrollViewObj.GetComponent<ScrollRect>().velocity.x;
			if ((velocityOn_x < 100f && velocityOn_x > 0) || (velocityOn_x > -100f && velocityOn_x< 0))
			{
				scrollViewObj.GetComponent<ScrollRect> ().velocity = new Vector2 (0.0f, 0.0f);
				int targetPosOn_x = (int)(startPos.x) + ((minDistanceChildCount * ((-1)*panelDistence)));
				targetPos = new Vector3(targetPosOn_x, gridPanel.gameObject.transform.localPosition.y, gridPanel.gameObject.transform.localPosition.z);
				ShopInfoPopupGoLeft(targetPos);
			}
		}
	}
	void ShopInfoPopupGoLeft(Vector3 _targetPosition)
	{
		iTween.MoveTo(this.gameObject, iTween.Hash(
			"islocal",true,
			"position", _targetPosition,
			"easeType", iTween.EaseType.easeInOutQuint,
			"time",0.2,
			"oncomplete", "setCanResetPosition", "oncompletetarget", this.gameObject
		)
		);
	}
	void setCanResetPosition()
	{
		foreach(Transform t in this.transform)
		{
			t.GetComponent<GridChildCall> ().isSnaped = false;
		}
		this.transform.GetChild(minDistanceChildCount).GetComponent<GridChildCall> ().isSnaped = true;
		EndDragging ();
	}
	void Dragging()
	{
		isdragging = true;
	}
	void EndDragging()
	{
		isdragging = false;
	}
}
