using GameOverlay;

using ImGuiNET;

namespace GTA5Menu.ESP;

internal class GTA5Overlay : Overlay
{
    private bool wantKeepDemoWindow = true;

    protected override Task PostInitialized()
    {
        this.VSync = true;
        return Task.CompletedTask;
    }

    protected override void Render()
    {
        ImGui.ShowDemoWindow(ref wantKeepDemoWindow);
        if (!this.wantKeepDemoWindow)
        {
            this.Close();
        }
    }
}
