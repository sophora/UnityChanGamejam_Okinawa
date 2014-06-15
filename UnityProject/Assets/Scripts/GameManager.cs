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

	public void AddDamage(int iDamage)
	{
		mHitPoint -= iDamage;
	}


	private void Begin()
	{
		mScoreManager.SetScore(0);
		SetEnabledEnemySpawner(true);
		BGM_Battle.Play();
		IsPlaying   = true;
		mIsGameOver = false;
		mHitPoint   = 10;
		mUnityChan = GameObject.FindWithTag("UnityChan").GetComponent<UnityChanControlScriptWithRgidBody>();

	}

	private void Result(bool iIsClear)
	{
		StartCoroutine(ResultProcess(iIsClear));
	}

	private IEnumerator ResultProcess(bool iIsClear)
	{
		mIsInResulrProduction = true;
		SetEnabledEnemySpawner(false);

		if (iIsClear)
		{
			BGM_Battle.Stop();
			BGM_Clear .Play();
		}
		else
		{
			BGM_Battle.Stop();
			BGM_Failed.Play();
		}

		yield return null;

		mIsInResulrProduction = false;
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

		if (mHitPoint <= 0 || (mUnityChan != null && mUnityChan.IsDead()))
		{
			mIsGameOver = true;
			IsPlaying  = false;
			Result(false);
			return;
		}

		mSeconds += Time.deltaTime;
		if (mSeconds >= GameSeconds)
		{
			mIsGameOver = true;
			IsPlaying  = false;
			Result(true);
			return;
		}
	}

	private IEnumerator Start()
	{
		mScoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
		yield return null;
		BGM_Battle.Stop();
		SetEnabledEnemySpawner(false);

		yield return new WaitForSeconds(3.0f);
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
		int aScore = (mScoreManager != null) ? mScoreManager.GetScore() : 0;

		if (!IsPlaying && !mIsInResulrProduction && mIsGameOver)
		{
			if (GUI.Button(new Rect((int)(Screen.width * 0.5) - 125, (int)(Screen.height * 0.5), 250, 60), "Score : " + aScore.ToString()))
			{
				Application.LoadLevel("Main");
			}

		}


		/*
		if (mScoreManager == null)
		{
			mScoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
		}
		*/



		System.TimeSpan aTimeSpan = new System.TimeSpan(0,0, Mathf.CeilToInt(mSeconds));
		string aMinutes = string.Format("{0:00}", aTimeSpan.Minutes);
		string aSeconds = string.Format("{0:00}", aTimeSpan.Seconds);
		int    aUnityChan = (mUnityChan != null) ? mUnityChan.Health : 0;

		if (mIsGameOver)
		{

		}
		else
		{
			GUI.Box  (new Rect(Screen.width -260, 10, 250, 120), "");
			//GUI.Box(new Rect(Screen.width -260, 10 ,250 ,150), "Interaction");
			GUI.Label(new Rect(Screen.width -250, 20, 250, 20), "Time       : " + aMinutes + ":" + aSeconds  );
			GUI.Label(new Rect(Screen.width -250, 40, 250, 20), "Unity Chan : " + aUnityChan.ToString());
			GUI.Label(new Rect(Screen.width -250, 60, 250, 20), "Friends    : " + mHitPoint.ToString()       );
			GUI.Label(new Rect(Screen.width -250, 80, 250, 20), "Score      : " + aScore.ToString()          );
			//GUI.Label(new Rect(Screen.width -245,50,250,30),"Left/Right Arrow : Turn Left/Turn Right");
			//GUI.Label(new Rect(Screen.width -245,70,250,30),"Hit Space key while Running : Jump");
			//GUI.Label(new Rect(Screen.width -245,90,250,30),"Hit Spase key while Stopping : Rest");
			//GUI.Label(new Rect(Screen.width -245,110,250,30),"Left Control : Front Camera");
			//GUI.Label(new Rect(Screen.width -245,130,250,30),"Alt : LookAt Camera");
		}
	}

	private UnityChanControlScriptWithRgidBody mUnityChan;
	private bool  mIsGameOver;
	private bool  mIsInResulrProduction;
	private float mSeconds;
	private int   mHitPoint;
	private ScoreManager mScoreManager;
}
