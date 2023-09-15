using Microsoft.JSInterop;

namespace ToDoListBlazorWASM.Layout;

public partial class MainLayout
{
    private readonly string _darkThemeIcon = "dark_mode";
    private readonly string _lightThemeIcon = "light_mode";

    private readonly string _darkThemeName = "dark";
    private readonly string _lightThemeName = "light";

    public string? ThemeName { get; set; }
    public string? ThemeIcon { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var theme = await localStorageService.GetValueAsync<string>("theme");

        ThemeName = theme;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            ThemeName ??= _darkThemeName;
            ThemeIcon = ThemeName == _darkThemeName ? _darkThemeIcon : _lightThemeIcon;

            StateHasChanged();

            await JS.InvokeVoidAsync("resetTooltip");
        }
    }

    private async Task ToggleTheme()
    {
        ThemeName = ThemeName == _darkThemeName ? _lightThemeName : _darkThemeName;
        ThemeIcon = ThemeIcon == _darkThemeIcon ? _lightThemeIcon : _darkThemeIcon;

        await localStorageService.SetValueAsync<string>("theme", ThemeName);
    }

}