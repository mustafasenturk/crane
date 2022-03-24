using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ForkController : MonoBehaviour {

    public Transform fork; 
    public Transform mast;
    public Transform pos1; //The minimum height of the platform and of the mast
    public Transform pos2; //The maximum height of the platform
    public Transform mastPos; //The maximum height of the mast
    public Slider _forkSlide; 
    public float speedTranslate; //Platform travel speed

    private bool mastMoveTrue = false; //Activate or deactivate the movement of the mast

    // Update is called once per frame
    void FixedUpdate () {
        //If the position of the fork more position of the mast enables lifting mast
        if (fork.transform.localPosition.y >= mastPos.position.y)
        {
            mastMoveTrue = true;
        }
        //If the position of the plug is less than the position of the mast, then down the lift mast
        if (fork.transform.localPosition.y <= mastPos.position.y)
        {
            mastMoveTrue = false;
        }
        //limiting positions forklift platform height and initial position
        fork.localPosition = new Vector3(fork.localPosition.x, Mathf.Clamp(fork.localPosition.y, pos1.localPosition.y, pos2.localPosition.y), fork.localPosition.z);
        //limiting positions mast height and initial position
        mast.localPosition = new Vector3(mast.localPosition.x, Mathf.Clamp(mast.localPosition.y, pos1.localPosition.y, mastPos.localPosition.y), mastPos.localPosition.z);
        //fork lifting platform and the mast by pressing the PageUp
        bool up = Input.GetKey(KeyCode.PageUp);
        bool down = Input.GetKey(KeyCode.PageDown);

#if MOBILE_INPUT
        if (_forkSlide.value == -1)
        {
            down = true;
            up = false;
        }
        if (_forkSlide.value == 1)
        {
            down = false;
            up = true;
        }
        if (_forkSlide.value == 0)
        {
            down = false;
            up = false;
        }
#endif

        moveFork(up, down);
    }

    public void moveFork(bool up, bool down)
    {
     
        if (up)
        {
            
            fork.Translate(Vector3.up * speedTranslate * Time.fixedDeltaTime);
            if (mastMoveTrue)
            {
                mast.Translate(Vector3.up * speedTranslate * Time.fixedDeltaTime);
            }
           
        }
         
        if(down)
        {
           
            fork.Translate(-Vector3.up * speedTranslate * Time.fixedDeltaTime);
            if (mastMoveTrue)
            {
                mast.Translate(-Vector3.up * speedTranslate * Time.fixedDeltaTime);
            }
           
        }

    }
}
