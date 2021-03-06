using UnityEngine;
using System.Collections;

public class BodyTouch : MonoBehaviour 
{
    public string touchName;
    private Animator mAnimator;
    public GameObject mWeaponPoint;
    public int mAttachBegin;
    public GameObject[] mAttachThings;

    private static BodyTouch single;

    public static BodyTouch getSingleton()
    {
        return single;
    }

    private void Awake()
    {
        single = this;
        mAnimator = GetComponent<Animator>();
    }

    public Animator GetAnimator()
    {
        return mAnimator;
    }

    //public void OnAnimatorChange()
    //{
    //    mAnimator = ChangeBody.getSingleton().mCurrentBody.GetComponent<Animator>();
    //}

	void Update () 
    {
        if (Input.GetMouseButton(0) || Input.touchCount == 1)
        {
            touchName = "";
            RaycastHit hit;
#if (UNITY_ANDROID || UNITY_IPHONE) && !UNITY_EDITOR
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began && Physics.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out hit))
            {
                touchName = hit.transform.name;
            }
#else
            if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                touchName = hit.transform.name;
            }
#endif
            if (touchName != "")
            {
                //if (!animator)
                //{
                //    animator = GetComponentInChildren(typeof(Animator)) as Animator;
                //}
                if (mAnimator)
                {
                    if (mAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.idle"))
                    {
                        if (touchName == "Bip01 Head")
                        {
                            mAnimator.SetBool("molian",true);
                            GameUtils.Call("incrementAchievement", "9");
                            SayPop.getSingleton().closePop();
                        }
                        else if (touchName == "Bip01 R UpperArm")
                        {
                            mAnimator.SetBool("mogebo", true);
                            GameUtils.Call("incrementAchievement", "9");
                        }
                        else
                        {
                        }
                    }
                }
            }
        }

        if (GUIUtility.hotControl == 0 &&  Input.touchCount == 1)
        {
            transform.localEulerAngles = new Vector3(0, -Input.GetTouch(0).deltaPosition.x + transform.localEulerAngles.y, 0);
        }
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0, 0, 0), "easetype", "easeOutQuad", "time", 0.5f));
        }
	}

    void FixedUpdate()
    {
        if (mAnimator)
        {
            AnimatorStateInfo stateInfo = mAnimator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("Base Layer.heshui"))
            {
                mAnimator.SetBool("heshui",false);
            }
            else if (stateInfo.IsName("Base Layer.chifan"))
            {
                mAnimator.SetBool("chifan", false);
            }
            else if (stateInfo.IsName("Base Layer.molian"))
            {
                mAnimator.SetBool("molian", false);
            }
            else if (stateInfo.IsName("Base Layer.mogebo"))
            {
                mAnimator.SetBool("mogebo", false);
            }
        }
    }
}
