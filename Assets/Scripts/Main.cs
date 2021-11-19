using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Main : MonoBehaviour
{
    static public Main solo;
    private static Dictionary<WeaponType, WeaponConcept> WEAP_DICT;
    public GameObject[] prefabEnemies; // Шаблоны с врагами
    public float enemySpawnPerSecond = 0.5f; // Интервалы возрождений
    public float enemyDefaultPadding = 1.5f; //  Отступы между врагами

    public WeaponConcept[] weaponConcepts;
     
    private BoundsChecker boundsChecker;

    private void Awake()
    {
        solo = this;
        boundsChecker = GetComponent<BoundsChecker>();
        // Вызываем спауненеми раз в 2 секунды
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);

        WEAP_DICT = new Dictionary<WeaponType, WeaponConcept>();
        foreach (var def in weaponConcepts)
        {
            WEAP_DICT[def.type] = def;
            //Итерации по элементам массива концептс и создает для них
            // записи в этом словаре
        }
    }

    public void SpawnEnemy()
    {
        //Выбираем случайного врага
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

        // Разместить врага над экраном в позиции x
        float enemyPadding = enemyDefaultPadding;
        if (go.GetComponent<BoundsChecker>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsChecker>().radius);
        }

        // Код ниже устанавливает изначальную позицию врага
        Vector3 position = Vector3.zero;
        float xMin = -boundsChecker.cameraWidth + enemyPadding;
        float xMax = boundsChecker.cameraWidth - enemyPadding;
        position.x = Random.Range(xMin, xMax);
        position.y = boundsChecker.cameraHeight + enemyPadding;
        go.transform.position = position;

        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }

    public void DelayedRestart(float delay)
    {
        Invoke("Restart", delay);
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
