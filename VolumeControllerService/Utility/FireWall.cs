namespace VolumeControllerService.Utility
{
    using NetFwTypeLib;
    using System;
    using Values;

    public class FireWall
    {
        public static void CreateException(string appLocation)
        {
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
            var currentProfiles = fwPolicy2.CurrentProfileTypes;

            foreach (var rule in fwPolicy2.Rules)
            {
                dynamic tempRule = rule;
                if (tempRule?.Name == ApplicationData.ServiceName)
                    return;
            }

            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            firewallPolicy.Rules.Add(CreateRule(currentProfiles, 6, CommuncationDetails.Port));
            firewallPolicy.Rules.Add(CreateRule(currentProfiles, 17, CommuncationDetails.PortUDP.ToString()));
        }

        private static INetFwRule2 CreateRule(int currentProfiles, int protocol, string port)
        {
            INetFwRule2 inboundRule = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
            inboundRule.Enabled = true;
            inboundRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
            inboundRule.Protocol = protocol;
            inboundRule.LocalPorts = port;
            inboundRule.Name = ApplicationData.ServiceName;
            inboundRule.serviceName = "*"; // For all services. Services only.

            inboundRule.Profiles = currentProfiles;
            return inboundRule;
        }
    }
}
