// 
//  MIT License
//  
//  Copyright (c) 2018 William "Xyphos" Scott
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

namespace SASAG
{
    // ReSharper disable once InconsistentNaming
    public class SASAG : PartModule
    {
        [KSPAction(guiName = "SAS Toggle")]
        public void SetToggle() => vessel.ActionGroups.ToggleGroup(group: KSPActionGroup.SAS);

        [KSPAction(guiName = "SAS Enable")]
        public void SetEnabled() => vessel.ActionGroups.SetGroup(group: KSPActionGroup.SAS, active: true);

        [KSPAction(guiName = "SAS Disable")]
        public void SetDisabled() => vessel.ActionGroups.SetGroup(group: KSPActionGroup.SAS, active: false);

        [KSPAction(guiName = "SAS Stability Assist")]
        public void SetStabilityAssist(KSPActionParam param) => SetSAS(autopilotMode: VesselAutopilot.AutopilotMode.StabilityAssist);

        [KSPAction(guiName = "SAS Maneuver Node")]
        public void SetManeuverNode(KSPActionParam param) => SetSAS(autopilotMode: VesselAutopilot.AutopilotMode.Maneuver);

        [KSPAction(guiName = "SAS Prograde")]
        public void SetPrograde(KSPActionParam param) => SetSAS(autopilotMode: VesselAutopilot.AutopilotMode.Prograde);

        [KSPAction(guiName = "SAS Retrograde")]
        public void SetRetrograde(KSPActionParam param) => SetSAS(autopilotMode: VesselAutopilot.AutopilotMode.Retrograde);

        [KSPAction(guiName = "SAS Radial Out")]
        public void SetRadialOut(KSPActionParam param) => SetSAS(autopilotMode: VesselAutopilot.AutopilotMode.RadialIn); // This is backwards in KSP???

        [KSPAction(guiName = "SAS Radial In")]
        public void SetRadialIn(KSPActionParam param) => SetSAS(autopilotMode: VesselAutopilot.AutopilotMode.RadialOut); // This is backwards in KSP???

        [KSPAction(guiName = "SAS Normal")]
        public void SetNormal(KSPActionParam param) => SetSAS(autopilotMode: VesselAutopilot.AutopilotMode.Normal);

        [KSPAction(guiName = "SAS Anti-Normal")]
        public void SetAntiNormal(KSPActionParam param) => SetSAS(autopilotMode: VesselAutopilot.AutopilotMode.Antinormal);

        [KSPAction(guiName = "SAS Target")]
        public void SetTarget(KSPActionParam param) => SetSAS(autopilotMode: VesselAutopilot.AutopilotMode.Target);

        [KSPAction(guiName = "SAS Anti-Target")]
        public void SetAntiTarget(KSPActionParam param) => SetSAS(autopilotMode: VesselAutopilot.AutopilotMode.AntiTarget);

        // ReSharper disable once InconsistentNaming
        private void SetSAS(VesselAutopilot.AutopilotMode autopilotMode)
        {
            if (!vessel.Autopilot.CanSetMode(mode: autopilotMode))
            {
                ScreenMessages.PostScreenMessage(message: string.Format(format: "Vessel cannot set SAS to {0}", arg0: autopilotMode));
                return;
            }

            if (!vessel.Autopilot.SAS.CanEngageSAS())
            {
                ScreenMessages.PostScreenMessage(message: "Vessel cannot engage SAS");
                return;
            }

            vessel.ActionGroups.SetGroup(group: KSPActionGroup.SAS, active: true); // turn on SAS
            vessel.Autopilot.Enable(mode: autopilotMode);                          // set SAS mode
        }


        public override string GetInfo() => "Allows SAS to be contolled with Action Groups";
    }
}
