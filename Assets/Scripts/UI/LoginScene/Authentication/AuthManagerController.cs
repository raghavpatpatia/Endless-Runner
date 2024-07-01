using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class AuthManagerController
{
    private AuthManagerView authManagerView;
    public AuthManagerController(AuthManagerView authManagerView, EventService eventService)
    {
        this.authManagerView = authManagerView;
        this.authManagerView.Init(this, eventService);
        if (!PlayerPrefs.HasKey("LoggedIn"))
        {
            PlayerPrefs.SetInt("LoggedIn", 0);
        }
    }

    public async void SignUp(string userName, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(userName, password);
            await AuthenticationService.Instance.UpdatePlayerNameAsync(userName);
            PlayerPrefs.SetInt("LoggedIn", 1);
            authManagerView.gameObject.SetActive(false);
        }
        catch (AuthenticationException ex)
        {
            ClearInputFields();
            Debug.Log(ex);
        }
        catch (RequestFailedException ex)
        {
            ClearInputFields();
            Debug.Log(ex);
        }
    }

    public async void SignIn(string userName, string password)
    {
        try
        {
            await AuthenticationService.Instance.SignInWithUsernamePasswordAsync(userName, password);
            await AuthenticationService.Instance.UpdatePlayerNameAsync(userName);
            PlayerPrefs.SetInt("LoggedIn", 1);
            authManagerView.gameObject.SetActive(false);
        }
        catch (AuthenticationException ex)
        {
            ClearInputFields();
            Debug.Log(ex);
        }
        catch (RequestFailedException ex)
        {
            ClearInputFields();
            Debug.Log(ex);
        }
    }

    private void ClearInputFields()
    {
        authManagerView.SetUserNameFieldText("");
        authManagerView.SetPasswordFieldText("");
    }
}