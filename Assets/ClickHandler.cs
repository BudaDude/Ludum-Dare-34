using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ClickHandler : MonoBehaviour {

    public UnityEvent actionClick;


    public void OnActionClick()
    {
        actionClick.Invoke();
    }
    
}
