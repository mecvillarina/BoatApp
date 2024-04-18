using UraniumUI.Material.Controls;

namespace BoatApp.Maui.UI.Views;

public partial class LoginOtpPage : PageBase
{
    private bool _isAutoFocus;
    
    public LoginOtpPage()
    {
        InitializeComponent();
    }

    public void ChangeFocus(object sender, bool isDirectionForward = true, bool isMove = false)
    {
        MainThread.BeginInvokeOnMainThread((() =>
        {
            if (_isAutoFocus) return;
            
            if (isDirectionForward)
            {
                if(string.IsNullOrEmpty(TxtFieldDigit1.Text) || (!isMove&& sender == TxtFieldDigit1))
                {
                    _isAutoFocus = true;
                    TxtFieldDigit1.Focus();
                }
                else if (string.IsNullOrEmpty(TxtFieldDigit2.Text) || (!isMove && sender == TxtFieldDigit2))
                {
                    _isAutoFocus = true;
                    TxtFieldDigit2.Focus();
                }
                else if (string.IsNullOrEmpty(TxtFieldDigit3.Text)|| (!isMove && sender == TxtFieldDigit3))
                {
                    _isAutoFocus = true;
                    TxtFieldDigit3.Focus();
                }
                else if (string.IsNullOrEmpty(TxtFieldDigit4.Text) || (!isMove && sender == TxtFieldDigit4))
                {
                    _isAutoFocus = true;
                    TxtFieldDigit4.Focus();
                }
                else if (string.IsNullOrEmpty(TxtFieldDigit5.Text) || (!isMove && sender == TxtFieldDigit5))
                {
                    _isAutoFocus = true;
                    TxtFieldDigit5.Focus();
                }
            }
            // else
            // {
            //     if(!string.IsNullOrEmpty(TxtFieldDigit5.Text))
            //     {
            //         _isAutoFocus = true;
            //         TxtFieldDigit5.Focus();
            //     }
            //     else if (!string.IsNullOrEmpty(TxtFieldDigit4.Text))
            //     {
            //         _isAutoFocus = true;
            //         TxtFieldDigit4.Focus();
            //     }
            //     else if (!string.IsNullOrEmpty(TxtFieldDigit3.Text))
            //     {
            //         _isAutoFocus = true;
            //         TxtFieldDigit3.Focus();
            //     }
            //     else if (!string.IsNullOrEmpty(TxtFieldDigit2.Text))
            //     {
            //         _isAutoFocus = true;
            //         TxtFieldDigit2.Focus();
            //     }
            //     else
            //     {
            //         _isAutoFocus = true;
            //         TxtFieldDigit1.Focus();
            //     }
            // }
        }));
    }

    private void TxtFieldDigit_OnFocused(object sender, FocusEventArgs e)
    {
        ChangeFocus(sender, true);
        _isAutoFocus = false;
    }

    private void TxtFieldDigit_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        var txtField = (TextField)sender;

        if (e.NewTextValue.Length == 1 && !char.IsNumber(e.NewTextValue[0]))
        {
            txtField.Text = string.Empty;
        }
        else
        {
            _isAutoFocus = false;
            var isBackward = string.IsNullOrEmpty(e.NewTextValue);
            ChangeFocus(sender, !isBackward, true);
        }
    }
}