using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class PageNotFound404 : MonoBehaviour, ITrackableEventHandler
{
    //[SerializeField]
    //private Slider x;
    //[SerializeField]
    //private Slider y;
    //[SerializeField]
    //private Slider z;
    //[SerializeField]
    //private Text xValue;
    //[SerializeField]
    //private Text yValue;
    //[SerializeField]
    //private Text zValue;
    [SerializeField]
    private Transform destination;
    //[SerializeField]
    //private UnityEngine.UI.Image image;

    private TrackableBehaviour mTrackableBehaviour;
    public Transform Target;//识别物
    Vector3 imgPos = new Vector3(0, 0.372f, 0);//识别图上的位置
    Vector3 camPos = new Vector3(0, 0, 500);//脱卡后在屏幕中的位置
                                            //这俩值，具体多少得自己调，模型尺寸、重心不同
    bool isFirstTime = true;
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
        Target.GetComponent<MeshRenderer>().enabled = false;//起始时不显示
    }

    void Update()
    {
        //imgPos.x = this.x.value;
        //imgPos.y = this.y.value;
        //imgPos.z = this.z.value;

        //this.xValue.text = imgPos.x + "";
        //this.yValue.text = imgPos.y + "";
        //this.zValue.text = imgPos.z + "";

        //this.Target.localPosition = imgPos;

        //Color color = this.image.color;
        //color.r = this.x.value;
        //color.g = this.y.value;
        //color.b = this.z.value;
        //this.image.color = color;
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            //视野内发现识别图时
            // Target.GetComponent<MeshRenderer>().enabled = true;
            // Target.parent = this.transform;
            //Target.localPosition = imgPos;
            // Target.position = this.destination.position;
            // Target.localRotation = Quaternion.identity;
            isFirstTime = false;
        }
        else
        {
            //视野内没有识别图时，这里我是把位置和旋转都归零了，如果不做处理，可以
            if (!isFirstTime)
            {
                Target.parent = Camera.main.transform;
                // Target.localPosition = camPos;
                Target.position = this.destination.position;
                Target.localRotation = Quaternion.identity;
            }
        }
    }
}