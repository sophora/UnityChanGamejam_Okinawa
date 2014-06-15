using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public EnemySpawner[]                     EnemySpawners;
	public float                              GameSeconds;
	public bool                               IsPlaying;
	public AudioSource                        BGM_Battle;
	public AudioSource                        BGM_Clear;
	public AudioSource                        BGM_Failed;

	private void Begin()
	{
		SetEnabledEnemySpawner(true);
		BGM_Battle.Play();
		IsPlaying   = true;
		mIsGameOver = false;
		mUnityChan = GameObject.FindWithTag("UnityChan").GetComponent<UnityChanControlScriptWithRgidBody>();

	}

	private void SetEnabledEnemySpawner(bool iIsEnabled)
	{
		foreach(EnemySpawner aEnemySpawner in EnemySpawners)
		{
			aEnemySpawner.enabled = iIsEnabled;
		}
	}

	private void Update()
	{
		if (!IsPlaying) { return; }
		if (mIsGameOver) { return; }

		if (mUnityChan != null && mUnityChan.IsDead())
		{
			mIsGameOver = true;
			IsPlaying  = false;
			BGM_Battle.Stop();
			BGM_Failed.Play();
			return;
		}

		mSeconds += Time.deltaTime;
		if (mSeconds >= GameSeconds)
		{
			mIsGameOver = true;
			IsPlaying  = false;
			BGM_Battle.Stop();
			BGM_Clear .Play();

			SetEnabledEnemySpawner(false);
			return;
		}
	}

	private IEnumerator Start()
	{
		yield return null;
		BGM_Battle.Stop();
		SetEnabledEnemySpawner(false);
		yield return new WaitForSeconds(5.0f);
		Begin();
	}

	private void Awake()
	{
		IsPlaying   = false;
		mIsGameOver = false;
		mSeconds    = 0.0f;
	}

	void OnGUI()
	{
		System.TimeSpan aTimeSpan = new System.TimeSpan(0,0, Mathf.CeilToInt(mSeconds));
		string aMinutes = string.Format("{0:00}", aTimeSpan.Minutes);
		string aSeconds = string.Format("{0:00}", aTimeSpan.Seconds);

		GUI.Box  (new Rect(Screen.width -260, 10, 250, 20), "Time   " + aMinutes + ":" + aSeconds);
		//GUI.Box(new Rect(Screen.width -260, 10 ,250 ,150), "Interaction");
		//GUI.Label(new Rect(Screen.width -245,30,250,30),"Up/Down Arrow : Go Forwald/Go Back");
		//GUI.Label(new Rect(Screen.width -245,50,250,30),"Left/Right Arrow : Turn Left/Turn Right");
		//GUI.Label(new Rect(Screen.width -245,70,250,30),"Hit Space key while Running : Jump");
		//GUI.Label(new Rect(Screen.width -245,90,250,30),"Hit Spase key while Stopping : Rest");
		//GUI.Label(new Rect(Screen.width -245,110,250,30),"Left Control : Front Camera");
		//GUI.Label(new Rect(Screen.width -245,130,250,30),"Alt : LookAt Camera");
	}

	private UnityChanControlScriptWithRgidBody mUnityChan;
	private bool  mIsGameOver;
	private float mSeconds;
}
