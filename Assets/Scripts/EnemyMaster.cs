using UnityEngine;

public class EnemyMaster : MonoBehaviour
{
    public Transform[] spawnPositions;
    public Transform destination;
    public EnemyWave[] waves;

    private bool isWaitigForWave = true;
    private bool won = false;
    private int currentWaveIndex = 0;
    private int numberOfSpawnedEnemies = 0;
    private float lastTime = 0f;

    public static EnemyMaster theMaster;

    private void Start ()
    {
        theMaster = this;
    }

    private void Update()
    {
        if (won)
            return;

        //wait a bit befor launching a wave (don't be a bitch the the player)
        if (isWaitigForWave)
        {
            //check if I'm done waiting
            if (Time.time > lastTime + waves[currentWaveIndex].initialDelay)
            {
                lastTime = Time.time;
                isWaitigForWave = false;
            }
        }
        else
        {
            //keep spawning enemies in every .spawnDelays second
            if (Time.time > lastTime + waves[currentWaveIndex].spawnDelays)
            {
                lastTime = Time.time;
                numberOfSpawnedEnemies++;

                GameObject enemyClone = Instantiate(waves[currentWaveIndex].enemyPrefab);
                enemyClone.transform.position = spawnPositions[Random.Range(0, spawnPositions.Length)].position;

                //done spawning enemies for the current wave
                if(numberOfSpawnedEnemies >= waves[currentWaveIndex].numberOfEnemies)
                {
                    currentWaveIndex++;

                    //already spawned all the waves, win the game here:
                    if(currentWaveIndex >= waves.Length)
                    {
                        //TODO win the game
                        won = true;
                    }
                    //done for this wave, go to the waiting mode again
                    else
                    {
                        numberOfSpawnedEnemies = 0;
                        isWaitigForWave = true;
                    }
                }
            }
        }
    }
}
