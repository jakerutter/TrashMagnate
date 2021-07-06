using UnityEngine;

//[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //References
   [SerializeField] private Light DirectionalLight;
   [SerializeField] private LightingPreset Preset;
   //Variables
   [SerializeField, Range(0,24)] private float TimeOfDay;
   [SerializeField] private GameObject MainGate;

   private bool resetNewDay = false;
   private bool nightHasCome = false;
   private Animator animator;
   private bool GateClosed = true;

   private CalendarMailUI cal;

    private void Start()
    {
        animator = MainGate.GetComponent<Animator>();
        cal = gameObject.GetComponent<CalendarMailUI>();
    }

    private void Update()
    {
        if(Preset == null)
        {
            return;
        }

        if(Time.timeScale > 0f)
        {
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= 24; //clamp value between 0-24
            UpdateLighting(TimeOfDay / 24f);
            cal.UpdateTime(TimeOfDay.ToString("0"));
        }
        //else
        //{
        //    UpdateLighting(TimeOfDay / 24f);
        //    string time = TimeOfDay.ToString();
        //    cal.UpdateTime(time);
        //}
        
        //if resetNewDay is true then update current date
        if(resetNewDay && nightHasCome)
        {
            resetNewDay = false;
            nightHasCome = false;
            //Debug.Log("Calling UpdateCurrentDay");
            cal.UpdateCurrentDay();
        }

        //if time < 1 set new day
        if(TimeOfDay < 1 && !resetNewDay)
        {
            resetNewDay = true;
            //Debug.Log("Set resetNewDay to TRUE");
        }
        
        if(TimeOfDay > 23)
        {
            nightHasCome = true;
            //Debug.Log("Set nightHasCome to TRUE");
        }

        //set bool for opening gate in morning
        if(TimeOfDay > 5 && TimeOfDay < 6 && GateClosed)
        {
            GateClosed = false;
            //animator.SetBool("IsClosed", GateClosed);
            //Debug.LogWarning("Opened gate");
            MainGate.transform.Rotate(0, 0, 180);
        }
        //set bool for closing gate in evening
        if(TimeOfDay > 19 && !GateClosed)
        {
            GateClosed = true;
            //animator.SetBool("IsClosed", GateClosed);
            //Debug.LogWarning("Closed gate");
            MainGate.transform.Rotate(0, 0, -180);
        }
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        if(DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3(timePercent * 360f - 90f, 170f, 0));
        }
    }

    private void OnValidate()
    {
        if(DirectionalLight != null)
        {
            return;
        }
       if(RenderSettings.sun != null)
       {
           DirectionalLight = RenderSettings.sun;
       }
       else
       {
           Light[] lights = GameObject.FindObjectsOfType<Light>();
           foreach(Light light in lights)
           {
               if(light.type == LightType.Directional)
               {
                   DirectionalLight = light;
                   return;
               }
           }
       }
    }
}
