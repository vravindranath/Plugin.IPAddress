using System;
using System.Net;
using System.Linq;
using Plugin.IPAddress.Abstractions;

namespace IPAddress.Plugin.Android
{
    /// <summary>
    /// IPAddress finder.
    /// </summary>
    public class IPAddressFinder : IIPAddressFinder
    {

        const string defaultResult = "0.0.0.0";
        /// <summary>
        /// Gets the ip address.
        /// </summary>
        /// <returns>The ip address.</returns>
        public string GetIpAddress()
        {
            try
            {
                System.Net.IPAddress[] adresses = Dns.GetHostAddresses(Dns.GetHostName());

                if (adresses != null && adresses.FirstOrDefault() != null)
                {
                    return adresses.FirstOrDefault().ToString();
                }
                else
                {
                    return defaultResult;
                }
            }
            catch (Exception ex)
            {
                return defaultResult;
            }
        }

    }
}
