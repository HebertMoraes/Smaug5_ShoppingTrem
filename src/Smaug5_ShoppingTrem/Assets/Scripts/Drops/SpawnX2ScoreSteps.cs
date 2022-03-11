using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnX2ScoreSteps : MonoBehaviour
{
    public GameObject x2ScoreStepsPrefab;
    [Range(0, 1)]
    public float chanceToSpawn;
    public float minPosZToSpawn, maxPosZToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        MovimentationCharacter playerCharacterMovBehavior = GameObject.FindGameObjectWithTag("Player").
            GetComponent<MovimentationCharacter>();
        List<float> posXPossiblesToSpawn = new List<float>();
        posXPossiblesToSpawn.Add(playerCharacterMovBehavior.posXLineLeft);
        posXPossiblesToSpawn.Add(playerCharacterMovBehavior.posXLineMid);
        posXPossiblesToSpawn.Add(playerCharacterMovBehavior.posXLineRight);

        if (Random.value <= chanceToSpawn) {

            Vector3 positionToSpawn = new Vector3(
                posXPossiblesToSpawn[Random.Range(0, 3)],
                x2ScoreStepsPrefab.transform.position.y,
                Random.Range(transform.position.z + minPosZToSpawn, transform.position.z + maxPosZToSpawn)
            );

            Instantiate(x2ScoreStepsPrefab, positionToSpawn, x2ScoreStepsPrefab.transform.rotation, transform);
        }
    }
}
