/* SASAG - a module plugin for Kerbal Space Program to control SAS through Action Groups.
 * Author: William "Xyphos" Scott
 * Date: April 22, 2017
 * Licence: PUBLIC DOMAIN
 * 
 * THIS SOFTWARE IS PROVIDED BY THE AUTHORS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES,
 * INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
 * WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
 * OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
namespace SASAG
{
    public class SASAG : PartModule
    {
        [KSPAction(guiName = "SAS Toggle")]
        public void SetToggle()
        {
            vessel.ActionGroups.ToggleGroup(KSPActionGroup.SAS);
        }

        [KSPAction(guiName = "SAS Enable")]
        public void SetEnabled()
        {
            vessel.ActionGroups.SetGroup(KSPActionGroup.SAS, true);
        }

        [KSPAction(guiName = "SAS Disable")]
        public void SetDisabled()
        {
            vessel.ActionGroups.SetGroup(KSPActionGroup.SAS, false);
        }

        [KSPAction(guiName = "SAS Stability Assist")]
        public void SetStabilityAssist(KSPActionParam param)
        {
            SetSAS(VesselAutopilot.AutopilotMode.StabilityAssist);
        }

        [KSPAction(guiName = "SAS Maneuver Node")]
        public void SetManeuverNode(KSPActionParam param)
        {
            SetSAS(VesselAutopilot.AutopilotMode.Maneuver);
        }

        [KSPAction(guiName = "SAS Prograde")]
        public void SetPrograde(KSPActionParam param)
        {
            SetSAS(VesselAutopilot.AutopilotMode.Prograde);
        }

        [KSPAction(guiName = "SAS Retrograde")]
        public void SetRetrograde(KSPActionParam param)
        {
            SetSAS(VesselAutopilot.AutopilotMode.Retrograde);
        }

        [KSPAction(guiName = "SAS Radial Out")]
        public void SetRadialOut(KSPActionParam param)
        {
            SetSAS(VesselAutopilot.AutopilotMode.RadialIn); // This is backwards in KSP???
        }

        [KSPAction(guiName = "SAS Radial In")]
        public void SetRadialIn(KSPActionParam param)
        {
            SetSAS(VesselAutopilot.AutopilotMode.RadialOut); // This is backwards in KSP???
        }

        [KSPAction(guiName = "SAS Normal")]
        public void SetNormal(KSPActionParam param)
        {
            SetSAS(VesselAutopilot.AutopilotMode.Normal);
        }

        [KSPAction(guiName = "SAS Anti-Normal")]
        public void SetAntiNormal(KSPActionParam param)
        {
            SetSAS(VesselAutopilot.AutopilotMode.Antinormal);
        }

        [KSPAction(guiName = "SAS Target")]
        public void SetTarget(KSPActionParam param)
        {
            SetSAS(VesselAutopilot.AutopilotMode.Target);
        }

        [KSPAction(guiName = "SAS Anti-Target")]
        public void SetAntiTarget(KSPActionParam param)
        {
            SetSAS(VesselAutopilot.AutopilotMode.AntiTarget);
        }

        private void SetSAS(VesselAutopilot.AutopilotMode autopilotMode)
        {
            if (!vessel.Autopilot.CanSetMode(autopilotMode))
            {
                ScreenMessages.PostScreenMessage(string.Format("Vessel cannot set SAS to {0}", autopilotMode));
                return;
            }

            if (!vessel.Autopilot.SAS.CanEngageSAS())
            {
                ScreenMessages.PostScreenMessage("Vessel cannot engage SAS");
                return;
            }

            vessel.ActionGroups.SetGroup(KSPActionGroup.SAS, true); // turn on SAS
            vessel.Autopilot.Enable(autopilotMode); // set SAS mode
        }


        public override string GetInfo()
        {
            return "Allows SAS to be contolled with Action Groups";
        }
    }
}
