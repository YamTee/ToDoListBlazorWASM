using Microsoft.JSInterop;

namespace ToDoListBlazorWASM.Layout;

public partial class MainLayout
{
    private string _darkThemeIcon = "dark_mode";
    private string _lightThemeIcon = "light_mode";

    private string _darkThemeName = "dark";
    private string _lightThemeName = "light";

    public string? ThemeName { get; set; }
    public string? ThemeIcon { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            ThemeIcon = _darkThemeIcon;
            ThemeName = _darkThemeName;

            StateHasChanged();

            await JS.InvokeVoidAsync("resetTooltip");
        }       
    }

    private void ToggleTheme()
    {
        ThemeName = ThemeName == _darkThemeName ? _lightThemeName : _darkThemeName;
        ThemeIcon = ThemeIcon == _darkThemeIcon ? _lightThemeIcon : _darkThemeIcon;
    }

}