using UnityEngine;
public class WindowRestart : MonoBehaviour
{
    public void WinResatart(GameObject _newWin)
    {
        Debug.Log(_newWin);
        GameObject _newWin2 = Instantiate(_newWin);
        _newWin2.SetActive(true);
    }
}
