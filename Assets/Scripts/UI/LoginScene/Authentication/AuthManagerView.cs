using System;
using TMPro;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.UI;
public class AuthManagerView : MonoBehaviour
{
    [SerializeField] private TMP_InputField userNameField;
    [SerializeField] private TMP_InputField passwordField;
    [SerializeField] private Button loginButton;
    [SerializeField] private Button signupButton;

    private AuthManagerController authManagerController;
    private EventService eventService;
    public void Init(AuthManagerController authManagerController, EventService eventService)
    {
        this.authManagerController = authManagerController;
        this.eventService = eventService;
    }

    private async void Awake()
    {
        try
        {
            await UnityServices.InitializeAsync();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    private void Start()
    {
        loginButton.onClick.AddListener(OnLoginButtonClick);
        signupButton.onClick.AddListener(OnSignUpButtonClick);
    }

    private void OnLoginButtonClick()
    {
        eventService.OnSoundEffectPlay.Invoke(Sounds.BUTTONCLICK);
        authManagerController.SignIn(userNameField.text, passwordField.text);
    }

    private void OnSignUpButtonClick()
    {
        eventService.OnSoundEffectPlay.Invoke(Sounds.BUTTONCLICK);
        authManagerController.SignUp(userNameField.text, passwordField.text);
    }

    public void SetUserNameFieldText(string text) => userNameField.text = text;
    public void SetPasswordFieldText(string text) => passwordField.text = text;
}