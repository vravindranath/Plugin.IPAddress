using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Linq;
using Plugin.IPAddress.Abstractions;

namespace IPAddress.Plugin.iOS
{
    /// <summary>
    /// IPA ddress finder.
    /// </summary>
    public class IPAddressFinder : IIPAddressFinder
    {
        const string defaultIpAddress = "0.0.0.0";
        /// <summary>
        /// Gets the ip address.
        /// </summary>
        /// <returns>The ip address.</returns>
        public string GetIpAddress()
        {
            string ipAddress = defaultIpAddress;

            try
            {
                foreach (var netInterface in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (netInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                        netInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    {
                        var result = netInterface.GetIPProperties().UnicastAddresses.FirstOrDefault(t => t.Address.AddressFamily == AddressFamily.InterNetwork);
                        if (result != null)
                        {
                            ipAddress = result.Address.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                 
                return ipAddress;
            }

            return ipAddress;
        }

    }
}
