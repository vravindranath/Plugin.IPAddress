using System;
namespace Plugin.IPAddress.Abstractions
{
	/// <summary>
	/// IPA ddress finder.
	/// </summary>
	public interface IIPAddressFinder
	{
		/// <summary>
		/// Gets the ip address.
		/// </summary>
		/// <returns>The ip address.</returns>
		string GetIpAddress();
	}
}
