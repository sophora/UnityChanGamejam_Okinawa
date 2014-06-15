using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	public void SetScore(int iValue) { mScore = iValue; }
	public int  GetScore()           { return mScore;   }

	public int AddScore(int iValue)
	{
		mScore += iValue;
		return mScore;
	}

	private int mScore;
}
