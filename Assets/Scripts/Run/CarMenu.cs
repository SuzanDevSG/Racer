using UnityEngine;

public class CarMenu : MonoBehaviour
{
    // Material 
    public MeshRenderer body;
    public Material[] mat;
    public int matIterater = 0;

    // Rotation
    private Vector3 degree;
    private Vector3 rotationStep = new(0,90,0);
    private bool isRotating = false;

    [SerializeField] private float time = 1;
    private float timeTaken;
    private int direction;
    private float control;

   
    void Update()
    {
        // control = Input.GetKeyDown(KeyCode.A) ?  1 : control;
        // control = Input.GetKeyDown(KeyCode.D) ? -1 : control;
        
        if(Input.GetKeyDown(KeyCode.D) && !isRotating){
            Rotate(1);  
        }
        if(Input.GetKeyDown(KeyCode.A) && !isRotating){
            Rotate(-1);
        }

        // int intcontrol = Mathf.RoundToInt(Input.GetAxis("Horizontal"));
        // if(intcontrol != 0 && !isRotating){
        //     Rotate(intcontrol);
        // }

        if(isRotating){
            Vector3 degree = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(degree +  direction * Time.deltaTime * rotationStep / (time <= 0 ? 1:time) );
            timeTaken += Time.deltaTime;
            if(timeTaken >= time){
                isRotating = false;
            }
            //Debug.Log("Delta time"+Time.deltaTime);
            //Debug.Log("TIme" + timeTaken);
        }
        
    }
    void Rotate(int direction){
            this.direction = direction;

            isRotating = true;
            timeTaken = 0;
            
            matIterater += direction + mat.Length;
            matIterater %= mat.Length;
            Debug.Log(matIterater);
            body.material = mat[matIterater];
    

    }
            // degree = transform.rotation.eulerAngles + rotationStep;
            // for(int i =0;i<5;i++){
            // transform.Rotate(degree);
        //     transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles,degree,Time.deltaTime));
        //     transform.rotation = Quaternion.Euler(degree * change);
        //     if(Input.GetKeyDown(KeyCode.J)){
        //     ++change;
        //     body.material.color = Color.black;
        //     transform.Rotate(-degree);
        //     //transform.rotation = Quaternion.Euler(degree * -change);
        // }



    // [SerializeField]private int a;
    // private float GetIndexValue(bool isRotation)
    // {
    //     if(isRotating){

    //         return a;
    //     }
    //     if(Input.GetKeyDown(KeyCode.A)){
    //         return a= -1;
    //     }
    //     else if(Input.GetKeyDown(KeyCode.D)){
    //         return a=1;
    //     }
    //     return a=0;
    // }


    // void RightRotation(){
    //     isRotating = true;
    //     timeTaken = 0;

    //     body.material = mat[matIterater++];
    //     matIterater %= mat.Length;

    //     Rotator();
        
    // }
    // void Rotator(){
    //     transform.rotation = Quaternion.Euler(degree + rotationStep * Time.deltaTime / (time <= 0 ? 1: time) );
    //     timeTaken
    // }
}

