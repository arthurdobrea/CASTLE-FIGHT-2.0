using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour, IService
{
    [SerializeField] private GameObject ui;
    [SerializeField] private TextMeshProUGUI text;


    public void EndingGame(string whoWon)
    {
        StartCoroutine(EndingGameFunc(whoWon));
    }

    private IEnumerator EndingGameFunc(string whoWon)
    {
        ui.SetActive(true);
        text.SetText(whoWon+" won");
        yield return new WaitForSeconds(2);
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}
