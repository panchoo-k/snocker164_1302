using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;
    public int PlayerScore { get { return playerScore; } set { playerScore = value; } }

    [SerializeField]
    private GameObject[] ballPositons;

    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private GameObject cueBall;

    [SerializeField]
    private float xInput = 0f;

    [SerializeField]
    private GameObject ballLine;

    [SerializeField]
    private TMP_Text notiText;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        SetBall(BallColor.red, 1);
        SetBall(BallColor.yellow, 2);
        SetBall(BallColor.green, 3);
        SetBall(BallColor.brown, 4);
        SetBall(BallColor.blue, 5);
        SetBall(BallColor.pink, 6);
        SetBall(BallColor.black, 7);
    }
    
    void Update()
    {
        RotateBall();

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            Shootball();

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            xInput = -0.1f;
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            xInput = 0.1f;
        else
            xInput = 0f;
        if (Keyboard.current.backspaceKey.isPressed)
            StopBall();
    }

    private void SetBall(BallColor col, int i)
    {
        GameObject obj = Instantiate(ballPrefab,
                                     ballPositons[i].transform.position,
                                     Quaternion.identity);
        Ball b = obj.GetComponent<Ball>();
        b.SetColorAndPoint(col);
    }

    private void Shootball()
    {
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.AddRelativeForce(Vector3.forward * 50, ForceMode.Impulse);

        ballLine.SetActive(false);
    }

    private void RotateBall()
    {
        if (cueBall != null)
            cueBall.transform.Rotate(new Vector3(0f, xInput, 0f));
    }

    private void StopBall()
    {
        Rigidbody rb = cueBall.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        cueBall.transform.eulerAngles = new Vector3(0f, 0f, 0f);

        ballLine.SetActive(true);
    }

    public void ShowScoreText(int n)
    {
        playerScore += n;
        notiText.text = $"Ball Point:{n}\nTotal Score:{playerScore}";
    }

    public void ShowString(string s)
    {
        notiText.text = s;
    }
}
