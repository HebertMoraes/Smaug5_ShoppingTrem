using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPackageProductMerchandise : MonoBehaviour
{
    public GameObject packageProductPrefab;
    [Range(0, 1)]
    public float chanceToSpawn;
    public int indiceDropSpots;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().currentProductsMerchandise <= 0) {

            MovimentationCharacter playerCharacterMovBehavior = GameObject.FindGameObjectWithTag("Player").
                GetComponent<MovimentationCharacter>();
            List<float> posXPossiblesToSpawn = new List<float>();
            posXPossiblesToSpawn.Add(playerCharacterMovBehavior.posXLineLeft);
            posXPossiblesToSpawn.Add(playerCharacterMovBehavior.posXLineMid);
            posXPossiblesToSpawn.Add(playerCharacterMovBehavior.posXLineRight);

            List<float> spotsZPossiblesToSpawn = new List<float>();
            int numberOfSpotsPossibles = transform.GetChild(indiceDropSpots).childCount;

            for (int i = 0; i <= numberOfSpotsPossibles - 1; i++)
            {
                spotsZPossiblesToSpawn.Add(transform.GetChild(indiceDropSpots).GetChild(i).transform.position.z);
            }

            if (Random.value <= chanceToSpawn) {

                int indiceChosenOfChildDropSpots = Random.Range(0, spotsZPossiblesToSpawn.Count);
                float posZSpotChosen = spotsZPossiblesToSpawn[indiceChosenOfChildDropSpots];

                Vector3 positionToSpawn = new Vector3(
                    posXPossiblesToSpawn[Random.Range(0, 3)],
                    packageProductPrefab.transform.position.y,
                    posZSpotChosen
                );
                Destroy(transform.GetChild(indiceDropSpots).GetChild(indiceChosenOfChildDropSpots).gameObject);

                Instantiate(packageProductPrefab, positionToSpawn, packageProductPrefab.transform.rotation, transform);
            }
        }
    }
}
