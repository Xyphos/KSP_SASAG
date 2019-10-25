// 
//  MIT License
//  
//  Copyright (c) 2017-2019 William "Xyphos" Scott (TheGreatXyphos@gmail.com)
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.

#pragma warning disable IDE0060 // Remove unused parameter
namespace XyphosAerospace
{
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once UnusedMember.Global
    // ReSharper disable once IdentifierTypo
    public class SASAG : PartModule
    {
        [KSPAction(guiName = "SAS Toggle")]
        public void SetToggle() => vessel.ActionGroups.ToggleGroup(@group: KSPActionGroup.SAS);

        [KSPAction(guiName = "SAS Enable")]
        public void SetEnabled() => vessel.ActionGroups.SetGroup(@group: KSPActionGroup.SAS, active: true);

        [KSPAction(guiName = "SAS Disable")]
        public void SetDisabled() => vessel.ActionGroups.SetGroup(@group: KSPActionGroup.SAS, active: false);

        [KSPAction(guiName = "SAS Stability Assist")]
        public void SetStabilityAssist(KSPActionParam param) => SetSAS(mode: VesselAutopilot.AutopilotMode.StabilityAssist);

        [KSPAction(guiName = "SAS Maneuver Node")]
        public void SetManeuverNode(KSPActionParam param) => SetSAS(mode: VesselAutopilot.AutopilotMode.Maneuver);

        [KSPAction(guiName = "SAS Prograde")]
        public void SetPrograde(KSPActionParam param) => SetSAS(mode: VesselAutopilot.AutopilotMode.Prograde);

        [KSPAction(guiName = "SAS Retrograde")]
        public void SetRetrograde(KSPActionParam param) => SetSAS(mode: VesselAutopilot.AutopilotMode.Retrograde);

        [KSPAction(guiName = "SAS Radial Out")]
        public void SetRadialOut(KSPActionParam param) => SetSAS(mode: VesselAutopilot.AutopilotMode.RadialIn); // This is backwards in KSP???

        [KSPAction(guiName = "SAS Radial In")]
        public void SetRadialIn(KSPActionParam param) => SetSAS(mode: VesselAutopilot.AutopilotMode.RadialOut); // This is backwards in KSP???

        [KSPAction(guiName = "SAS Normal")]
        public void SetNormal(KSPActionParam param) => SetSAS(mode: VesselAutopilot.AutopilotMode.Normal);

        [KSPAction(guiName = "SAS Anti-Normal")]
        public void SetAntiNormal(KSPActionParam param) => SetSAS(mode: VesselAutopilot.AutopilotMode.Antinormal);

        [KSPAction(guiName = "SAS Target")]
        public void SetTarget(KSPActionParam param) => SetSAS(mode: VesselAutopilot.AutopilotMode.Target);

        [KSPAction(guiName = "SAS Anti-Target")]
        public void SetAntiTarget(KSPActionParam param) => SetSAS(mode: VesselAutopilot.AutopilotMode.AntiTarget);

        // ReSharper disable once InconsistentNaming
        private void SetSAS(VesselAutopilot.AutopilotMode mode)
        {
            if (!vessel.Autopilot.SAS.CanEngageSAS())
            {
                ScreenMessages.PostScreenMessage(message: "Vessel cannot engage SAS");
                return;
            }

            if (!vessel.Autopilot.CanSetMode(mode: mode))
            {
                ScreenMessages.PostScreenMessage(message: $"Vessel cannot set SAS to {mode}");
                return;
            }
            
            vessel.ActionGroups.SetGroup(@group: KSPActionGroup.SAS, active: true); // turn on SAS
            vessel.Autopilot.Enable(mode: mode);                          // set SAS mode
        }


        public override string GetInfo() => "Allows SAS to be controlled with Action Groups";
    }
}
